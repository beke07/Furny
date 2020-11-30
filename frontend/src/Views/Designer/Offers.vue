<template>
  <FurnyTable
    title="Árajánlatok"
    :rows="offers"
    property="furnitureName"
    plusProperty="state"
    @edited="edit"
  />
</template>

<script>
import FurnyTable from "../../components/FurnyTable";
import { get } from "../../store/services/single-element";
import { offerStateToString } from "../../helpers/enum-helpers";

export default {
  name: "Offers",
  components: {
    FurnyTable,
  },
  data: () => ({
    name: "offers",
    offers: [],
  }),
  methods: {
    edit(id) {
      const offer = this.offers.find((o) => o.id === id);
      this.$router.push({
        path: "/create-offer",
        query: { oid: id, fid: offer.furnitureId },
      });
    },
  },
  computed: {
    userId() {
      return this.$store.state.user.id;
    },
    role() {
      return this.$store.state.role;
    },
  },
  async beforeMount() {
    this.offers = await get(this.role, this.name, this.userId);

    this.offers.forEach((offer) => {
      offer.state = offerStateToString(offer.state);
    });
  },
};
</script>
