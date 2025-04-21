$('#SaveUpdate').click(function () {
    var ID = $('#HID').val()?.trim() || "0";

    if (!validateHolidaysForm()) {
        return; 
    }

    var branch = {
        ID: ID,
        HolidaysName: $('#HolidaysName').val()?.trim(),
        HolidaysDate: $('#HolidaysDate').val()?.trim(),
    };

    $.ajax({
        url: 'SaveHolidaysUpdate',
        type: 'POST',
        data: branch,
        success: function (response) {
            if (ID !== "0") {
                showToast("Holidays has been updated successfully!", "success");
            } else {
                showToast("New Holidays saved successfully!", "success");
            }

            setTimeout(() => {
                location.reload();
            }, 3100);
        },
        error: function (xhr, status, error) {
            showToast("An error occurred while saving: " + (xhr.responseText || error), "error");
        }
    });
});

function EditHolidays(ID) {
    $.ajax({
        url: 'GetHolidaysById',
        type: 'GET',
        data: { ID: ID },
        success: function (data) {
            if (data) {
                $('#HID').val(data.ID);
                $('#HolidaysName').val(data.HolidaysName);
                $('#HolidaysDate').val(data.HolidaysDate);
                $('#SaveUpdate')
                    .text('Update')
                    .removeClass('btn-subtle-primary')
                    .addClass('btn-subtle-info');
            } else {
                toastr.error('Not Found!', 'Oops!', {
                    positionClass: 'toast-top-right',
                    timeOut: 3000
                });

                setTimeout(() => {
                    location.reload();
                }, 3100);
            }
        },
        error: function (error) {
            toastr.error('An error occurred!', 'Error', {
                positionClass: 'toast-top-right',
                timeOut: 3000
            });
        }
    });
}

function DeleteHolidays(ID) {
    $.ajax({
        url: 'DeleteHolidaysById',
        type: 'GET',
        data: { ID: ID },
        success: function (data) {
            showToast("Your Data Has Been Deleted successfully!", "danger");

            setTimeout(() => {
                location.reload();
            }, 3100);
        },
        error: function (xhr, status, error) {
            showToast(`Error: ${status} - ${error}`, "error");
        }
    });
}

function validateHolidaysForm() {
    let errors = []; 

    var HolidaysName = $('#HolidaysName').val()?.trim();
    var HolidaysDate = $('#HolidaysDate').val()?.trim();

    if (!HolidaysName) {
        errors.push("HolidayscName cannot be empty!");
    }
    if (!HolidaysDate) {
        errors.push("Holidays Date cannot be empty!");
    }

    if (errors.length > 0) {
        errors.forEach((error, index) => {
            setTimeout(() => {
                showToast(error, "warning");
            }, index * 200);
        });
        return false;
    }

    return true;
}