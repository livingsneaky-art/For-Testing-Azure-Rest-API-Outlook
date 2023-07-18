// Function to handle "Pick Date" button click
$(".calendar-btn").click(function () {
    // Get the applicant ID from the data attribute
    var applicantId = $(this).data("applicant-id");

    // Set the applicant ID in the modal's Save button data attribute
    $("#saveDateBtn").data("applicant-id", applicantId);

    // Clear any previous date selection from the datepicker
    $(".datepicker").val("");

    // Open the modal
    $("#calendarModal").modal("show");
});

// Function to handle the "Save" button click in the modal
$("#saveDateBtn").click(function () {
    // Get the applicant ID from the modal's Save button data attribute
    var applicantId = $(this).data("applicant-id");

    // Retrieve the selected date from the datepicker input (assuming you have a class named "datepicker" for the input)
    var selectedDate = $(".datepicker").val();

    // Perform an AJAX POST request to update the applicant's UpdateTime property
    $.ajax({
        type: "POST",
        url: "/Dashboard/UpdateApplicantUpdateTime",
        data: {
            applicantId: applicantId,
            updateTime: selectedDate
        },
        success: function (data) {
            // Check the success property in the JSON response
            if (data.success) {
                // If the update is successful, you can perform any necessary actions, such as updating the table in real-time.
                console.log("Update successful!");
                // For example, you can update the table row to display the new UpdateTime value:
                var row = $("tr[data-application-id='" + applicantId + "']");
                row.find("td:nth-child(7)").text(selectedDate);
            } else {
                console.log("Update failed!");
            }
        },
        error: function (error) {
            console.log("Update error:", error);
        }
    });

    // Close the modal
    $("#calendarModal").modal("hide");
});

// Function to handle the "Close" icon click and "Cancel" button click in the modal
$("#calendarModal").on("hidden.bs.modal", function () {
    // Clear the datepicker value when the modal is closed
    $(".datepicker").val("");
});

// Initialize the datepicker
$(".datepicker").datepicker({
    format: "yyyy-mm-dd",
    autoclose: true,
    todayHighlight: true
});