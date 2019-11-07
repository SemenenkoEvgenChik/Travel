let idCustomer = $("#idCustomer").val();
function ChangeDiscountStep() {
    let step = $("#discountStep").val();
    let request = {
        IdCustomer: idCustomer,
        NewStep: step
    };

    $.ajax({
        type: "Post",
        url: '/Admin/Customer/ChangeStepDiscount',
        contentType: 'application/json; charset=utf-8;',
        data: JSON.stringify(request),
        dataType: 'json',
        success: function (response) {
            alert(`Шаг скидки изменен на ${step}%`);
            $("#dataDismiss").click();
        },
        error: function (response) {
            response.responseJSON.Error.forEach(x => {
                let errors = x.Errors.join('\n');
                $(`#${x.Key}-error`).text(errors);
            });
        }
    });
}

function ChangeDiscountLimit() {
    let limit = $("#discountLimit").val();

    let request = {
        IdCustomer: idCustomer,
        NewLimit: limit
    };

    $.ajax({
        type: "Post",
        url: '/Admin/Customer/ChangeDiscountLimit',
        contentType: 'application/json; charset=utf-8;',
        data: JSON.stringify(request),
        dataType: 'json',
        success: function (response) {
            alert(`Максимальная скидка изменена на ${limit}%`);
            $("#dataDismiss").click();
        },
        error: function (response) {
            response.responseJSON.Error.forEach(x => {
                let errors = x.Errors.join('\n');
                $(`#${x.Key}-error`).text(errors);
            });
        }
    });
}
function ChangeCustomerEmail() {
    let newEmail = $("#newEmail").val();
    let request = {
        Id: idCustomer,
        Email: newEmail
    };

    $.ajax({
        type: "Post",
        url: '/Admin/Customer/ChangeCustomerEmail',
        contentType: 'application/json; charset=utf-8;',
        data: JSON.stringify(request),
        dataType: 'json',
        success: function (response) {
            if (response.StateResult) {
                alert("Изменил почту клиенту");
            }
        },
        error: function (response) {
            response.responseJSON.Error.forEach(x => {
                let errors = x.Errors.join('\n');
                $(`#${x.Key}-error`).text(errors);
            });
        }
    });
}

