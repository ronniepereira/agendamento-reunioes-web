<template>
  <div class="panel panel-default">
    <div class="panel-heading">
      <TheHeader />
    </div>
    <div class="panel-body">
      <transition mode="out-in">
        <router-view></router-view>
      </transition>
    </div>
    <div class="panel-footer">
      <TheFooter />
    </div>
  </div>
</template>
<script>
import TheHeader from "./components/TheHeader.vue";
import TheFooter from "./components/TheFooter.vue";

export default {
  components: {
    TheHeader,
    TheFooter
  }
};
</script>
<style>
* {
  box-sizing: border-box;
}

body,
ul,
li,
h1,
h2,
p {
  padding: 0px;
  margin: 0px;
}

ul {
  list-style: none;
}

body {
  font-family: "Avenir", Helvetica, Arial, sans-serif;
  color: #345;
  background-color: #fff;
}

a {
  color: #345;
  text-decoration: none;
}

img {
  max-width: 100%;
  display: block;
}

label {
  margin-bottom: 5px;
}

select {
  /* background: #ffffff url("./assets/arrow-dropdown.png") no-repeat right center; */
  background-size: 15px 15px;
  background-origin: content-box, padding-box;
  appearance: none;
  text-shadow: 0 0 0 #000;
  outline: none;
}

.btn {
  display: block;
  padding: 10px 30px;
  background: #336633;
  border-radius: 4px;
  color: #fff;
  text-align: center;
  font-size: 1rem;
  box-shadow: 0 4px 8px rgba(30, 60, 90, 0.2);
  transition: all 0.3s;
  font-family: "Avenir", Helvetica, Arial, sans-serif;
  cursor: pointer;
  border: none;
}

.btn:hover {
  background: #336633;
  transform: scale(1.1);
}

#app {
  display: flex;
  min-height: 100vh;
  flex-direction: column;
}

#main {
  flex: 1;
}

input,
select,
textarea {
  border-radius: 4px;
  border: none;
  padding: 10px;
  box-shadow: 0 4px 8px rgba(30, 60, 90, 0.2);
  transition: all 0.3s;
  font-size: 1rem;
  font-family: "Avenir", Helvetica, Arial, sans-serif;
}

input:hover,
input:focus,
textarea:hover,
textarea:focus,
select:hover,
select:focus {
  outline: none;
  box-shadow: 0 6px 12px rgba(30, 60, 90, 0.3);
  border-color: #336633;
}

.panel-body {
  min-height: calc(100vh - 70px);
}

/* Style Vue-MultiSelect */

/* Remover estilo padrão da arrow-dropdown */
.multiselect .multiselect__select::before {
  border-style: none;
}

.multiselect {
  margin-bottom: 15px;
}

.multiselect input {
  box-shadow: none;
}

.multiselect div.multiselect__tags {
  border-radius: 4px;
  border: none;
  padding: 10px;
  box-shadow: 0 4px 8px rgba(30, 60, 90, 0.2);
  transition: all 0.3s;
  font-size: 1rem;
  font-family: "Avenir", Helvetica, Arial, sans-serif;
}

.multiselect .multiselect__select {
  /* background: #ffffff url("./assets/arrow-dropdown.png") no-repeat right center; */
  background-size: 15px 15px;
  background-origin: content-box, padding-box;

  outline: none;
  width: 30px;
  height: 30px;

  z-index: 1;
}

.multiselect__option--selected {
  background: #336633;
  color: #fff;
}
</style>
