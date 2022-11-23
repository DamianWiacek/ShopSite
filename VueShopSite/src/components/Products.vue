<template>
    <div v-for="product in products" :key="product.id"> 
   <Product
   :id= "product.id"
   :name = "product.name"
   :category = "product.category"
   :price = "product.price"
   :description = "product.description"
   :photo = "product.photoLink"
   />
   </div>
</template>

<script>
import Product from './Product'
export default {
        name: 'Products',
        components:{
            Product
        },
        data(){
            return{
                products:[]
            }
        },
        methods: {
            async fetchProducts() {
                const res = await fetch("https://localhost:5001/api/ProductController")

                const data = await res.json()

                return data
            }
        },
        async created(){
            this.products=await this.fetchProducts()
        },
              
    }
</script>

<style scoped>

</style>