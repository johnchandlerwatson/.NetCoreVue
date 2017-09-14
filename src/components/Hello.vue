<template>
  <div class="hello">
    <h1>Welcome to Servable+</h1>
    <div class="container">
      <div class="row">
        <div class="col-sm-12">
          <div class="flexrow">
            <div v-for="party in model.activeParties" :key="party.Id">
              <party :party="party"></party>
            </div>
          </div>
          <div class="btn-holder">
            <button v-on:click="showOrderModal" class="btn btn-lg btn-success">Add Order</button>
            <button v-on:click="showCheckoutModal" class="btn btn-lg btn-success">Checkout</button>
          </div>
        </div>
      </div>
    </div>
    <loginmodal/>
    <ordermodal/>
    <v-dialog/>
  </div>
</template>

<script>
  import party from './Party.vue'
  import loginmodal from './LoginModal.vue'
  import ordermodal from './OrderModal.vue'

  export default {
    name: 'hello',

    components: { party, loginmodal, ordermodal },

    data () {
      var model = {activeParties: [{table: {number: 1}}]}
      return {
        model
      }
    },
    created () {
      this.$http
          .get('/api/home')
          .then((res) => {
            this.model = res.body
          })
          .catch((ex) => console.log(ex))
    },
    mounted () {
      this.$modal.show('login-modal')
    },

    methods: {
      showOrderModal () {
        this.$modal.show('order-modal')
      },
      showCheckoutModal () {
        this.$modal.show('add-checkout-modal')
      }
    }
  }
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped>
h, h2 {
  font-weight: normal;
}

.btn-lg {
  margin-right: 20px;
}
</style>
