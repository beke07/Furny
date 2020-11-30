export const clearAndfill = (cy, index, text) => {
  cy.get("input")
    .eq(index)
    .clear()
    .type(text);
};

export const fill = (cy, index, text) => {
  cy.get("input")
    .eq(index)
    .type(text);
};
