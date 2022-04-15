<template>
  <div>
    <div class="product-search">
      <input type="text" id="txtSearch" />
      <button>搜索</button>
    </div>
    <hr>
    <div class="product-list">
      <ul>
        <li v-for="product in productList" :key="product.id">
           <router-link :to="'/ProductDetail?pid='+product.id">商品详情页</router-link>
           <img :src="product.productImageUrl" alt="" />
           <p class="p-price">&yen;{{product.price}}</p>
           <p>{{product.productName}}</p>
        </li>
      </ul>
    </div>
  </div>
</template>

<script>
export default{
  data(){
    return{
      productList:[]
    };
  },
  mounted(){
    this.getProductList();
  },
  methods:{
    getProductList:function(){
      var thisVue=this;
      this.$http.get("https://localhost:44394/api/Products/GetProducts/").then(function(res){
        thisVue.productList=res.data;
      });
    }
  }
}
</script>

<!-- Add "scoped" attribute to limit CSS to this component only 要加scoped 防止页面污染 -->
<style scoped>
  *{ 
    padding:0;
    margin:0;
  }
  #txtSearch {
    width:1000px;
    height:50px;
    border:6px solid black;
    float:left;
    outline:none;
    padding:0 6px;
  }
  button {
    width: 80px;
    height: 62px;
    border: none;
    background-color: black;
    color: white;
    float: left;
    outline: none;
  }
  .product-search{
    width:1200px;
    height:62px;
    margin:auto;
  }
  hr{
    margin-top:60px;
    border:2px solid black;
  }
  .product-list li:hover {
    border-color:white;
    box-shadow:0 0 6px #ccc;
  }
  .product-list li {
    width: 400px;
    margin: 60px 0 0 60px;
    list-style: none;
    float: left;
    border:1px solid white;
  }
    .product-list li image {
      width: 400px;
    }
    .product-list li p {
      font-size: 30px;
      text-align: left;
    }
  .p-price{
    font-size:30px;
    font-weight:bold;
    margin-bottom:8px;
  }
</style>
