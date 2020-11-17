import axios from "axios";

const NProgress = window.NProgress;

const instance = axios.create({
  baseURL: process.env.VUE_APP_API_ENDPOINT,
});

instance.interceptors.request.use(
  (config) => {
    NProgress.start();

    const token = localStorage.getItem("token");
    if (token) config.headers["Authorization"] = `Bearer ${token}`;

    return config;
  },
  () => {
    NProgress.done();
  }
);

instance.interceptors.response.use(
  (response) => {
    NProgress.done();
    return response;
  },
  (error) => {
    NProgress.done();
    const errors = error.response.data.errors;
    if (errors) {
      for (const property in errors) {
        throw new Error(`${error.response.data.errors[property]}`);
      }
    } else {
      throw new Error(error.response.data);
    }
  }
);

export function toParams(object) {
  return {
    params: object,
  };
}

export default instance;
