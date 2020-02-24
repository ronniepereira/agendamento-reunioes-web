<template>
  <section>
    <h1>Criar sala de reunião</h1>
    <form class="sala">
      <label for="nome">Nome</label>
      <input id="nome" name="nome" type="text" v-model="sala.nome" required />
      <button @click.prevent="createSala()" class="btn">Salvar</button>
    </form>
  </section>
</template>
<script>
import { api } from "../helpers/services";

export default {
  data() {
    return {
      sala: {
        nome: ""
      }
    };
  },
  methods: {
    createSala() {
      console.log(this.sala);
      api.post("salas", this.sala).then(() => {
        this.$router.push({ name: "sala.gerenciar" });
      });
    }
  }
};
</script>
<style scoped>
h1 {
  text-align: center;
  font-size: 2rem;
  color: #336633;
  margin-bottom: 15px;
}

.sala {
  display: flex;
  flex-direction: column;
  align-items: center;
  justify-content: center;
  max-width: 500px;
  margin: 0 auto;
}

.sala label,
.sala input,
.sala select {
  margin-bottom: 15px;
  width: 100%;
}

.button {
  margin-top: 10px;
}
</style>
