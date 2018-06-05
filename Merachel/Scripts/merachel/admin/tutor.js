Current = {};

$(document).ready(function () {
    Tables.Init();

    $('#panelTransaction').hide();
    $('#panelConfirmed').hide();
    $('.panel-search-info').hide();
    $('.panel-search-result').hide();

    $('.search').unbind().click(function () {
        Tables.Refresh();
    });

    $('.reset').unbind().click(function () {
        Filter.Reset();
    });

    $('.create').unbind().click(function () {
        Form.Init.Create();
    });

    $("#formTransaction").submit(function (e) {
        Form.Submit();
        e.preventDefault();
    });

    $('.back').unbind().click(function () {
        Form.Back();
    });

    $('.delete').unbind().click(function () {
        Form.Delete();
    });

    $('#tbSearchCategoryName').keypress(function (e) {
        if (e.which == 13) {
            Tables.Refresh();
            return false;
        }
    });

    $('#fileupload').fileupload({
        maxFileSize: 2500,
        dataType: 'json',
        url: merachel.Configuration.merachelUrl + '/Upload/UploadTutor',
        autoUpload: true,
        maxNumberOfFiles: 1,
        done: function (e, data) {
            attachments = {
                id: merachel.Utility.GuidGenerator(),
                FileName: data.result.name,
                FileOriginalName: data.result.name,
                FilePath: merachel.Configuration.merachelUrl + '/Upload/' + data.result.name,
                FileSize: data.result.size,
                Description: ''
            };
            console.log(attachments);
            $('#pnlUploadAttachment').append(Form.Attachment(attachments));
            //$('#hdAttachment' + attachments.id).val(JSON.stringify(attachments));

            //setTimeout(function () {
            //    $('.progress .progress-bar').css('width', '0%');
            //}, 1000);

            //$('#pnlListAttachment-error').hide();
        }
    }).bind('fileuploadprogressall', function (e, data) {
        var progress = parseInt(data.loaded / data.total * 100, 10);
        $('.progress .progress-bar').css('width', progress + '%');
    });
});

var Tables = {
    Init: function () {
        var tblSummaryData = $('#tblSummaryData').DataTable({
            "oLanguage": {
                "sEmptyTable": "No data available"
            },
            "bLengthChange": false,
            "bFilter": false,
            "data": [],
            "scrollX": true,
            "columns": [
                { data: "EmployeeName" },
                { data: "EmployeeDescription" },
                { data: "EmployeeSpecial" },
                { data: "Status" }
            ]
        });

        $('#tblSummaryData tbody').on('dblclick', 'tr', function (e) {
            var table = $('#tblSummaryData').DataTable();
            var data = table.row(this).data();
            if (data != null) {
                Current.Selected = data;
                Form.Init.Edit();
            }
        });

        $(window).resize(function () {
            $("#tblSummaryData").DataTable().columns.adjust().draw();
        });
    },
    Refresh: function () {
        var params = {
            employeename: $('#tbSearchTutorName').val(),
            employeedescription: $('#tbSearchTutorDescription').val(),
            employeespecial: $('#tbSearchTutorSpecial').val(),
            status: ($('#rbSearchStatusActive').is(':checked') ? 1 : ($('#rbSearchStatusInactive').is(':checked') ? 0 : null))
        };

        $.ajax({
            url: merachel.Configuration.merachelUrl + '/api/v1/tutor',
            data: params,
            type: 'GET',
            beforeSend: function (xhr) {
                BeforeSendAjaxBehaviour();
            }
        })
        .done(function (data, textStatus, jqXHR) {
            if (data.length > 0) {
                $('.panel-search-info').hide('slow');
                $('.panel-search-result').show('slow');
            }
            else {
                $('.panel-search-info').show('slow');
                $('.panel-search-result').hide('slow');
            }
            var table = $('#tblSummaryData').DataTable();
            table.clear().rows.add(data).draw();
            AfterSendAjaxBehaviour();
        })
        .fail(function (jqXHR, textStatus, errorThrown) {
            AfterSendAjaxBehaviour(null, errorThrown);
        });
    }
}

var Filter = {
    Reset: function () {
        $('#tbSearchTutorName').val('');
        $('#tbSearchTutorDescription').val('');
        $('#tbSearchTutorSpecial').val('');
        $('#rbSearchStatusAll').prop('checked', true);
    }
}

