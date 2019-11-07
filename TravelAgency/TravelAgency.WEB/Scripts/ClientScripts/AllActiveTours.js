let numPage = 1;

$(document).ready(function () {
    $('#partialPaginationAllActiveTour').on('change', '#sortIndexBLL', function () {
        searchTours();
    });
    searchTours();
});
function searchTours() {
    let sort = $("#sortIndexBLL").val();
    let numberPerson = $("#NumberPerson").val();
    let priceDown = $("#PriceDown").val();
    let priceUp = $("#PriceUp").val();
    let numberOfStars = $("#NumberOfStars").val();
    let typeOfRest = $("#TypeOfRest").val();

    let request = {
        numberPage: numPage,
        sizePage: 5,
        statusTour: 1,
        sortIndex: sort,
        SerchTours: {
            NumberPerson: numberPerson,
            PriceDown: priceDown,
            PriceUp: priceUp,
            NumberOfStars: numberOfStars,
            TypeOfRest: typeOfRest
        }
    };

    $.ajax({
        url: '/Home/AllActiveTours',
        type: 'POST',
        contentType: 'application/json; charset=utf-8;',
        data: JSON.stringify(request),
        dataType: 'html',
        beforeSend: function () {
            $('#spinnerAllActiveTour').show();
        },
        success: function (response) {
            $("#partialPaginationAllActiveTour").html(response);
            $("#NumberPerson").val(numberPerson);
            $("#NumberOfStars").val(numberOfStars);
            $("#PriceDown").val(priceDown);
            $("#PriceUp").val(priceUp);
            $("#TypeOfRest").val(typeOfRest);
        },
        complete: function () {
            $('#spinnerAllActiveTour').hide();
        }
    });
}
function Prev() {
    if (numPage > 1) {
        numPage--;
    }
    searchTours();
}
function Next() {
    numPage++;
    searchTours();
}