<template>
  <div class="container-fluid mt-3">
    <form class="row" @keyup.enter="update">
      <div class="col form update-input-form">
        <FurnyEmailInput
          class="update-input"
          :disabled="true"
          label-placeholder="E-mail cím"
          :inputData.sync="email"
        />
        <FurnyRequiredInput
          class="update-input"
          type="text"
          label-placeholder="Név"
          :inputData.sync="user.name"
        />
        <FurnyAddressSelect
          :value.sync="user.addressId"
          :selectedId="user.addressId"
          label="Cím"
          inputLabel="city"
          inputTrackBy="id"
        />
        <FurnyRequiredInput
          type="text"
          label-placeholder="Telefon"
          class="update-input"
          :inputData.sync="user.phone"
        />
        <FurnyRequiredInput
          type="text"
          label-placeholder="Utca, házszám"
          class="update-input"
          :inputData.sync="user.streetAndHouse"
        />
        <FurnyRequiredInput
          v-if="roleIsPanelCutter"
          type="text"
          label-placeholder="Nyitvatartás"
          class="update-input"
          :inputData.sync="user.opened"
        />
        <FurnyRequiredInput
          v-if="roleIsPanelCutter"
          type="text"
          label-placeholder="Facebook"
          class="update-input"
          :inputData.sync="user.facebook"
        />
        <FurnyRequiredInput
          v-if="roleIsPanelCutter"
          type="text"
          label-placeholder="Extrák"
          class="update-input"
          :inputData.sync="extras"
        />
      </div>
      <div class="col update-button-form">
        <vs-upload
          automatic
          text="Profilkép feltötése"
          :action="uploadPath"
          fileName="file"
          @on-success="successUpload"
        />
        <FurnyButton
          class="update-button"
          type="relief"
          text="Mentés"
          @clicked="update"
        />
      </div>
    </form>
  </div>
</template>

<script>
import FurnyButton from "../FurnyButton";
import FurnyRequiredInput from "../FurnyRequiredInput";
import FurnyAddressSelect from "../FurnyAddressSelect";
import FurnyEmailInput from "../FurnyEmailInput";
import UserDesignerProfilDto from "../../dtos/UserDesignerProfilDto";
import UserPanelCutterProfilDto from "../../dtos/UserPanelCutterProfilDto";
import * as jsonpatch from "fast-json-patch";
import { CSVToArray } from "../../helpers/csv-helper";

export default {
  name: "FurnyProfil",
  props: {
    role: String,
  },
  components: {
    FurnyButton,
    FurnyRequiredInput,
    FurnyEmailInput,
    FurnyAddressSelect,
  },
  data: () => ({
    email: "",
    observer: undefined,
    extras: "",
    storedUser: undefined,
  }),
  computed: {
    roleIsPanelCutter() {
      return this.role === "PanelCutter";
    },
    user() {
      return this.roleIsPanelCutter
        ? new UserPanelCutterProfilDto(this.storedUser)
        : new UserDesignerProfilDto(this.storedUser);
    },
    uploadPath() {
      return `${process.env.VUE_APP_API_ENDPOINT}/file`;
    },
  },
  async beforeMount() {
    this.storedUser = this.$store.state.user;
    this.email = this.storedUser.email;
    this.extras = this.roleIsPanelCutter
      ? this.storedUser.extras.join(",")
      : "";
    this.observer = jsonpatch.observe(this.user);
  },
  methods: {
    successUpload(event) {
      this.user.imageId = event.target.response;
    },
    async update() {
      if (this.roleIsPanelCutter) {
        this.user.extras = CSVToArray(this.extras)[0];
      }
      const patches = jsonpatch.generate(this.observer);
      await this.$store.dispatch("updateProfile", {
        role: this.role,
        id: this.storedUser.id,
        patch: patches,
      });

      location.reload();
      this.$vs.notify({
        color: "success",
        title: "Siker",
        text: "Profil sikeresen elmentve!",
      });
    },
  },
};
</script>

<style scoped>
.update-input {
  width: 80%;
  margin-top: 25px;
}
.update-input-form {
  display: flex;
  flex-direction: column;
  justify-content: flex-start;
  align-items: flex-start;
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
