$(document).ready(function () {
    Tutor.Init();
});

var Tutor = {

    Init: function () {

        $.ajax({
            url: merachel.Configuration.merachelUrl + '/api/v1/Tutor',
            type: 'GET'
        })
            .done(function (data, textStatus, jqXHR) {
                if (data.length > 0) {
                    Tutor.Template(data);
                }
                else {
                    console.log(textStatus);
                }
            })
            .fail(function (jqXHR, textStatus, errorThrown) {
                console.log(errorThrown);
            });
    },
    Template: function (data) {
        var template = '';
        $.each(data, function (i, item) {
            template += '<div class="media">' +
                '<img class="align-self-start mr-3" src="' + item.EmployeeFilePath + '" alt="' + item.EmployeeFileName + '" />' +
                '<div class="media-body">' +
                '<h5 class="mt-0">' + item.EmployeeName + '</h5>' +
                '<p>' + item.EmployeeDescription + '</p>' +
                '<p class="text-mute">' + item.EmployeeSpecial + '</p>' +
                '</div></div>';
        });
        $('#tutor-media').append(template);
    }
};