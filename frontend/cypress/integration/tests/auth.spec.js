/// <reference types="cypress" />

import { fill } from "./helper";

context("Auth", () => {
  beforeEach(() => {
    cy.visit("http://localhost:8080");

    cy.viewport(1500, 1000);
  });

  it("designer registration", () => {
    cy.get("a[href='/registration-type']").click();

    cy.wait(500);

    cy.get("[type=button]")
      .eq(0)
      .click();

    fill(cy, 0, "Teszt designer");
    fill(cy, 1, "tesztdesigner@furny.hu");
    fill(cy, 2, "Asd123.");
    fill(cy, 3, "Asd123.");
    fill(cy, 4, "06030/123-12-12");

    cy.get(".multiselect").click();
    cy.get(".multiselect__element")
      .eq(0)
      .click();

    fill(cy, 6, "Rákóczi utca 12.");

    cy.get("[type=button]")
      .eq(0)
      .click();
  });

  it("panel cutter registration", () => {
    cy.get("a[href='/registration-type']").click();

    cy.wait(500);

    cy.get("[type=button]")
      .eq(1)
      .click();

    fill(cy, 0, "Teszt lapszabász");
    fill(cy, 1, "tesztlapszabasz@furny.hu");
    fill(cy, 2, "Asd123.");
    fill(cy, 3, "Asd123.");
    fill(cy, 4, "06030/123-12-12");
    fill(cy, 5, "facebook/teszt_lapszabasz");

    cy.get(".multiselect").click();
    cy.get(".multiselect__element")
      .eq(0)
      .click();

    fill(cy, 7, "Rákóczi utca 12.");
    fill(cy, 8, "H-P 8:00 - 14:00");
    fill(cy, 9, "kiszállítunk,számlázunk");

    cy.get("[type=button]")
      .eq(0)
      .click();
  });

  it("designer login-logout", () => {
    fill(cy, 0, "tesztdesigner@furny.hu");
    fill(cy, 1, "Asd123.");

    cy.get(".vs-button-relief").click();

    cy.wait(500);

    cy.get(".vs-con-dropdown")
      .eq(1)
      .click();

    cy.get(".vs-dropdown--item")
      .eq(1)
      .click();
  });

  it("panelcutter login-logout", () => {
    fill(cy, 0, "tesztlapszabasz@furny.hu");
    fill(cy, 1, "Asd123.");

    cy.get(".vs-button-relief").click();

    cy.wait(500);

    cy.get(".vs-con-dropdown")
      .eq(1)
      .click();

    cy.get(".vs-dropdown--item")
      .eq(1)
      .click();
  });
});
