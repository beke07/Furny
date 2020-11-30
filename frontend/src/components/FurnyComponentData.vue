<template>
  <div class="white-card mb-2 component-card">
    <div>
      <h3>{{ name }}</h3>
      <h4>{{ width }} mm * {{ height }} mm</h4>
    </div>
    <div>
      <slot name="first-button"></slot>
      <slot name="second-button"></slot>
    </div>
  </div>
</template>

<script>
export default {
  name: "FurnyComponentData",
  props: {
    index: Number,
    name: String,
    width: Number,
    height: Number,
  },
};
</script>

<style scoped>
.component-card {
  display: flex;
  justify-content: space-between;
  flex-direction: row;
}
.component-card .button {
  width: 25px !important;
  height: 25px !important;
}
</style>
