<template>
    <div class="container">
        <div class="go-back">
            <router-link to="/">
            <img src="../assets/arrow-back.png" >
        </router-link>
        </div>
        <form @submit.prevent="onSubmit">
            <div class = "from-control" >
            <input type="email" placeholder="Email" v-model="email">
            </div>
            <div class = "from-control" >
            <input type="password" placeholder="Password" v-model="password">
            </div>
            <input type="submit" value="Login">
            
        </form>
        <div v-if="loginError"> Zły e-mail lub hasło</div>
    </div>


</template>

<script>

import axios from 'axios'


    export default {
        name:'login',
        data() {
            return {
                email:'',
                password:'',
                loginError : false
            }
            },
  methods: {
    async onSubmit(){
           try {
            const res = await axios.post('https://localhost:5001/api/UserController/login',
            {email:this.email,
            password: this.password},
            )
            localStorage.token = res.data
            const logedUser = await (await axios.get(`https://localhost:5001/api/UserController/${this.email}`)).data
            localStorage.user = JSON.stringify(logedUser)
           }
           catch{
             this.loginError = true
           }
            
            
        }
   
    }
}



</script>

<style scoped>

.go-back{
    background-color: #52b788;
    color: #1b4332;
    text-decoration: none;
    height: 30px;
    width: 60px;
    border-radius: 5px;
    text-align: center  ;
}
img{

  object-fit: cover;
  height: 30px;
  margin-left: auto;

}
form{
    background-color:  rgb(245, 243, 243);
    height: 80%;
    width: 60%;
    margin-left: 100px;
}
.from-control{
   padding: 10px; 
   text-align: center;
}
input[type =password],input[type =email]{
    width: 100%;
  padding: 12px 20px;
  margin: 8px 0;
  display: inline-block;
  border: 1px solid #ccc;
  border-radius: 4px;
  box-sizing: border-box;
}

input[type=submit] {
  width: 100%;
  background-color: #4CAF50;
  color: white;
  padding: 14px 20px;
  margin: 8px 0;
  border: none;
  border-radius: 4px;
  cursor: pointer;
}
</style>