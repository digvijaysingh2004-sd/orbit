$('#SaveUpdate').click(function () {
    var ID = $('#HID').val()?.trim() || "0";

    if (!validateLeaveTypeForm()) {
        return;
    }

    var leave = {
        ID: ID,
        LeaveType: $('#LeaveType').val()?.trim(),
        Days: $('#Days').val()?.trim(),
    };

    $.ajax({
        url: 'SaveLeaveTypeUpdate',
        type: 'POST',
        data: leave,
        success: function (response) {
            if (ID !== "0") {
                showToast("LeaveType has been updated successfully!", "success");
            } else {
                showToast("New LeaveType saved successfully!", "success");
            }

            // Reload after the toast disappears
            setTimeout(() => {
                location.reload();
            }, 3100);
        },
        error: function (xhr, status, error) {
            showToast("An error occurred while saving: " + (xhr.responseText || error), "error");
        }
    });
});

function EditLeaveType(ID) {
    debugger;
    $.ajax({
        url: 'GetLeaveTypeById',
        type: 'GET',
        data: { ID: ID },
        success: function (data) {
            if (data) {
                $('#HID').val(data.ID);
                $('#LeaveType').val(data.LeaveType);
                $('#Days').val(data.Days);
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

function DeleteLeaveType(ID) {
    $.ajax({
        url: 'DeleteLeaveTypeById',
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

function validateLeaveTypeForm() {
    let errors = [];

    var LeaveType = $('#LeaveType').val()?.trim();
    var Days = $('#Days').val()?.trim();

    if (!LeaveType) {
        errors.push("LeaveType cannot be empty!");
    }
    if (!Days) {
        errors.push("Days / Years cannot be empty!");
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