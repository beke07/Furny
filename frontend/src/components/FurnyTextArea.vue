<template>
  <vs-textarea
    :color="color"
    :label="labelPlaceholder"
    @input="handleInput"
    v-model="input"
  />
</template>

<script>
export default {
  name: "FurnyTextArea",
  props: {
    labelPlaceholder: String,
    inputData: {
      type: String,
      default: "",
    },
  },
  data: () => ({
    input: "",
  }),
  watch: {
    inputData: function(newVal) {
      this.input = newVal;
    },
  },
  computed: {
    color() {
      return this.$store.state.inputColor;
    },
  },
  methods: {
    handleInput() {
      this.$emit("update:inputData", this.input);
    },
  },
  beforeMount() {
    this.input = this.inputData;
  },
};
</script>
