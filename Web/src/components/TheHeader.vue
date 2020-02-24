<template>
  <header>
    <nav>
      <router-link to="/agenda" class="logo">
        <img src="../assets/logo.png" alt="Logo" />
      </router-link>
      <div class="nav-buttons">
        <router-link class="btn" to="/admin">Administração</router-link>
        <router-link class="btn" to="/agenda">Agenda</router-link>
      </div>
    </nav>
  </header>
</template>
<script>
export default {
  data() {
    return {};
  },
  methods: {
    logout() {
      this.$store.dispatch("logout");
      this.$router.push({ name: "login" });
    }
  },
  created() {
    console.log(this.$store.getters.isAdmin);
  }
};
</script>

<style scoped>
nav {
  display: flex;
  align-items: center;
  justify-content: space-between;
  height: 70px;
  padding: 0 20px;
  box-shadow: 0 2px 4px rgba(30, 60, 90, 0.1);
}

.logo {
  padding: 0;
}

.logo img {
  padding: 10px 0;
  max-height: 100px;
  border-radius: 30px;
}

.nav-buttons {
  display: flex;
}

.nav-buttons .btn {
  margin: 0 5px;
}
</style>
