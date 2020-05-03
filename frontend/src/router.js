import VueRouter from 'vue-router';
import Auth from './components/Auth.vue';


const router = new VueRouter({
  mode: 'history',
  routes: [
    { path: '/', component: Auth },
    { path: '/auth', component: Auth }
  ]
});

export default router;