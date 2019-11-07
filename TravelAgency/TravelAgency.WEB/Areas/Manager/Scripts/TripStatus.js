function changeTripStatus() {
    let tripStatus = $("#changeTripStatus").val();
    let idTourCustomer = $("#IdTourCustomer").val();

    let request = {
        IdTourCustomer: idTourCustomer,
        TripStatus: tripStatus
    };

    $.ajax({
        type: "Post",
        url: '/Manager/Tour/ChangeTripStatus',
        contentType: 'application/json; charset=utf-8;',
        data: JSON.stringify(request),
        dataType: 'json',
        success: function (response) {
            swal({ title: '', text: 'Изменил!', type: 'success' }, function () {
                $("#dataDismiss").click();
            });
        }
    });

}