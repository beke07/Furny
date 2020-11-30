export function offerStateToString(state) {
  switch (state) {
    case 1:
      return "Feldolgozás alatt";
    case 2:
      return "Elfogadva";
    case 3:
      return "Elutasítva";
    case 4:
      return "Feldolgozva";
  }
}

export function orderStateToString(state) {
  return state === null ? "Nem teljesített" : "Teljesített";
}
