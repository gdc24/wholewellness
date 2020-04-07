
function searchFoodAlternatives() {
    var intFoodItemID = $("#foodDropDown").val();
    var data = {
        intFoodItemID: intFoodItemID
    };
    AjaxCall('/Food/GetHealthierOptions', JSON.stringify(data), 'POST').done(function (response) {

        $('#food-results').html(response);

    }).fail(function (error) {
        console.log(error);
        alert(error.StatusText);
    });
}

function AjaxCall(url, data, type) {
    return $.ajax({
        url: url,
        type: type ? type : 'GET',
        data: data,
        contentType: 'application/json',
        async: false
    });
}