<template>
    <div class="container">
        <router-link class="Register" to="/Register">Register</router-link>
        

    </div>
    
</template>

<script>
    export default {
        name: 'Register',
    }
</script>

<style scoped>
    .container{ 
        padding: 15px;
        font-family: 'Trebuchet MS', sans-serif;
        cursor: pointer;
    }
    .Register{
        text-decoration: none;
        color: #1b4332;
    }
    
</style>