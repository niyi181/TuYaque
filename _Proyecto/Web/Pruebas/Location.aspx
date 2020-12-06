<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Location.aspx.cs" Inherits="TuYaque.Location" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
  <title></title>
  <script src="Scripts/jquery-3.5.1.min.js"></script>
  <script type="text/javascript">
    var x;
    function getLocation() {
      if (navigator.geolocation) {
        navigator.geolocation.getCurrentPosition(showPosition);
      } else {
        x.innerHTML = "Geolocation is not supported by this browser.";
        alert("mal");
      }
    }
    function showPosition(position) {
      alert(position.coords.latitude);
      x.innerHTML = "Latitude: " + position.coords.latitude +
        "<br>Longitude: " + position.coords.longitude;
    }

    $(document).ready(function () {
      console.log("ready!");
      x = document.getElementById("demo");
    });

  </script>
</head>
<body>
  <button onclick="getLocation()">Try It</button>
  <p id="demo"></p>
  <form id="form1" runat="server">
  </form>
</body>
</html>
