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
        path: "/home",
        name: "HomePage",
        meta: {
          authenticated: true,
        },
        component: () => import("../Views/HomePage.vue"),
      },
      {
        path: "/profil",
        name: "Profil",
        meta: {
          authenticated: true,
        },
        component: () => import("../Views/Profil.vue"),
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
      {
        path: "/furnitures",
        name: "Frunitures",
        meta: {
          authenticated: true,
        },
        component: () => import("../Views/Designer/Furnitures.vue"),
      },
      {
        path: "/create-furniture",
        name: "CreateFurniture",
        meta: {
          authenticated: true,
        },
        component: () => import("../Views/Designer/CreateFurniture.vue"),
      },
      {
        path: "/create-offer",
        name: "CreateOffer",
        meta: {
          authenticated: true,
        },
        component: () => import("../Views/Designer/CreateOffer.vue"),
      },
      {
        path: "/create-order",
        name: "CreateOrder",
        meta: {
          authenticated: true,
        },
        component: () => import("../Views/Designer/CreateOrder.vue"),
      },
      {
        path: "/designer-offers",
        name: "DesignerOffers",
        meta: {
          authenticated: true,
        },
        component: () => import("../Views/Designer/Offers.vue"),
      },
      {
        path: "/designer-orders",
        name: "Orders",
        meta: {
          authenticated: true,
        },
        component: () => import("../Views/Designer/Orders.vue"),
      },
      {
        path: "/ads",
        name: "Ads",
        meta: {
          authenticated: true,
        },
        component: () => import("../Views/PanelCutter/Ads.vue"),
      },
      {
        path: "/create-ad",
        name: "CreateAd",
        meta: {
          authenticated: true,
        },
        component: () => import("../Views/PanelCutter/CreateAd.vue"),
      },
      {
        path: "/closings",
        name: "Closings",
        meta: {
          authenticated: true,
        },
        component: () => import("../Views/PanelCutter/Closings.vue"),
      },
      {
        path: "/create-closing",
        name: "CreateClosing",
        meta: {
          authenticated: true,
        },
        component: () => import("../Views/PanelCutter/CreateClosing.vue"),
      },
      {
        path: "/create-material",
        name: "CreateMaterial",
        meta: {
          authenticated: true,
        },
        component: () => import("../Views/PanelCutter/CreateMaterial.vue"),
      },
      {
        path: "/materials",
        name: "Materials",
        meta: {
          authenticated: true,
        },
        component: () => import("../Views/PanelCutter/Materials.vue"),
      },
      {
        path: "/panelcutter-offers",
        name: "PanelCutterOffers",
        meta: {
          authenticated: true,
        },
        component: () => import("../Views/PanelCutter/Offers.vue"),
      },
      {
        path: "/panelcutter-orders",
        name: "PanelCutterOrders",
        meta: {
          authenticated: true,
        },
        component: () => import("../Views/PanelCutter/Orders.vue"),
      },
      {
        path: "/accept-offer",
        name: "AcceptOffer",
        meta: {
          authenticated: true,
        },
        component: () => import("../Views/PanelCutter/AcceptOffer.vue"),
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
