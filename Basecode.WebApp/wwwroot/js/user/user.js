$('.modal').on('shown.bs.modal', function () {
    var modal = $(this); // Get the modal element that has just been shown
    var form = modal.find('form'); // Find the form element within the modal
    var formId = '#' + form.attr('id'); // Get the ID of the form

    $(formId).submit(function (e) {
        e.preventDefault();

        var form = $(this);

        $.ajax({
            url: form.attr('action'),
            type: 'POST',
            data: form.serialize(),
            success: function (response) {
                window.location.href = response.redirectToUrl;
            },
            error: function (response) {
                if (response.status === 400) {
                    var errors = response.responseJSON.value;

                    // Iterate over the errors and display them
                    $.each(errors, function (key, value) {
                        if (formId == "#editUserForm") {
                            key = 'Update' + key;
                        }
                        $('#' + key + 'Error').text(value);
                    });
                }
                else {
                    // Handle other error cases
                    console.log("other error");
                }
            }
        });
    });
});

$('.modal').on('hidden.bs.modal', function () {
    $(this).parent().empty();
});