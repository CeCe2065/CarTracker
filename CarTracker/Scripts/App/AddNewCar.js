//Added entire page



$(document).ready(function () {
    $('#ShowNewDescriptionFormButton').on('click', function (event) {
        event.preventDefault();
        $('#CarMakeDropdown').hide();
        $('#NewCarMakeForm').show();
    });

    $('#NewCarMakeCancelButton').on('click', function (event) {
        event.preventDefault();
        $('#CarMakeDropdown').show();
        $('#NewCarMakeForm').hide();
    });

    $('#NewCarMakeOkButton').on('click', function (event) {
        event.preventDefault();

        $.post('/api/CarMakesApi', {
            Description: $('#NewCarMakeDescription').val()
        }).done(function (data) {
            console.log(data);
            //Add the new option to the select element.
            $('#CarMakeID').append(new Option(data.Description, data.CarMakeID));

            //Select the option from the dropdown.
            $('#CarMakeID').val(data.CarMakeID);
            
            //Clear out the new exercise text field.
            $('#NewCarMakeDescription').val('');
            
            $('#CarMakeDropdown').show();
            $('#NewCarMakeForm').hide();
        });

    });

});