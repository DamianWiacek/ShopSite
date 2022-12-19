<template>
<div class="container">
        <div id="search-bar">
        <input id="search-field" v-model="name" @change="fetchProductWithName()" />
        <button type="submit" @click="fetchProductWithName()" class="search-button">
          <img src="../assets/mag.png">
        </button>
       
        </div>
        <ul v-if="products">
        <li class = "result" v-for="product in products" :key="product.id"> 
            <Product
            :id= "product.id"
            :name = "product.name"
            :category = "product.category"
            :price = "product.price"
            :description = "product.description"
            :photo = "product.photoLink"
            />
        
        </li>
        </ul>
</div>
   
        

</template>

<script>
import Product from './Product'
import axios from 'axios'
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
  
                this.products  =  await (await axios.get(`https://localhost:5001/api/ProductController/name/${this.name}`)).data

                
            },

            
        },
        
        
              
    }
</script>
<style scoped>
    .container{
        padding: 10px;
        margin-left: 400px auto;
        
                
    }
    #search-bar{
        width: 400px;
        height: auto;
        text-align: center;
        line-height: 30px;
        border: solid 2px #52796f;
        background-color: rgb(245, 243, 243);
        display: flex;
        flex-direction: row;

    }
    #search-field{
        width: 100%;
        background: transparent;
        border: none;   
    }
    .result{
        
        background-color: rgb(245, 243, 243);
        border: solid 2px #52796f;
        padding-left: 30px;
        height: 120px;
        width: 370px;
        list-style-type: none;
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

