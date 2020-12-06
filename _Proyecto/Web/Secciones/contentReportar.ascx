<%@ Control
  Language="C#" AutoEventWireup="true"
  CodeBehind="contentReportar.ascx.cs"
  Inherits="TuYaque.Secciones.contentReportar" %>

<%@ Register Src="~/Controles/Map.ascx" TagPrefix="uc1" TagName="Map" %>

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
            <div class="col-lg-10">
              <!-- Portfolio Modal - Title-->
              <h2 class="portfolio-modal-title text-secondary text-uppercase mb-0" id="portfolioModal1Label">Reporta</h2>
              <!-- Icon Divider-->
              <div class="divider-custom">
                <div class="divider-custom-line"></div>
              </div>
              <br />
              <form id="reportarForm" novalidate="novalidate">
                <div class="control-group">
                  <div class="form-group floating-label-form-group controls mb-0 pb-2">
                    <textarea class="form-control" id="txtproblema" rows="2" 
                      placeholder="¿Cuál es el problema?"
                      required="required"
                      data-validation-required-message="Por favor completar la descripción del problema"></textarea>
                  </div>
                </div>
                <br />
                <div class="control-group">
                  <label>Comparte la evidencia</label><br />
                  <input type="file" accept="image/*;capture=camera" id="evidencia1" />
                  <input type="file" accept="image/*;capture=camera" id="evidencia2" />
                </div>
                <br />
                <uc1:Map runat="server" ID="Map" />
                <br />
                <div class="control-group">
                  <h4>Puedes reportar de forma anónima o dejarnos tus datos</h4>
                  <div class="form-group floating-label-form-group controls mb-0 pb-2">
                    <input class="form-control" id="txtname" 
                      type="text" placeholder="Nombre Completo" />
                  </div>
                  <div class="form-group floating-label-form-group controls mb-0 pb-2">
                    <input class="form-control" id="txtemail" type="email" 
                      placeholder="Correo electronico" required="required"
                      data-validation-required-message="Por favor escriba una dirección electrónica" />
                  </div>
                </div>
                <br />
                <div class="form-group">
                  <button class="btn btn-primary" type="submit" id="ReportarBtnEnviar">Enviar</button>
                  <button class="btn btn-primary" data-dismiss="modal">
                    <i class="fas fa-times fa-fw"></i>Cerrar
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
