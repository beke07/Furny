<template>
  <vs-table
    v-model="selected"
    pagination
    max-items="5"
    @selected="select"
    @dblSelection="edit"
    search
    noDataText="Nem található adat"
    :data="rows"
  >
    <template slot="header">
      <div>
        <h3>
          {{ title }}
        </h3>
        <small>Szerkesztéshez kattints duplán az elemre.</small>
      </div>
    </template>

    <template slot="thead">
      <vs-th sort-key="name">
        Elenevezés
      </vs-th>
      <vs-th></vs-th>
      <vs-th class="float-right">
        <slot name="first-button"></slot>
        <slot name="second-button"></slot>
        <slot name="third-button"></slot>
        <slot name="fourth-button"></slot>
      </vs-th>
    </template>

    <template slot-scope="{ data }">
      <vs-tr :data="tr" :key="indextr" v-for="(tr, indextr) in data">
        <vs-td :data="data[indextr].id">
          {{ data[indextr][property] }}
        </vs-td>
        <vs-td></vs-td>
        <vs-td v-if="plusProperty"> {{ data[indextr][plusProperty] }}</vs-td>
        <vs-td v-else></vs-td>
      </vs-tr>
    </template>
  </vs-table>
</template>

<script>
export default {
  name: "FurnyTable",
  props: {
    rows: Array,
    title: String,
    property: String,
    plusProperty: String,
  },
  data: () => ({
    selected: [],
  }),
  methods: {
    select() {
      this.$emit("selected", this.selected.id);
    },
    edit() {
      if (this.selected) this.$emit("edited", this.selected.id);
    },
  },
};
</script>

<style scoped>
div.vs-table-text {
  justify-content: space-between;
}
.vs-table--td {
  padding: 15px !important;
}
</style>
