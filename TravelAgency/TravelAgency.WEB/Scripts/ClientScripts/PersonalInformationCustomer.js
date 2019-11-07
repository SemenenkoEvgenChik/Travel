
function forgotPassword() {
    let email = $("#email").val();

    let request = {
        Email: email
    };

    $.ajax({
        url: '/Home/ForgotPassword',
        type: 'POST',
        contentType: 'application/json; charset=utf-8;',
        data: JSON.stringify(request),
        dataType: 'json',
        success: function (response) {
            if (response.StateResult) {
                swal({ title: '', text: 'Новый пароль отправили на почту!', type: 'success' }, function () {
                    window.location.href = '/Account/Login';
                });
            }
        },
        error: function (response) {
            alert(response.responseJSON.Message);
        }
    });
}

function ChangePersonalInformation() {

    let name = $("#Name").val();
    let surname = $("#Surname").val();
    let email = $("#Email").val();

    let request = {
        Name: name,
        Surname: surname,
        Email: email
    };

    $.ajax({
        url: '/Home/ChangePersonalInformation',
        type: 'POST',
        contentType: 'application/json; charset=utf-8;',
        data: JSON.stringify(request),
        dataType: 'json',
        success: function (response) {
            if (!response.StateResult) {
                response.Error.forEach(x => {
                    let errors = x.Errors.join('\n');
                    $(`#${x.Key}-error`).text(errors);

                    $(`#${x.Key}-error`).change(
                        function () {
                            $(this).text('');
                        });
                });
            } else {
                swal({ title: '', text: 'Успешно!', type: 'success' }, function () {
                    window.location.href = '/Home/PersonalAccount';
                });
            }
        },
        error: function (response) {
            swal({ title: '', text: response.responseJSON.Message, type: 'error' }, function () {
                window.location.href = '/Home/PersonalAccount';
            });
        }
    });
}

$(document).on('click', '#changePasswordBtn', function () {

    let request = {
        OldPassword: $('#oldPassword').val(),
        NewPassword: $('#newPassword').val(),
        ConfirmPassword: $('#confirmPassword').val()
    };

    $.ajax({
        type: 'POST',
        url: '/Account/ChangePassword',
        data: JSON.stringify(request),
        contentType: 'application/json; charset=utf-8;',
        success: function (response) {
            alert("Успешно!");
            window.location.href = '/Home/PersonalAccount';
        },
        error: function (response) {
            let error = 'Возникла ошибка во время выполнения запроса к серверу.';
            if (typeof (response.responseJSON) !== "undefined") {
                if (typeof (response.responseJSON.Message) !== 'undefined') {
                    error = response.responseJSON.Message;
                }
                if (typeof (response.responseJSON.Error) !== 'undefined') {
                    response.responseJSON.Error.forEach(x => {
                        let errors = x.Errors.join('\n');
                        $(`#${x.Key}-error`).text(errors);

                        $(`#${x.Key}`).change(
                            function () {
                                $(this).text('');
                            });
                    });
                    return;
                }
            }
            swal({ title: '', text: error, type: 'error' });
        }
    });
});