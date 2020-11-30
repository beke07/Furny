import axios, { downloadFile } from "../../http";

export async function excelExport(excelType, id, fid) {
  return await axios
    .get(`designer/${id}/furnitures/${fid}/export`, {
      params: {
        excelType: excelType,
      },
      responseType: "blob",
    })
    .then((response) =>
      downloadFile(response, "application/vnd.ms-excel", "furniture", "xlsx")
    );
}
