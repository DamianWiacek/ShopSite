<template>
    <div class="container">
        <div class="go-back">
            <router-link to="/">
            <img src="../assets/arrow-back.png" >
        </router-link>
        </div>
        <form @submit="onSubmit">
            <div class = "from-control">
            <input type="text" placeholder="Name" v-model="name">
            </div>
            <div class = "from-control" >
            <input type="text" placeholder="Surname" v-model="surname">
            </div>
            <div class = "from-control" >
            <input type="email" placeholder="Email" v-model="email">
            </div>
            <div class = "from-control" >
            <input type="text" placeholder="Password" v-model="password">
            </div>
            <div class = "from-control" >
            <input type="text" placeholder="Confirm password" v-model="confirmPassword">
            </div>
            <div class = "from-control" >
            <input type="number" placeholder="Age" v-model="age">
            </div>
            <div class = "from-control" >
            <input type="text" placeholder="Nationality" v-model="nationality">
            </div>
            <div class = "from-control" >
            <input type="text" placeholder="Street" v-model="street">
            </div>
            <div class = "from-control" >
            <input type="text" placeholder="City" v-model="city">
            </div>
            <div class = "from-control" >
            <input type="text" placeholder="Country" v-model="country">
            </div>
            <div class = "from-control" >
            <input type="text" placeholder="Postal code" v-model="postalCode">
            </div>
            <div class = "from-control" >
            <input type="text" placeholder="House number" v-model="houseNumber">
            </div>
            <input type="submit" value="Potwierdź">
            
        </form>

    </div>

</template>

<script>
    export default {
        name:'register',
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
    async onSubmit(e) {
      e.preventDefault()
      if (!this.name) {
        alert('Please add a name')
        return
      }
      const newUser = {      
                name:this.name,
                surname:this.surname,
                email:this.email,
                password:this.password,
                confirmPassword:this.confirmPassword,
                age:this.age,
                nationality:this.nationality,
                street:this.street,
                city:this.city,
                country:this.country,
                postalCode:this.postalCode,
                houseNumber:this.houseNumber
      }
      const res = await fetch('https://localhost:5001/api/UserController', {
        method: 'POST',
        headers: {
          'Content-type': 'application/json',
        },
        body: JSON.stringify(newUser)})
      
        const data = await res
        this.id = data.id
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
    background-color: #f5fff7;
    height: 80%;
    width: 60%;
    margin-left: 100px;
}
.from-control{
   padding: 10px; 
   text-align: center;
}
input[type =text],input[type =email],input[type =number]{
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