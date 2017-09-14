<template>
    <div class="item-order">
      <label :for="makeId(item.Id, 'name')">Name</label>
      <input :id="makeId(item.Id, 'name')" v-model="item.name" type="text" placeholder="Name">
      <label :for="makeId(item.Id, 'quantity')">Quantity</label>
      <div class="row align-row">
        <div class="col-sm-6">
          <p class="quantity">{{this.quantity}}</p>
        </div>
        <div class="col-sm-6">
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
      makeId (index, name) {
        return index + '_' + name
      },
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
    padding-left: 25px; 
    color: white;
    font-size: 18px;
  }

  .quantity-button {
    width: 30px; 
    min-width:30px; 
    margin-bottom: 5px;
  }
</style>