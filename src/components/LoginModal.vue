<template>
    <modal name="loginmodal" transition="pop-out" :width="modalWidth" :height="250" @before-close="beforeClose">
        <div class="box">
            <div class="box-part" id="bp-left">
                <div class="partition" id="partition-register">
                    <div class="partition-title">LOG-IN</div>                      
                        <div class="partition-form">
                            <form autocomplete="false">
                                <input v-bind:class="{ notValid: notValidPin & loginAttempts > 0 }" v-model="pin" type="text" placeholder="Pin">
                            </form>
                            <div style="margin-top: 42px"></div>
                            <div class="button-set">
                                <button v-on:click="validatePin">Log In</button>
                            </div>
                        </div>
                    </div>
                    </div>
                    <div class="box-messages">
                </div>
            </div>
        </div>
    </modal>
</template>

<script>
    const MODAL_WIDTH = 656
    export default {
      name: 'loginmodal',
      data () {
        return {
          modalWidth: MODAL_WIDTH,
          pin: '',
          notValidPin: true,
          loginAttempts: 0
        }
      },
      created () {
        this.modalWidth = window.innerWidth < MODAL_WIDTH
        ? MODAL_WIDTH / 2
        : MODAL_WIDTH
      },
      methods: {
        validatePin () {
          this.loginAttempts++
          this.$http
            .get('/api/home/validatepin/' + this.pin)
            .then((res) => {
              if (res.body) {
                this.notValidPin = false
                this.$modal.hide('loginmodal')
              } else {
                this.notValidPin = true
              }
            })
            .catch((ex) => console.log(ex))
        },
        beforeClose (event) {
          if (this.notValidPin) {
            event.stop()
          }
        }
      }
    }
</script>
<style lang="scss">
$background_color: #404142;
.box {
  background: white;
  overflow: hidden;
  width: 656px;
  height: 400px;
  border-radius: 2px;
  box-sizing: border-box;
  box-shadow: 0 0 40px black;
  color: #8b8c8d;
  font-size: 0;
  .box-part {
    display: inline-block;
    position: relative;
    vertical-align: top;
    box-sizing: border-box;
    height: 100%;
    width: 100%;
  }
  .box-messages {
    position: absolute;
    left: 0;
    bottom: 0;
    width: 100%;
  }
  .box-error-message {
    position: relative;
    overflow: hidden;
    box-sizing: border-box;
    height: 0;
    line-height: 32px;
    padding: 0 12px;
    text-align: center;
    width: 100%;
    font-size: 15px;
    color: white;
    background: #F38181;
  }
  .partition {
    width: 100%;
    height: 100%;
    .partition-title {
      box-sizing: border-box;
      padding: 30px;
      width: 100%;
      text-align: center;
      letter-spacing: 1px;
      font-size: 25px;
      font-weight: 300;
    }
    .partition-form {
      padding: 0 20px;
      box-sizing: border-box;
    }
  }
  input[type=password],
  input[type=text] {
    display: block;
    box-sizing: border-box;
    margin-bottom: 4px;
    width: 100%;
    font-size: 18px;
    line-height: 2;
    border: 0;
    border-bottom: 1px solid #DDDEDF;
    padding: 4px 8px;
    font-family: inherit;
    transition: 0.5s all;
    outline: none;
  }
  button {
    background: white;
    border-radius: 4px;
    box-sizing: border-box;
    padding: 10px;
    letter-spacing: 1px;
    font-family: "Open Sans", sans-serif;
    font-weight: 400;
    min-width: 140px;
    margin-top: 8px;
    color: #8b8c8d;
    cursor: pointer;
    border: 1px solid #DDDEDF;
    text-transform: uppercase;
    transition: 0.1s all;
    font-size: 10px;
    outline: none;
    &:hover {
      border-color: mix(#DDDEDF, black, 90%);
      color: mix(#8b8c8d, black, 80%);
    }
  }
  .large-btn {
    width: 100%;
    background: white;
    span {
      font-weight: 600;
    }
    &:hover {
      color: white !important;
    }
  }
  .button-set {
    margin-bottom: 8px;
  }
}
.pop-out-enter-active,
.pop-out-leave-active {
  transition: all 0.5s;
}
.pop-out-enter,
.pop-out-leave-active {
  opacity: 0;
  transform: translateY(24px);
}
.notValid {
    border: 5px solid #ffdddd !important;
}
</style>