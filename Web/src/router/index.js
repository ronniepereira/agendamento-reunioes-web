import Vue from "vue";
import VueRouter from "vue-router";
import Agenda from "../views/Agenda.vue";
import Admin from "../views/Admin.vue";
import ReservarSala from "../components/ReservarSala.vue";
import AgendaCompleta from "../components/AgendaCompleta.vue";
import AgendaDisponivel from "../components/AgendaDisponivel.vue";
import SalaGerenciar from "../components/SalaGerenciar.vue";
import SalaCriar from "../components/SalaCriar.vue";

Vue.use(VueRouter);

const routes = [{
    path: "/",
    redirect: {
      name: "agenda.completa"
    }
  },
  {
    path: "/admin",
    component: Admin,
    children: [{
        path: "",
        redirect: {
          name: "sala.criar"
        }
      },
      {
        path: "sala/criar",
        name: "sala.criar",
        component: SalaCriar
      },
      {
        path: "sala/gerenciar",
        name: "sala.gerenciar",
        component: SalaGerenciar
      }
    ]
  },
  {
    path: "/agenda",
    component: Agenda,
    children: [{
        path: "",
        redirect: {
          name: "agenda.completa"
        }
      },
      {
        path: "completa",
        name: "agenda.completa",
        component: AgendaCompleta
      },
      {
        path: "disponivel",
        name: "agenda.disponivel",
        component: AgendaDisponivel
      },
      {
        path: "reservar",
        name: "reservar.sala",
        component: ReservarSala
      }
    ]
  },
  {
    path: "/about",
    name: "About",
    // route level code-splitting
    // this generates a separate chunk (about.[hash].js) for this route
    // which is lazy-loaded when the route is visited.
    component: () =>
      import( /* webpackChunkName: "about" */ "../views/About.vue")
  }
];

const router = new VueRouter({
  mode: "history",
  base: process.env.BASE_URL,
  routes
});

export default router;