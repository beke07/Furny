<template>
  <div class="container auth-container">
    <div class="row">
      <div class="col">
        <h1>Sajnáljuk, a kért oldal nem található.</h1>
        <img src="../assets/logo.png" width="100" />
      </div>
    </div>
  </div>
</template>

<script>
export default {
  name: "NotFound",
};
</script>

<style scoped>
.col > img {
  margin-top: 30px;
}
.col {
  display: flex;
  flex-direction: column;
  align-items: center;
}
</style>
