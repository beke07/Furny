import axios from "../../http";

export async function getNotifications(id) {
  return (await axios.get(`users/${id}/notifications`)).data;
}

export async function doneNotification(id, nid) {
  return (await axios.post(`users/${id}/notifications/${nid}`)).data;
}
