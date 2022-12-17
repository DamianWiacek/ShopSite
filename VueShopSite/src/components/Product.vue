<template>
   <div class="container">
    <div class="left">
    <p class="name">{{name}}</p>
    <p>Id :{{id}} Cena: {{price}}zł</p>
   </div>
    <div class="right">
        <img :src="photo">
    </div>
   </div>
</template>

<script>


export default{
    name:'Product',
    props:{
        id: Number,
        name : String,
        price : Number,
        category : Number,
        description: String,
        photo : String

    }
}
</script>
<style scoped>
.container{
    display: flex;
    flex-direction: row ;
    
    height: 100px;
    width: 300px;

}
img{
    height: 100px;
    width: 100px;
    
    
}
.left{
    flex-grow: 4;
}
</style>