let numPage = 1;

$(document).ready(function () {
    $("#statusTourEnum").change(function (evt) {
        //let text = $(evt.target).children('option:selected').text();
        //$('#statusTour').html(`<p>${text}</p>`);
        GetAllNewTours();
    }).trigger('change');
    $('#partialPagination').on('change', '#sortIndexBLL', function () {
        GetAllNewTours();
    });
    GetAllNewTours();
});
function GetAllNewTours() {
    let en = $("#statusTourEnum").val();
    let sort = $("#sortIndexBLL").val();
    let numberPerson = $("#NumberPerson").val();
    let priceDown = $("#PriceDown").val();
    let priceUp = $("#PriceUp").val();
    let numberOfStars = $("#NumberOfStars").val();
    let typeOfRest = $("#TypeOfRest").val();

    let request = {
        numberPage: numPage,
        sizePage: 5,
        statusTour: en,
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
        url: '/Admin/Tour/AllTours',
        type: 'POST',
        contentType: 'application/json; charset=utf-8;',
        data: JSON.stringify(request),
        dataType: 'html',
        beforeSend: function () {
            $('#spinner').show();
        },
        success: function (response) {
            $("#partialPagination").html(response);
            $("#NumberPerson").val(numberPerson);
            $("#NumberOfStars").val(numberOfStars);
            $("#PriceDown").val(priceDown);
            $("#PriceUp").val(priceUp);
            $("#TypeOfRest").val(typeOfRest);
        },
        complete: function () {
            $('#spinner').hide();
        }
    });
}
function Prev() {
    if (numPage > 1) {
        numPage--;
    }
    GetAllNewTours();
}
function Next() {
    numPage++;
    GetAllNewTours();
}

