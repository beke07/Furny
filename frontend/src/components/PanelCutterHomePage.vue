<template>
  <div class="container white-card">
    <div class="row">
      <div class="col">
        <router-link to="panelcutter-offers">
          <div
            class="border d-flex justify-content-center align-items-center flex-column p-5 mt-5 mb-5 ml-5 mr-3"
          >
            <h1>{{ home.offers }}</h1>
            <h6>új ajánlatkérés</h6>
          </div>
        </router-link>
      </div>

      <div class="col">
        <router-link to="panelcutter-offers">
          <div
            class="border d-flex justify-content-center align-items-center flex-column p-5 mt-5 mb-5 mr-5 ml-3"
          >
            <h1>{{ home.orders }}</h1>
            <h6>új rendelés</h6>
          </div>
        </router-link>
      </div>
    </div>
  </div>
</template>

<script>
import { getHomePage } from "../store/services/panelcutter";

export default {
  name: "PanelCutterHomePage",
  computed: {
    userId() {
      return this.$store.state.user.id;
    },
  },
  methods: {},
  data: () => ({
    home: {},
  }),
  async beforeMount() {
    this.home = await getHomePage(this.userId);
  },
};
</script>

<style>
a {
  color: #2b2b2b;
}
a:hover {
  color: rgb(88, 140, 184);
}
</style>
