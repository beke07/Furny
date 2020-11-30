<template>
  <div class="white-card">
    <h1>Ajánlat</h1>

    <table class="w-75">
      <tr>
        <th class="pl-0"><h4>Komponens mérete</h4></th>
        <th class="pl-0"><h4>Anyaga</h4></th>
        <th class="pl-0"><h4>Élzárása</h4></th>
      </tr>
      <tr v-for="(component, index) in components" :key="index">
        <td>
          <h6>
            {{ component.componentHeight }}*{{ component.componentWidth }}
          </h6>
        </td>
        <td>
          <h6>{{ component.materialName }}</h6>
        </td>
        <td>
          <h6>{{ component.closingName }}</h6>
        </td>
      </tr>
    </table>

    <h2 class="mb-2 mt-3">Alapanyagok</h2>
    <h4
      class="d-block"
      v-for="(key, index) in Object.keys(materialQuantaties)"
      :key="key"
    >
      {{ key }}: {{ Object.values(materialQuantaties)[index] }}
    </h4>

    <h2 class="mb-2 mt-3">Élzárások</h2>
    <h4
      class="d-block"
      v-for="(closingKey, index) in Object.keys(closingQuantaties)"
      :key="closingKey"
    >
      {{ closingKey }}: {{ Object.values(closingQuantaties)[index] }}
    </h4>

    <FurnyNumberInput
      :disabled="state !== 1"
      class="ml-0 mt-4 w-50"
      style="height: 36px;"
      label="Összeg (Ft)"
      :inputData.sync="offer.price"
    />
    <FurnyRequiredInput
      :disabled="state !== 1"
      class="mt-4 w-50"
      type="date"
      label-placeholder="Teljesítés dátuma"
      :inputData.sync="offer.deadline"
    />
    <div class="mb-4">
      <FurnyButton
        v-if="state === 1"
        type="relief"
        text="Mentés"
        class="float-right"
        @clicked="create"
      />
      <h3 v-if="state === 3" class="float-right text-danger">
        A megrendelő elutasította az árajánlatot
      </h3>
      <h3 v-if="state === 2" class="float-right text-success">
        A megrendelő elfogadta az árajánlatot
      </h3>
    </div>
  </div>
</template>

<script>
import { getById } from "../../store/services/single-element";
import { fillOffer } from "../../store/services/offers";
import FurnyRequiredInput from "../../components/FurnyRequiredInput";
import FurnyNumberInput from "../../components/FurnyNumberInput";
import FurnyButton from "../../components/FurnyButton";

export default {
  name: "AcceptOffer",
  components: {
    FurnyNumberInput,
    FurnyRequiredInput,
    FurnyButton,
  },
  data: () => ({
    name: "offers",
    offer: {},
    materialQuantaties: [],
    closingQuantaties: [],
    components: [],
    materials: [],
    state: 0,
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
    async create() {
      await fillOffer(
        this.role,
        this.name,
        this.userId,
        {
          price: this.offer.price,
          deadline: this.offer.deadline,
        },
        this.$route.query.id
      );

      this.$router.push("/home");
    },
  },
  async beforeMount() {
    this.offer = await getById(
      this.role,
      this.name,
      this.userId,
      this.$route.query.id
    );

    this.state = this.offer.offer.state;

    this.materialQuantaties = JSON.parse(
      JSON.stringify(this.offer.materialQuantity)
    );
    this.closingQuantaties = JSON.parse(
      JSON.stringify(this.offer.closingQuantity)
    );

    this.offer.price = this.offer.countedPrice;
    this.offer.deadline = "2020-12-01";

    this.components = this.offer.offer.components;
  },
};
</script>
