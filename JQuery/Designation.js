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

    $.ajax({
        type: "GET",
        url: "GetDepartment",
        dataType: "json",
        success: function (data) {
            var s = '<option value="" selected disabled>Select Department</option>';
            for (var i = 0; i < data.length; i++) {
                s += '<option value="' + data[i].ID + '">' + data[i].DepartmentName + '</option>';
            }
            $("#Department").html(s);
        }
    });
});

$('#SaveUpdate').click(function () {
    var ID = $('#HID').val()?.trim() || "0";

    if (!validateDesignationForm()) {
        return;
    }

    var designation = {
        ID: ID,
        Branch: $('#Branch').val()?.trim(),
        Department: $('#Department').val()?.trim(),
        DesignationName: $('#DesignationName').val()?.trim(),
    };

    $.ajax({
        url: 'SaveDesignationUpdate',
        type: 'POST',
        data: designation,
        success: function (response) {
            if (ID !== "0") {
                showToast("Designation has been updated successfully!", "success");
            } else {
                showToast("New Designation saved successfully!", "success");
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

function EditDesignation(ID) {
    debugger;
    $.ajax({
        url: 'GetDesignationById',
        type: 'GET',
        data: { ID: ID },
        success: function (data) {
            if (data) {
                $('#HID').val(data.ID);
                $('#Branch').val(data.Branch);
                $('#Department').val(data.Department);
                $('#DesignationName').val(data.DesignationName);
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

function DeleteDesignation(ID) {
    $.ajax({
        url: 'DeleteDesignationById',
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

function validateDesignationForm() {
    let errors = [];

    var DesignationName = $('#DesignationName').val()?.trim();
    var Department = $('#Department').val()?.trim();
    var Branch = $('#Branch').val()?.trim();

    if (!DesignationName) {
        errors.push("Department cannot be empty!");
    }
    if (!Department) {
        errors.push("Branch cannot be empty!");
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