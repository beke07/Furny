<template>
  <div id="parentx">
    <vs-sidebar
      default-index="1"
      color="primary"
      class="sidebarx"
      :hiddenBackground="doNotClose"
      spacer
      :click-not-close="doNotClose"
      v-model="isSidebarActive"
    >
      <div class="header-sidebar text-center" slot="header">
        <vs-avatar size="70px" :src="profileImage" />
        <h4>
          {{ user.name }}<br />
          <small>{{ user.email }}</small>
        </h4>
      </div>

      <template v-for="(sidebarLink, index) in sidebarLinks">
        <vs-sidebar-item
          v-if="sidebarLink.roles.includes(role)"
          :icon="sidebarLink.icon"
          :to="sidebarLink.url"
          :key="`sidebarLink-${index}`"
          :index="index"
        >
          <span class="hide-in-minisidebar">{{ sidebarLink.name }}</span>
        </vs-sidebar-item>
      </template>
    </vs-sidebar>
  </div>
</template>

<script>
export default {
  name: "SideBar",
  props: {
    parent: String,
    sidebarLinks: {
      type: Array,
      required: true,
    },
    index: {
      default: null,
      type: [String, Number],
    },
    profileImage: String,
  },
  data: () => ({
    doNotClose: false,
    windowWidth: window.innerWidth,
    user: {},
  }),
  computed: {
    role() {
      return this.$store.state.role;
    },
    isSidebarActive: {
      get() {
        return this.$store.state.isSidebarActive;
      },
      async set(val) {
        await this.$store.dispatch("setSidebarActivate", val);
      },
    },
  },
  methods: {
    handleWindowResize(event) {
      this.windowWidth = event.currentTarget.innerWidth;
      this.setSidebar();
    },
    async setSidebar() {
      if (this.windowWidth < 1170) {
        await this.$store.dispatch("setSidebarActivate", false);
        this.doNotClose = false;
      } else {
        await this.$store.dispatch("setSidebarActivate", true);
        this.doNotClose = true;
      }
    },
  },
  async beforeMount() {
    this.user = {
      email: this.$store.state.user.email,
      name: this.$store.state.user.name || "Névtelen",
    };
  },
  mounted() {
    this.$nextTick(() => {
      window.addEventListener("resize", this.handleWindowResize);
    });
    this.setSidebar();
  },
  beforeDestroy() {
    window.removeEventListener("resize", this.handleWindowResize);
    this.setSidebar();
  },
};
</script>
