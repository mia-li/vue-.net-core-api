<template>
  <div class="product-page">
    <div class="product-info">
        <div class="product-info-left">
            <img :src="product.productImageUrl" alt="" />
        </div>
        <div class="product-info-right">
            <p class="p-name">{{product.productName}}</p>
            <p class="p-price">&yen;{{product.price}}</p>
            <p class="p-number">
                <span class="sub" @click="subNumber()">-</span>
                <input type="text" v-model="count" @change="changeCount()" />
                <span class="pls" @click="plsNumber()">+</span>
            </p>
            <p class="p-button">
                <button @click="AddCart()">加入购物车</button>
            </p>
        </div>
    </div>
    <hr>
    <div class="product-detail">
        <img :src="product.productDetailImageUrl" alt="" />
    </div>
  </div>
</template>
<script>
export default {
    data(){
        return{
            count:1,
            product:{}
        }
    },
    mounted(){
        var pid=this.$route.query.pid;
        this.getProductById(pid);
    },
    methods:{
        plsNumber(){
            this.count++;
        },
        subNumber(){
            if(this.count>1) 
            {
                this.count--;
            }
        },
        changeCount(){
            var newCount=Event.target.value;
        },
        getProductById(pid){
            var thisVue=this;
            this.$http.get("https://localhost:44394/api/Products/GetProductById/?id="+pid).then(function(res){
                thisVue.product=res.data;
            });
        },
        AddCart(){
            var thisVue=this;
            this.$http.get("https://localhost:44394/api/Products/AddCart/?productId="+this.product.id+"&count="+this.count+" ").then(function(res){
                if(res.data>0)
                {
                    thisVue.$router.push("/AddSuccess");
                }
            });
        },
    },
    watch:{
        count:function(nVal,oVal){
            if(isNaN(nVal)||nVal<1){
                this.count=oVal;
            }
        }
    }
};
</script>
<style>
    .product-info{
        height: 390px;
    }
    .product-info-left{
        float: left;
    }
    .product-info-right{
        float: left;
        margin-left: 60px;
    }
    .product-info-right p{
        margin-bottom: 60px;
        text-align: left;
    }
    .product-info-right .p-name{
        margin-top: 20px;
        font-size: 18px;
        font-weight: bold;
    }
    .product-info-right .p-price{
        font-size: 18px;
        font-weight: bold;
    }
    .product-info-right .p-button button{
        width: 210px;
        height: 50px;
        border: 0 none;
        border-radius: 3px;
        background-color: black;
        color:white;
        font-size: 16px;
        font-weight: bold;
        cursor: pointer;
    }
    .p-number input{
        height: 36px;
        border: 1px solid black;
        border-left: 0 solid black;
        border-right: 0 solid black;
        width: 66px;
        outline: none;
        text-align: center;
        float: left;

    }
    .p-number{
        height: 36px;
        width: 300px;

    }
    .p-number span{
        display: inline-block;
        width: 36px;
        height: 36px;
        border: solid 1px black;
        text-align: center;
        cursor: pointer;
        line-height: 36px;
        float: left;
    }
    .sub{
        border-radius: 3px 0 0 3px;
    }
    .pls{
        border-radius:  0 3px 3px 0;
    }
    .product-page{
        width: 719px;
        margin: auto;
    }
    .product-detail img{
        width: 500px;
    }
</style>