// Function to handle "Pick Date" button click
$(".calendar-btn").click(function () {
    // Get the applicant ID from the data attribute
    var applicantId = $(this).data("applicant-id");

    // Set the applicant ID in the modal's Save button data attribute
    $("#saveDateBtn").data("applicant-id", applicantId);

    // Set the minimum date for the datepicker to today
    $(".datepicker").datepicker("setStartDate", new Date());

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
                row.find(".next-process").text(selectedDate); // Update the "Next Process" column (assuming it's the 7th column in the table)
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

// Function to handle the "Cancel" button click in the modal
$("#cancelBtn").click(function () {
    // Close the modal
    $("#calendarModal").modal("hide");
});

// Function to handle the "Close" icon click
$(".close").click(function () {
    // Close the modal
    $("#calendarModal").modal("hide");
});

// Initialize the datepicker
$(".datepicker").datepicker({
    format: "mm-dd-yyyy", // Change the date format to mm-dd-yyyy
    autoclose: true,
    beforeShowDay: function (date) {
        var selectedDate = $(".datepicker").val();
        var currentDate = new Date(date.getFullYear(), date.getMonth(), date.getDate()).toISOString().slice(0, 10);
        return currentDate == selectedDate ? 'highlighted' : '';
    }
});
