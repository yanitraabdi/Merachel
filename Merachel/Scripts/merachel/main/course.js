$(document).ready(function () {
    Course.Init();
});

var Course = {

    Init: function () {

        $.ajax({
            url: merachel.Configuration.merachelUrl + '/api/v1/course?coursecategoryid=' + merachel.Utility.queryString()['course'],
            type: 'GET'
        })
            .done(function (data, textStatus, jqXHR) {
                if (data.length > 0) {
                    Course.Template(data);
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
        var prices = '';
        $.each(data, function (i, item) {
            $.each(item.ListPrice, function (j, price) {
                prices += '<div class="card">' +
                    '<div class="card-body">' +
                    '<h5 class="mt-0">' + price.CoursePriceName + '</h5>' +
                    '<p>' + price.CoursePriceDescription + '</p>' +
                    '<p>' + merachel.Utility.formatMoney(price.CoursePriceTotal) + '</p>' +
                    '</div></div>';
            });


            if (item.ListPrice.length > 0) {
                template += '<div class="media mb-5">' +
                    '<img class="mr-3" src="' + item.CoursePictureFilePath + '" alt="' + item.CoursePictureFileName + '" />' +
                    '<div class="media-body">' +
                    '<h1 class="mt-0">' + item.CourseName + '</h1>' +
                    '<p>' + item.CourseDescription + '</p>' +
                    '<div class="card-columns">' +
                    prices +
                    '</div></div></div>';
            }
        });
        $('#course-list').append(template);
    }
};