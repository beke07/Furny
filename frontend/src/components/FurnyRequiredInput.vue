<template>
  <vs-input
    :disabled="disabled"
    :type="type"
    :color="color"
    :label-placeholder="labelPlaceholder"
    :danger-text="dangerText"
    :danger="error"
    @input="handleInput"
    v-model="input"
  />
</template>

<script>
import { required } from "vuelidate/lib/validators";

export default {
  name: "FurnyRequiredInput",
  props: {
    labelPlaceholder: String,
    inputData: {
      type: String,
      default: "",
    },
    disabled: Boolean,
    type: {
      type: String,
      default: "text",
    },
  },
  watch: {
    inputData: function(newVal) {
      this.input = newVal;
    },
  },
  validations: {
    input: {
      required,
    },
  },
  data: () => ({
    input: "",
  }),
  beforeMount() {
    this.input = this.inputData;
  },
  computed: {
    color() {
      return this.$store.state.inputColor;
    },
    dangerText() {
      return this.input?.length !== 0 && !this.$v.input.required
        ? "Kötelező"
        : "";
    },
    error() {
      if (this.input) return this.input?.length !== 0 && this.$v.input.$invalid;
      return false;
    },
  },
  methods: {
    handleInput() {
      this.$emit("update:inputData", this.input);
    },
  },
};
</script>
