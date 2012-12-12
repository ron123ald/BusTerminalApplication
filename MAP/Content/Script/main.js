var infowindow = new google.maps.InfoWindow();
var marker, i;
var map;

$(document).ready(function(){
	
	InitializeHashHandler();

});

/// this will method will initialize the hashchange event in the browser
function InitializeHashHandler(){
  $(window).bind('hashchange', function() {
      // replace the '#' char to empty. this character will be find in the first index of the hash change value
      var hash = (window.location.hash).replace("#", "");
      // splitting value to get the lat , long and info 
      // <url>http://www.tizag.com/javascriptT/javascript-string-split.php</url>
      // Lattitude value
      console.log(hash.split("&")[0]);
      // Longitude value
      console.log(hash.split("&")[1]);
      // Bus information value
      console.log(hash.split("&")[2]);

      // send to function InitInitializeMap to set the Google map in the browser
      InitializeMap(hash.split("&")[0], hash.split("&")[1]);

      // send to function InitializeMapMarker to set the Google map's marker
      InitializeMapMarker(hash.split("&")[0], hash.split("&")[1]);

      // check if the variable this.i (in global declaration) is null
      // purpose of this checking is to see if the the Information has been set or not
      // if the information is set there for we will not update it.
      // if not. update.
      if(this.i == null) {
        // send to function InitializeMapMarkerInformation to set Google map marker's information
        InitializeMapMarkerInformation(hash.split("&")[2]);
      }
	});
}

function InitializeMap(lattitude, longitude){  

  map = new google.maps.Map(document.getElementById('map'), {
    zoom: 18,
    center: new google.maps.LatLng(lattitude, longitude),
    mapTypeId: google.maps.MapTypeId.ROADMAP
  });  
}

function InitializeMapMarker(lattitude, longitude){
  
  marker = new google.maps.Marker({
    position: new google.maps.LatLng(lattitude, longitude),
    map: map,
    title: "Bus"
  });
}

function InitializeMapMarkerInformation(busInfo){

   google.maps.event.addListener(marker, 'click', (function (marker, i) {
    return function () {
      infowindow.setContent(busInfo);
      infowindow.open(map, marker);
    }
  })(marker, i));
}