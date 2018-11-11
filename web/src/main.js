import Vue from 'vue'
import VueMaterial from 'vue-material'
import 'vue-material/dist/vue-material.min.css'
import 'vue-material/dist/theme/black-green-dark.css' 
import App from './App.vue'

// not recommended to pull in the entire VueMaterial bundle, will affect performance
// when we figure out what we are actually using, we can bring in only the stuff we are actually using
// ie. import { MdButton, MdContent } from 'vue-material/dist/components' and
// Vue.use(MdButton)
// Vue.use(MdContent)
Vue.use(VueMaterial)
Vue.config.productionTip = false

new Vue({
  render: h => h(App),
}).$mount('#app')