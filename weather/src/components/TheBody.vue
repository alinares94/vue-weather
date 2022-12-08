<script setup lang="ts">
import BodyItem from './BodyItem.vue'
import IconThermometer from './icons/IconThermometer.vue'
import IconCloud from './icons/IconCloud.vue'
import IconDrop from './icons/IconDrop.vue'
import IconDropMeasure from './icons/IconDropMeasure.vue'
</script>

<template>
  <BodyItem>
    <template #icon>
      <IconThermometer />
    </template>
    <template #heading>Temperatura Interna</template>
    La temperatura en la habitación es: <h2 class="m-2">{{tempMeasure}} ºC</h2>
  </BodyItem>

  <BodyItem>
    <template #icon>
      <IconCloud />
    </template>
    <template #heading>Temperatura Externa</template>
    La temperatura en el exterior es: <h2 class="m-2">{{temp}} ºC</h2>
  </BodyItem>

  <BodyItem>
    <template #icon>
      <IconDropMeasure />
    </template>
    <template #heading>Humedad Interna</template>
    La humedad en la habitación es: <h2 class="m-2">{{humedadMeasure}} %</h2>
  </BodyItem>

  <BodyItem>
    <template #icon>
      <IconDrop />
    </template>
    <template #heading>Humedad Externa</template>
    La humedad en el exterior es: <h2 class="m-2">{{humedad}} %</h2>
  </BodyItem>
</template>
<script lang="ts">
import axios from 'axios'
import type { IWeatherResponse } from '../interfaces/IWeatherResponse'
import type { IMeasureResponse } from '../interfaces/IMeasureResponse';

export default {
  data() {
    return {
      temp: '-',
      humedad: '-',
      tempMeasure: '-',
      humedadMeasure: '-',
    }
  },
  mounted() {
    axios
      .get<IWeatherResponse>(`https://api.openweathermap.org/data/2.5/weather?lat=39.16045525833788&lon=-3.0176301597631534&appid=${import.meta.env.VITE_WEATHER_API_KEY}`)
      .then((response) => {
        if (response?.data){
          const celsius = response.data.main.temp - 273.15;
          const humedad = response.data.main.humidity;
          this.temp = Number(celsius).toFixed(2);
          this.humedad = Number(humedad).toFixed(2);
        }
      });
    axios
      .get<IMeasureResponse>(`${import.meta.env.VITE_MEASURES_API}`)
      .then((response) => {
        if (response?.data){
          const celsius = response.data.temperature;
          const humedad = response.data.humidity;
          this.tempMeasure = Number(celsius).toFixed(2);
          this.humedadMeasure = Number(humedad).toFixed(2);
        }
      });
  }
}
</script>