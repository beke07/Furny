<template>
  <FurnyTable
    title="Árajánlatok"
    :rows="offers"
    property="designerName"
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
      this.$router.push({
        path: "/accept-offer",
        query: { id: id },
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
