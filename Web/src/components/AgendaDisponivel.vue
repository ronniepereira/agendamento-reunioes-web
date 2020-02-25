<template>
  <section class="agenda">
    <h1>Salas Disponiveis</h1>
    <table>
      <thead>
        <tr>
          <th>Nome</th>
          <th>Disponibilidade</th>
        </tr>
      </thead>
      <tbody>
        <tr v-for="sala in salas" :key="sala.id">
          <td>{{ sala.nome }}</td>
          <td>{{ sala.reservado | reservado }}</td>
        </tr>
      </tbody>
    </table>
  </section>
</template>
<script>
import { api } from "../helpers/services";

export default {
  data() {
    return {
      salas: []
    };
  },
  methods: {
    getSalas() {
      api.get("salas").then(res => (this.salas = res.data));
    }
  },
  created() {
    this.getSalas();
  },
  filters: {
    reservado: function(value) {
      return value == true ? "Ocupada" : "Disponivel";
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

.agenda {
  display: flex;
  justify-content: center;
  flex-direction: column;

  margin: 30px 0;
  padding: 0 15px;
}

.agenda table {
  width: 100%;
  border-collapse: collapse;
  box-shadow: 0 2px 4px rgba(30, 60, 90, 0.1);
}

.agenda table th,
.agenda table td {
  padding: 15px;
  background-color: rgba(255, 255, 255, 0.2);
  border-bottom: 1px solid #ddd;
}

.agenda table thead {
  position: relative;
}

.agenda table thead tr {
  background: #336633;
}
.agenda table thead tr th {
  color: #fff;
  font-weight: bold;
  font-size: 18px;
  text-align: left;
}

.agenda table thead tr th.action-title {
  border-bottom: none;
}

.agenda table tbody tr td {
  font-size: 16px;
}

.agenda table tbody tr td button {
  padding: 5px 15px;
  background: #336633;
  border-radius: 4px;
  color: #fff;
  text-align: center;
  box-shadow: 0 4px 8px rgba(30, 60, 90, 0.1);
  cursor: pointer;
  border: none;
  margin-right: 5px;
}
</style>
