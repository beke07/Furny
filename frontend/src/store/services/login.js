import axios, { toParams } from "../../http";

export async function login(user) {
  const response = await axios.post("auth/login", user);
  return response.data;
}

export async function userSync(role) {
  await axios.get("auth/user-sync", toParams({ role: role }));
}

export async function getGoogleUserRole(email) {
  return (await axios.get(`auth/user-roles/${email}`)).data;
}
