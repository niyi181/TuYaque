<%@ Page Title="" Language="C#" MasterPageFile="~/Plantilla.Master" AutoEventWireup="true" CodeBehind="DefaultConPlantilla.aspx.cs" Inherits="TuYaque.Default1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="ContentHeader" runat="server">
  <!-- Masthead Avatar Image-->
  <img class="masthead-avatar mb-5" src="assets/img/avataaars.svg" alt="" />
  <!-- Masthead Heading-->
  <h1 class="masthead-heading text-uppercase mb-0">¿Estas listo para el Reto?</h1>
  <!-- Icon Divider-->
  <div class="divider-custom divider-light">
    <div class="divider-custom-line"></div>
    <div class="divider-custom-icon"><i class="fas fa-star"></i></div>
    <div class="divider-custom-line"></div>
  </div>
  <!-- Masthead Subheading-->
  <p class="masthead-subheading font-weight-light mb-0">
    asdlkjas lkdjsakdjsalkd jklsajd klasjdklsajkd lasjld asd
    sa dkasjd lksajd lkjasd lkasjlkdasjlkd aslkd jhsalkd jaslkjd aslkjd laskj dlkasjdlkjadlasjl da
    sa dlkajsdlkjaslkdasjkdjaskldjaslkd jaslk djaslksl
  </p>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Content" runat="server">

  <!-- Portfolio Section-->
  <section class="page-section portfolio" id="portfolio">
    <div class="container">
      <!-- Portfolio Section Heading-->
      <h2 class="page-section-heading text-center text-uppercase text-secondary mb-0">Opciones</h2>
      <!-- Icon Divider-->
      <div class="divider-custom">
        <div class="divider-custom-line"></div>
        <div class="divider-custom-icon"><i class="fas fa-star"></i></div>
        <div class="divider-custom-line"></div>
      </div>
      <!-- Portfolio Grid Items-->
      <div class="row justify-content-center">
        <!-- Portfolio Item 1-->
        <div class="col-md-6 col-lg-4 mb-5">
          <a href="Reporta.aspx">
            <div class="portfolio-item mx-auto">
              <div class="portfolio-item-caption d-flex align-items-center justify-content-center h-100 w-100">
                <div class="portfolio-item-caption-content text-center text-white"><i class="fas fa-plus fa-3x"></i></div>
              </div>
              <img class="img-fluid" src="assets/img/portfolio/cabin.png" alt="" />
              <h2 class="text-center text-uppercase text-primary mb-0">Reporta</h2>
            </div>
          </a>
        </div>
        <!-- Portfolio Item 2-->
        <div class="col-md-6 col-lg-4 mb-5">
          <div class="portfolio-item mx-auto" data-toggle="modal" data-target="#portfolioModal2">
            <div class="portfolio-item-caption d-flex align-items-center justify-content-center h-100 w-100">
              <div class="portfolio-item-caption-content text-center text-white"><i class="fas fa-plus fa-3x"></i></div>
            </div>
            <img class="img-fluid" src="assets/img/portfolio/cake.png" alt="" />
            <h2 class="text-center text-uppercase text-primary mb-0">Conoce tu Rio</h2>
          </div>
        </div>
        <!-- Portfolio Item 3-->
        <div class="col-md-6 col-lg-4 mb-5">
          <div class="portfolio-item mx-auto" data-toggle="modal" data-target="#portfolioModal3">
            <div class="portfolio-item-caption d-flex align-items-center justify-content-center h-100 w-100">
              <div class="portfolio-item-caption-content text-center text-white"><i class="fas fa-plus fa-3x"></i></div>
            </div>
            <img class="img-fluid" src="assets/img/portfolio/circus.png" alt="" />
            <h2 class="text-center text-uppercase text-primary mb-0">Unéte al Reto</h2>
          </div>
        </div>
        <!-- Portfolio Item 4-->
        <div class="col-md-6 col-lg-4 mb-5 mb-lg-0">
          <div class="portfolio-item mx-auto" data-toggle="modal" data-target="#portfolioModal4">
            <div class="portfolio-item-caption d-flex align-items-center justify-content-center h-100 w-100">
              <div class="portfolio-item-caption-content text-center text-white"><i class="fas fa-plus fa-3x"></i></div>
            </div>
            <img class="img-fluid" src="assets/img/portfolio/game.png" alt="" />
            <h2 class="text-center text-uppercase text-primary mb-0">Llama a la Acción</h2>
          </div>
        </div>
      </div>
    </div>
  </section>

  <!-- About Section-->
  <section class="page-section bg-primary text-white mb-0" id="about">
    <div class="container">
      <!-- About Section Heading-->
      <h2 class="page-section-heading text-center text-uppercase text-white">Sobre nosotros</h2>
      <!-- Icon Divider-->
      <div class="divider-custom divider-light">
        <div class="divider-custom-line"></div>
        <div class="divider-custom-icon"><i class="fas fa-star"></i></div>
        <div class="divider-custom-line"></div>
      </div>
      <!-- About Section Content-->
      <div class="row">
        <div class="col-lg-4 ml-auto">
          <p class="lead">Freelancer is a free bootstrap theme created by Start Bootstrap. The download includes the complete source files including HTML, CSS, and JavaScript as well as optional SASS stylesheets for easy customization.</p>
        </div>
        <div class="col-lg-4 mr-auto">
          <p class="lead">You can create your own custom avatar for the masthead, change the icon in the dividers, and add your email address to the contact form to make it fully functional!</p>
        </div>
      </div>
    </div>
  </section>

</asp:Content>
