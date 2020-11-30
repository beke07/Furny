<template>
  <FurnyTable
    title="Alapanyagaim"
    :rows="materials"
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
  name: "Materials",
  components: {
    FurnyTable,
    FurnyButton,
  },
  data: () => ({
    name: "materials",
    materials: [],
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
      this.$router.push("/create-material");
    },
    async remove() {
      if (this.selected) {
        await remove(this.role, this.name, this.userId, this.selected);
        this.materials = await get(this.role, this.name, this.userId);
      }
    },
    edit(id) {
      this.$router.push({ path: "/create-material", query: { id: id } });
    },
    select(id) {
      this.selected = id;
    },
  },
  async beforeMount() {
    this.materials = await get(this.role, this.name, this.userId);
  },
};
</script>
