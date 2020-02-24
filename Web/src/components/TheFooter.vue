<template>
  <footer>
    <p>@ {{ ano_atual }} - Todos direitos reservados.</p>
  </footer>
</template>

<script>
export default {
  data() {
    return {
      ano_atual: null
    };
  },
  created() {
    var data_atual = new Date();
    var ano_atual = data_atual.getFullYear();
    this.ano_atual = ano_atual;
  }
};
</script>

<style>
footer {
  background: #336633;
  padding: 10px 0;
  text-align: center;
  font-size: 12px;
  color: #fff;

  position: relative;
  bottom: 0;
  width: 100%;
}
</style>
