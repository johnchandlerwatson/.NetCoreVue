<template>
  <div class="totals">
    <div class="row">
      <div class="col-sm-6">
        <label v-bind:for="partyToCheckout.subtotalDisplay">Subtotal</label>
      </div>
      <div class="col-sm-6">
        <span>{{partyToCheckout.subtotalDisplay}}</span>
      </div>
    </div>
    <div class="row" v-if="partyToCheckout.discountAmount > 0">
      <div class="col-sm-6">
        <label v-bind:for="partyToCheckout.discountAmountDisplay">Discount</label>
      </div>
      <div class="col-sm-6">
        <span>{{partyToCheckout.discountAmountDisplay}}</span>
      </div>
    </div>
    <div class="row">
      <div class="col-sm-6">
        <label v-bind:for="partyToCheckout.taxAmountDisplay">Taxes</label>
      </div>
      <div class="col-sm-6">
        <span>{{partyToCheckout.taxAmountDisplay}}</span>
      </div>
    </div>
    <div class="row total-row">
      <div class="col-sm-6">
        <label v-bind:for="partyToCheckout.totalAfterTaxesDisplay">Total</label>
      </div>
      <div class="col-sm-6">
        <span>{{partyToCheckout.totalAfterTaxesDisplay}}</span>
      </div>
    </div>
  </div>
</template>
<script>
    export default {
      name: 'totals',

      props: {
        'partyToCheckout': {
          type: Object
        }
      },
      data () {
        return {}
      },
      created () {
        console.log(this.partyToCheckout)
      }
    }
</script>
<style lang="scss" scoped>
.total-row {
  font-size: 15px;
  font-weight: bold;
  color: #444444
}

.totals {
  margin-top: 5px;
  background: #f2f2f2;
  padding-left: 10px;
}
</style>