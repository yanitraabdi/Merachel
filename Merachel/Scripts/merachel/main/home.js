$(document).ready(function () {
    Home.Course.Init();
});

var Home = {
    Course : {
        Init: function () {
            $.ajax({
                url: merachel.Configuration.merachelUrl + '/api/v1/coursecategory',
                //data: params,
                type: 'GET'
            })
                .done(function (data, textStatus, jqXHR) {
                    if (data.length > 0) {
                        Home.Course.Template(data);
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
                template += '<div class="card mb-4 box-shadow">' +
                    '<div class="card-header">' +
                    '<h4 class="my-0 font-weight-normal">' + item.CourseCategoryName + '</h4>' +
                    '</div>' +
                    '<div class="card-body">' +
                    '<ul class="list-unstyled mt-3 mb-4">' +
                    '<li>' + item.CourseCategoryName + '</li>' +
                    '</ul>' +
                    '<button type="button" class="btn btn-lg btn-block btn-outline-primary">Sign up for free</button>' +
                    '</div>' +
                    '</div>' 
                    //'<tr><td>' + item.CourseCategoryName + '</td><td>' + item.content + '</td><td>' + item.UID + '</td></tr>';
            });
            $('#home-course').append(template);
        }
    },
        
    
};