<template>
  <div class="white-card">
    <div class="row">
      <div class="col-8">
        <h3>{{ closing.name }}</h3>
        <FurnyRequiredInput
          class="mt-4 w-100"
          label-placeholder="Név"
          :inputData.sync="closing.name"
        />
        <FurnyNumberInput
          class="ml-0 mr-0 w-100 mt-2"
          style="height: 36px;"
          label="Ár (Ft/m)"
          :inputData.sync="closing.price"
        />
        <FurnyButton
          type="relief"
          class="float-right mt-3"
          text="Mentés"
          @clicked="createOrUpdate"
        />
      </div>
      <div class="col"></div>
    </div>
  </div>
</template>

<script>
import FurnyRequiredInput from "../../components/FurnyRequiredInput";
import FurnyNumberInput from "../../components/FurnyNumberInput";
import FurnyButton from "../../components/FurnyButton";
import { getById, create, update } from "../../store/services/single-element";
import * as jsonpatch from "fast-json-patch";

export default {
  name: "CreateClosing",
  components: {
    FurnyRequiredInput,
    FurnyNumberInput,
    FurnyButton,
  },
  computed: {
    userId() {
      return this.$store.state.user.id;
    },
    role() {
      return this.$store.state.role;
    },
  },
  data: () => ({
    name: "closings",
    cid: undefined,
    observer: undefined,
    closing: { name: "Új élzárás", price: 0 },
  }),
  methods: {
    async createOrUpdate() {
      if (this.cid) await this.update();
      else await this.create();
      this.$router.push("closings");
    },
    async create() {
      await create(this.role, this.name, this.userId, this.closing);
    },
    async update() {
      const patches = jsonpatch.generate(this.observer);
      await update(this.role, this.name, this.userId, this.cid, patches);
    },
  },
  async beforeMount() {
    this.cid = this.$route.query.id;
    if (this.cid) {
      this.closing = await getById(this.role, this.name, this.userId, this.cid);
      this.observer = jsonpatch.observe(this.closing);
    }
  },
};
</script>
