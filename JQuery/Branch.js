$('#SaveUpdate').click(function () {
    var ID = $('#HID').val()?.trim() || "0";
    var BranchName = $('#BranchName').val()?.trim();

    if (!BranchName) {
        showToast("Branch Name cannot be empty!", "warning");
        return;
    }

    var branch = {
        ID: ID,
        BranchName: BranchName,
    };

    $.ajax({
        url: 'SaveBranchUpdate',
        type: 'POST',
        data: branch,
        success: function (response) {
            if (ID !== "0") {
                showToast("Your Changes have been Updated successfully!", "success");
            } else {
                showToast("Your Data have been Saved successfully!", "success");
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

function Edit(ID) {
    debugger;
    $.ajax({
        url: 'GetBranchById',
        type: 'GET',
        data: { ID: ID },
        success: function (data) {
            if (data) {
                $('#HID').val(data.ID);
                $('#BranchName').val(data.BranchName);
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

function Delete(ID) {
    $.ajax({
        url: 'DeleteBranchById',
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
