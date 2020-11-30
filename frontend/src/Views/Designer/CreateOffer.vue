<template>
  <div class="white-card">
    <vs-tabs class="w-100" position="left" :color="color">
      <vs-tab label="Árajánlat">
        <h3>{{ furniture.name }} - {{ state }}</h3>
      </vs-tab>
      <vs-tab
        class="container pl-4"
        v-for="(modul, index) in moduls"
        :key="index"
        :label="modul.name"
      >
        <FurnyOfferComponent
          :readonly="!(oid === undefined)"
          :panelCutters="panelCutters"
          :components="modul.components"
          :color="color"
        />
      </vs-tab>
      <vs-tab label="Komponensek" class="container pl-4">
        <FurnyOfferComponent
          :readonly="!(this.oid === undefined)"
          :panelCutters="panelCutters"
          :components="furniture.components"
          :color="color"
        />
      </vs-tab>
    </vs-tabs>
    <div class="mb-4" v-if="oid === undefined">
      <FurnyButton
        type="relief"
        text="Ajánlatot kérek"
        class="float-right"
        @clicked="createOffer"
      />
    </div>
    <div class="mb-4 mt-2" v-if="offer && offer.state == 4">
      <div>
        <h2 class="d-inline-block mr-2">Összeg:</h2>
        <h3 class="d-inline-block">{{ offer.price }} Ft</h3>
        <br />
        <h2 class="d-inline-block mr-2">Teljesítési határidő:</h2>
        <h3 class="d-inline-block">{{ deadline }}</h3>
        <br />
      </div>
      <div class="d-flex float-right">
        <vs-checkbox class="mr-3" :color="color" v-model="offer.delivery"
          >Kérek szállítást</vs-checkbox
        >
        <FurnyButton
          type="relief"
          text="Megrendelem"
          class="float-right mr-2"
          @clicked="acceptOrDeclineOffer(true)"
        />
        <FurnyButton
          type="relief"
          text="Nem rendelem meg"
          class="float-right"
          @clicked="acceptOrDeclineOffer(false)"
        />
      </div>
    </div>
  </div>
</template>

<script>
import { getById, get } from "../../store/services/single-element";
import { create, accept, decline } from "../../store/services/offers";
import FurnyOfferComponent from "../../components/offers/FurnyOfferComponent";
import FurnyButton from "../../components/FurnyButton";
import { formatDate } from "../../helpers/date-helper";
import { offerStateToString } from "../../helpers/enum-helpers";

const fillComponent = (offerComponent, component) => {
  component.panelCutterId = offerComponent.panelCutterId;
  component.materialId = offerComponent.materialId;
  component.closingId = offerComponent.closingId;
};

export default {
  name: "CreateOffer",
  components: {
    FurnyOfferComponent,
    FurnyButton,
  },
  data: () => ({
    oid: undefined,
    fid: undefined,
    moduls: [],
    panelCutters: [],
    furniture: {},
    offer: {
      delivery: false,
    },
  }),
  methods: {
    mapComponent(component) {
      return {
        designerId: this.userId,
        furnitureId: this.fid,
        componentId: component.id,
        panelCutterId: component.panelCutterId,
        materialId: component.materialId,
        closingId: component.closingId,
      };
    },
    async acceptOrDeclineOffer(accepted) {
      if (accepted) await accept(this.role, this.oid, this.offer);
      else await decline(this.role, this.oid);

      this.$router.push("/designer-offers");
      this.$vs.notify({
        title: "Siker!",
        text: "Sikeres rendelés!",
        color: "success",
      });
    },
    async createOffer() {
      this.offer.components = [];
      this.moduls.forEach((modul) => {
        modul.components.forEach((component) => {
          this.offer.components.push(this.mapComponent(component));
        });
      });
      this.furniture.components.forEach((component) => {
        this.offer.components.push(this.mapComponent(component));
      });
      await create(this.userId, this.fid, this.offer);
      this.$router.push("/designer-offers");
      this.$vs.notify({
        title: "Siker!",
        text: "Sikeres ajánlatkérés!",
        color: "success",
      });
    },
  },
  computed: {
    deadline() {
      return formatDate(this.offer.deadline);
    },
    userId() {
      return this.$store.state.user.id;
    },
    role() {
      return this.$store.state.role;
    },
    color() {
      return this.$store.state.inputColor;
    },
    state() {
      return offerStateToString(this.offer.state);
    },
  },
  async beforeMount() {
    this.oid = this.$route.query.oid;
    this.fid = this.$route.query.fid;
    if (this.fid) {
      this.furniture = await getById(
        this.role,
        "furnitures",
        this.userId,
        this.fid
      );
      await this.furniture.moduls.forEach(async (modulId) => {
        this.moduls.push(
          await getById(this.role, "modules", this.userId, modulId)
        );
      });

      this.panelCutters = await get(this.role, "favorites", this.userId);

      await this.panelCutters.forEach(async (panelcutter) => {
        panelcutter.materials = await get(
          "panelcutter",
          "materials",
          panelcutter.id
        );
        panelcutter.closings = await get(
          "panelcutter",
          "closings",
          panelcutter.id
        );
      });

      if (this.oid) {
        const furnitureOffers = await get(
          this.role,
          `furnitures/${this.fid}/offers`,
          this.userId
        );

        this.offer = furnitureOffers.find((f) => f.id === this.oid);

        this.moduls.forEach((modul) => {
          modul.components.forEach((component) => {
            const offerComponent = this.offer.components.find(
              (c) => c.componentId === component.id
            );
            if (offerComponent) fillComponent(offerComponent, component);
          });
        });

        this.furniture.components.forEach((component) => {
          const offerComponent = this.offer.components.find(
            (c) => c.componentId === component.id
          );
          if (offerComponent) fillComponent(offerComponent, component);
        });
      }
    } else throw new Error("Kell, hogy legyen bútor azonosító!");
  },
};
</script>

<style>
.con-slot-tabs {
  width: 100%;
}
.vs-select-primary ul {
  margin-bottom: 0 !important;
}
</style>
