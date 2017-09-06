<template>
    <div class="table-card" v-bind:class="warningLevelClass">
      <div class="flexcolumn">
        <h4 class="table-header">Table: {{ party.table.number }}</h4>
        <div class="info-section">
          <p>{{party.orderCount}} orders</p>
          <p>{{party.maxMinutesWaiting}} minutes waiting</p>
        </div>
        <div class="btn-holder">
          <button class="btn btn-sm btn-default">Add Order</button>
          <button class="btn btn-sm btn-default">Checkout</button>
        </div>
      </div>  
    </div>
</template>

<script>
  import order from './Order.vue'

  export default {
    name: 'party',

    components: { order },

    props: {
      'party': {
        type: Object
      }
    },
    data () {
      return {
      }
    },
    computed: {
      warningLevelClass: function () {
        return {
          'urgent': this.party.avgWarningLevel === 3,
          'warning': this.party.avgWarningLevel === 2,
          'info': this.party.avgWarningLevel === 1,
          'good': this.party.avgWarningLevel === 0
        }
      }
    }
  }
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped>
  .table-card {
    width: 200px;
    height: 175px;
    box-shadow: 1px 1px 6px #888888;
    border-radius: 15px;
    margin: 20px;
  }

  .info-section {
    height: 75px;
  }

  .btn-holder > button {
    margin-right: 15px;
  }

  .table-header
  {
    padding-top: 10px;
    padding-bottom: 5px; 
    border-bottom: 2px dotted #aaafb7;
  }

  .urgent {
    background: #ffdde4;
  }

  .warning {
    background: #ffeff2;
  }

  .info {
    background: #fff7e2;
  }

  .good {
    background: #eaf7ec;
  }
</style>
