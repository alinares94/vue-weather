<script setup lang="ts">
import { RouterLink, RouterView } from 'vue-router'
import TheHeader from './components/TheHeader.vue'
</script>

<template>
  <header>
    <div class="header-margin-item">
      <img alt="Weather logo" class="logo" src="@/assets/weather.png"/>
    </div>

    <div class="wrapper header-margin-item">
      <TheHeader msg="Weather" />

      <nav>
        <RouterLink to="/">Home</RouterLink>
        <RouterLink to="/about">About</RouterLink>
      </nav>
    </div>
  </header>

  <RouterView />
</template>

<style scoped>
header {
  line-height: 1.5;
  max-height: 100vh;
  display: flex;
  justify-content: center;
  margin-bottom: 20px;
}

.header-margin-item {
  margin: 0px 3vw;
}

.logo {
  display: block;
  width: 80px;
  height: 80px;
}

header .wrapper {
  display: flex;
  flex-direction: column;
  justify-content: center;
}

nav {
  width: 100%;
  font-size: 12px;
  text-align: center;
}

nav a.router-link-exact-active {
  color: var(--color-text);
}

nav a.router-link-exact-active:hover {
  background-color: transparent;
}

nav a {
  display: inline-block;
  padding: 0 1rem;
  border-left: 1px solid var(--color-border);
}

nav a:first-of-type {
  border: 0;
}

@media (min-width: 992px) {
  header {
    display: flex;
    place-items: center;
    padding-right: calc(var(--section-gap) / 2);
  }

  .header-margin-item {
    margin: 0px 8px;
  }

  .logo {
    margin: 0 2rem 0 0;
    width: 125px;
    height: 125px;
  }

  header .wrapper {
    place-items: flex-start;
    flex-wrap: wrap;
  }

  nav {
    font-size: 1rem;
    margin-top: 1rem;
  }
}
</style>