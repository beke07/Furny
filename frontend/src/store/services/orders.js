import axios from "../../http";

export async function done(id) {
  return await axios.post(`orders/${id}/done`);
}
