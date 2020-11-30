<template>
  <FurnyTable
    title="Rendelések"
    :rows="orders"
    property="designerName"
    plusProperty="state"
    @selected="select"
    @edited="edit"
  >
    <template v-slot:first-button>
      <FurnyButton
        type="border"
        text="Elkészült"
        class="mb-1 mr-1"
        @clicked="done"
      /> </template
  ></FurnyTable>
</template>

<script>
import FurnyTable from "../../components/FurnyTable";
import FurnyButton from "../../components/FurnyButton";
import { get } from "../../store/services/single-element";
import { orderStateToString } from "../../helpers/enum-helpers";
import { done } from "../../store/services/orders";

export default {
  name: "PanelCutterOrders",
  components: {
    FurnyTable,
    FurnyButton,
  },
  data: () => ({
    name: "orders",
    orders: [],
    selected: undefined,
  }),
  methods: {
    select(id) {
      this.selected = id;
    },
    async done() {
      if (this.selected) {
        await done(this.selected);
        let order = this.orders.find((e) => e.id === this.selected);
        order.state = orderStateToString(1);
      }
    },
    edit(id) {
      const order = this.orders.find((e) => e.id === id);
      this.$router.push({
        path: "/accept-offer",
        query: { id: order.offerId },
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
