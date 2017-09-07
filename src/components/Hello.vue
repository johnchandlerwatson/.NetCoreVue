<template>
  <div class="hello">
    <h1>Welcome to Serve+</h1>
    <div class="container">
      <div class="row">
        <div class="col-sm-12">
          <div class="flexrow">
            <div v-for="party in model.activeParties" :key="party.Id">
              <party :party="party"></party>
            </div>
          </div>
        </div>
      </div>
    </div>
    <loginmodal/>
    <v-dialog/>
  </div>
</template>

<script>
  import party from './Party.vue'
  import loginmodal from './LoginModal.vue'

  export default {
    name: 'hello',

    components: { party, loginmodal },

    data () {
      var model = {activeParties: [{table: {number: 1}}]}
      return {
        model
      }
    },
    // Send a request to /api/profile
    created () {
      this.$http
          .get('/api/home')
          .then((res) => {
            this.model = res.body
          })
          .catch((ex) => console.log(ex))
    },
    mounted () {
      this.$modal.show('loginmodal')
    }
  }
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped>
h, h2 {
  font-weight: normal;
}
</style>
