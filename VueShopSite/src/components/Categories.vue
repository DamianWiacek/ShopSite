<template>
    <div class="container">
        <p class="Categories">Categories</p>
        <ul>
            <li>Electronics</li>
            <li>Clothes</li>
        </ul>
    </div>
</template>

<script>
    export default {
        name: 'Categories',
    }
</script>

<style scoped>
    .container{
        padding: 15px;
        font-family: 'Trebuchet MS', sans-serif;
        cursor: pointer;
    }
    .container:hover + ul{
  max-height: inherit;
  opacity: 1;
}

ul{
  list-style-type: none;
  padding: 0px;
  margin: 0px;
  max-height: 0px;
  opacity: 0;
  overflow: hidden;
  transition: opacity 300ms ease;
}
    
  
</style>