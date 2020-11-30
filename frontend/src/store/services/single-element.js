import axios from "../../http";

export async function create(role, name, id, element) {
  return await axios.post(`${role}/${id}/${name}`, element);
}

export async function update(role, name, id, elementId, patch) {
  return await axios.patch(`${role}/${id}/${name}/${elementId}`, patch);
}

export async function get(role, name, id) {
  return (await axios.get(`${role}/${id}/${name}`)).data;
}

export async function getById(role, name, id, elementId) {
  return (await axios.get(`${role}/${id}/${name}/${elementId}`)).data;
}

export async function remove(role, name, id, elementId) {
  return await axios.delete(`${role}/${id}/${name}/${elementId}`);
}
