<template>
  <div>
    <div class="row" v-for="(component, index) in components" :key="index">
      <div class="col-3 mb-3 d-flex justify-content-start align-items-end">
        <h4>{{ component.name }}</h4>
        <small class="ml-1"
          >({{ component.height }} * {{ component.width }})</small
        >
      </div>
      <div class="col-3 d-flex justify-content-center align-items-end">
        <vs-select
          :disabled="readonly"
          label="Labszabászat"
          v-model="component.panelCutterId"
        >
          <vs-select-item
            :color="color"
            :key="index"
            :value="panelCutter.id"
            :text="panelCutter.name"
            v-for="(panelCutter, index) in panelCutters"
          />
        </vs-select>
        <div class="pl-1">
          <vs-tooltip text="Összes kitöltése" position="top">
            <vs-button
              class="all-button"
              :color="color"
              type="border"
              icon="done"
              @click="allpanelCutter(component.panelCutterId)"
            ></vs-button>
          </vs-tooltip>
        </div>
      </div>
      <div class="col-3 d-flex justify-content-center align-items-end pl-1">
        <vs-select
          :disabled="readonly"
          label="Alapanyag"
          v-if="component.panelCutterId"
          v-model="component.materialId"
        >
          <vs-select-item
            :key="index"
            :value="material.id"
            :text="material.name"
            v-for="(material, index) in findMaterial(component.panelCutterId)"
          />
        </vs-select>
        <div class="pl-1" v-if="component.panelCutterId">
          <vs-tooltip text="Összes kitöltése" position="top">
            <vs-button
              class="all-button"
              :color="color"
              type="border"
              icon="done"
              @click="allMaterial(component.materialId)"
            ></vs-button>
          </vs-tooltip>
        </div>
      </div>
      <div class="col-3 d-flex justify-content-center align-items-end pl-1">
        <vs-select
          :disabled="readonly"
          label="Élzárás"
          v-if="component.panelCutterId"
          v-model="component.closingId"
        >
          <vs-select-item
            :key="index"
            :value="closing.id"
            :text="closing.name"
            v-for="(closing, index) in findClosing(component.panelCutterId)"
          />
        </vs-select>
        <div class="pl-1" v-if="component.panelCutterId">
          <vs-tooltip text="Összes kitöltése" position="top">
            <vs-button
              class="all-button"
              :color="color"
              type="border"
              icon="done"
              @click="allClosing(component.closingId)"
            ></vs-button>
          </vs-tooltip>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
export default {
  name: "FurnyOfferCreate",
  props: {
    components: Array,
    panelCutters: Array,
    color: String,
    readonly: Boolean,
  },
  methods: {
    findClosing(id) {
      return this.panelCutters.find((p) => p.id === id).closings;
    },
    findMaterial(id) {
      return this.panelCutters.find((p) => p.id === id).materials;
    },
    allpanelCutter(panelCutterId) {
      if (panelCutterId) {
        this.components.map((c) => (c.panelCutterId = panelCutterId));
        this.$forceUpdate();
      }
    },
    allMaterial(materialId) {
      if (materialId) {
        this.components.map((c) => (c.materialId = materialId));
        this.$forceUpdate();
      }
    },
    allClosing(closingId) {
      if (closingId) {
        this.components.map((c) => (c.closingId = closingId));
        this.$forceUpdate();
      }
    },
  },
};
</script>

<style>
.all-button {
  height: 36px !important;
}
</style>
