$('#SaveUpdate').click(function () {
    var ID = $('#HID').val()?.trim() || "0"; PerformanceType

    if (!validatePerformanceTypeForm()) {
        return;
    }

    var data = {
        ID: ID,
        PerformanceType: $('#PerformanceType').val()?.trim(),
    };

    $.ajax({
        url: 'SavePerformanceTypeUpdate',
        type: 'POST',
        data: data,
        success: function (response) {
            if (ID !== "0") {
                showToast("PerformanceType has been updated successfully!", "success");
            } else {
                showToast("New PerformanceType saved successfully!", "success");
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

function EditPerformanceType(ID) {
    $.ajax({
        url: 'GetPerformanceTypeById',
        type: 'GET',
        data: { ID: ID },
        success: function (data) {
            if (data) {
                $('#HID').val(data.ID);
                $('#PerformanceType').val(data.PerformanceType);
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

function DeletePerformanceType(ID) {
    $.ajax({
        url: 'DeletePerformanceTypeById',
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

function validatePerformanceTypeForm() {
    let errors = [];

    var PerformanceType = $('#PerformanceType').val()?.trim();

    if (!PerformanceType) {
        errors.push("PerformanceType cannot be empty!");
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