<template>
  <div class="main-wrapper">
    <Navbar
      :topbarColor="topbarColor"
      :logo="require('@/assets/header-logo.png')"
      :title="logotitle"
      :profileImage="profileImage"
    />

    <SideBar :sidebarLinks="sidebarLinks" :profileImage="profileImage" />

    <div class="main-container-fluid">
      <router-view class="inner-router-view"></router-view>
    </div>
  </div>
</template>

<script>
import Navbar from "@/layout/header/Navbar.vue";
import SideBar from "@/layout/sidebar/SideBar.vue";
import sidebarLinks from "@/layout/sidebar/sidebarlinks.js";

export default {
  name: "MainContainer",
  components: {
    Navbar,
    SideBar,
  },
  data: () => ({
    logotitle: "Furny",
    sidebarLinks: sidebarLinks,
    profileImage: "",
  }),
  computed: {
    topbarColor() {
      return this.$store.state.backgroundColor;
    },
  },
  async beforeMount() {
    this.profileImage = await this.$store.dispatch("getProfilePicture", true);
  },
};
</script>

<style scoped>
.main-container-fluid {
  padding: 90px 30px 30px 30px;
}
.inner-router-view {
  padding: 40px;
  max-width: 1100px;
}
</style>
