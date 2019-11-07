function changeTripStatus() {
    let tripStatus = $("#changeTripStatus").val();
    let idTourCustomer = $("#IdTourCustomer").val();
    
    let request = {
        IdTourCustomer: idTourCustomer,
        TripStatus: tripStatus
    };

    $.ajax({
        type: "Post",
        url: '/Admin/Customer/ChangeTripStatus',
        contentType: 'application/json; charset=utf-8;',
        data: JSON.stringify(request),
        dataType: 'json',
        success: function (response) {
            alert("Изменил da!");
        }
    });

}