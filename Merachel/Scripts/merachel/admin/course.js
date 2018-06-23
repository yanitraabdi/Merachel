Current = {};

$(document).ready(function () {
    Tables.Init();
    //Select2.Init();

    $('#panelTransaction').hide();
    $('#panelConfirmed').hide();
    $('.panel-search-info').hide();
    $('.panel-search-result').hide();

    //merachel.Utility.rangeDatepicker('tbSearchStartDate', 'tbSearchEndDate');

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

    $("#btSubmit").unbind().click(function (e) {
        Form.Submit();
    });

    $('#btnModal').unbind().click(function (e) {
        e.preventDefault();
    });

    $("#btSubmitPrice").unbind().click(function (e) {
        Grid.Submit();
    });

    $('#tbSearchCategoryName').keypress(function (e) {
        if (e.which == 13) {
            Tables.Refresh();
            return false;
        }
    });

    $('#fileupload').fileupload({
        maxFileSize: 4000,
        dataType: 'json',
        url: merachel.Configuration.merachelUrl + '/Shared/UploadCourse',
        autoUpload: true,
        maxNumberOfFiles: 1,
        done: function (e, data) {
            attachments = {
                id: merachel.Utility.GuidGenerator(),
                FileName: data.result.name,
                FileOriginalName: data.result.name,
                FilePath: merachel.Configuration.merachelUrl + '/Upload/Course/' + data.result.name,
                FileSize: data.result.size,
                Description: ''
            };

            $('#pnlUploadAttachment').append(Form.Attachment(attachments));
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
                { data: "TestimonialUser" },
                { data: "TestimonialContent" },
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
            employeename: $('#tbSearchName').val(),
            employeedescription: $('#tbSearchTestimonial').val(),
            status: ($('#rbSearchStatusActive').is(':checked') ? 1 : ($('#rbSearchStatusInactive').is(':checked') ? 0 : null))
        };

        $.ajax({
            url: merachel.Configuration.merachelUrl + '/api/v1/course',
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

var Select2 = {
    Init: function () {

    },
    Refresh: {
        ViolationGroup: function (data) {
            merachel.Utility.Select2Ajax({
                id: 'slViolationGroup',
                placeholderName: 'Select Violation Group',
                data: data,
                onSelect: function () {
                    $('#slViolationCategory').val(null).trigger('change');
                    $('#slViolationType').val(null).trigger('change');

                    $("#slViolationCategory").select2().empty();
                    $("#slViolationType").select2().empty();

                    var idx = $('#slViolationGroup').val();
                    var data = Enumerable.from(Data.Collection.ViolationCategory.items).where(i => i.parentId == idx).select().toArray();
                    Select2.Refresh.ViolationCategory(data);
                }
            });
        }
    }
}

var Filter = {
    Reset: function () {
        $('#tbSearchName').val('');
        $('#tbSearchTestimonial').val('');
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
            $('#btDelete').hide();

            Current.IsNew = true;
        },
        Edit: function () {
            $('#panelSummary').hide('slow');
            $('#panelTransaction').show('slow');
            $('#spTitle').text('Edit');

            console.log(Current.Selected);

            $('#tbCategoryName').val(Current.Selected.BlogCategoryName);
            (Current.Selected.Status == 1) ? $('#rbStatusActive').prop('checked', true) : $('#rbStatusInactive').prop('checked', true)
            $('.select2').attr('style', 'width:100%;');

            $('#btDelete').show();

            Current.IsNew = false;
        }
    },
    Submit: function () {
        if (Current.IsNew) {
            Courses.Post();
        } else {
            Courses.Put();
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
        Courses.Delete();
    },
    Attachment: function (data) {
        return '<div id="pnlAttachment-' + data.id + '" class="comment"style="margin-bottom:10px;"> ' +
            '<img src="' + data.FilePath + '" alt="" class="img-error" style="max-width: 300px; "> ' +
            '<div class="overflow-h" style="display: inline-block; vertical-align: top;"> ' +
            '<strong><a id="${id}" href=' + data.FilePath + ' target="_blank" style="display: none">' + data.FileOriginalName + '</a><span class="pull-right pointer" onclick="removeAttachment(\'' + data.id + '\');" style="cursor: pointer;"><i class="fa fa-times"></i></span></strong> ' +
            //'<p>Size: ' + data.FileSize + '</p> ' +
            '</div> ' +
            '<input type="hidden" id="hdAttachment' + data.id + '" class="attachment-hidden-data" /> ' +
            '</div>';
    }
}

var Grid = {
    Add: function () {

    },
    Submit: function () {

    },
}

var Courses = {
    Post: function () {
        var params = Data.PostParams();

        var l = Ladda.create(document.querySelector('#btSubmit'));
        $.ajax({
            url: merachel.Configuration.merachelUrl + '/api/v1/courses',
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
            url: merachel.Configuration.merachelUrl + '/api/v1/courses/' + Current.Selected.CourseID,
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
            url: merachel.Configuration.merachelUrl + '/api/v1/courses/' + Current.Selected.CourseID,
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
            CourseCode: $('#tbNewTemplateCode').val(),
            CourseName: $('#tbNewTemplateDesc').val(),
            CoursePicturePatch: $('#tbNewTemplateHeader').val(),
            CoursePictureName: $('#tbNewTemplateContent').val(),
            CourseCategoryID: $('#slTemplateType').val(),
            Status: $('#chIsActive').is(':checked') ? 1 : 0,
            ListPrice: []
        };

        return params;
    }
}

function removeAttachment(id) {
    $('#pnlAttachment-' + id).remove();
}