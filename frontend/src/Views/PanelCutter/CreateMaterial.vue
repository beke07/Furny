<template>
  <div class="white-card">
    <div class="row">
      <div class="col-8">
        <h3>{{ material.name }}</h3>
        <FurnyRequiredInput
          class="mt-4 w-100"
          label-placeholder="Név"
          :inputData.sync="material.name"
        />
        <div class="row p-3">
          <FurnyNumberInput
            class="ml-0 mr-0 w-50 pr-1"
            style="height: 36px;"
            label="Ár (Ft)"
            :inputData.sync="material.price"
          />
          <vs-select v-model="material.type" class="w-50 mt-1 pl-1">
            <vs-select-item text="Tábla" value="1" />
            <vs-select-item text="M²" value="2" />
          </vs-select>
        </div>
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
import FurnyNumberInput from "../../components/FurnyNumberInput";
import FurnyRequiredInput from "../../components/FurnyRequiredInput";
import FurnyButton from "../../components/FurnyButton";
import { getById, create, update } from "../../store/services/single-element";
import MaterialDto from "../../dtos/MaterialDto";
import * as jsonpatch from "fast-json-patch";

export default {
  name: "CreateMaterial",
  components: {
    FurnyRequiredInput,
    FurnyButton,
    FurnyNumberInput,
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
    name: "materials",
    mid: undefined,
    observer: undefined,
    material: new MaterialDto({ name: "Új alapanyag", type: 1 }),
  }),
  methods: {
    async createOrUpdate() {
      if (this.mid) await this.update();
      else await this.create();
      this.$router.push("materials");
    },
    async create() {
      await create(this.role, this.name, this.userId, this.material);
    },
    async update() {
      const patches = jsonpatch.generate(this.observer);
      await update(this.role, this.name, this.userId, this.mid, patches);
    },
  },
  async beforeMount() {
    this.mid = this.$route.query.id;
    if (this.mid) {
      this.material = await getById(
        this.role,
        this.name,
        this.userId,
        this.mid
      );
      this.observer = jsonpatch.observe(this.material);
    }
  },
};
</script>

<style>
.vs-select-primary ul {
  margin-bottom: 0 !important;
}
</style>
