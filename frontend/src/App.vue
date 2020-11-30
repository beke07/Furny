<template>
  <div id="app">
    <router-view></router-view>
  </div>
</template>

<style>
#app {
  height: 100%;
}
</style>

<script>
import { getAddresses } from "./store/services/address";

export default {
  name: "App",
  async beforeMount() {
    const addresses = await getAddresses();
    await this.$store.dispatch("saveAddresses", addresses);
  },
};
</script>
