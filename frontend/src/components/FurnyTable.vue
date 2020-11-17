<template>
  <vs-table
    v-model="selected"
    pagination
    max-items="5"
    @dblSelection="edit"
    search
    stripe
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
      <vs-th class="float-right">
        <FurnyButton
          type="border"
          color="danger"
          text="Törlés"
          class="mb-1 mr-1"
          @clicked="remove"
        />
        <FurnyButton type="border" text="Új" class="mb-1" @clicked="create" />
      </vs-th>
    </template>

    <template slot-scope="{ data }">
      <vs-tr :data="tr" :key="indextr" v-for="(tr, indextr) in data">
        <vs-td :data="data[indextr].id">
          {{ data[indextr][property] }}
        </vs-td>
        <vs-td></vs-td>
      </vs-tr>
    </template>
  </vs-table>
</template>

<script>
import FurnyButton from "./FurnyButton";

export default {
  name: "FurnyTable",
  props: {
    rows: Array,
    title: String,
    property: String,
  },
  components: {
    FurnyButton,
  },
  data: () => ({
    selected: [],
  }),
  methods: {
    create() {
      this.$emit("created");
    },
    remove() {
      if (this.selected) this.$emit("removed", this.selected.id);
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
</style>
