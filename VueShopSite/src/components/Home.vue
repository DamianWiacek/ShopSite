<template>
    <div class="container" >
     <router-link class="Home" to="/">Home</router-link>
     

 </div>
 
</template>

<script>
 export default {
     name: 'Home',
 }
</script>

<style scoped>
 
 .container{
     padding: 15px;
     font-family: 'Trebuchet MS', sans-serif;
     cursor: pointer;
 }
 .Home{
     text-decoration: none;
     color: #1b4332;       
 }
 
</style>