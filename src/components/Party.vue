<template>
    <div class="table-card" v-bind:class="warningLevelClass">
      <div class="flexcolumn">
        <h4 class="table-header">Table: {{ party.table.number }}</h4>
        <div class="info-section">
          <p><strong>{{party.outstandingOrderCount}}</strong> active orders</p>
          <p><strong>{{party.maxMinutesWaiting}}</strong> mins waiting</p>
          <br>
          <template v-if="party.waiter">
            <p><strong>{{party.waiter.fullName}}</strong></p>
          </template>
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
    width: 175px;
    height: 140px;
    box-shadow: 1px 1px 6px #888888;
    border-radius: 15px;
    margin: 20px;
  }

  .info-section {
    padding-top: 3px;
    height: 50px;
  }

  .table-header
  {
    padding-top: 4px;
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
