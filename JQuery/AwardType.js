$('#SaveUpdate').click(function () {
    var ID = $('#HID').val()?.trim() || "0";

    if (!validateAwardTypeForm()) {
        return;
    }

    var data = {
        ID: ID,
        AwardType: $('#AwardType').val()?.trim(),
    };

    $.ajax({
        url: 'SaveAwardTypeUpdate',
        type: 'POST',
        data: data,
        success: function (response) {
            if (ID !== "0") {
                showToast("AwardType has been updated successfully!", "success");
            } else {
                showToast("New AwardType saved successfully!", "success");
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

function EditAwardType(ID) {
    $.ajax({
        url: 'GetAwardTypeById',
        type: 'GET',
        data: { ID: ID },
        success: function (data) {
            if (data) {
                $('#HID').val(data.ID);
                $('#AwardType').val(data.AwardType);
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

function DeleteAwardType(ID) {
    $.ajax({
        url: 'DeleteAwardTypeById',
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

function validateAwardTypeForm() {
    let errors = [];

    var AwardType = $('#AwardType').val()?.trim();

    if (!AwardType) {
        errors.push("AwardType cannot be empty!");
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