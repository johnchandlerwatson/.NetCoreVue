import Vue from 'vue'
import Router from 'vue-router'
import Hello from '@/components/Hello'
import 'bootstrap'
import 'bootstrap/dist/css/bootstrap.min.css'

Vue.use(Router)

export default new Router({
  routes: [
    {
      path: '/',
      name: 'Hello',
      component: Hello
    }
  ]
})
