<template>
  <div class="white-card">
    <h3>{{ furniture.name }}</h3>
    <div class="container-fluid ml-0 mt-3">
      <form class="row" @keyup.enter="create">
        <div class="col-8 form update-input-form">
          <FurnyRequiredInput
            class="update-input"
            label-placeholder="Bútor neve"
            :inputData.sync="furniture.name"
          />

          <FurnyModulSelect
            @select="select"
            label="Modul"
            inputLabel="name"
            inputTrackBy="id"
          />

          <FurnyRequiredInput
            class="update-input"
            label-placeholder="Komponens neve"
            :inputData.sync="comp.name"
          />

          <FurnyComponentCreate
            :inputData.sync="comp"
            @addComponent="addComponent"
          />
        </div>
        <div class="col-4 pl-5 update-input-form">
          <vs-collapse
            accordion
            class="white-card mb-3"
            v-if="moduls.length > 0"
          >
            <div v-for="(modul, index) in moduls" :key="index">
              <vs-collapse-item>
                <div slot="header">
                  <vs-button
                    class="remove-modul-button"
                    color="danger"
                    type="border"
                    icon="clear"
                    @click="removeModul(index)"
                  ></vs-button>
                  <h5>{{ modul.name }}</h5>
                </div>
                <div
                  v-for="(component, compIndex) in modul.components"
                  :key="compIndex"
                >
                  <h6>
                    {{ component.name }}: {{ component.width }}mm*{{
                      component.height
                    }}mm
                  </h6>
                </div>
              </vs-collapse-item>
            </div>
          </vs-collapse>

          <div v-for="(component, index) in furniture.components" :key="index">
            <FurnyComponentData
              :index="index"
              :name="component.name"
              :height="component.height"
              :width="component.width"
              @removeComponent="removeComponent"
            >
              <template v-slot:first-button>
                <vs-button
                  class="mr-1 button"
                  :color="color"
                  type="border"
                  icon="content_copy"
                  @click="copyComponent(index)"
                ></vs-button>
              </template>
              <template v-slot:second-button>
                <vs-button
                  class="button"
                  color="danger"
                  type="border"
                  icon="clear"
                  @click="removeComponent(index)"
                ></vs-button>
              </template>
            </FurnyComponentData>
          </div>

          <FurnyButton
            v-if="
              furniture.components.length > 0 || furniture.moduls.length > 0
            "
            class="update-button float-right"
            type="relief"
            text="Mentés"
            @clicked="createOrUpdate"
          />
        </div>
      </form>
    </div>
  </div>
</template>

<script>
import FurnyButton from "../../components/FurnyButton";
import FurnyComponentCreate from "../../components/FurnyComponentCreate";
import FurnyRequiredInput from "../../components/FurnyRequiredInput";
import FurnyModulSelect from "../../components/FurnyModulSelect";
import FurnyComponentData from "../../components/FurnyComponentData";
import { removeElement } from "../../helpers/array-helper";
import { update, create, getById } from "../../store/services/single-element";
import * as jsonpatch from "fast-json-patch";
import { initComp } from "../../helpers/component-helper";

export default {
  name: "CreateModul",
  components: {
    FurnyButton,
    FurnyRequiredInput,
    FurnyComponentCreate,
    FurnyComponentData,
    FurnyModulSelect,
  },
  data: () => ({
    name: "furnitures",
    fid: undefined,
    observer: undefined,
    furniture: {
      name: "Új bútor",
      moduls: [],
      components: [],
    },
    moduls: [],
    selectedModulId: "",
    comp: initComp(),
  }),
  computed: {
    color() {
      return this.$store.state.inputColor;
    },
    userId() {
      return this.$store.state.user.id;
    },
    role() {
      return this.$store.state.role;
    },
  },
  methods: {
    async createOrUpdate() {
      if (this.fid) await this.update();
      else await this.create();
      this.$router.push("furnitures");
    },
    async create() {
      await create(this.role, this.name, this.userId, this.furniture);
    },
    async update() {
      const patches = jsonpatch.generate(this.observer);
      await update(this.role, this.name, this.userId, this.fid, patches);
    },
    async select(id) {
      const modul = await getById(this.role, "modules", this.userId, id);
      this.moduls.push(modul);
      this.furniture.moduls.push(id);
    },
    removeModul(index) {
      removeElement(this.furniture.moduls, index);
      removeElement(this.moduls, index);
    },
    addComponent() {
      if (this.comp.name && this.comp.width && this.comp.height) {
        this.furniture.components.push(this.comp);
        this.comp = initComp();
      } else throw new Error("Tölts ki az adatok előbb!");
    },
    copyComponent(index) {
      const component = this.furniture.components[index];
      this.furniture.components.push(component);
    },
    removeComponent(index) {
      removeElement(this.furniture.components, index);
    },
  },
  async beforeMount() {
    this.fid = this.$route.query.id;
    if (this.fid) {
      this.furniture = await getById(
        this.role,
        this.name,
        this.userId,
        this.fid
      );
      this.observer = jsonpatch.observe(this.furniture);
      this.furniture.moduls.forEach(async (modulId) => {
        const modul = await getById(this.role, "modules", this.userId, modulId);
        this.moduls.push(modul);
      });
    }
  },
};
</script>

<style scoped>
.update-input {
  width: 100%;
  margin-top: 25px;
}
.update-input-form {
  display: flex;
  flex-direction: column;
}
.update-button-form {
  display: flex;
  flex-direction: row;
  justify-content: flex-end;
}
.update-button {
  margin-top: 30px;
  align-self: flex-end;
  width: 30%;
}
.remove-modul-button {
  width: 20px !important;
  height: 20px !important;
  margin-right: 5px;
}
.w-70 {
  width: 70%;
}
</style>
