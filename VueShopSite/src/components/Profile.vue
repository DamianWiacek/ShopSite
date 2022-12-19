<template>
    <div class="container" >
     <router-link class="Profile" v-if="user.roleId ===1" to="/UserProfile">{{user.name }}</router-link>
     

 </div>
 
</template>

<script>
 export default {
     name: 'Profile',
     data(){
        return{
            user : JSON.parse(localStorage.user)
        }
     }
 }
</script>

<style scoped>
 
 .container{
     padding: 15px;
     font-family: 'Trebuchet MS', sans-serif;
     cursor: pointer;
 }
 .Profile{
     text-decoration: none;
     color: #1b4332;       
 }
 
</style>