var HA = (function () {
    var HA = function () {
        return new Object();
    };
});

$(document).ready(function () {
    HA.HtmlForm = window.document.forms[0];

    HA.author = "Karega Scott";
    HA.Version = "1.0.0";
    HA.UnsecuredHostBaseUrl = "http://" + document.location.host;
    HA.SecuredHostBaseUrl = "https://" + document.location.host;
    HA.ActualHostBaseUrl = document.location.protocol + "//" + document.location.host;
});

function _showDialog (title, data) {
    $("#dialog").html(data);

    $("#dialog").dialog({
        title: title,
        model: true
    });
}


HA.eventCalendar = HA.prototype = {
    init: function () {
        $('#calendar').fullCalendar({
            header: {
                left: 'prev,next today',
                center: 'title',
                right: 'month,agendaWeek,agendaDay'
            },
            editable: false,
            events: function (start, end, callback) {
                var tokenSet = 'undefined';
                $.each(document.cookie.split(';'), function(index,item){
                    var pair = item.split('=');
                    if(pair[0] == 'X-XSRF-TOKEN') {
                        tokenSet = pair;
                        return;
                    }
                });
                
                $.ajax({
                    url: HA.ActualHostBaseUrl + '/eventcalendar/events',
                    type: 'POST',
                    data: {date: start},
                    headers: {"X-XSRF-TOKEN": tokenSet[1]},
                    success: function (results) {
                        var events = [];
                        results.forEach(function (result) {
                            // Shouldn't haven't to call replace twice...
                            var resultStart = result.TimeStamps.StartDate;
                            //var resultEnd = result.TimeStamps.EndDate;

                            var url = "javascript:HA.eventCalendar.showDialog({" +
                                "Title: '" + result.Title + "'," +
                                "Location: '" + result.Location + "'," +
                                "Description: '" + result.Description + "'," +
                                "Speakers: '" + result.Speakers + "'," +
                                "Start: '" + resultStart + "'," +
                               // "End: '" + resultEnd + "'," +
                                "})";


                            events.push({
                                title: result.Title,
                                start: resultStart,
                               // end: resultEnd,
                                url: url,
                                allDay: false
                            });
                        });
                        callback(events);
                    },
                    error: function () { }
                });
            }
        });
    },

    showDialog: function (options) {
        var start = new Date(options.Start);
        var end = new Date(options.End);

        var dates = $.fullCalendar.formatDate(start, "MMMM dd") + "&nbsp;to&nbsp;" + 
                    $.fullCalendar.formatDate(end, "MMMM dd, yyyy")
    
        var times = $.fullCalendar.formatDate(start, "HH:mm TT") + "&nbsp;to&nbsp;" + 
                    $.fullCalendar.formatDate(end, "HH:mm TT")
    
        var html =
        "<table>" +
        "<tr><td>Date:</td><td>" + dates + "</td></tr>" +
        "<tr><td>Time:</td><td>" + times + "</td></tr>" +
        "<tr><td>Speakers:</td><td>" + options.Speakers + "</td></tr>" +
        "<tr><td>Location:</td><td>" + options.Location + "</td></tr>" +
        "<tr><td colspan='2'>" + options.Description + "</td></tr>" +
        "</table>";

        _showDialog(options.Title, html);
    },
};
