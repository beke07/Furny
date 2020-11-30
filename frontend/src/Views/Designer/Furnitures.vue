<template>
  <FurnyTable
    title="Bútoraim"
    :rows="furnitures"
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
      <FurnyButton
        type="border"
        text="Exportálás"
        class="mb-1 mr-1"
        color="warning"
        @clicked="excelExport"
      />
    </template>
    <template v-slot:third-button>
      <FurnyButton
        type="border"
        text="Ajánlatot kérek"
        class="mb-1 mr-1"
        color="success"
        @clicked="createOffer"
      />
    </template>
    <template v-slot:fourth-button>
      <FurnyButton type="border" text="Új" class="mb-1" @clicked="create" />
    </template>
  </FurnyTable>
</template>

<script>
import FurnyTable from "../../components/FurnyTable";
import FurnyButton from "../../components/FurnyButton";
import { get, remove } from "../../store/services/single-element";
import { excelExport } from "../../store/services/furnitures";

export default {
  name: "Furnitures",
  components: {
    FurnyTable,
    FurnyButton,
  },
  data: () => ({
    name: "furnitures",
    furnitures: [],
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
    async excelExport() {
      if (this.selected) await excelExport(1, this.userId, this.selected);
    },
    async createOffer() {
      if (this.selected)
        this.$router.push({
          path: "/create-offer",
          query: { fid: this.selected },
        });
    },
    create() {
      this.$router.push("/create-furniture");
    },
    async remove() {
      if (this.selected) {
        await remove(this.role, this.name, this.userId, this.selected);
        this.furnitures = await get(this.role, this.name, this.userId);
      }
    },
    edit(id) {
      this.$router.push({ path: "/create-furniture", query: { id: id } });
    },
    select(id) {
      this.selected = id;
    },
  },
  async beforeMount() {
    this.furnitures = await get(this.role, this.name, this.userId);
  },
};
</script>
