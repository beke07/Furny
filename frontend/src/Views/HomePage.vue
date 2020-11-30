<template>
  <div v-if="role === 'Designer'">
    <DesignerHomePage />
  </div>
  <div v-else-if="role === 'PanelCutter'">
    <PanelCutterHomePage />
  </div>
</template>

<script>
import DesignerHomePage from "../components/DesignerHomePage";
import PanelCutterHomePage from "../components/PanelCutterHomePage";
export default {
  name: "HomePage",
  components: {
    DesignerHomePage,
    PanelCutterHomePage,
  },
  computed: {
    role() {
      return this.$store.state.role;
    },
  },
};
</script>
