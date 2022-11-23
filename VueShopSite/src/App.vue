<template>
    <div id="app">
        <div id="top-menu">
            <search/>
            <register/>
            <login/>
            
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

    export default {
        name: 'App',
        components: {
           search,
           register,
           login
          
            
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
        background-color: #e4f5e7;
    }
    #top-menu{
        display: flex;
        width: 100%;
        height: 50px;
        background-color: #52b788;
        border-bottom: solid #1b4332 3px;
        position: relative;
        flex-direction:row;
        align-items: center;
    }
    .container{
        padding: 20px;
    }



</style>