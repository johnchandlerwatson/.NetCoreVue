<template>
    <modal name="checkout-modal" transition="pop-out" :width="modalWidth" :pivotY=0.0 height="auto" :scrollable="true">
      <div class="container">
        <div class="box-checkout">
          <div class="checkout-modal-title">CHECKOUT</div>                      
              <div class="partition-form">
                <form autocomplete="false">
                  <div class="form-group">
                    <label for="table-select">Table #</label>
                    <select id="table-select" class="form-control" style="width: 150px;" v-on:change="setParty" v-model="tableNumber">
                      <option v-for="party in model.parties" v-bind:value="party.table.number" :key="party.Id">
                        {{ party.table.number }}
                      </option>
                    </select>
                  </div>
                  <div id="summary" v-if="partyAndOrders">
                    <h3>Table #{{partyToCheckout.table.number}}'s Orders:</h3>
                    <div class="row titles">
                      <div class="col-sm-6">
                        <label><strong>Item</strong></label>
                      </div>
                      <div class="col-sm-6">
                        <span><strong>Price</strong></span>
                      </div>
                    </div>
                    <div v-for="order in partyToCheckout.orders" :key="order.Id">                    
                      <div v-for="itemOrder in order.items" :key="itemOrder.Id">
                        <div class="row">
                          <div class="col-sm-6">
                            <label v-bind:for="itemOrder.item.name">{{itemOrder.item.name}}</label>
                          </div>
                          <div class="col-sm-6">
                            <span>
                              {{itemOrder.item.priceDisplay}}
                              <span v-if="itemOrder.quantity > 1">(x{{itemOrder.quantity}})</span>
                            </span>
                          </div>
                        </div>
                      </div>
                    </div>
                    <totals :partyToCheckout="partyToCheckout"></totals>
                  </div>
                  <div v-else>
                    <h3>No orders for the party :(</h3>
                  </div>
                </form>
                <div class="btn-holder" style="margin-bottom: 20px;" v-if="partyAndOrders">
                  <button class="btn btn-lg btn-success" v-on:click="checkout">PRINT</button>
                </div>
              </div>
            </div>
          </div>
        </div>
      </div>
    </modal>
</template>
<script>
    import totals from './CheckoutTotals.vue'

    const MODAL_WIDTH = 900
    export default {
      name: 'checkoutmodal',

      components: { totals },

      data () {
        return {
          modalWidth: MODAL_WIDTH,
          model: {},
          tableNumber: 1,
          partyToCheckout: null
        }
      },
      computed: {
        partyAndOrders: function () {
          return this.partyToCheckout != null && this.partyToCheckout.orders.length > 0
        }
      },
      created () {
        this.$http
          .get('/api/checkout')
          .then((res) => {
            this.model = res.body
            this.setParty()
          })
          .catch((ex) => console.log(ex))
      },
      methods: {
        checkout () {
          fetch('/api/checkout/' + this.tableNumber,
            {
              method: 'GET'
            })
          .then(function (res) { res.json() })
        },
        setParty () {
          var tableNumber = this.tableNumber
          this.partyToCheckout = this.model.parties.find(function (party) {
            return party.table.number === tableNumber
          })
        }
      }
    }
</script>
<style lang="scss" scoped>
.checkout-modal-title {
    box-sizing: border-box;
    padding: 10px;
    width: 100%;
    text-align: center;
    letter-spacing: 1px;
    font-size: 35px;
    font-weight: 300;
  }
.box-checkout {
  background: white;
  overflow: hidden;
  width: 900px;
  height: 700px;
  border-radius: 2px;
  box-sizing: border-box;
  box-shadow: 0 0 40px black;
  color: #8b8c8d;
}

.total-row {
  font-size: 15px;
  font-weight: bold;
  color: #444444
}

.titles {
  margin-bottom: 10px;
  border-bottom: thin dotted gray;
}
</style>