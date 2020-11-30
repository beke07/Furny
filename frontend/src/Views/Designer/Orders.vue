<template>
  <FurnyTable
    title="Rendelések"
    :rows="orders"
    property="name"
    plusProperty="state"
    @edited="edit"
  />
</template>

<script>
import FurnyTable from "../../components/FurnyTable";
import { get } from "../../store/services/single-element";
import { orderStateToString } from "../../helpers/enum-helpers";

export default {
  name: "DesignerOrders",
  components: {
    FurnyTable,
  },
  data: () => ({
    name: "orders",
    orders: [],
  }),
  methods: {
    edit(id) {
      const order = this.orders.find((o) => o.id === id);
      this.$router.push({
        path: "/create-offer",
        query: { oid: order.offerId, fid: order.furnitureId },
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
    this.orders = await get(this.role, this.name, this.userId);

    this.orders.forEach((order) => {
      order.state = orderStateToString(order.state);
    });
  },
};
</script>
