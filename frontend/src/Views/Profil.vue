<template>
  <div class="white-card ">
    <h3>Profilom</h3>
    <FurnyProfil :role="this.$store.state.role" />
  </div>
</template>

<script>
import FurnyProfil from "../components/profil/FurnyProfil";

export default {
  name: "Profil",
  components: {
    FurnyProfil,
  },
};
</script>
