/// <reference types="cypress" />

import { clearAndfill, fill } from "./helper";

context("Profil", () => {
  beforeEach(() => {
    cy.visit("http://localhost:8080");

    cy.viewport(1500, 1000);

    cy.wait(1500);
  });

  xit("designer profil", () => {
    fill(cy, 0, "tesztdesigner@furny.hu");
    fill(cy, 1, "Asd123.");

    cy.get(".vs-button-relief").click();

    cy.wait(500);

    cy.get(".vs-con-dropdown")
      .eq(1)
      .click();

    cy.get(".vs-dropdown--item")
      .eq(0)
      .click();

    clearAndfill(cy, 1, "Teszt Designer");

    cy.get(".vs-button")
      .eq(0)
      .click();

    cy.get("input")
      .eq(1)
      .should("have.value", "Teszt Designer");
  });
});
