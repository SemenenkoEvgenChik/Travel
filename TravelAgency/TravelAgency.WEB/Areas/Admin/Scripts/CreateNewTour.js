$('#DepartureDate').datetimepicker({
    step: 5,
    closeOnDateSelect: false,
    format: 'd.m.Y H:i',
    minDate: 0,
    timepicker: true
});

$('#ArrivalDate').datetimepicker({
    step: 5,
    closeOnDateSelect: false,
    format: 'd.m.Y H:i',
    minDate: 0,
    timepicker: true
});

$(document).ready(function () {
    $('#countries').change(selecteCitiesForCountry);

    $('.model-prop').change(function (evt) {
        $(`#${evt.target.id}-error`).text('');
    });
});

function selecteCitiesForCountry() {

    let CountyId = $("#countries").val();

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
            $('select#cityForCountry').html(options);
        }
    });
}

function requesTourModel() {
    let departureDateString = $("#DepartureDate").val();
    let arrivalDateString = $("#ArrivalDate").val();
    let price = $("#price").val();
    let numberOfPersons = $("#countPerson").val();
    let foodId = $("#typeOfFood").val();
    let typeOfRestId = $("#typeOfRest").val();
    let countriesId = $("#countries").val();
    let typeOfTourId = $("#typeOfTour").val();
    let meansOfTransportId = $("#meansOfTransport").val();
    let whereToId = $("#cityForCountry").val();
    let fromWhereId = $("#fromWhere").val();
    let hotelId = $("#numberOfStars").val();

    let request = {
        DepartureDate: departureDateString,
        ArrivalDate: arrivalDateString,
        HotelId: hotelId,
        Price: price,
        MaxNumberOfPersons: numberOfPersons,
        FoodId: foodId,
        TypeOfRestId: typeOfRestId,
        CountriesId: countriesId,
        TypeOfTourId: typeOfTourId,
        MeansOfTransportId: meansOfTransportId,
        WhereToId: whereToId,
        FromWhereId: fromWhereId
    };
    $.ajax({
        type: "Post",
        url: '/Admin/Tour/CreatNewTour',
        contentType: 'application/json; charset=utf-8;',
        data: JSON.stringify(request),
        complete: function (res) {
            console.log(res);
        },
        success: function (response) {
            if (response.StateResult) {
                swal({ title: '', text: '+1 тур', type: 'success' }, function () {
                    window.location.href = '/Admin/Tour/Index';
                });
            }
        },
        error: function (response) {
            response.responseJSON.Error.forEach(x => {
                let errors = x.Errors.join('\n');
                $(`#${x.Key}-error`).text(errors);

                $(`#${x.Key}-error`).change(
                    function () {
                        $(this).text('');
                    });
            });
        }

    });

}