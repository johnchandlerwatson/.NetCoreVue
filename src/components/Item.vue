<template>
  <div class="item-order"> 
    <div class="row align-row">
      <label v-bind:for="this.item.name">{{this.item.name}}</label>
    </div>
    <div class="row align-row">
      <div class="col-sm-4">
        <p class="quantity">{{this.quantity}}</p>
      </div>
      <div class="col-sm-8">   
        <button class="btn btn-sm btn-info quantity-button" v-on:click="addQuantity">+</button>
        <button class="btn btn-sm btn-info quantity-button" v-on:click="removeQuantity">-</button>
      </div>
    </div>
  </div>
</template>

<script>
  export default {
    name: 'item',

    props: {
      'item': {
        type: Object
      }
    },
    data () {
      return {
        quantity: 0
      }
    },
    methods: {
      addQuantity () {
        this.quantity++
      },
      removeQuantity () {
        if (this.quantity > 0) {
          this.quantity--
        }
      }
    }
  }
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped>
  .item-order {
    padding: 10px;
    margin-right: 10px;
    background: gray;
    border-radius: 5px;
  }

  .align-row {
    display: flex;
    align-items: center;
    justify-content: center;
  }

  label {
    color: white;
  }

  .quantity {
    color: white;
    font-size: 18px;
    padding-left: 20px;
  }

  .quantity-button {
    width: 30px; 
    min-width: 30px;
    margin-right: 5px;
  }
</style>