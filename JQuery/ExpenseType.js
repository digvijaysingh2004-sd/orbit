$('#SaveUpdate').click(function () {
    var ID = $('#HID').val()?.trim() || "0";

    if (!validateExpenseTypeForm()) {
        return;
    }

    var data = {
        ID: ID,
        ExpenseType: $('#ExpenseType').val()?.trim(),
    };

    $.ajax({
        url: 'SaveExpenseTypeUpdate',
        type: 'POST',
        data: data,
        success: function (response) {
            if (ID !== "0") {
                showToast("ExpenseType has been updated successfully!", "success");
            } else {
                showToast("New ExpenseType saved successfully!", "success");
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

function EditExpenseType(ID) {
    $.ajax({
        url: 'GetExpenseTypeById',
        type: 'GET',
        data: { ID: ID },
        success: function (data) {
            if (data) {
                $('#HID').val(data.ID);
                $('#ExpenseType').val(data.ExpenseType);
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

function DeleteExpenseType(ID) {
    $.ajax({
        url: 'DeleteExpenseTypeById',
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

function validateExpenseTypeForm() {
    let errors = [];

    var ExpenseType = $('#ExpenseType').val()?.trim();

    if (!ExpenseType) {
        errors.push("ExpenseType cannot be empty!");
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