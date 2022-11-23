import {createRouter, createWebHistory} from 'vue-router'
import RegisterPage from '../views/RegisterPage'
import HomePage from '../views/Home'
import LoginPage from '../views/LoginPage'

const routes =[
    {
        path:'/Register',
        name: 'RegisterPage',
        component: RegisterPage,      
    },
    {
        path:'/',
        name: 'Home',
        component: HomePage,      
    },
    {
        path:'/Login',
        name: 'Loginpage',
        component: LoginPage,      
    }
]

const router = createRouter({
    history: createWebHistory(process.env.BASE_URL),
    routes,

})

export default router