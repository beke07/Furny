<template>
  <header class="gridx">
    <vs-navbar
      v-model="indexActive"
      :color="topbarColor"
      class="topnavbar"
      text-color="rgba(255,255,255,0.7)"
      active-text-color="rgba(255,255,255,1)"
    >
      <div slot="title" class="themelogo">
        <router-link to="/home">
          <img
            :src="logo"
            v-if="logo"
            alt="Dashboard"
            width="30"
            class="mr-2"
          />
          <span class="logo-text" v-if="title">{{ title }}</span>
        </router-link>
      </div>

      <div slot="title">
        <div class="hiddenDesktop cursor-pointer" @click.stop="activeSidebar">
          <vs-icon icon="menu"></vs-icon>
        </div>
      </div>

      <vs-spacer></vs-spacer>

      <vs-dropdown
        vs-trigger-click
        left
        class="cursor-pointer pr-2 pl-2 ml-1 mr-1"
      >
        <a class="text-white-dark" href="#">
          <vs-icon
            v-if="notifications.filter((n) => !n.isDone).length === 0"
            icon="notifications"
          />
          <vs-icon v-else icon="notifications_active" />
        </a>
        <vs-dropdown-menu class="topbar-dd">
          <vs-dropdown-item v-if="notifications.length === 0"
            >Nincsenek értesítések 😢</vs-dropdown-item
          >
          <vs-dropdown-item
            v-else
            v-for="notification in notifications.filter((n) => !n.isDone)"
            :key="notification.id"
            :to="notification.link"
            v-on:click="doneNotification(notification.id)"
            >{{ notification.text }}</vs-dropdown-item
          >
        </vs-dropdown-menu>
      </vs-dropdown>

      <vs-dropdown
        vs-trigger-click
        left
        class="cursor-pointer pr-2 pl-2 ml-1 mr-md-3"
      >
        <a class="text-white-dark user-image" href="#"
          ><img :src="profileImage" alt="User"
        /></a>
        <vs-dropdown-menu class="topbar-dd">
          <vs-dropdown-item to="/profil"
            ><vs-icon icon="person_outline" class="mr-1"></vs-icon
            >Profilom</vs-dropdown-item
          >
          <hr class="m-1" />
          <vs-dropdown-item @click="logout"
            ><vs-icon icon="exit_to_app" class="mr-1"></vs-icon> Kijelentkezés
          </vs-dropdown-item>
        </vs-dropdown-menu>
      </vs-dropdown>
    </vs-navbar>
  </header>
</template>

<script>
import {
  getNotifications,
  doneNotification,
} from "../../store/services/notifications";

export default {
  name: "Navbar",
  props: {
    topbarColor: String,
    title: String,
    logo: String,
    profileImage: String,
  },
  computed: {
    user() {
      return this.$store.state.user.id;
    },
  },
  data: () => ({
    indexActive: 0,
    showToggle: false,
    notifications: [],
  }),
  methods: {
    async doneNotification(id) {
      console.log("asd");
      await doneNotification(this.user, id);
      let notification = this.notifications.find((e) => e.id === id);
      notification.isDone = true;
    },
    async activeSidebar() {
      await this.$store.dispatch("setSidebarActivate", true);
    },
    async logout() {
      await this.$store.dispatch("logout");
      this.$router.push("/login");
    },
  },
  async beforeMount() {
    this.notifications = await getNotifications(this.user);
  },
};
</script>
