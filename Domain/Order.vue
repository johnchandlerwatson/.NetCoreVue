<template>
    <div class="item-list">
      <p>Order: {{order.orderNumber}}</p>
      <p>{{order.orderDescription}}</p>
    </div>
</template>

<script>
  export default {
    name: 'order',

    props: {
      'order': {
        type: Object
      }
    },
    data () {
      return {
      }
    }
  }
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped>
  .item-list {
    text-align: left;
    padding-left: 6px;
  }
</style>