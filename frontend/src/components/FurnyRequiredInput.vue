<template>
  <vs-input
    :type="type"
    :color="color"
    :label-placeholder="labelPlaceholder"
    :danger-text="dangerText"
    :danger="error"
    @input="handleInput"
    v-model="dataInput"
  />
</template>

<script>
import { required } from "vuelidate/lib/validators";

export default {
  name: "FurnyRequiredInput",
  props: {
    labelPlaceholder: String,
    inputData: String,
    type: String,
  },
  validations: {
    dataInput: {
      required,
    },
  },
  data: () => ({
    dataInput: "",
  }),
  computed: {
    color() {
      return this.$store.state.inputColor;
    },
    dangerText() {
      return this.dataInput.length !== 0 && !this.$v.dataInput.required
        ? "Kötelező"
        : "";
    },
    error() {
      return this.dataInput.length !== 0 && this.$v.dataInput.$invalid;
    },
  },
  methods: {
    handleInput() {
      this.$emit("update:inputData", this.dataInput);
    },
  },
  beforeMount() {
    if (this.inputData) this.dataInput = this.inputData;
  },
};
</script>
