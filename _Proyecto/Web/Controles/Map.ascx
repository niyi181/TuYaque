<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Map.ascx.cs" Inherits="TuYaque.Controles.Map" %>

<script type="text/javascript">

  /*
  var greenIcon = new L.Icon({
    iconUrl: 'https://raw.githubusercontent.com/pointhi/leaflet-color-markers/master/img/marker-icon-2x-green.png',
    shadowUrl: 'https://cdnjs.cloudflare.com/ajax/libs/leaflet/0.7.7/images/marker-shadow.png',
    iconSize: [25, 41],
    iconAnchor: [12, 41],
    popupAnchor: [1, -34],
    shadowSize: [41, 41]
  });*/
  //L.marker([51.5, -0.09], { icon: greenIcon }).addTo(map);
  var mymap;
  var newMarker = null;

  function LoadMap() {

    navigator.geolocation.getCurrentPosition(function (location) {
      var latlng = new L.LatLng(location.coords.latitude, location.coords.longitude);

      mymap = L.map('mapid').setView(latlng, 15)
      L.tileLayer('https://api.tiles.mapbox.com/v4/{id}/{z}/{x}/{y}.png?access_token={accessToken}', {
        attribution: 'Map data &copy; <a href="http://openstreetmap.org">OpenStreetMap</a> contributors, <a href="http://creativecommons.org/licenses/by-sa/2.0/">CC-BY-SA</a>, Imagery © <a href="https://mapbox.com">Mapbox</a>',
        maxZoom: 100,
        id: 'mapbox.streets',
        accessToken: 'pk.eyJ1IjoibWFwYm94IiwiYSI6ImNpejY4NXVycTA2emYycXBndHRqcmZ3N3gifQ.rJcFIG214AriISLbB6B5aw'
      }).addTo(mymap);

      newMarker = L.marker(latlng).addTo(mymap)
        .bindPopup("<b>Tu ubicación Actual!</b><br />Marca el punto de Reporte").openPopup();

      /*
      L.circle([51.508, -0.11], 500, {
        color: 'red',
        fillColor: '#f03',
        fillOpacity: 0.5
      }).addTo(mymap).bindPopup("I am a circle.");
 
      L.polygon([
        [51.509, -0.08],
        [51.503, -0.06],
        [51.51, -0.047]
      ]).addTo(mymap).bindPopup("I am a polygon.");
      */

      popup = L.popup();
      mymap.on('click', onMapClick);
    });

    function onMapClick(e) {
      if (newMarker != null) {
        newMarker.setLatLng(e.latlng)
          .bindPopup("<b>Punto seleccionado</b><br />Listo para Reportar").openPopup();
        /*} else {
          newMarker = new L.marker(e.latlng).addTo(mymap)
            .bindPopup("<b>Punto Seleccionado</b><br />Listo para Reportar").openPopup();*/
      }
      $("#maphf_lat").val(e.latlng.lat);
      $("#maphf_lon").val(e.latlng.lng);
      /*popup
        .setLatLng(e.latlng)
        .setContent("You clicked the map at " + e.latlng.toString())
        .openOn(mymap);*/
    }
  }

</script>

<div id="mapid"></div>
<input type="hidden" id="maphf_lat" Value="0" />
<input type="hidden" id="maphf_lon" Value="0" />