var Form = {
    Init: {
        Create: function () {
            $('#panelSummary').hide('slow');
            $('#panelTransaction').show('slow');
            $('#spTitle').text('Create');

            merachel.Utility.ClearForm("formTransaction");
            $('#rbStatusActive').prop('checked', true);
            $('.select2').attr('style', 'width:100%;');
            $('.delete').hide();            

            Current.IsNew = true;
        },
        Edit: function () {
            $('#panelSummary').hide('slow');
            $('#panelTransaction').show('slow');
            $('#spTitle').text('Edit');
            $('.delete').show();

            console.log(Current.Selected);

            $('#tbTutorName').val(Current.Selected.EmployeeName);
            $('#tbTutorSpecial').val(Current.Selected.EmployeeSpecial);
            $('#tbNewTemplateContent').val(Current.Selected.EmployeeDescription);
            (Current.Selected.status == 1) ? $('#chIsActive').prop('checked', true) : $('#chIsActive').prop('checked', false)
            $('.select2').attr('style', 'width:100%;');

            Current.IsNew = false;
        }
    },
    Submit: function () {
        if (Current.IsNew) {
            Tutors.Post();
        } else {
            Tutors.Put();
        }
    },
    Back: function () {
        $('#panelTransaction').hide('slow');
        $('#panelConfirmed').hide('slow');
        $('#panelSummary').show('slow');
    },
    Confirm: function () {
        $('#panelTransaction').hide('slow');
        $('#panelConfirmed').show('slow');
        $('.panel-search-result').hide('slow');
    },
    Delete: function () {
        Tutors.Delete();
    },
    Back: function () {
        $('#panelTransaction').hide('slow');
        $('#panelSummary').show('slow');
    },
    Attachment: function (data) {
        return '<div id="pnlAttachment-' + data.id + '" class="comment"> ' +
                    '<img src="' + data.FilePath + '" alt="" class="img-error"> ' +
                    '<div class="overflow-h"> ' +
                        '<strong><a id="${id}" href=' + data.FilePath + ' target="_blank">' + data.FileOriginalName + '</a><small class="pull-right pointer" onclick="removeAttachment(\'' + data.id + '\');"><i class="fa fa-times"></i></small></strong> ' +
                        '<p>Size: ' + data.FileSize + '</p> ' +
                    '</div> ' +
                    '<input type="hidden" id="hdAttachment' + data.id + '" class="attachment-hidden-data" /> ' +
                '</div>';
    }
}

var Tutors = {
    Post: function () {
        var params = Data.PostParams();

        var l = Ladda.create(document.querySelector('#btSubmit'));
        $.ajax({
            url: merachel.Configuration.merachelUrl + '/api/v1/tutor',
            type: 'POST',
            dataType: "json",
            contentType: "application/json",
            data: JSON.stringify(params),
            cache: false,
            beforeSend: function (xhr) {
                BeforeSendAjaxBehaviour(l);
            }
        }).done(function (data, textStatus, jqXHR) {
            AfterSendAjaxBehaviour(l);
            Form.Confirm();
        })
        .fail(function (jqXHR, textStatus, errorThrown) {
            AfterSendAjaxBehaviour(l, errorThrown);
        })
    },
    Put: function () {
        var params = Data.PostParams()

        var l = Ladda.create(document.querySelector('#btSubmit'));
        $.ajax({
            url: merachel.Configuration.merachelUrl + '/api/v1/tutor/' + Current.Selected.employeeId,
            type: 'PUT',
            dataType: "json",
            contentType: "application/json",
            data: JSON.stringify(params),
            cache: false,
            beforeSend: function (xhr) {
                BeforeSendAjaxBehaviour(l);
            }
        }).done(function (data, textStatus, jqXHR) {
            AfterSendAjaxBehaviour(l);
            Form.Confirm();
            Current.Selected = null;
        })
        .fail(function (jqXHR, textStatus, errorThrown) {
            AfterSendAjaxBehaviour(l, errorThrown);
        })
    },
    Delete: function () {
        var l = Ladda.create(document.querySelector('#btSubmit'));
        $.ajax({
            url: merachel.Configuration.merachelUrl + '/api/v1/tutor/' + Current.Selected.employeeId,
            type: 'DELETE',
            dataType: "json",
            contentType: "application/json",
            cache: false,
            beforeSend: function (xhr) {
                BeforeSendAjaxBehaviour(l);
            }
        }).done(function (data, textStatus, jqXHR) {
            AfterSendAjaxBehaviour(l);
            Form.Confirm();
        })
        .fail(function (jqXHR, textStatus, errorThrown) {
            AfterSendAjaxBehaviour(l, errorThrown);
        })
    }
}

var Data = {
    PostParams: function () {
        var params = {
            employeename: $('#tbTutorName').val(),
            employeespecial: $('#tbTutorSpecial').val(),
            employeedescription: $('#tbNewTemplateContent').val(),
            status: $('#chIsActive').is(':checked') ? 1 : 0,
            employeefilename: attachments.FileName,
            employeefilepath: "Tutor"
        };

        return params;
    }
}

function removeAttachment(id) {
    $('#pnlAttachment' + id).remove();
}