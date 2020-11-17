import axios from "../../http";

export async function registerDesigner(user) {
  await axios.post("auth/register/designer", user);
}

export async function registerPanelCutter(user) {
  await axios.post("auth/register/panel-cutter", user);
}
