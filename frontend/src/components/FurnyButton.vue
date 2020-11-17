<template>
  <vs-button :type="type" :color="compColor" @click="handleClick">{{
    text
  }}</vs-button>
</template>

<script>
export default {
  name: "FurnyButton",
  props: {
    type: String,
    color: String,
    text: String,
  },
  computed: {
    compColor() {
      return this.color ? this.color : this.$store.state.inputColor;
    },
  },
  methods: {
    handleClick() {
      this.$emit("clicked");
    },
  },
};
</script>
