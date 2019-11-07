function createNewManager() {

    let name = $("#Name").val();
    let surname = $("#Surname").val();
    let email = $("#Email").val();

    let request = {
        Name: name,
        Surname: surname,
        Email: email
    };

    $.ajax({
        type: "Post",
        url: '/Admin/Manager/CreateManager',
        contentType: 'application/json; charset=utf-8;',
        data: JSON.stringify(request),
        dataType: 'json',
        success: function (response) {
            if (response.StateResult) {
                swal({ title: '', text: '+1', type: 'success' }, function () {
                window.location.href = '/Admin/Manager/Index';
                });
            }
          
        },
        error: function (response) {
            let obj = response.responseJSON;
            let count = Object.keys(obj).length;
            if (count > 1) {
                $("#DoesSuchMailExist").text("");
                response.responseJSON.Error.forEach(x => {
                    let errors = x.Errors.join('\n');
                    $(`#${x.Key}-error`).text(errors);
                });
            } else {
                $("#Name-error").text("");
                $("#Surname-error").text("");
                $("#Email-error").text("");
                $("#DoesSuchMailExist").text(response.responseJSON.Message);
            }
            
        }
    });
}

$(document).on('click', '.delete-manager-btn', function (evt) {
    let managerId = $(evt.target).data('managerid');

    swal({ title: 'Вы уверены?', showConfirmButton: true, showCancelButton: true, type: 'warning' }, function () {
        window.location.href = `/Admin/Manager/DeleteManager/${managerId}`;
    });
});