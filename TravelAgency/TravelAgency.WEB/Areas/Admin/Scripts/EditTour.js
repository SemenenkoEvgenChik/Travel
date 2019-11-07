$('#EditDepartureDate').datetimepicker({
    lang: 'ru',
    step: 5,
    closeOnDateSelect: false,
    minDate: 0,
    format: 'd.m.Y H:i',
    timepicker: true
});

$('#EditArrivalDate').datetimepicker({
    lang: 'ru',
    step: 5,
    closeOnDateSelect: false,
    minDate: 0,
    format: 'd.m.Y H:i',
    timepicker: true
});
let message;
$(document).ready(function () {
    message = $('#infMessage');
    $('#EditCountries').change(selecteCitiesForCountry);
});

function selecteCitiesForCountry() {

    let CountyId = $("#EditCountries").val();

    let request = {
        Id: CountyId
    };

    $.ajax({
        type: "Post",
        url: '/Admin/Tour/GetCitisForCountry',
        contentType: 'application/json; charset=utf-8;',
        data: JSON.stringify(request),
        dataType: 'json',
        success: function (response) {
            let options = response.map(x => `<option value='${x.Id}'>${x.NameOfCity}</option>`).join('');
            $('select#EditCityForCountry').html(options);
        }
    });
}
function tourEditRequestModel() {
    let idTour = $("#IdTour").val();
    let idFlight = $("#IdFlight").val();
    let edepartureDateString = $("#EditDepartureDate").val();
    let earrivalDateString = $("#EditArrivalDate").val();
    let eHotelId = $("#EditHotel").val();
    let eprice = $("#EditPrice").val();
    let enumberOfPersons = $("#EditCountPerson").val();
    let efoodId = $("#EditTypeOfFood").val();
    let etypeOfRestId = $("#EditTypeOfRest").val();
    let ecountriesId = $("#EditCountries").val();
    let etypeOfTourId = $("#EditTypeOfTour").val();
    let emeansOfTransportId = $("#EditMeansOfTransport").val();
    let ewhereToId = $("#EditCityForCountry").val();
    let efromWhereId = $("#EditFromWhere").val();


    let request = {
        IdTour: idTour,
        IdFlight: idFlight,
        DepartureDate: edepartureDateString,
        ArrivalDate: earrivalDateString,
        HotelId: eHotelId,
        Price: eprice,
        MaxNumberOfPersons: enumberOfPersons,
        FoodId: efoodId,
        CountriesId: ecountriesId,
        TypeOfRestId: etypeOfRestId,
        TypeOfTourId: etypeOfTourId,
        MeansOfTransportId: emeansOfTransportId,
        WhereToId: ewhereToId,
        FromWhereId: efromWhereId
    };
    $.ajax({
        type: "Post",
        url: '/Admin/Tour/Edit',
        contentType: 'application/json; charset=utf-8;',
        data: JSON.stringify(request),
        dataType: 'json',
        complete: function (res) {
            console.log(res);
        },
        success: function (response) {
            if (response.StateResult) {
                swal({ title: '', text: 'Информация изменена', type: 'success' }, function () {
                    window.location.href = '/Admin/Tour/Index';
                });
            }
        },
        error: function (response) {
            response.responseJSON.Error.forEach(x => {
                let errors = x.Errors.join('\n');
                $(`#${x.Key}-error`).text(errors);

                $(`#${x.Key}`).change(
                    function () {
                        $(this).text('');
                    });
            });
        }
    });

}