import VueRouter from "vue-router";
import store from "../store";
const NProgress = window.NProgress;

const routes = [
  {
    path: "",
    meta: {
      authenticated: true,
    },
    component: () => import("../layout/MainContainer.vue"),
    children: [
      {
        path: "/profil",
        name: "Profil",
        meta: {
          authenticated: true,
        },
        component: () => import("../Views/Profil.vue"),
      },
      {
        path: "/offers",
        name: "Offers",
        meta: {
          authenticated: true,
        },
        component: () => import("../Views/Offers.vue"),
      },
      {
        path: "/moduls",
        name: "Moduls",
        meta: {
          authenticated: true,
        },
        component: () => import("../Views/Designer/Moduls.vue"),
      },
      {
        path: "/create-modul",
        name: "CreateModul",
        meta: {
          authenticated: true,
        },
        component: () => import("../Views/Designer/CreateModul.vue"),
      },
    ],
  },
  {
    path: "/login",
    name: "Login",
    meta: {
      authenticated: false,
    },
    component: () => import("../Views/Auth/Login.vue"),
  },
  {
    path: "/registration-type",
    name: "RegistrationType",
    meta: {
      authenticated: false,
    },
    component: () => import("../Views/Auth/RegistrationType.vue"),
  },
  {
    path: "/designer-registration",
    name: "DesignerRegistration",
    meta: {
      authenticated: false,
    },
    component: () => import("../Views/Auth/DesignerRegistration.vue"),
  },
  {
    path: "/panelcutter-registration",
    name: "PanelCutterRegistration",
    meta: {
      authenticated: false,
    },
    component: () => import("../Views/Auth/PanelCutterRegistration.vue"),
  },
  {
    path: "*",
    name: "NotFound",
    meta: {
      authenticated: false,
    },
    component: () => import("../Views/NotFound.vue"),
  },
];

const router = new VueRouter({
  mode: "history",
  base: process.env.BASE_URL,
  routes,
});

router.beforeEach((to, _from, next) => {
  if (to.meta.authenticated && !store.state.isAuthenticated)
    next({ name: "Login" });
  else next();
});

router.beforeResolve((to, _from, next) => {
  if (to.name) {
    NProgress.start();
  }
  next();
});

router.afterEach(() => {
  NProgress.done();
});

export default router;
