let numPage = 1;
let statusTour = 1;
$(document).ready(function () {
    $('#partialPagination').on('change', '#sortIndexBLL', function () {
        GetAllNewTours();
    });
    GetAllNewTours();
});
function GetAllNewTours() {
    let sort = $("#sortIndexBLL").val();
    let numberPerson = $("#NumberPerson").val();
    let priceDown = $("#PriceDown").val();
    let priceUp = $("#PriceUp").val();
    let numberOfStars = $("#NumberOfStars").val();
    let typeOfRest = $("#TypeOfRest").val();

    let request = {
        numberPage: numPage,
        sizePage: 4,
        statusTour: statusTour,
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
        url: '/Manager/Tour/AllTours',
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

function ChangeTypeOfTour() {
    let idTour = $("#idTour").val();
    let TypeOfTour = $("#typeOfTour").val();

    let request = {
        IdTour: idTour,
        TypeOfTour: TypeOfTour
    };

    $.ajax({
        url: '/Manager/Tour/ChangeTypeOfTour',
        type: 'POST',
        contentType: 'application/json; charset=utf-8;',
        data: JSON.stringify(request),
        dataType: 'json',
        success: function (response) {
            swal({ title: '', text: 'Изменил!', type: 'success' }, function () {
                location.reload();
            });
        }
    });
}