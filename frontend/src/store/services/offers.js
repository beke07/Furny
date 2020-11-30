import axios from "../../http";

export async function create(id, fid, offer) {
  return await axios.post(`designer/${id}/furnitures/${fid}/offers`, offer);
}

export async function fillOffer(role, name, id, element, oid) {
  return await axios.post(`${role}/${id}/${name}/${oid}`, element);
}

export async function accept(role, id, order) {
  return await axios.post(`${role}/offers/${id}/accept`, order);
}

export async function decline(role, id) {
  return await axios.post(`${role}/offers/${id}/decline`);
}
