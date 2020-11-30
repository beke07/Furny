/// <reference types="cypress" />

import { clearAndfill, fill } from "./helper";

context("Panelcutter ads", () => {
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
      .eq(4)
      .click();
  });

  it("add", () => {
    add();
  });

  it("edit", () => {
    cy.get(".vs-table--tr")
      .eq(0)
      .dblclick();

    cy.get("textarea")
      .eq(0)
      .clear()
      .type("Editált teszt szöveg hirdetés szövege, szövege.");

    cy.get(".vs-button-relief").click();
  });

  it("delete", () => {
    cy.get(".vs-table--tr")
      .eq(0)
      .click();

    cy.get(".vs-button-border")
      .eq(0)
      .click();

    add();
  });
});

function add() {
  cy.get(".vs-button-border")
    .eq(1)
    .click();

  cy.wait(500);

  clearAndfill(cy, 0, "Teszt hirdetés!");

  cy.get("textarea").type("Teszt hirdetés szövege, szövege.");

  cy.get(".vs-button-relief").click();
}
