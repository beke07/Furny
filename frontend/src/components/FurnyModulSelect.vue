<template>
  <div class="multiselect-input">
    <label>{{ label }}</label>
    <multiselect
      selectedLabel="Kiválasztott"
      selectLabel="Enter a választáshoz"
      deselectLabel="Enter az eltávolításhoz"
      placeholder="Válassz!"
      v-model="selected"
      :options="options"
      :custom-label="name"
      :label="inputLabel"
      :track-by="inputTrackBy"
      @input="handleInput"
    >
      <template v-slot:noResult>
        Nincs találat
      </template>
      <template v-slot:noOptions>
        A lista üres
      </template>
    </multiselect>
  </div>
</template>

<script>
import Multiselect from "vue-multiselect";
import { get } from "../store/services/single-element";

export default {
  name: "FurnyModulSelect",
  components: {
    Multiselect,
  },
  props: {
    label: String,
    inputLabel: String,
    inputTrackBy: String,
    value: String,
    selectedId: String,
  },
  data: () => ({
    selected: "",
    options: [],
  }),
  methods: {
    handleInput() {
      this.$emit("select", this.selected.id);
      this.selected = "";
    },
    name({ name }) {
      return `${name}`;
    },
  },
  async beforeMount() {
    this.options = await get(
      this.$store.state.role,
      "modules",
      this.$store.state.user.id
    );
    this.selected = this.options.find((e) => e.id === this.selectedId);
  },
};
</script>

<style src="vue-multiselect/dist/vue-multiselect.min.css"></style>

<style scoped>
.multiselect-input label {
  font-size: 12px;
  padding-left: 5px;
  margin-bottom: 5px;
  color: rgba(0, 0, 0, 0.4);
}
.multiselect-input {
  width: 100%;
  margin-top: 3px;
}
</style>
