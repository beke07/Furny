import Vue from "vue";
import Vuex from "vuex";
import VuexPersistence from "vuex-persist";
import { login, userSync } from "./services/login";
import { getProfile } from "./services/profile";
import { patchProfile } from "./services/profile";
import Firebase from "../helpers/firebase";
import { parseJwt } from "./../helpers/jwt-helper";

Vue.use(Vuex);

const persistence = new VuexPersistence({
  storage: window.localStorage,
});

export default new Vuex.Store({
  plugins: [persistence.plugin],
  state: {
    isAuthenticated: false,
    user: null,
    role: null,
    token: null,
    picture: null,
    addresses: [],
    panelCutters: [],
    materials: [],
    closings: [],
    newRegistrated: false,
    isSidebarActive: false,
    backgroundColor: "#83a4c1",
    inputColor: "rgb(88, 140, 184)",
  },
  mutations: {
    setSessionData(state, value) {
      state.user = value.user;
      state.role = value.role;
      state.isAuthenticated = true;
    },
    unsetSessionData(state) {
      state.user = null;
      state.token = null;
      state.role = null;
      state.isAuthenticated = false;
    },
    setToken(state, token) {
      state.token = token;
      localStorage.setItem("token", token);
    },
    setSidebarActive(state, value) {
      state.isSidebarActive = value;
    },
    setPicture(state, picture) {
      state.picture = picture;
    },
    setAddresses(state, addresses) {
      state.addresses = addresses;
    },
    setImageId(state, imageId) {
      state.user.imageId = imageId;
    },
    setNewRegistrated(state, value) {
      state.newRegistrated = value;
    },
    setUser(state, user) {
      state.user = user;
    },
  },
  actions: {
    getPanelCutters() {
      const panelCutters = this.state.panelCutters;
      panelCutters.forEach((panelCutter) => {
        panelCutter.materials = this.state.materials.find(
          (m) => m.pid === panelCutter.id
        );
        panelCutter.closings = this.state.closings.find(
          (m) => m.pid === panelCutter.id
        );
      });
      return panelCutters;
    },
    async getProfilePicture() {
      const imageId = this.state.user.imageId;
      if (imageId) return `${process.env.VUE_APP_API_ENDPOINT}/file/${imageId}`;
      else
        return "https://www.nanx.com.pk/wp-content/uploads/2017/01/istockphoto-476085198-612x612.jpg";
    },

    async setUser(context, user) {
      context.commit("setUser", user);
    },

    async updateProfile(context, value) {
      await patchProfile(value.role, value.id, value.patch);
      const profil = await getProfile(value.id, value.role);
      context.commit("setUser", profil);
    },

    async setSidebarActivate(context, value) {
      context.commit("setSidebarActive", value);
    },

    async login(context, user) {
      const token = await login(user);
      const parsedToken = parseJwt(token);
      const profile = await getProfile(parsedToken.id, parsedToken.role);

      context.commit("setSessionData", {
        user: profile,
        role: parsedToken.role,
      });
      context.commit("setToken", token);
    },

    async logout(context) {
      context.commit("unsetSessionData");
      Firebase.logout();
    },

    async saveAddresses(context, addresses) {
      context.commit("setAddresses", addresses);
    },

    async saveToken(context, token) {
      context.commit("setToken", token);
    },

    async syncUserWithRole(context, role) {
      await userSync(role);

      const token = parseJwt(this.state.token);
      const picture = token.picture;
      const email = token.email;
      const profile = await getProfile(null, role, email);

      context.commit("setSessionData", {
        user: profile,
        role: role,
      });
      context.commit("setPicture", picture);
    },
  },
  modules: {},
});
