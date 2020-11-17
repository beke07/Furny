<template>
  <router-link :to="toComputed" :style="{ color: color }">{{
    text
  }}</router-link>
</template>

<script>
export default {
  name: "FurnyRouterLink",
  props: {
    to: String,
    text: String,
  },
  computed: {
    color() {
      return this.$store.state.inputColor;
    },
    toComputed() {
      return this.to === undefined || this.to === null || this.to.length === 0
        ? function() {
            console.log("Nem adtál mert routingot");
          }
        : this.to;
    },
  },
};
</script>
