<template>
  <div class="container auth-container">
    <div class="row">
      <div class="col form">
        <FurnyButton
          class="registration-type-button"
          type="border"
          text="Designer vagyok"
          @clicked="designerRegistration"
        />
      </div>
      <div class="col form">
        <FurnyButton
          class="registration-type-button"
          type="border"
          text="Lapszabász vagyok"
          @clicked="panelCutterRegistration"
        />
      </div>
    </div>
  </div>
</template>

<script>
import FurnyButton from "../../components/FurnyButton";

export default {
  name: "RegistrationType",
  components: {
    FurnyButton,
  },
  methods: {
    async designerRegistration() {
      this.$router.push("designer-registration");
    },
    async panelCutterRegistration() {
      this.$router.push("panelcutter-registration");
    },
  },
};
</script>

<style scoped>
.registration-type-button {
  width: 60%;
  margin: 100px 0 100px 0;
}
</style>
