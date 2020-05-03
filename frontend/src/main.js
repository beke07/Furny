import Vue from "vue";
import App from "./App.vue";
import VueRouter from "vue-router";
import VueCookies from "vue-cookies";
import router from "./router";
import Axios from "axios";

Vue.config.productionTip = false;

Vue.use(VueRouter);
Vue.use(VueCookies);
Vue.$cookies.config("7d");

Vue.mixin({
  data: function() {
    return {
      user: {
        name: null,
        isAuthenticated: false
      }
    }
  }
})

Axios.interceptors.request.use(
  (config) => {
    config.headers.authorization = `Bearer ${Vue.$cookies.get("token")}`;
    return config;
  },
  (error) => Promise.reject(error)
);

new Vue({
  router,
  render: (h) => h(App),
}).$mount("#app");
