import axios from "../../http";

export async function getHomePage(id) {
  return (await axios.get(`panelCutter/${id}`)).data;
}
