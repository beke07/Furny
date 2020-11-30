<template>
  <FurnyTable
    title="Hirdetéseim"
    :rows="ads"
    property="title"
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
  name: "Ads",
  components: {
    FurnyTable,
    FurnyButton,
  },
  data: () => ({
    name: "ads",
    ads: [],
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
      this.$router.push("/create-ad");
    },
    async remove() {
      if (this.selected) {
        await remove(this.role, this.name, this.userId, this.selected);
        this.ads = await get(this.role, this.name, this.userId);
      }
    },
    edit(id) {
      this.$router.push({ path: "/create-ad", query: { id: id } });
    },
    select(id) {
      this.selected = id;
    },
  },
  async beforeMount() {
    this.ads = await get(this.role, this.name, this.userId);
  },
};
</script>
