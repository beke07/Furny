import Vue from "vue";
import App from "./App.vue";
import VueRouter from "vue-router";
import router from "./router";
import store from "./store";
import { Vuelidate } from "vuelidate";
import Vuesax from "vuesax";
import "vuesax/dist/vuesax.css";
import "material-icons/iconfont/material-icons.css";
import "prismjs";
import "prismjs/themes/prism.css";
import VsPrism from "./components/prism/VsPrism.vue";
import Multiselect from "vue-multiselect";
import "@/assets/scss/style.scss";

Vue.config.productionTip = false;
Vue.config.devtools = true;
Vue.use(Vuesax);

Vue.use(VueRouter);
Vue.use(Vuelidate);

Vue.component(VsPrism.name, VsPrism);
Vue.component("multiselect", Multiselect);

new Vue({
  router,
  store,
  render: (h) => h(App),
}).$mount("#app");

let vue = new Vue({
  store,
  router,
  render: (h) => h(App),
}).$mount("#app");

Vue.config.errorHandler = (err) => {
  vue.$vs.notify({
    title: "Error",
    text: err,
    color: "danger",
  });
};
