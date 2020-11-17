<template>
  <vs-input
    :disabled="disabled"
    :color="color"
    :label-placeholder="labelPlaceholder"
    :danger-text="dangerText"
    :danger="error"
    @input="handleInput"
    v-model="dataInput"
  />
</template>

<script>
import { email } from "vuelidate/lib/validators";

export default {
  name: "FurnyEmailInput",
  props: {
    labelPlaceholder: String,
    inputData: String,
    disabled: Boolean,
  },
  validations: {
    dataInput: {
      email,
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
      return !this.$v.dataInput.email ? "Helytelen e-mail formátum" : "";
    },
    error() {
      return this.$v.dataInput.$invalid;
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
