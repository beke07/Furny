<template ref="auth" lang="html">
<div class="container">
  <button v-if="!user.isAuthenticated" @click="login">Login</button>
  <div v-if="user.isAuthenticated">
  <button @click="logout">Logout</button>
  <h1>Hi {{ user.name }}!</h1>
  </div>

  <img src="https://localhost:44348/api/PanelCutter/5eb6810fee11170b21ec3a3d/profile" width="1000"/>  
</div>
</template>

<script>
import Firebase from "../helpers/firebase";
import axios from "axios";

export default {
  name: "Auth",
  methods: {
    login() {
      Firebase.login();
    },
    logout() {
      Firebase.logout();
    }
  },
  mounted: function() {
    Firebase.auth.onAuthStateChanged(result => {
      if (result) {
        axios.get("https://localhost:44348/api/auth/user-sync").then(
          function(response) {
            if (response.status === 202) {
              //TODO: itt kell feldobni a választós cuccot, aztán kiküldeni role-al együtt.
              axios.get("https://localhost:44348/api/auth/user-sync", { params: { role: 'designer' } })
            }
          }
        );
        this.user.isAuthenticated = true;
        this.user.name = result.displayName.split(" ")[0];
      } else {
        this.user.isAuthenticated = false;
        this.user.name = null;
      }
    });
  }
};
</script>

<style scoped>
</style>
