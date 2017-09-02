<template>
  <div class="hello">
    <h1>{{ msg }}</h1>
    <div class="container">
      <div class="row">
        <div class="col-sm-12">
          <p>testing bootstrap</p>
          <button class="btn btn-lg btn-success">Click me!</button>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
  export default {
    name: 'hello',
    data () {
      return {
        msg: 'Pulling data..'
      }
    },
    // Send a request to /api/profile
    created () {
      this.$http
          .get('/api/home')
          .then((res) => {
            console.log(res.body)
            this.msg = 'Active Table # ' + res.body.activeParties[0].table.number
          })
          .catch((ex) => console.log(ex))
    }
  }
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped>
h1, h2 {
  font-weight: normal;
}
</style>
