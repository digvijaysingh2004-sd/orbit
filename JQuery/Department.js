$(document).ready(function () {
    $.ajax({
        type: "GET",
        url: "GetBranch",
        dataType: "json",
        success: function (data) {
            var s = '<option value="" selected disabled>Select Branch</option>'; 
            for (var i = 0; i < data.length; i++) {
                s += '<option value="' + data[i].ID + '">' + data[i].BranchName + '</option>';
            }
            $("#Branch").html(s);
        }
    });
});

$('#SaveUpdate').click(function () {
    var ID = $('#HID').val()?.trim() || "0";

    // Call validation function
    if (!validateDepartmentForm()) {
        return; // Stop execution if validation fails
    }

    var branch = {
        ID: ID,
        Branch: $('#Branch').val()?.trim(),
        DepartmentName: $('#DepartmentName').val()?.trim(),
    };

    $.ajax({
        url: 'SaveDepartmentUpdate',
        type: 'POST',
        data: branch,
        success: function (response) {
            if (ID !== "0") {
                showToast("Department has been updated successfully!", "success");
            } else {
                showToast("New department saved successfully!", "success");
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

function EditDepartment(ID) {
    $.ajax({
        url: 'GetDepartmentById',
        type: 'GET',
        data: { ID: ID },
        success: function (data) {
            if (data) {
                $('#HID').val(data.ID);
                $('#Branch').val(data.Branch);
                $('#DepartmentName').val(data.DepartmentName);
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

function DeleteDepartment(ID) {
    $.ajax({
        url: 'DeleteDepartmentById',
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

function validateDepartmentForm() {
    let errors = [];

    var DepartmentName = $('#DepartmentName').val()?.trim();
    var Branch = $('#Branch').val()?.trim();

    if (!DepartmentName) {
        errors.push("Department cannot be empty!");
    }
    if (!Branch) {
        errors.push("Branch cannot be empty!");
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