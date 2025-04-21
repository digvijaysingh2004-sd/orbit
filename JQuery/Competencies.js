$(document).ready(function () {
    $.ajax({
        type: "GET",
        url: "GetPerformanceType",
        dataType: "json",
        success: function (data) {
            var s = '<option value="" selected disabled>Select Performance</option>'; 
            for (var i = 0; i < data.length; i++) {
                s += '<option value="' + data[i].ID + '">' + data[i].PerformanceType + '</option>';
            }
            $("#Perfromance").html(s);
        }
    });
});

$('#SaveUpdate').click(function () {
    var ID = $('#HID').val()?.trim() || "0";

    if (!validateCompetenciesForm()) {
        return; 
    }

    var data = {
        ID: ID,
        Perfromance: $('#Perfromance').val()?.trim(),
        CompetenciesName: $('#CompetenciesName').val()?.trim(),
    };

    $.ajax({
        url: 'SaveCompetenciesUpdate',
        type: 'POST',
        data: data,
        success: function (response) {
            if (ID !== "0") {
                showToast("Competencies has been updated successfully!", "success");
            } else {
                showToast("New Competencies saved successfully!", "success");
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

function EditCompetencies(ID) {
    $.ajax({
        url: 'GetCompetenciesById',
        type: 'GET',
        data: { ID: ID },
        success: function (data) {
            if (data) {
                $('#HID').val(data.ID);
                $('#Perfromance').val(data.Perfromance);
                $('#CompetenciesName').val(data.CompetenciesName);
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

function DeleteCompetencies(ID) {
    $.ajax({
        url: 'DeleteCompetenciesById',
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

function validateCompetenciesForm() {
    let errors = [];

    var CompetenciesName = $('#CompetenciesName').val()?.trim();
    var Performances = $('#Perfromance').val()?.trim();

    if (!CompetenciesName) {
        errors.push("CompetenciesName cannot be empty!");
    }
    if (!Performances) {
        errors.push("Performance cannot be empty!");
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