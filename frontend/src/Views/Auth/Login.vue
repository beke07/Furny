<template ref="auth" lang="html">
  <div class="container auth-container">
    <div class="row">
      <div class="col logo">
        <img src="../../assets/logo.png" height="400" />
      </div>
      <form class="col form" @keyup.enter="login">
        <FurnyEmailInput
          label-placeholder="E-mail cím"
          :inputData.sync="user.username"
        />
        <FurnyRequiredInput
          type="password"
          label-placeholder="Jelszó"
          :inputData.sync="user.password"
        />
        <FurnyButton type="relief" text="Belépés" @clicked="login" />

        <FurnyButton type="line" text="Google belépés" @clicked="googleLogin" />
        <vs-popup
          class="holamundo"
          title="Válassz szerepkört!"
          :active.sync="popup"
        >
          <FurnyButton
            type="border"
            text="Designer"
            class="role-button role-button-right"
            @clicked="setRole(true)"
          />
          <FurnyButton
            type="border"
            text="Lapszabász"
            class="role-button"
            @clicked="setRole(false)"
          />
        </vs-popup>
        <FurnyRouterLink to="/registration-type" text="Regisztráció" />
      </form>
    </div>
  </div>
</template>

<script>
import Firebase from "../../helpers/firebase";
import UserLoginDto from "../../dtos/UserLoginDto";
import FurnyButton from "../../components/FurnyButton";
import FurnyRouterLink from "../../components/FurnyRouterLink";
import FurnyEmailInput from "../../components/FurnyEmailInput";
import FurnyRequiredInput from "../../components/FurnyRequiredInput";
import { getGoogleUserRole } from "../../store/services/login";
import { parseJwt } from "../../helpers/jwt-helper";

export default {
  name: "Login",
  components: {
    FurnyButton,
    FurnyRouterLink,
    FurnyEmailInput,
    FurnyRequiredInput,
  },
  data: () => ({
    popup: false,
    designer: false,
    user: new UserLoginDto(),
  }),
  methods: {
    async setRole(role) {
      await this.$store.dispatch("syncUserWithRole", role);
      this.$router.push("/");
    },
    async login() {
      await this.$store.dispatch("login", this.user);
      this.$router.push("/");
    },
    async googleLogin() {
      Firebase.login().then(async (token) => {
        await this.$store.dispatch("saveToken", token);
        const role = await getGoogleUserRole(parseJwt(token).email);
        if (role) await this.setRole(role);
        else this.popup = true;
      });
    },
  },
  async mounted() {
    Firebase.auth.onAuthStateChanged(async (result) => {
      if (result) {
        this.user.isAuthenticated = true;
        this.user.name = result.displayName.split(" ")[0];
      } else {
        this.user.isAuthenticated = false;
        this.user.name = null;
      }
    });
  },
};
</script>

<style scoped>
.auth-container > .row .col.form {
  align-items: center;
  justify-content: center;
  flex-direction: column;
}
.auth-container > .row .col.logo {
  padding: 50px 0 50px 0;
}
.auth-container > .row .col.form > .vs-input {
  margin-top: 20px;
  width: 60%;
}
.auth-container > .row .col.form > .vs-button {
  margin-top: 20px;
  width: 60%;
}
.auth-container > .row .col.form > a {
  margin-top: 20px;
  width: 60%;
  text-align: center;
}
.role-button {
  width: 49%;
}
.role-button-right {
  margin-right: 2%;
}
</style>
