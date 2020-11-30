<template>
  <div class="white-card">
    <h3>{{ modul.name }}</h3>
    <div class="container-fluid mt-3">
      <form class="row" @keyup.enter="create">
        <div class="col-8 form update-input-form">
          <FurnyRequiredInput
            class="update-input"
            label-placeholder="Modul neve"
            :inputData.sync="modul.name"
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
          <div v-for="(component, index) in modul.components" :key="index">
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
            v-if="modul.components.length > 0"
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
import FurnyComponentData from "../../components/FurnyComponentData";
import { removeElement } from "../../helpers/array-helper";
import { initComp } from "../../helpers/component-helper";
import { getById, update, create } from "../../store/services/single-element";
import * as jsonpatch from "fast-json-patch";

export default {
  name: "CreateModul",
  components: {
    FurnyButton,
    FurnyRequiredInput,
    FurnyComponentCreate,
    FurnyComponentData,
  },
  data: () => ({
    name: "modules",
    mid: undefined,
    observer: undefined,
    modul: {
      name: "Új modul",
      components: [],
    },
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
      if (this.mid) await this.update();
      else await this.create();
      this.$router.push("moduls");
    },
    async create() {
      await create(this.role, this.name, this.userId, this.modul);
    },
    async update() {
      const patches = jsonpatch.generate(this.observer);
      await update(this.role, this.name, this.userId, this.mid, patches);
    },
    addComponent() {
      if (this.comp.name && this.comp.width && this.comp.height) {
        this.modul.components.push({ ...this.comp });
        this.comp = initComp();
      } else throw new Error("Tölts ki az adatok előbb!");
    },
    copyComponent(index) {
      const component = this.modul.components[index];
      this.modul.components.push({ ...component });
    },
    removeComponent(index) {
      removeElement(this.modul.components, index);
    },
  },
  async beforeMount() {
    this.mid = this.$route.query.id;
    if (this.mid) {
      this.modul = await getById(this.role, this.name, this.userId, this.mid);
      this.observer = jsonpatch.observe(this.modul);
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
</style>
