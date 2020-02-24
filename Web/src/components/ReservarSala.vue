<template>
  <section>
    <h1>Reservar sala para reunião</h1>
    <div v-if="error" class="error">
      <p>{{ error }}</p>
    </div>
    <form class="reserva">
      <label for="titulo">Titulo reunião</label>
      <input
        id="titulo"
        name="titulo"
        type="text"
        v-model="agendamento.titulo"
        required
      />
      <div class="horario">
        <div class="hora">
          <label for="horainicio">Hora de inicio</label>
          <datetime v-model="agendamento.horaInicio" type="datetime"></datetime>
        </div>
        <div class="hora">
          <label for="horafim">Hora Fim</label>
          <datetime v-model="agendamento.horaFim" type="datetime"></datetime>
        </div>
      </div>

      <label for="sala">Sala de reunião</label>
      <multiselect
        v-model="salaSelecionada"
        :options="salas"
        :searchable="false"
        :close-on-select="true"
        track-by="id"
        label="nome"
        :allow-empty="false"
        placeholder="Selecione uma sala"
      ></multiselect>

      <button @click.prevent="salvarAgendamento()" class="btn">Salvar</button>
    </form>
  </section>
</template>
<script>
import Multiselect from "vue-multiselect";
import { Datetime } from "vue-datetime";
import { api } from "../helpers/services";
import "vue-datetime/dist/vue-datetime.css";

export default {
  data() {
    return {
      error: "",
      agendamento: {
        titulo: "",
        horaInicio: "",
        horaFim: "",
        salaId: ""
      },
      salas: [],
      salaSelecionada: {}
    };
  },
  components: {
    Datetime,
    Multiselect
  },
  methods: {
    salvarAgendamento() {
      this.error = "";
      api
        .post("agendamentos", {
          Titulo: this.agendamento.titulo,
          HoraInicio: this.agendamento.horaInicio,
          HoraFim: this.agendamento.horaFim,
          SalaId: this.salaSelecionada.id
        })
        .then(res => {
          if (res.data.success == true) {
            this.$router.push({ name: "agenda.completa" });
          } else {
            var mensagemDeErro = res.data.data;
            typeof mensagemDeErro === "object"
              ? (this.error = mensagemDeErro[0].message)
              : (this.error = mensagemDeErro);
          }
        });
      console.log(this.salaSelecionada.id);
    },
    getSalas() {
      api.get("salas").then(res => {
        this.salas = res.data;
      });
    }
  },
  created() {
    this.getSalas();
  }
};
</script>
<style src="vue-multiselect/dist/vue-multiselect.min.css"></style>
<style scoped>
h1 {
  text-align: center;
  font-size: 2rem;
  color: #336633;
  margin-bottom: 15px;
}

.reserva {
  display: flex;
  flex-direction: column;
  align-items: center;
  justify-content: center;
  max-width: 500px;
  margin: 0 auto;
}

.reserva label,
.reserva input,
.reserva select {
  margin-bottom: 15px;
  width: 100%;
}

.horario {
  display: flex;
  margin: 20px;
}

.hora {
  margin: 0 25px;
  display: flex;
  flex-direction: column;
}

.error {
  display: flex;
  justify-content: center;
  align-items: center;
  margin: 10px;
  border: 1px solid black;
  border-radius: 10px;
}

.error p {
  color: red;
  font-weight: bold;
}

.button {
  margin-top: 10px;
}
</style>
