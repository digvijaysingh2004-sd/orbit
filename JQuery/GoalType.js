$('#SaveUpdate').click(function () {
    var ID = $('#HID').val()?.trim() || "0";

    if (!validateGoalTypeForm()) {
        return;
    }

    var goal = {
        ID: ID,
        GoalType: $('#GoalType').val()?.trim(),
    };

    $.ajax({
        url: 'SaveGoalTypeUpdate',
        type: 'POST',
        data: goal,
        success: function (response) {
            if (ID !== "0") {
                showToast("GoalType has been updated successfully!", "success");
            } else {
                showToast("New GoalType saved successfully!", "success");
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

function EditGoalType(ID) {
    $.ajax({
        url: 'GetGoalTypeById',
        type: 'GET',
        data: { ID: ID },
        success: function (data) {
            if (data) {
                $('#HID').val(data.ID);
                $('#GoalType').val(data.GoalType);
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

function DeleteGoalType(ID) {
    $.ajax({
        url: 'DeleteGoalTypeById',
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

function validateGoalTypeForm() {
    let errors = [];

    var GoalType = $('#GoalType').val()?.trim();

    if (!GoalType) {
        errors.push("GoalType cannot be empty!");
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