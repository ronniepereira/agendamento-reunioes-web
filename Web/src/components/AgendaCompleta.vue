<template>
  <section class="agenda">
    <h1>Agenda completa</h1>
    <table>
      <thead>
        <tr>
          <th>Titulo reunião</th>
          <th>Hora de inicio</th>
          <th>Hora de finalização</th>
          <th>Sala</th>
        </tr>
      </thead>
      <tbody>
        <tr v-for="agendamento in agendamentos" :key="agendamento.id">
          <td>{{ agendamento.titulo }}</td>
          <td>
            {{ agendamento.horaInicio | formatDate }}
          </td>
          <td>{{ agendamento.horaFim | formatDate }}</td>
          <td>{{ agendamento.sala }}</td>
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
      agendamentos: []
    };
  },
  methods: {
    getAgendamentos() {
      api.get("agendamentos").then(res => {
        this.agendamentos = res.data;
        console.log(res.data);
      });
    }
  },
  created() {
    this.getAgendamentos();
  },
  filters: {
    dateTime: function(value) {
      if (!value) return "";
      value = value.toString();
      return value.charAt(0).toUpperCase() + value.slice(1);
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
