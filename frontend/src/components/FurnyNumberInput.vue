<template>
  <vs-input-number
    :disabled="disabled"
    size="medium"
    :color="color"
    :label="label"
    @input="handleInput"
    v-model="input"
  />
</template>

<script>
export default {
  name: "FurnyNumberInput",
  props: {
    disabled: Boolean,
    label: String,
    inputData: {
      type: Number,
      default: 0,
    },
  },
  watch: {
    inputData: function(newVal) {
      this.input = newVal;
    },
  },
  data: () => ({
    input: 0,
  }),
  beforeMount() {
    this.input = this.inputData;
  },
  computed: {
    color() {
      return this.$store.state.inputColor;
    },
  },
  methods: {
    handleInput() {
      this.$emit("update:inputData", parseInt(this.input));
    },
  },
};
</script>
