Current = {};

$(document).ready(function () {
    Tables.Init();
    Select2.Init();

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

    $('#tbSearchCategoryName').keypress(function (e) {
        if (e.which == 13) {
            Tables.Refresh();
            return false;
        }
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
                { data: "BlogCategoryName" },
                { data: "StatusDescription" }
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
            categoryName: $('#tbSearchCategoryName').val(),
            status: ($('#rbSearchStatusActive').is(':checked') ? 1 : ($('#rbSearchStatusInactive').is(':checked') ? 0 : null))
        };

        $.ajax({
            url: merachel.Configuration.merachelUrl + '/api/v1/blogcategories',
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
        $('#tbSearchCategoryName').val('');
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
            $('#rbStatusInactive').prop('checked', false);
            $('.select2').attr('style', 'width:100%;');
            $('#btDelete').hide('slow');

            Current.IsNew = true;
        },
        Edit: function () {
            $('#panelSummary').hide('slow');
            $('#panelTransaction').show('slow');
            $('#spTitle').text('Edit');

            $('#tbCategoryName').val(Current.Selected.BlogCategoryName);
            (Current.Selected.Status == 1) ? $('#rbStatusActive').prop('checked', true) : $('#rbStatusInactive').prop('checked', true)
            $('.select2').attr('style', 'width:100%;');

            $('#btDelete').show();

            Current.IsNew = false;
        }
    },
    Submit: function () {
        if (Current.IsNew) {
            BlogCategories.Post();
        } else {
            BlogCategories.Put();
        }
    },
    Back: function () {
        $('#panelConfirmed').hide('slow');
        $('#panelTransaction').hide('slow');
        $('#panelSummary').show('slow');
    },
    Confirm: function () {
        $('#panelTransaction').hide('slow');
        $('#panelConfirmed').show('slow');
        $('.panel-search-result').hide('slow');
    },
    Delete: function () {
        BlogCategories.Delete();
    }
}

var BlogCategories = {
    Post: function () {
        var params = Data.PostParams();

        var l = Ladda.create(document.querySelector('#btSubmit'));
        $.ajax({
            url: merachel.Configuration.merachelUrl + '/api/v1/blogcategories',
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
            url: merachel.Configuration.merachelUrl + '/api/v1/blogcategories/' + Current.Selected.blogcategoryid,
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
            url: merachel.Configuration.merachelUrl + '/api/v1/blogcategories/' + Current.Selected.blogcategoryid,
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
            BlogCategoryName: $('#tbCategoryName').val(),
            Status: $('#rbStatusActive').is(':checked') ? 1 : 0
        };

        return params;
    }
}