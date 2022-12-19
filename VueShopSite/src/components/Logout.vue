<template>
    <div class="container"  @click="logout()">Logout</div>
</template>

<script>

    export default{
        name: 'Logout',
        methods:{
            logout() {
                localStorage.removeItem('user');
                localStorage.removeItem('token');
                location.reload()
            }
        }

    }

</script>

<style scoped>

.container{
        padding: 15px;
        font-family: 'Trebuchet MS', sans-serif;
        color: #1b4332; 
        cursor: pointer;
        text-decoration: none;
    }


</style>