<template>
  <FurnyTable
    title="Moduljaim"
    :rows="moduls"
    property="name"
    @created="create"
    @removed="remove"
    @edited="edit"
  />
</template>

<script>
import FurnyTable from "../../components/FurnyTable";

export default {
  name: "Moduls",
  components: {
    FurnyTable,
  },
  data: () => ({
    moduls: [
      {
        id: "1",
        name: "modul",
      },
    ],
  }),
  methods: {
    create() {
      this.$router.push("/create-modul");
    },
    remove(id) {
      console.log("REMOVE", id);
    },
    edit(id) {
      console.log("EDIT", id);
    },
  },
};
</script>
