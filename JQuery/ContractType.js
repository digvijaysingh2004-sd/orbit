$('#SaveUpdate').click(function () {
    var ID = $('#HID').val()?.trim() || "0";

    if (!validateContractTypeForm()) {
        return;
    }

    var data = {
        ID: ID,
        ContractType: $('#ContractType').val()?.trim(),
    };

    $.ajax({
        url: 'SaveContractTypeUpdate',
        type: 'POST',
        data: data,
        success: function (response) {
            if (ID !== "0") {
                showToast("ContractType has been updated successfully!", "success");
            } else {
                showToast("New ContractType saved successfully!", "success");
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

function EditContractType(ID) {
    $.ajax({
        url: 'GetContractTypeById',
        type: 'GET',
        data: { ID: ID },
        success: function (data) {
            if (data) {
                $('#HID').val(data.ID);
                $('#ContractType').val(data.ContractType);
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

function DeleteContractType(ID) {
    $.ajax({
        url: 'DeleteContractTypeById',
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

function validateContractTypeForm() {
    let errors = [];

    var ContractType = $('#ContractType').val()?.trim();

    if (!ContractType) {
        errors.push("ContractType cannot be empty!");
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