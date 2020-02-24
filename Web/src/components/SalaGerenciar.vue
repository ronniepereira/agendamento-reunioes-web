<template>
  <section class="sala">
    <h1>Gerenciar salas</h1>
    <table>
      <thead>
        <tr>
          <th>Nome</th>
          <th>Ações</th>
        </tr>
      </thead>
      <tbody>
        <tr v-for="sala in salas" :key="sala.id">
          <td class="sala-nome">{{ sala.nome }}</td>
          <td class="action-body">
            <button class="btn" @click.prevent="deleteSala(sala.id)">
              Remover
            </button>
          </td>
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
      api.get("salas").then(res => {
        this.salas = res.data;
      });
    },
    deleteSala(id) {
      api.delete(`salas/${id}`).then(() => {
        this.getSalas();
      });
    }
  },
  created() {
    this.getSalas();
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
  justify-content: center;
  flex-direction: column;

  margin: 30px 0;
  padding: 0 15px;
}

.sala table {
  width: 100%;
  border-collapse: collapse;
  box-shadow: 0 2px 4px rgba(30, 60, 90, 0.1);
}

.sala table th,
.sala table td {
  padding: 15px;
  background-color: rgba(255, 255, 255, 0.2);
  border-bottom: 1px solid #ddd;
}

.sala table thead {
  position: relative;
}

.sala table thead tr {
  background: #336633;
}
.sala table thead tr th {
  color: #fff;
  font-weight: bold;
  font-size: 18px;
  text-align: left;
}

.sala table thead tr th.action-title {
  border-bottom: none;
}

.sala table tbody tr td {
  font-size: 16px;
}

.sala table tbody tr td button {
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
