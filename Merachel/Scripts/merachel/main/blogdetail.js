$(document).ready(function () {
    Blog.Init();
});

var Blog = {

    Init: function () {

        $.ajax({
            url: merachel.Configuration.merachelUrl + '/api/v1/blogcategories?status=1',
            type: 'GET'
        })
            .done(function (data, textStatus, jqXHR) {
                if (data.length > 0) {
                    Blog.CategoryTemplate(data);
                }
                else {
                    console.log(textStatus);
                }
            })
            .fail(function (jqXHR, textStatus, errorThrown) {
                console.log(errorThrown);
            });
    },

    LoadInit: function () {

        $.ajax({
            url: merachel.Configuration.merachelUrl + '/api/v1/blogs?blogid=' + merachel.Utility.queryString()['blogId'],
            type: 'GET'
        })
            .done(function (data, textStatus, jqXHR) {
                if (data.length > 0) {
                    Blog.Template(data);
                }
                else {
                    console.log(textStatus);
                }
            })
            .fail(function (jqXHR, textStatus, errorThrown) {
                console.log(errorThrown);
            });
    },


    LoadList: function (id) {

        $.ajax({
            url: merachel.Configuration.merachelUrl + '/api/v1/blogs?status=1&limit=10&categoryId=' + id,
            type: 'GET'
        })
            .done(function (data, textStatus, jqXHR) {
                if (data.length > 0) {
                    Blog.Template(data);
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
        $('#blog-list').html('');
        var template = '';
        $.each(data, function (i, item) {
            template += '<div class="card mb-4 box-shadow">' +
                '<div class="card-body d-flex flex-column align-items-start">' +
                '<strong class="d-inline-block mb-2 text-primary">' + item.BlogCategoryName + '</strong>' +
                '<h3 class="mb-0"><a class="text-dark" href="' + merachel.Configuration.merachelUrl + "/Blog/Detail/" + item.BlogID + '">' + item.BlogTitle + '</a></h3>' +
                '<p class="card-text mb-auto">' + item.BlogContent + '</p>' +
                '<a href="' + merachel.Configuration.merachelUrl + "/Blog/Detail/" + item.BlogID + '">Continue reading</a>' +
                '</div></div>';
        });
        $('#blog-list').append(template);
    },
    CategoryTemplate: function (data) {
        var template = '';
        $.each(data, function (i, item) {
            if (data.length > 0) {
                template += '<a href="' + merachel.Configuration.merachelUrl + "/Blog?categoryId=" + item.BlogCategoryID + '" class="list-group-item list-group-item-action">' + item.BlogCategoryName + '</a>';
            }
        });
        $('#blogcategory-list').append(template);
    }
};