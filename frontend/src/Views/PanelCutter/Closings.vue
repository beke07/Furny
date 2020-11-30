<template>
  <FurnyTable
    title="Élzárásaim"
    :rows="closings"
    property="name"
    @edited="edit"
    @selected="select"
  >
    <template v-slot:first-button>
      <FurnyButton
        type="border"
        color="danger"
        text="Törlés"
        class="mb-1 mr-1"
        @clicked="remove"
      />
    </template>
    <template v-slot:second-button>
      <FurnyButton type="border" text="Új" class="mb-1" @clicked="create" />
    </template>
  </FurnyTable>
</template>

<script>
import FurnyTable from "../../components/FurnyTable";
import FurnyButton from "../../components/FurnyButton";
import { remove, get } from "../../store/services/single-element";

export default {
  name: "Closings",
  components: {
    FurnyTable,
    FurnyButton,
  },
  data: () => ({
    name: "closings",
    closings: [],
    selected: undefined,
  }),
  computed: {
    userId() {
      return this.$store.state.user.id;
    },
    role() {
      return this.$store.state.role;
    },
  },
  methods: {
    create() {
      this.$router.push("/create-closing");
    },
    async remove() {
      if (this.selected) {
        await remove(this.role, this.name, this.userId, this.selected);
        this.closings = await get(this.role, this.name, this.userId);
      }
    },
    edit(id) {
      this.$router.push({ path: "/create-closing", query: { id: id } });
    },
    select(id) {
      this.selected = id;
    },
  },
  async beforeMount() {
    this.closings = await get(this.role, this.name, this.userId);
  },
};
</script>
