<template>
    <p>{{ party.table.number }}</p>
</template>

<script>
  console.log(this.table)
  export default {
    name: 'party',

    props: {
      'party': {
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

</style>
