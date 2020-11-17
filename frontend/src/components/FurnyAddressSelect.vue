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

export default {
  name: "FurnyAddressSelect",
  components: {
    Multiselect,
  },
  props: {
    objectPlease: {
      type: Boolean,
      default: false,
    },
    label: String,
    inputLabel: String,
    inputTrackBy: String,
    value: String,
    selectedId: String,
  },
  data: () => ({
    selected: "",
    options: Array,
  }),
  methods: {
    handleInput() {
      const result = this.objectPlease ? this.selected : this.selected.id;
      this.$emit("update:value", result);
    },
    name({ city, zipCode }) {
      return `${zipCode} - ${city}`;
    },
  },
  async beforeMount() {
    this.options = this.$store.state.addresses;
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
  width: 80%;
  margin-top: 3px;
}
</style>
