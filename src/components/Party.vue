<template>
    <div class="table-card" v-bind:class="warningLevelClass">
      <div class="flexcolumn">
        <h4 class="table-header">Table: {{ party.table.number }}</h4>
        <div id="orders" style="height: 150px">
          <div v-for="order in party.orders" :key="order.Id">
            <order :order="order"></order>
          </div>
        </div>
        <div class="btn-holder">
          <button class="btn btn-sm btn-default" style="margin-right: 10px">
            Add Order
          </button>
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
    height: 250px;
    box-shadow: 1px 1px 6px #888888;
    border-radius: 15px;
    margin: 20px;
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
