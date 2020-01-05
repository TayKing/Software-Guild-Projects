// home.js

$(document).ready(function() {

  $('#getWeather').click(function (event) {

    clearWeatherInfo();
    retrieveWeatherInfo();

  });

});

function retrieveWeatherInfo() {
  var units = $("#units").val();
  var degree = ' F';
  var unitsurl = '&units=';
  var windSpeed = ' miles/hour'

  if ( units == 'imperial') {
    degree = ' F';
    unitsurl += 'imperial';
    windspeed = ' miles/hour';
  } else {
    degree = ' C';
    unitsurl += 'metric';
    windspeed = ' kilometers/hour';
  }

  $.ajax({
    type: 'GET',
    url: 'http://api.openweathermap.org/data/2.5/forecast?zip=' + $('#zip-code').val() + '&APPID=951d5b61f16c0f7e98a230dc673583f3' + unitsurl,
    success: function(weatherArray) {

        $('#currentConditionsCity').text('Current Conditions in ' + weatherArray.city.name);

        $('#currentConditionsIcon')
            .append($('<img>')
            .attr({src: 'http://openweathermap.org/img/w/' + weatherArray.list[0].weather[0].icon + '.png'}))
            .append(weatherArray.list[0].weather[0].main + ': ' + weatherArray.list[0].weather[0].description);

        $('#currentConditions')
        .append($('<p>')
        .text('Temperature: ' + weatherArray.list[0].main.temp + degree))
        .append($('<p>')
        .text('Humidity: ' + weatherArray.list[0].main.humidity + '%'))
        .append($('<p>')
        .text('Wind: ' + weatherArray.list[0].wind.speed + windspeed));

        var startDate = weatherArray.list[0].dt_txt.split(" ");
        var day = startDate[0];
        var forecastCount = 1;
        var arrayCount = weatherArray.cnt;
        var count = 0;
        var minTemp = 100;
        var maxTemp = -100;
        var displayDate = new Date(day).toUTCString().split( " ")

        $.each(weatherArray.list, function(index, object) {

          var newDate = object.dt_txt.split(" ");
          var newMinTemp = object.main.temp;
          var newMaxTemp = object.main.temp;

          var d = new Date(newDate[0]);
          var month = new Array();
          month[0] = "January";
          month[1] = "February";
          month[2] = "March";
          month[3] = "April";
          month[4] = "May";
          month[5] = "June";
          month[6] = "July";
          month[7] = "August";
          month[8] = "September";
          month[9] = "October";
          month[10] = "November";
          month[11] = "December";
          var displayMonth = month[d.getMonth()];

          if(newMinTemp < minTemp)
          {
            minTemp = newMinTemp;
          }

          if(newMaxTemp > maxTemp)
          {
            maxTemp = newMaxTemp;
          }

          count += 1;

          if(newDate[0] != day){
            $('#forecast-' + forecastCount)
            .append($('<p>')
            .text(displayDate[1] + " " + displayMonth))
            .append($('<img>')
            .attr({src: 'http://openweathermap.org/img/w/' + object.weather[0].icon + '.png'}))
            .append(object.weather[0].main)
            .append($('<p>')
            .text('H ' + maxTemp + degree + ' L ' + minTemp + degree))
              minTemp = 100;
              maxTemp = -100
              day = newDate[0];
              displayDate = new Date(day).toUTCString().split( " ");
              forecastCount += 1;
          }

          if ( count == arrayCount) {
            $('#forecast-' + forecastCount)
            .append($('<p>')
            .text(displayDate[1] + " " + displayMonth))
            .append($('<img>')
            .attr({src: 'http://openweathermap.org/img/w/' + object.weather[0].icon + '.png'}))
            .append(object.weather[0].main)
            .append($('<p>')
            .text('H ' + maxTemp + degree + ' L ' + minTemp + degree))
          }

        });

        $('#weatherInfo').show();
  },

    error: function() {
      $('#errorMessages')
        .append($('<li>')
        .attr({class: 'list-group-item list-group-item-danger'})
        .text('Zipcode: Please enter a 5-digit zip code.'));
    }

  });
}

function clearWeatherInfo() {
  $('#currentConditions').empty();
  $('#currentConditionsIcon').empty();
  $('#forecast-1').empty();
  $('#forecast-2').empty();
  $('#forecast-3').empty();
  $('#forecast-4').empty();
  $('#forecast-5').empty();
}
