<%@ Control
  Language="C#" AutoEventWireup="true"
  CodeBehind="contentReportar.ascx.cs"
  Inherits="TuYaque.Secciones.contentReportar" %>
<div class="portfolio-modal modal fade" id="portfolioModal1" tabindex="-1"
  role="dialog" aria-labelledby="portfolioModal1Label" aria-hidden="true">
  <div class="modal-dialog modal-xl" role="document">
    <div class="modal-content">
      <button class="close" type="button" data-dismiss="modal" aria-label="Close">
        <span aria-hidden="true"><i class="fas fa-times"></i></span>
      </button>
      <div class="modal-body text-center">
        <div class="container">
          <div class="row justify-content-center">
            <div class="col-lg-8">
              <!-- Portfolio Modal - Title-->
              <h2 class="portfolio-modal-title text-secondary text-uppercase mb-0" id="portfolioModal1Label">Reporta</h2>
              <!-- Icon Divider-->
              <div class="divider-custom">
                <div class="divider-custom-line"></div>
                <div class="divider-custom-icon"><i class="fas fa-star"></i></div>
                <div class="divider-custom-line"></div>
              </div>

              <br />
              <form id="contactForm" name="sentMessage" novalidate="novalidate">
                <div class="control-group">
                  <div class="form-group floating-label-form-group controls mb-0 pb-2">
                    <label>¿Cúal es el problema?</label>
                    <textarea class="form-control" id="message" rows="5" placeholder="¿Cúal es el problema?"
                      required="required"
                      data-validation-required-message="Please enter a message."></textarea>
                    <p class="help-block text-danger"></p>
                  </div>
                </div>
                <div class="control-group">
                  <div class="form-group floating-label-form-group controls mb-0 pb-2">
                    <label>¿Dónde esta el problema?</label>
                    <textarea class="form-control" id="message" rows="5" placeholder="¿Dónde esta el problema?"
                      required="required" data-validation-required-message="Please enter a message.">
                    </textarea>
                    <p class="help-block text-danger"></p>
                  </div>
                </div>
                <br />
                <br />

                <div class="mapouter">
                  <div class="gmap_canvas">
                    <iframe style="width: 100%" height="500" id="gmap_canvas"
                      src="https://maps.google.com/maps?q=university%20of%20san%20francisco&t=&z=13&ie=UTF8&iwloc=&output=embed"
                      frameborder="0" scrolling="no" marginheight="0"
                      marginwidth="0"></iframe>
                    <a href="https://embedgooglemap.net/127/">86</a>
                  </div>
                  <style>
                    .mapouter {
                      position: relative;
                      text-align: right;
                      height: 500px;
                      width: 100%;
                    }

                    .gmap_canvas {
                      overflow: hidden;
                      background: none !important;
                      height: 100%;
                      /*width: 100%;*/
                    }
                  </style>
                </div>

                <br />
                <h2>Puedes reportar de forma anonima o dejarnos tus datos </h2>
                <div class="control-group">
                  <div class="form-group floating-label-form-group controls mb-0 pb-2">
                    <label>Nombre completo</label>
                    <input class="form-control" id="name" type="text" placeholder="Nombre Completo" required="required" data-validation-required-message="Please enter your name." />
                    <p class="help-block text-danger"></p>
                  </div>
                </div>
                <div class="control-group">
                  <div class="form-group floating-label-form-group controls mb-0 pb-2">
                    <label>Correo electronico</label>
                    <input class="form-control" id="email" type="email" placeholder="Correo electronico" required="required" data-validation-required-message="Please enter your email address." />
                    <p class="help-block text-danger"></p>
                  </div>
                </div>

                <div id="success"></div>
                <div class="form-group">
                  <button class="btn btn-primary btn-xl" id="sendMessageButton" type="submit">Enviar</button>
                  <button class="btn btn-primary" data-dismiss="modal">
                    <i class="fas fa-times fa-fw"></i>
                    Close Window
                  </button>
                  <button class="btn btn-primary" id="ReportarBtnEnviar">
                    <i class="fas fa-times fa-fw"></i>Enviar
                  </button>
                </div>

              </form>
            </div>
          </div>
        </div>
      </div>
    </div>
  </div>
</div>
