var infowindow = new google.maps.InfoWindow();
var marker1, marker2, marker3, info, map;
var bus1, bus2, bus3;
var occupied, vacant, capacity;
var flag = false;

$(document).ready(function(){
	
	InitializeHashHandler();

});

/// http://stackoverflow.com/questions/4474177/google-maps-panto
/// http://stackoverflow.com/questions/6191714/google-maps-panto-onclick
/// https://developers.google.com/maps/documentation/javascript/reference
/// http://stackoverflow.com/questions/8024784/how-to-move-marker-in-google-maps-api
/// http://stackoverflow.com/questions/4504636/google-maps-moving-marker-on-click

/// this will method will initialize the hashchange event in the browser
function InitializeHashHandler(){
	$(window).bind('hashchange', function() {
		// replace the '#' char to empty. this character will be find in the first index of the hash change value
		var hash = (window.location.hash).replace("#", "");
		console.log(hash);
		// splitting value to get the lat , long and info 
		// <url>http://www.tizag.com/javascriptT/javascript-string-split.php</url>
		// Bus number value
		console.log("Bus number: " + hash.split("&")[0]);
		// Bus Lattitude value
		console.log("Bus lattitude: " + hash.split("&")[1]);
		// Bus Longitude value
		console.log("Bus longitude: " + hash.split("&")[2]);
		// Bus information value
		console.log("Bus Details: " + hash.split("&")[3]);
		// Bus Occupied
		occupied = hash.split("&")[4];
		// Bus Vacanct
		vacant = hash.split("&")[5];
		// Bus Capacity
		capacity = hash.split("&")[6];

		if(!flag) {
			// send to function InitInitializeMap to set the Google map in the browser
			InitializeMap(hash.split("&")[1], hash.split("&")[2]);
			flag = true;
		}

		setBusNumber(hash.split("&")[0]);

		if(bus1 == hash.split("&")[0]){
			moveBus1(hash.split("&")[1], hash.split("&")[2]);
			// send to function InitializeMapMarkerInformation to set Google map marker's information
			InitializeMapMarkerInformation(marker1, hash.split("&")[3]);

			// assign bus # in bus information panel
			$('#bus_number1').html("");
			$('#bus_number1').html("Bus # " + hash.split("&")[0]);
			// assign capacity, occupied and vacant
			$('#occupied1').html(occupied); 
			$('#vacancy1').html(vacant); 
			$('#capacity1').html(capacity); 

		} else if(bus2 == hash.split("&")[0]){
			moveBus2(hash.split("&")[1], hash.split("&")[2]);
			// send to function InitializeMapMarkerInformation to set Google map marker's information
			InitializeMapMarkerInformation(marker2, hash.split("&")[3]);

			// assign bus # in bus information panel
			$('#bus_number2').html("");
			$('#bus_number2').html("Bus # " + hash.split("&")[0]);
			// assign capacity, occupied and vacant
			$('#occupied2').html(occupied); 
			$('#vacancy2').html(vacant); 
			$('#capacity2').html(capacity); 

		} else if(bus3 == hash.split("&")[0]){
			moveBus3(hash.split("&")[1], hash.split("&")[2]);
			// send to function InitializeMapMarkerInformation to set Google map marker's information
			InitializeMapMarkerInformation(marker3, hash.split("&")[3]);

			// assign bus # in bus information panel
			$('#bus_number3').html("");
			$('#bus_number3').html("Bus # " + hash.split("&")[0]);
			// assign capacity, occupied and vacant
			$('#occupied3').html(occupied); 
			$('#vacancy3').html(vacant); 
			$('#capacity3').html(capacity); 

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

function InitializeMapMarker1(busNumber, lattitude, longitude){
	/*
	marker1 = new google.maps.Marker({
		position: new google.maps.LatLng(lattitude, longitude),
		map: map,
		title: busNumber
	});*/

	marker1 = new MarkerWithLabel({
       position: new google.maps.LatLng(lattitude, longitude),
       draggable: true,
       raiseOnDrag: true,
       map: map,
       labelContent: busNumber,
       labelAnchor: new google.maps.Point(22, 0),
       labelClass: "labels", // the CSS class for the label
       labelStyle: {opacity: 0.75}
     });
}

function InitializeMapMarker2(busNumber, lattitude, longitude){
  
	marker2 = new MarkerWithLabel({
       position: new google.maps.LatLng(lattitude, longitude),
       draggable: true,
       raiseOnDrag: true,
       map: map,
       labelContent: busNumber,
       labelAnchor: new google.maps.Point(22, 0),
       labelClass: "labels", // the CSS class for the label
       labelStyle: {opacity: 0.75}
     });
}

function InitializeMapMarker3(busNumber, lattitude, longitude){
  
	marker3 = new MarkerWithLabel({
       position: new google.maps.LatLng(lattitude, longitude),
       draggable: true,
       raiseOnDrag: true,
       map: map,
       labelContent: busNumber,
       labelAnchor: new google.maps.Point(22, 0),
       labelClass: "labels", // the CSS class for the label
       labelStyle: {opacity: 0.75}
     });
}

function InitializeMapMarkerInformation(marker, busInfo){


	google.maps.event.addListener(marker, 'click', (function (marker, info) {
		return function () {
			infowindow.setContent(busInfo);
			infowindow.open(map, marker);
		}
	})(marker, info));
}

function moveBus1(lattitude, longitude) {
    marker1.setPosition(new google.maps.LatLng(lattitude, longitude));
    map.panTo(new google.maps.LatLng(lattitude, longitude));
}

function moveBus2(lattitude, longitude) {
    marker2.setPosition(new google.maps.LatLng(lattitude, longitude));
    map.panTo(new google.maps.LatLng(lattitude, longitude));
}

function moveBus3(lattitude, longitude) {
    marker3.setPosition(new google.maps.LatLng(lattitude, longitude));
    map.panTo(new google.maps.LatLng(lattitude, longitude));
}

function moveBus(marker, lattitude, longitude) {
    marker.setPosition(new google.maps.LatLng(lattitude, longitude));
    map.panTo(new google.maps.LatLng(lattitude, longitude));
}

function setBusNumber(busnumber, lattitude, longitude){
	/// set bus number
	if(bus1 == undefined || bus1 == null || bus1 == ''){
		bus1 = busnumber;
		// initialize marker1
		InitializeMapMarker1(busnumber, lattitude, longitude);
	} else if(bus2 == undefined || bus2 == null || bus2 == ''){
		bus2 = busnumber;
		// initialize marker2
		InitializeMapMarker2(busnumber, lattitude, longitude);
	} else if(bus3 == undefined || bus3 == null || bus3 == ''){
		bus3 = busnumber;
		// initialize marker3
		InitializeMapMarker3(busnumber, lattitude, longitude);
	}
}