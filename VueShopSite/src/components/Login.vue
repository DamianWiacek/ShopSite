<template>
       <div class="container" >
        <router-link class="Login" to="/Login">Login</router-link>
        

    </div>
    
</template>

<script>
    export default {
        name: 'Login',
    }
</script>

<style scoped>
    
    .container{
        padding: 15px;
        font-family: 'Trebuchet MS', sans-serif;
        cursor: pointer;
    }
    .Login{
        text-decoration: none;
        color: #1b4332;       
    }
    
</style>