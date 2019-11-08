let idTour;
let countPerson = $("#countPerson");
let discount;
let priceForTour = $("#priceForTour");
let price;
$(document).ready(function () {
    price = $("#modelPrice").val();
    idTour = $("#idTour").val();
    discount = $("#discount").val();
    PriceForTour();
    $('#countPerson').change(PriceForTour);
});
function PriceForTour() {
    let discountPrice;
    let numberPerson = Number(`${countPerson.val()}`);
    let disc = discount / 100;
    if (disc > 0) {
        discountPrice = price * disc;
    } else {
        discountPrice = 0;
    }
    let result = (price - discountPrice) * numberPerson;
    priceForTour.text(`${result}`);
}
function RegisterOrder() {
    let request = {
        idTour: idTour,
        numberPerson: countPerson.val(),
        discount: discount
    };
    $.ajax({
        url: '/Home/RegisterOrder',
        type: 'POST',
        contentType: 'application/json; charset=utf-8;',
        data: JSON.stringify(request),
        dataType: 'json',
        success: function (response) {
            if (response.StateResult) {
                swal({ title: '', text: 'Спасибо за заказ! Вы можете посмотреть информацию в личном кабинете', type: 'success' }, function () {
                    window.location.href = '/Home/PersonalAccount';
                });
            }
        }

    });
}