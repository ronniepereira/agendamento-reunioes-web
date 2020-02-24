<template>
  <section class="admin">
    <nav class="sidenav">
      <ul>
        <li>
          <router-link :to="{ name: 'reservar.sala' }">Reservar sala</router-link>
        </li>
        <li>
          <router-link :to="{ name: 'agenda.completa' }">Agenda completa</router-link>
        </li>
      </ul>
    </nav>
    <transition mode="out-in">
      <router-view></router-view>
    </transition>
  </section>
</template>

<script>
export default {
  methods: {}
};
</script>

<style scoped>
.admin {
  display: grid;
  grid-template-columns: 175px 1fr;
  max-width: 1100px;
  margin: 0px auto;
  grid-gap: 30px;
  padding: 20px;
}

.sidenav {
  margin-top: 50px;
}

@media screen and (max-width: 500px) {
  .admin {
    grid-template-columns: 1fr;
    margin: 0px auto;
  }
}

.sidenav a,
.sidenav button {
  padding: 10px;
  display: block;
  background: #f4f7fc;
  margin-bottom: 10px;
  border-radius: 4px;
}

.sidenav a.router-link-exact-active,
.sidenav a:hover,
.sidenav button:hover {
  background: #336633;
  color: #fff;
}

.sidenav button {
  border: none;
  width: 100%;
  font-size: 1rem;
  text-align: left;
  font-family: "Avenir", Arial, Helvetica, sans-serif;
  cursor: pointer;
}

.v-enter,
.v-leave-to {
  opacity: 0;
}

.v-enter {
  transform: translate3d(0, -20px);
}

.v-enter-active,
.v-leave-active {
  transition: all 0.3s;
}
</style>
