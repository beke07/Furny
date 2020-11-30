/// <reference types="cypress" />

import { clearAndfill, fill } from "./helper";

context("Designer moduls", () => {
  before(() => {
    cy.visit("http://localhost:8080");

    fill(cy, 0, "tesztdesigner@furny.hu");
    fill(cy, 1, "Asd123.");

    cy.get(".vs-button-relief").click();

    cy.wait(500);
  });

  beforeEach(() => {
    cy.viewport(1500, 1000);

    cy.get(".vs-sidebar--item")
      .eq(3)
      .click();

    cy.wait(500);
  });

  it("add", () => {
    add();
  });

  xit("delete", () => {
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

  clearAndfill(cy, 0, "Fiók");
  clearAndfill(cy, 1, "Alja-Teteje");

  cy.get(".vs-input-number--input")
    .eq(0)
    .type(200);

  cy.get(".vs-input-number--input")
    .eq(1)
    .type(300);

  cy.get(".vs-checkbox--input")
    .eq(0)
    .click();

  cy.get(".vs-checkbox--input")
    .eq(1)
    .click();

  cy.get(".vs-checkbox--input")
    .eq(2)
    .click();

  cy.get(".vs-checkbox--input")
    .eq(3)
    .click();

  cy.get(".vs-button-relief")
    .eq(0)
    .click();

  cy.get(".vs-checkbox--input")
    .eq(0)
    .should("have.attr", "value", "false");

  cy.get(".includeIcon")
    .eq(0)
    .click();

  cy.get(".includeIcon")
    .eq(1)
    .click();

  cy.get(".vs-button-relief")
    .eq(1)
    .click();
}
