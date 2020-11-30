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
      .eq(2)
      .click();

    cy.wait(500);
  });

  it("add", () => {
    cy.get(".vs-button-border")
      .eq(3)
      .click();

    cy.wait(500);

    clearAndfill(cy, 0, "3 fiókos szekrény");

    cy.get(".multiselect").click();
    cy.get(".multiselect__element")
      .eq(0)
      .click();

    cy.get(".multiselect").click();
    cy.get(".multiselect__element")
      .eq(0)
      .click();

    cy.get(".multiselect").click();
    cy.get(".multiselect__element")
      .eq(0)
      .click();

    clearAndfill(cy, 2, "Takaró");

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

    cy.get(".vs-button-relief")
      .eq(1)
      .click();
  });

  it("offer", () => {
    cy.get(".vs-table--tr")
      .eq(0)
      .click();

    cy.get(".vs-button-border")
      .eq(2)
      .click();

    cy.wait(1500);

    fillTab(1);
    fillTab(2);
    fillTab(3);
    fillTab(4);

    cy.get(".vs-button-relief")
      .eq(0)
      .click();
  });
});

const fillTab = (index) => {
  cy.get(".vs-tabs--btn")
    .eq(index)
    .click();

  cy.wait(500);

  selectFromMulti(0, 0);
  selectFromMulti(1, 0);
  selectFromMulti(2, 0);
};

const selectFromMulti = (index1, index2) => {
  cy.get(".vs-select--input")
    .eq(index1)
    .click();

  cy.get(".vs-select--item")
    .eq(index2)
    .click();
};
