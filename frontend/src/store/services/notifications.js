import axios from "../../http";

export async function getNotifications(id) {
  return (await axios.get(`users/${id}/notifications`)).data;
}
