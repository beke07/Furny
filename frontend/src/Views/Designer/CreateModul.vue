<template>
  <div class="white-card ">
    <h3>{{ modulName }}</h3>
    <div class="container-fluid mt-3">
      <form class="row" @keyup.enter="create">
        <div class="col form update-input-form">
          <FurnyRequiredInput
            class="update-input"
            label-placeholder="Modul neve"
            :inputData.sync="modulName"
          />
          <FurnyRequiredInput
            class="update-input"
            label-placeholder="Komponens neve"
            :inputData.sync="componentName"
          />
          <FurnyButton
            class="update-button"
            type="relief"
            text="Hozzáad"
            @clicked="add"
          />
        </div>
        <div class="col update-button-form">
          <FurnyButton
            class="update-button"
            type="relief"
            text="Mentés"
            @clicked="create"
          />
        </div>
      </form>
    </div>
  </div>
</template>

<script>
import FurnyButton from "../../components/FurnyButton";
import FurnyRequiredInput from "../../components/FurnyRequiredInput";

export default {
  name: "CreateModul",
  components: {
    FurnyButton,
    FurnyRequiredInput,
  },
  data: () => ({
    modulName: "Új modul",
    componentName: "",
  }),
  methods: {
    create() {
      console.log("create");
    },
    add() {
      console.log("add");
    },
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
