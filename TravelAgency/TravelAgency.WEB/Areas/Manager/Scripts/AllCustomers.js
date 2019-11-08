let numPage = 1;
$(document).ready(function () {
    searchCustomers();
});
function searchCustomers() {
    let request = {
        numberPage: numPage,
        sizePage: 4
    };

    $.ajax({
        url: '/Manager/Customer/AllCustomers',
        type: 'POST',
        contentType: 'application/json; charset=utf-8;',
        data: JSON.stringify(request),
        dataType: 'html',
        success: function (response) {
            $("#partialAllCustomers").html(response);
        }
    });
}
function Prev() {
    if (numPage > 1) {
        numPage--;
    }
    searchCustomers();
}
function Next() {
    numPage++;
    searchCustomers();
}

function searchCustomersByEmail() {
    let email = $("#email").val();

    let request = {
        Email: email
    };

    $.ajax({
        url: '/Manager/Customer/SearchCustomerByEmail',
        type: 'POST',
        contentType: 'application/json; charset=utf-8;',
        data: JSON.stringify(request),
        dataType: 'html',
        success: function (response) {
            $("#resultSearchCustomer").fadeIn();
            $("#resultSearchCustomer").html(response);

        },
        error: function (response) {
            let Response = JSON.parse(response.responseText);
            if (Response.Message !== undefined) {
                $("#resultSearchCustomer").fadeIn();
                $("#resultSearchCustomer").html(`<h4 class="text-center">Результат поиска</h4>
                    <h3 class="text-center">${Response.Message}</h3>`);
                $("#resultSearchCustomer").delay(3200).fadeOut(300);
            } else {
                Response.Error.forEach(x => {
                    $(`#${x.Key}-error`).fadeIn();

                    let errors = x.Errors.join('\n');
                    $(`#${x.Key}-error`).text(errors);

                    $(`#${x.Key}-error`).delay(3200).fadeOut(300);
                });
            }
        }
    });
}