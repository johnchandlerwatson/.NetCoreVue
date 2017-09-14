<template>
    <modal name="order-modal" transition="pop-out" :width="modalWidth" :pivotY=0.0 height="auto" :scrollable="true" @before-close="beforeClose">
        <div class=".box-order ">
          <div class="order-modal-title">ADD ORDER</div>                      
              <div class="partition-form">
                <form autocomplete="false">
                  <div class="category" v-for="category in model.categories" :key="category.Id">
                    <h3>{{category.itemType}}</h3>
                    <div class="subsection" v-for="subcategory in category.subcategories" :key="subcategory.Id">
                      <h4>{{subcategory.itemSubType}}</h4>                       
                      <div class="flexrow-left">
                        <div v-for="itemOrder in subcategory.items" :key="itemOrder.Id">
                          <item :item="itemOrder.item"></item>
                        </div>
                      </div>                       
                    </div>
                  </div>
                </form>
                <div class="btn-holder" style="margin-bottom: 20px;">
                  <button class="btn btn-lg btn-success" v-on:click="addOrder">ADD</button>
                </div>
              </div>
            </div>
          </div>
        </div>
    </modal>
</template>
<script>
    import item from './Item.vue'

    const MODAL_WIDTH = 900
    export default {
      name: 'ordermodal',

      components: { item },

      data () {
        return {
          modalWidth: MODAL_WIDTH,
          model: {}
        }
      },
      created () {
        this.$http
          .get('/api/orders/items')
          .then((res) => {
            this.model = res.body
          })
          .catch((ex) => console.log(ex))
      },
      methods: {
        addOrder () {
          this.$http
            .post('/api/orders/add', { categories: this.model.categories })
            .then((res) => {
              if (res.body) {
                this.$modal.hide('order-modal')
              }
            })
            .catch((ex) => console.log(ex))
        },
        beforeClose (event) {
          if (this.notValidPin) {
            event.stop()
          }
        },
        entermonitor: function (event) {
          if (event.key === 'Enter') {
            this.validatePin()
          }
        }
      }
    }
</script>
<style lang="scss" scoped>
.order-modal-title {
    box-sizing: border-box;
    padding: 10px;
    width: 100%;
    text-align: center;
    letter-spacing: 1px;
    font-size: 35px;
    font-weight: 300;
  }
.box-order {
  background: white;
  overflow: hidden;
  width: 900px;
  height: 700px;
  border-radius: 2px;
  box-sizing: border-box;
  box-shadow: 0 0 40px black;
  color: #8b8c8d;
  font-size: 0;
}
.flexrow-left {
  display: flex;
  flex-direction: row;
  justify-content: flex-start;
}

.subsection {
  padding-left: 15px;
}

.category {
  background:#d9dde2;
  border-radius: 10px;
  padding: 15px;
  margin-bottom: 7px;
}
</style>