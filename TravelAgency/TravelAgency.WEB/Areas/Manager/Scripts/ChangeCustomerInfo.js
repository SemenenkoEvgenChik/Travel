let idCustomer = $("#idCustomer").val();
function ChangeDiscountStep() {
    let step = $("#discountStep").val();
    let request = {
        IdCustomer: idCustomer,
        NewStep: step
    };

    $.ajax({
        type: "Post",
        url: '/Manager/Customer/ChangeStepDiscount',
        contentType: 'application/json; charset=utf-8;',
        data: JSON.stringify(request),
        dataType: 'json',
        success: function (response) {
            swal({ title: '', text: `Шаг скидки изменен на ${step}%`, type: 'success' }, function () {
            });
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
        url: '/Manager/Customer/ChangeDiscountLimit',
        contentType: 'application/json; charset=utf-8;',
        data: JSON.stringify(request),
        dataType: 'json',
        success: function (response) {
            swal({ title: '', text: `Максимальная скидка изменена на ${limit}%`, type: 'success' }, function () {
            });
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