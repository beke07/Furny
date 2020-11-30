<template>
  <div class="w-100">
    <div class="position-relative component-add">
      <FurnyNumberInput
        class="position-absolute component-add-input mag"
        label="Mag. (mm)"
        :inputData.sync="inputData.height"
      />
      <vs-checkbox
        class="position-absolute left-check"
        :color="color"
        v-model="inputData.closings.left"
      ></vs-checkbox>
      <FurnyNumberInput
        class="position-absolute component-add-input szel"
        label="Szél. (mm)"
        :inputData.sync="inputData.width"
      />
      <vs-checkbox
        class="position-absolute top-check"
        :color="color"
        v-model="inputData.closings.top"
      ></vs-checkbox>
      <img
        src="../assets/component.svg"
        height="250"
        width="250"
        class="pt-4 pb-4 position-absolute"
      />
      <vs-checkbox
        class="position-absolute right-check"
        :color="color"
        v-model="inputData.closings.right"
      ></vs-checkbox>
      <vs-checkbox
        class="position-absolute bottom-check"
        :color="color"
        v-model="inputData.closings.bottom"
      ></vs-checkbox>
    </div>
    <div class="float-right mt-4 w-25">
      <FurnyButton
        class="update-button w-100"
        type="relief"
        text="Hozzáad"
        @clicked="add"
      />
    </div>
  </div>
</template>

<script>
import FurnyNumberInput from "./FurnyNumberInput";
import FurnyButton from "./FurnyButton";

export default {
  name: "FurnyComponentCreate",
  components: {
    FurnyNumberInput,
    FurnyButton,
  },
  props: {
    inputData: {
      height: Number,
      width: Number,
      closings: {
        right: Boolean,
        left: Boolean,
        top: Boolean,
        bottom: Boolean,
      },
    },
  },
  computed: {
    color() {
      return this.$store.state.inputColor;
    },
  },
  methods: {
    add() {
      this.$emit("addComponent", this.inputData);
    },
  },
};
</script>

<style>
.component-add {
  min-height: 400px;
}
.component-add .vs-checkbox--check {
  display: flex;
  align-items: center;
  justify-content: center;
}
.component-add .checkbox_x {
  width: 45px;
  height: 45px;
}
.component-add img {
  padding: 0 !important;
  left: 340px;
  top: 100px;
}
.component-add-input {
  width: 200px;
  height: 45px;
}
.szel {
  left: 265px;
  top: 45px;
}
.mag {
  left: 85px;
  top: 197px;
}
.top-check {
  left: 477px;
  top: 50px;
}
.right-check {
  left: 580px;
  top: 202px;
}
.left-check {
  left: 295px;
  top: 202px;
}
.bottom-check {
  left: 477px;
  top: 355px;
}
</style>
