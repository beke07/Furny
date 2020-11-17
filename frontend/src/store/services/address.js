import axios from "../../http";

export async function getAddresses() {
  return (await axios.get("address")).data;
}
