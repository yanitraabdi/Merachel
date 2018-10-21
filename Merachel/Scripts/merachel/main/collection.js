$(document).ready(function () {
    Collection.Init();
});

var Collection = {

    Init: function () {

        $.ajax({
            url: merachel.Configuration.merachelUrl + '/api/v1/collections',
            type: 'GET'
        })
            .done(function (data, textStatus, jqXHR) {
                if (data.length > 0) {
                    Collection.Template(data);
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
            if (item.ListPicture.length > 0) {
            template += '<div class="card mb-3 bg-dark text-white border-0">' +
                '<img class="card-img" src="' + item.ListPicture[0].CollectionPictureFilePath + '" alt="' + item.ListPicture[0].CollectionPictureFileName + '" />' +
                '<div class="card-img-overlay">' +
                '<h5 class="card-title">' + item.CollectionTitle + '</h5>' +
                //'<p class="card-text">' + item.EmployeeDescription + '</p>' +
                    '</div></div>';
            }
        });
        $('#collection-list').append(template);
    }
};