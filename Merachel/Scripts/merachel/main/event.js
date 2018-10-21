$(document).ready(function () {
    Event.Init();

    if (merachel.Utility.queryString()['eventId'] !== undefined) {
        Event.LoadDetail(merachel.Utility.queryString()['eventId']);
    }
    //else {
    //    Event.LoadInit();
    //}
});

var Event = {

    Init: function () {

        $.ajax({
            url: merachel.Configuration.merachelUrl + '/api/v1/event?status=1',
            type: 'GET'
        })
            .done(function (data, textStatus, jqXHR) {
                if (data.length > 0) {
                    Event.ListTemplate(data);
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
            url: merachel.Configuration.merachelUrl + '/api/v1/event?status=1&limit=10',
            type: 'GET'
        })
            .done(function (data, textStatus, jqXHR) {
                if (data.length > 0) {
                    Event.DetailTemplate(data);
                }
                else {
                    console.log(textStatus);
                }
            })
            .fail(function (jqXHR, textStatus, errorThrown) {
                console.log(errorThrown);
            });
    },

    LoadDetail: function (id) {

        $.ajax({
            url: merachel.Configuration.merachelUrl + '/api/v1/event?eventId=' + id,
            type: 'GET'
        })
            .done(function (data, textStatus, jqXHR) {
                if (data.length > 0) {
                    Event.DetailTemplate(data);
                }
                else {
                    console.log(textStatus);
                }
            })
            .fail(function (jqXHR, textStatus, errorThrown) {
                console.log(errorThrown);
            });
    },

    DetailTemplate: function (data) {
        $('#event-detail').html('');
        var template = '';
        $.each(data, function (i, item) {
            template += '<div class="blog-post">' +
                '<h2 class="mb-2">' + item.EventName + '</h2>' +
                '<h5 class="card-title">' + item.EventLocation + ' - ' + item.EventHost + '</h5>' +
                '<h6 class="card-subtitle mb-2 text-muted">' + moment(item.EventEndDate).format("MMMM Do YYYY") + ', ' + moment(item.EventTimeEnd).format("HH:mm") + '</h6>' +
                '<p class="card-text mb-auto">' + item.EventDescription + '</p>' +
                '</div>';
        });
        $('#event-detail').append(template);
    },

    ListTemplate: function (data) {
        var template = '';
        $.each(data, function (i, item) {
            if (data.length > 0) {
                template += '<a href="' + merachel.Configuration.merachelUrl + "/Home/Event?eventId=" + item.EventID + '" style="text-decoration: none"><div class="card mb-3 border-success">' +
                    '<div class="card-body">' +
                    '<h5 class="card-title">' + item.EventName + '</h5>' +
                    '<h6 class="card-subtitle mb-2 text-muted">' + item.EventLocation + '</h6>' +
                    '<p class="card-text mb-auto">' + item.EventHost + '</p>' +
                    //'<p class="card-text mb-auto">' + moment(item.EventDateCreated).format("MMMM Do YYYY") + ', ' + moment(item.EventTimeStart).format("HH:mm") + ' - ' + moment(item.EventEndDate).format("MMMM Do YYYY") + ', ' + moment(item.EventTimeEnd).format("HH:mm") + '</p>' +
                    '<p class="card-text mb-auto">' + moment(item.EventEndDate).format("MMMM Do YYYY") + ', ' + moment(item.EventTimeEnd).format("HH:mm") + '</p>' +
                    '</div></div></a>';
            }
        });
        $('#event-list').append(template);
    }
};