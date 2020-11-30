<template>
  <div class="container auth-container">
    <form class="row" @keyup.enter="registration">
      <div class="col form registration-input-form">
        <h1>Regisztráció</h1>
        <FurnyRequiredInput
          type="text"
          class="registration-input"
          label-placeholder="Név"
          :inputData.sync="user.name"
        />
        <FurnyEmailInput
          class="registration-input"
          label-placeholder="E-mail cím"
          :inputData.sync="user.email"
        />
        <FurnyRequiredInput
          type="password"
          class="registration-input"
          label-placeholder="Jelszó"
          :inputData.sync="user.password"
        />
        <FurnyRequiredInput
          type="password"
          class="registration-input"
          label-placeholder="Jelszó mégegyszer"
          :inputData.sync="user.passwordAgain"
        />
      </div>
      <div class="col form registration-form">
        <img src="../../assets/logo.png" height="55" />
        <FurnyRequiredInput
          type="text"
          class="registration-input"
          label-placeholder="Telefon"
          :inputData.sync="user.phone"
        />
        <FurnyAddressSelect
          :value.sync="user.userAddress.address.id"
          label="Cím"
          inputLabel="city"
          inputTrackBy="id"
        />
        <FurnyRequiredInput
          type="text"
          class="registration-input"
          label-placeholder="Utca, házszám"
          :inputData.sync="user.userAddress.streetAndHouse"
        />

        <FurnyButton
          class="registration-button"
          type="relief"
          text="Regisztrálok"
          @clicked="registration"
        />
      </div>
    </form>
  </div>
</template>

<script>
import FurnyButton from "../../components/FurnyButton";
import FurnyRequiredInput from "../../components/FurnyRequiredInput";
import FurnyEmailInput from "../../components/FurnyEmailInput";
import FurnyAddressSelect from "../../components/FurnyAddressSelect";
import { registerDesigner } from "../../store/services/registration";

export default {
  name: "DesignerRegistration",
  components: {
    FurnyButton,
    FurnyRequiredInput,
    FurnyEmailInput,
    FurnyAddressSelect,
  },
  data: () => ({
    user: { userAddress: { address: { id: null } } },
  }),
  methods: {
    async registration() {
      await registerDesigner(this.user);
      this.$store.commit("setNewRegistrated", true);
      this.$router.push("/login");
    },
  },
};
</script>

<style scoped>
.registration-input {
  width: 80%;
  margin-top: 25px;
}
.registration-input-form {
  display: flex;
  flex-direction: column;
  align-items: center;
}
.registration-button {
  margin-top: 30px;
  width: 60%;
}
.registration-form {
  display: flex;
  justify-content: center;
  align-items: center;
  flex-direction: column;
}
</style>
