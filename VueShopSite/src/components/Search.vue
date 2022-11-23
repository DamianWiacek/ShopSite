<template>
<div class="container">
    <div id="search-bar">
        <input id="search-field" v-model="name" @keypress="fetchProductWithName()" />
        <button type="submit" @click="fetchProductWithName()"  class="search-button">
          <img src="../assets/mag.png">
        </button>
       
    </div>

        <div class = "result" v-for="product in products" :key="product.id"> 
   <Product
   :id= "product.id"
   :name = "product.name"
   :category = "product.category"
   :price = "product.price"
   :description = "product.description"
   :photo = "product.photoLink"
   />

    </div>
</div>
   
        

</template>

<script>
import Product from './Product'
export default {
        name: 'Search',
        components:{
            Product,
        },
        data(){
            return{
                products: [],               
                name:''
            }
        },
        methods: {
            async fetchProductWithName() {
                const res = await fetch(`https://localhost:5001/api/ProductController/name/${this.name}`)

                const data = await res.json()

                this.products   =  data
            },

            
        },
        
        
              
    }
</script>
<style scoped>
    .container{
        padding: 10px;
    }
    #search-bar{
        width: 400px;
        height: auto;
        text-align: center;
        line-height: 30px;
        border: solid 2px #52796f;

        background-color: #cad2c5;
        display: flex;
        flex-direction: row;
    }
    #search-field{
        width: 100%;
        background: transparent;
        border: none;
    }
    .result{
        border: solid 2px #52796f;
        background-color: #cad2c5;
        padding-left: 30px;
    }
    .search-button {
  background: transparent;
  border: none;
  outline: none;
  
  
  
}
    .search-button img {
  width: 20px;
  height: 20px;
  object-fit: cover;

}
</style>

