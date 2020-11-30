/// <reference types="cypress" />

import { clearAndfill, fill } from "./helper";

context("Designer moduls", () => {
  before(() => {
    cy.visit("http://localhost:8080");

    fill(cy, 0, "tesztlapszabasz@furny.hu");
    fill(cy, 1, "Asd123.");

    cy.get(".vs-button-relief").click();

    cy.wait(500);
  });

  beforeEach(() => {
    cy.viewport(1500, 1000);

    cy.get(".vs-sidebar--item")
      .eq(2)
      .click();

    cy.wait(500);
  });

  it("create-offer", () => {
    cy.get(".vs-sidebar--item")
      .eq(0)
      .click();

    cy.get(".vs-table--tr")
      .eq(0)
      .dblclick();

    clearAndfill(cy, 0, 6000);

    cy.get(".vs-button-relief").click();
  });
});
