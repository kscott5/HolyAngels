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

function _clearForm() {
    $(HA.HtmlForm).find("input").attr("value", "");
    $(HA.HtmlForm).find("input[type='checkbox']").removeAttr("checked");
    
    $(HA.HtmlForm).find("textarea").attr("value", "");
    $(HA.HtmlForm).find("select option[selected]").removeAttr("selected")
}

function _submitForm() {
    $(HA.HtmlForm).submit();
}

function _initRichTextEditor(options) {
    if (options != null && 
        options.content_css_url.indexOf(HA.UnsecuredHostBaseUrl) == -1 &&
        options.content_css_url.indexOf(HA.SecuredHostBaseUrl) == -1) {
        options.content_css_url = HA.ActualHostBaseUrl + options.content_css_url;
    }

    if (options != null &&
        options.media_url.indexOf(HA.UnsecuredHostBaseUrl) == -1 &&
        options.media_url.indexOf(HA.SecuredHostBaseUrl) == -1) {
        options.media_url = HA.ActualHostBaseUrl + options.media_url + "/";
    }

    //$(HA.HtmlForm).find("textarea[class='rtarea']").rte(options);
    $(HA.HtmlForm).find("textarea").rte(options);
}

function _initDatePickers(options) {
    $("#StartDate").datepicker(options);
    $("#EndDate").datepicker(options);
}

function _showDialog (title, data) {
    $("#dialog").html(data);

    $("#dialog").dialog({
        title: title,
        model: true
    });
}

// Javascript function used to home page
HA.home = HA.prototype = {
    init: function () {
        HA.common.initNavigation();

        // TODO: initialize the home page
    }
};


// Common javascript functions
HA.common = HA.prototype = {
    initNavigation: function () {

        // TODO: initialize the primary site navigation

    },

    richTextEditor: function (options) {
        _initRichTextEditor(options);
    },

    datePickers: function (options) {
        _initDatePickers(options);
    },

    bindClicks: function () {
        var objClear = $("#clear");
        if (objClear) {
            objClear.bind("click", function () {
                _clearForm();
            });
        }

        var objSave = $("#save");
        if (objSave) {
            objSave.bind("click", function () {
                _submitForm();
            });
        }

        var objRegister = $("#register");
        if (objRegister) {
            objRegister.bind("click", function () {
                _submitForm();
            });
        }

        var objSignIn = $("#signin");
        if (objSignIn) {
            objSignIn.bind("click", function () {
                _submitForm();
            });
        }

        var objRetreivePwd = $("#retreivePwd");
        if (objRetreivePwd) {
            objRetreivePwd.bind("click", function () {
                _submitForm();
            });
        }
    }
};

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
                            var resultStart = result.TimeStamp.StartDate;
                            var resultEnd = result.TimeStamp.EndDate;

                            var url = "javascript:HA.eventCalendar.showDialog({" +
                                "Title: '" + result.Title + "'," +
                                "Location: '" + result.Location + "'," +
                                "Description: '" + result.Description + "'," +
                                "Speakers: '" + result.Speakers + "'," +
                                "Start: '" + resultStart + "'," +
                                "End: '" + resultEnd + "'," +
                                "})";


                            events.push({
                                title: result.Title,
                                start: resultStart,
                                end: resultEnd,
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

// javascript functions for managing users
HA.manageUsers = HA.prototype = {
    initListPage: function () {
        //TODO: Any page initialization
    },

    initAddPage: function () {
        HA.common.bindClicks();
    },

    initEditPage: function () {
        HA.common.bindClicks();
    }
};

// javascript functions for managing events
HA.manageEvents = HA.prototype = {
    initListPage: function () {
        //TODO: Any page initialization
    },

    initAddPage: function (dpOptions, rteOptions) {
        HA.common.bindClicks();
        HA.common.datePickers(dpOptions);
        HA.common.richTextEditor(rteOptions);
    },

    initEditPage: function (dpOptions, rteOptions) {
        HA.common.bindClicks();
        HA.common.datePickers(dpOptions);
        HA.common.richTextEditor(rteOptions);
    }
};

// javascript functions for managing quotes
HA.manageQuotes = HA.prototype = {
    initListPage: function () {
        //TODO: Any page initialization
    },

    initAddPage: function (rteOptions) {
        HA.common.bindClicks();
        HA.common.richTextEditor(rteOptions);
    },

    initEditPage: function (rteOptions) {
        HA.common.bindClicks();
        HA.common.richTextEditor(rteOptions);
    }
};

// javascript functions for managing ministries
HA.manageMinistries = HA.prototype = {
    initListPage: function () {
        //TODO: Any page initialization
    },

    initAddPage: function (rteOptions) {
        HA.common.bindClicks();
        HA.common.richTextEditor(rteOptions);
    },

    initEditPage: function (rteOptions) {
        HA.common.bindClicks();
        HA.common.richTextEditor(rteOptions);
    }
};

// javascript functions for managing articles
HA.manageArticles = HA.prototype = {
    initListPage: function () {
        //TODO: Any page initialization
    },

    initAddPage: function (dpOptions, rteOptions) {        
        HA.common.bindClicks();
        HA.common.datePickers(dpOptions);
        HA.common.richTextEditor(rteOptions);
    },

    initEditPage: function (dpOptions, rteOptions) {
        HA.common.bindClicks();
        HA.common.datePickers(dpOptions);
        HA.common.richTextEditor(rteOptions);
    }
};
