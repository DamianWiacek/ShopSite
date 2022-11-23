<template>
    <div class="container">
        <div class="go-back">
            <router-link to="/">
            <img src="../assets/arrow-back.png" >
        </router-link>
        </div>
        <form @submit="onSubmit">
            <div class = "from-control" >
            <input type="email" placeholder="Email" v-model="email">
            </div>
            <div class = "from-control" >
            <input type="text" placeholder="Password" v-model="password">
            </div>
            <input type="submit" value="Login">
            
        </form>

    </div>

</template>

<script>
    export default {
        name:'login',
        data() {
            return {
                id:0,
                name:'',
                surname:'',
                email:'',
                password:'',
                confirmPassword:'',
                age:0,
                nationality:'',
                street:'',
                city:'',
                country:'',
                postalCode:'',
                houseNumber:''

            }
            },
  methods: {
   
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
    background-color: #f5fff7;
    height: 80%;
    width: 60%;
    margin-left: 100px;
}
.from-control{
   padding: 10px; 
   text-align: center;
}
input[type =text],input[type =email]{
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