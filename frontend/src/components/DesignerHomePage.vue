<template>
  <div class="container">
    <div v-for="(ad, index) in ads" :key="index" class="white-card mb-3 pl-4">
      <div class="row">
        <div class="col-1">
          <vs-avatar
            size="70px"
            :src="
              ad.panelCutterImageId ? `${env}/${ad.panelCutterImageId}` : null
            "
          />
        </div>
        <div class="col-11 pl-4">
          <h4>{{ ad.panelCutterUserName }}</h4>
          <small>{{ ad.hourAgo }}</small>
        </div>
      </div>
      <div class="row pl-2 pr-3">
        <div class="col-12 p-2 border">
          <h6 class="mb-2">{{ ad.title }}</h6>
          <p class="mb-1 mt-1 mb-3">{{ ad.text }}</p>
          <div v-if="ad.imageId" class="col d-flex justify-content-center">
            <img width="400" :src="`${env}/${ad.imageId}`" />
          </div>
        </div>
      </div>
      <div class="row mt-2 pr-3 rate">
        <div class="col-12 d-flex justify-content-end">
          <vs-button
            v-if="!favorites.includes(ad.panelCutterId)"
            color="warning"
            type="border"
            icon="star_border"
            @click="favorite(ad.panelCutterId)"
          ></vs-button>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
import { create, get } from "../store/services/single-element";
import { getHomePage } from "../store/services/designer";

export default {
  name: "DesignerHomePage",
  computed: {
    userId() {
      return this.$store.state.user.id;
    },
    role() {
      return this.$store.state.role;
    },
    env() {
      return `${process.env.VUE_APP_API_ENDPOINT}/file`;
    },
  },
  methods: {
    async favorite(panelCutterId) {
      await create(this.role, `favorites/${panelCutterId}`, this.userId);
      this.favorites.push(panelCutterId);
    },
  },
  data: () => ({
    ads: [],
    favorites: [],
  }),
  async beforeMount() {
    this.favorites = (await get(this.role, "favorites", this.userId)).map(
      (f) => f.id
    );
    this.ads = (await getHomePage(this.userId)).ads;
  },
};
</script>
<style>
.rate .vs-icon {
  font-size: 30px;
}
</style>
