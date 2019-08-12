// home.js

$(document).ready(function() {

    LoadMachine();

    $('div').find('.box').click(SelectedItem);

    $('#add-nickel').click(AddNickel);
    $('#add-dime').click(AddDime);
    $('#add-quarter').click(AddQuarter);
    $('#add-dollar').click(AddDollar);
    $('#change-return').click(Change);

    $('#purchase').click(PurchaseItem);

});

function SelectedItem() {

  $('#messages').val('');
  var moneyDeposited = $('#total-monies').val();
  var itemID = this.id;
  $('#vending').val(itemID);

  $('#change-return').hide();

}

function AddNickel() {

   var totalMonies = parseFloat($('#total-monies').val(), 10) + .05;

  $('#total-monies').val(totalMonies.toFixed(2));

}

function AddDime() {

   var totalMonies = parseFloat($('#total-monies').val(), 10) + .10;

  $('#total-monies').val(totalMonies.toFixed(2));

}

function AddQuarter() {

   var totalMonies = parseFloat($('#total-monies').val(), 10) + .25;

  $('#total-monies').val(totalMonies.toFixed(2));

}

function AddDollar() {

   var totalMonies = parseFloat($('#total-monies').val(), 10) + 1.00;

  $('#total-monies').val(totalMonies.toFixed(2));

}

function Change() {

  var changeReturn = $('#total-monies').val().toString();
  var changeTotal = (changeReturn + '').replace('.','');
  var changeRemainder = parseInt(changeTotal);
  var displayChange = '';

  var changeDollars = Math.floor(changeRemainder / 100);
  changeRemainder = changeRemainder % 100;
  if (changeDollars >= 1) {
    if (changeDollars > 1) {
      displayChange = changeDollars + ' Dollars ';
    }
    else {
      displayChange += changeDollars + ' Dollar ';
    }
  }
  var changeQuarters = Math.floor(changeRemainder / 25);
  changeRemainder = changeRemainder % 25;
  if (changeQuarters >= 1) {
    if (changeQuarters > 1) {
      displayChange += changeQuarters + ' Quarters ';
    }
    else {
      displayChange += changeQuarters + ' Quarter ';
    }
  }
  var changeDimes = Math.floor(changeRemainder / 10);
  changeRemainder = changeRemainder % 10;
  if (changeDimes >= 1) {
    if (changeDimes > 1) {
      displayChange += changeDimes + ' Dimes ';
    }
    else {
      displayChange += changeDimes + ' Dime ';
    }
  }
  var changeNickels = Math.floor(changeRemainder / 5);
  if (changeNickels >= 1) {
    if (changeNickels > 1) {
      displayChange += changeNickels + ' Nickels';
    }
    else {
      displayChange += changeNickels + ' Nickel';
    }
  }

  $('#total-monies').val('0.00');
  $('#change').val(displayChange);
}

function LoadMachine(){
  $.ajax({
    type: 'GET',
    url: 'http://localhost:8080/items',
    dataType:'json',
    success: function(itemArray) {

      var itemCount = 1;

      $.each(itemArray, function(index, item) {

        var itemNumber = item.id;
        var itemName = item.name;
        var itemPrice = item.price.toFixed(2);
        var itemQuantity = item.quantity;


        var itemDisplay = '<p class="left-align" id="item-number">' + itemNumber + '</p>';
            itemDisplay += '<p id="item' + itemNumber + '-name">' + itemName + '</p>';
            itemDisplay += '<p id= "item' + itemNumber + '-price">' + '$' + itemPrice + '</p>';
            itemDisplay += '<p class="bottom-align" id="item' + itemNumber + '-quantity">' + 'Quantity Left: '+ itemQuantity + '</p>';

        $('#' + itemCount).append(itemDisplay);

        itemCount += 1;

      });
  },

    error: function() {
      alert('Failure');
    }

  });
}

function PurchaseItem() {
    var currentQuantity = $('#item' + $('#vending').val() + '-quantity').text().split(':');
    var num = currentQuantity[1];
    var total = $('#total-monies').val();
    var price = $('#item' + $('#vending').val() + '-price').text().replace('$','');
    price = parseFloat(price, 10);
    var sum = Math.abs(total - price).toFixed(2);

    var message = $('#messages').val();

    if (num > 0) {

      if (total >= price) {
        var newQuantity = num - 1;
        $('#messages').val('Thank You!!!');
        $('#item' + $('#vending').val() + '-quantity').text('Quantity Left: ' + newQuantity);
        $('#total-monies').val(sum);
      }
      else {
        $('#messages').val('Please deposit: $' + sum);
      }

    }
    else {
      $('#messages').val('SOLD OUT!!!');
    }



    console.log(price);
    $('#change-return').show();
}
