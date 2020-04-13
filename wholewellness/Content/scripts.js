
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

function filterExercises() {
    var muscleGroup = $("#muscleGroupDropDown option:selected").text();
    var equipment = $("#equipmentDropDown option:selected").text();
    var intensity = $("#intensityDropDown option:selected").text().toLowerCase();
    var accessibility = $("#accessibilityCheckBox").is(":checked");
    var data = {
        muscleGroup: muscleGroup,
        equipment: equipment,
        intensity: intensity,
        ysnAccessibility: accessibility
    };
    AjaxCall('/Workout/FilterExercises', JSON.stringify(data), 'POST').done(function (response) {

        $('#exercise-results').html(response);

    }).fail(function (error) {
        console.log(error);
        alert(error.StatusText);
    });
}

function searchExercises() {
    var muscleGroup = $("#muscleGroupDropDown option:selected").text();
    var data = {
        muscleGroup: muscleGroup
    };
    AjaxCall('/Workout/SearchForExercises', JSON.stringify(data), 'POST').done(function (response) {

        $('#exercise-results').html(response);

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