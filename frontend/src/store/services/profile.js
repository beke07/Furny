import axios, { toParams } from "../../http";

export async function getProfile(id, role, email) {
  return (
    await axios.get(
      `${role}/profile`,
      toParams({
        id: id,
        email: email,
      })
    )
  ).data;
}

export async function patchProfile(role, id, patch) {
  return await axios.patch(`${role}/${id}/profile`, patch);
}
