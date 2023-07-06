$(document).ready(function () {
    $(document).on('submit', '#addUserForm', function (e) {
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
                        $('#' + key + 'Error').text(value);
                    });
                }
                else {
                    // Handle other error cases
                }
            }
        });
    });
});