<template>
  <div class="white-card">
    <div class="row">
      <div class="col-8">
        <h3>{{ ad.title }}</h3>
        <FurnyRequiredInput
          class="mt-4 w-100"
          label-placeholder="Cím"
          :inputData.sync="ad.title"
        />
        <FurnyTextArea
          class="w-100 mt-3"
          label-placeholder="Szöveg"
          :inputData.sync="ad.text"
        />
        <vs-upload
          automatic
          text="Kép feltötése"
          :action="uploadPath"
          fileName="file"
          @on-success="successUpload"
        />
        <FurnyButton
          type="relief"
          class="float-right"
          text="Mentés"
          @clicked="createOrUpdate"
        />
      </div>
      <div class="col-4">
        <div class="w-100 pl-5" v-if="aid && ad.imageId">
          <h6 class="mb-2">Kép</h6>
          <img class="border p-2" width="300" :src="downloadPath" />
        </div>
      </div>
    </div>
  </div>
</template>

<script>
import FurnyRequiredInput from "../../components/FurnyRequiredInput";
import FurnyButton from "../../components/FurnyButton";
import FurnyTextArea from "../../components/FurnyTextArea";
import AdDto from "../../dtos/AdDto";
import { getById, create, update } from "../../store/services/single-element";
import * as jsonpatch from "fast-json-patch";

export default {
  name: "CreateAd",
  components: {
    FurnyRequiredInput,
    FurnyTextArea,
    FurnyButton,
  },
  computed: {
    downloadPath() {
      return `${process.env.VUE_APP_API_ENDPOINT}/file/${this.ad.imageId}`;
    },
    uploadPath() {
      return `${process.env.VUE_APP_API_ENDPOINT}/file`;
    },
    userId() {
      return this.$store.state.user.id;
    },
    role() {
      return this.$store.state.role;
    },
  },
  data: () => ({
    name: "ads",
    aid: undefined,
    observer: undefined,
    ad: new AdDto({ title: "Új hirdetés" }),
  }),
  methods: {
    successUpload(event) {
      this.ad.imageId = event.target.response;
    },
    async createOrUpdate() {
      if (this.aid) await this.update();
      else await this.create();
      this.$router.push("ads");
    },
    async create() {
      await create(this.role, this.name, this.userId, this.ad);
    },
    async update() {
      const patches = jsonpatch.generate(this.observer);
      await update(this.role, this.name, this.userId, this.aid, patches);
    },
  },
  async beforeMount() {
    this.aid = this.$route.query.id;
    if (this.aid) {
      this.ad = await getById(this.role, this.name, this.userId, this.aid);
      this.observer = jsonpatch.observe(this.ad);
    }
  },
};
</script>

<style scoped>
.vs-con-textarea,
.border {
  border-radius: 2px;
  border: 1px solid rgba(0, 0, 0, 0.2);
}
</style>
