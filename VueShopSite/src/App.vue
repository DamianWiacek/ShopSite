<template>
    <div id="app">
        <div id="top-menu">
            <categories/>
            <div class="search"><search/></div>
            
            <div class="right-panel">
                <div v-if="!logedUser"><register/></div>
                <div v-if="!logedUser"><login/></div>
                <div v-if="logedUser"><logout/></div>
                <div v-if="logedUser"><profile/></div>
                <home/>
                
            </div>
            
        </div>
        <div class="container"> 
            
            <router-view></router-view>
            
        </div>
    </div>
</template>

<script>
    import search from './components/Search.vue'
    import register from './components/Register.vue'
    import login from './components/Login.vue'
    import logout from './components/Logout.vue'
    import profile  from './components/Profile.vue'
    import home  from './components/Home.vue'
    import categories from './components/Categories.vue'


    export default {
        name: 'App',
        components: {
    search,
    register,
    login,
    logout,
    profile,
    home,
    categories
},
        data(){
            return{
            logedUser:null,
            token : ""
            }
        },
        mounted() {
        if (localStorage.token) {
         this.token = localStorage.token;
        }
        if (localStorage.user){
            this.logedUser = JSON.parse(localStorage.user)
        }
         },

        
        
      
}
</script>
    
<style>
    *{
        padding: 0;
        margin: 0;
        text-decoration: none;
    }

    body{   
        width: 100%;
        height: 100%;
        margin: 0px;
       
    }
    #top-menu{
        display: flex;
        width: 100%;
        height: 50px;
        background-color: #057742;
        border-bottom: solid #1b4332 3px;
        position: relative;
        flex-direction:row;
        justify-content:  space-between;
        
    }
    .right-panel{
        display: flex;
        flex-direction: row;
    }

    .search{
        justify-self: flex-start;
    }



</style>