var merachel = {};
var dateFormat = 'dd M yy';
var send = {
    id: '2'
};


(function ($, merachel) {
    // Utility
    merachel.Utility = {};
    merachel.Shared = {};

    merachel.Utility.setDatepicker = function (id) {
        return $("#" + id).datepicker({
            changeMonth: true,
            changeYear: true,
            yearRange: "-100:+1",
            dateFormat: dateFormat,
            prevText: '<i class="fa fa-angle-left"></i>',
            nextText: '<i class="fa fa-angle-right"></i>',
            showButtonPanel: true
        }).datepicker("setDate", new Date());
    }
    merachel.Utility.setFromDatepicker = function (idDateFrom, idDateTo) {
        return $("#" + idDateFrom).datepicker({
            changeMonth: true,
            changeYear: true,
            yearRange: "-100:+1",
            dateFormat: dateFormat,
            prevText: '<i class="fa fa-angle-left"></i>',
            nextText: '<i class="fa fa-angle-right"></i>',
            showButtonPanel: true,
            onSelect: function (date) {
                var selectedFromDate = $('#' + idDateFrom).datepicker("getDate");
                var selectedToDate = $('#' + idDateTo).datepicker("getDate");

                if (selectedFromDate > selectedToDate) {
                    $('#' + idDateTo).datepicker("setDate", selectedFromDate);
                }
                $('#' + idDateTo).datepicker("option", "minDate", selectedFromDate);
            }
        }).datepicker("setDate", new Date());
    }
    merachel.Utility.setToDatepicker = function (idDateFrom, idDateTo) {
        return $("#" + idDateTo).datepicker({
            changeMonth: true,
            changeYear: true,
            yearRange: "-100:+1",
            dateFormat: dateFormat,
            prevText: '<i class="fa fa-angle-left"></i>',
            nextText: '<i class="fa fa-angle-right"></i>',
            showButtonPanel: true,
            onSelect: function (date) {
            }
        }).datepicker("setDate", new Date());
    }
    merachel.Utility.queryString = function () {
        var vars = [], hash;
        var hashes = window.location.href.slice(window.location.href.indexOf('?') + 1).split('&');
        for (var i = 0; i < hashes.length; i++) {
            hash = hashes[i].split('=');
            vars.push(hash[0]);
            vars[hash[0]] = hash[1];
        }
        return vars;
    }
    merachel.Utility.setStartDatePicker = function (idDateFrom, idDateTo, format) {
        if (format == null) {
            return $("#" + idDateFrom).datepicker({
                //changeMonth: true,
                //changeYear: true,
                dateFormat: "DD, dd MM yy",
                prevText: '<i class="fa fa-angle-left"></i>',
                nextText: '<i class="fa fa-angle-right"></i>',
                yearRange: "-80:+1",
                numberOfMonths: [1, 2],
                minDate: 0,
                maxDate: 365,
                showButtonPanel: true,
                onSelect: function (date) {
                    var selectedFromDate = $('#' + idDateFrom).datepicker("getDate");
                    var selectedToDate = $('#' + idDateTo).datepicker("getDate");

                    if (selectedFromDate > selectedToDate) {
                        $('#' + idDateTo).datepicker("setDate", selectedFromDate);
                    }
                    $('#' + idDateTo).datepicker("option", "minDate", selectedFromDate);
                }
            }).datepicker("setDate", new Date());
        }
        else {
            return $("#" + idDateFrom).datepicker({
                //changeMonth: true,
                //changeYear: false,
                showYear: false,
                showButtonPanel: false,
                dateFormat: format,
                minDate: 0,
                maxDate: 365,
                numberOfMonths: [1, 2],
                showButtonPanel: true,
                onSelect: function (date) {
                    var selectedFromDate = $('#' + idDateFrom).datepicker("getDate");
                    var selectedToDate = $('#' + idDateTo).datepicker("getDate");

                    if (selectedFromDate > selectedToDate) {
                        $('#' + idDateTo).datepicker("setDate", selectedFromDate);
                    }
                    $('#' + idDateTo).datepicker("option", "minDate", selectedFromDate);
                }
            }).datepicker("setDate", new Date());
        }
    }
    merachel.Utility.setEndDatePicker = function (idDateTo, idDateFrom, format) {
        if (format == null) {
            return $("#" + idDateTo).datepicker({
                //changeMonth: true,
                //changeYear: true,
                dateFormat: "DD, dd MM yy",
                prevText: '<i class="fa fa-angle-left"></i>',
                nextText: '<i class="fa fa-angle-right"></i>',
                yearRange: "-80:+1",
                minDate: 0,
                maxDate: 365,
                numberOfMonths: [1, 2],
                showButtonPanel: true,
                onSelect: function (date) {
                }
            }).datepicker("setDate", new Date());
        }
        else {
            return $("#" + idDateTo).datepicker({
                //changeMonth: true,
                //changeYear: false,
                showYear: false,
                showButtonPanel: false,
                dateFormat: format,
                minDate: 0,
                maxDate: 365,
                numberOfMonths: [1, 2],
                showButtonPanel: true,
                onSelect: function (date) {

                }
            }).datepicker("setDate", new Date());
        }
    }
    merachel.Utility.setDatetimepicker = function (id, format) {
        var defaultDate = new Date
        var maxDate = new Date();
        maxDate.setDate(maxDate.getDate() + 365);

        var option = {
            useCurrent: false,
            minDate: defaultDate,
            maxDate: maxDate,
            defaultDate: defaultDate,
            showTodayButton: true,
            sideBySide: true,
            useCurrent: true,
            ignoreReadonly: true
        };
        if (format == null) {
            option.format = "DD MMMM YYYY HH:mm";
        } else {
            option.format = format;
        }

        var datetimePicker = $("#" + id).datetimepicker(option);

        return datetimePicker;
    }
    merachel.Utility.setStartDatetimePicker = function (idDateFrom, idDateTo, format) {
        var defaultDate = new Date();

        var option = {
            useCurrent: false,
            minDate: defaultDate,
            maxDate: defaultDate,
            defaultDate: defaultDate,
            showTodayButton: true,
            sideBySide: true,
            useCurrent: true,
            ignoreReadonly: true
        };
        if (format == null) {
            option.format = "DD MMMM YYYY HH:mm";
        } else {
            option.format = format;
        }

        var datetimePicker = $("#" + idDateFrom).datetimepicker(option).on('dp.change', function (e) {
            $('#' + idDateTo).data("DateTimePicker").minDate(e.date);
        });

        return datetimePicker;
    }
    merachel.Utility.GetLocalTimeDifference = function () {
        var date = new Date();
        var localTimeFromUtc = (date.getTimezoneOffset() / 60) * -1;
        return localTimeFromUtc
    }
    merachel.Utility.setEndDatetimePicker = function (idDateTo, idDateFrom, format) {
        var defaultDate = new Date();
        var maxDate = new Date();
        maxDate.setDate(maxDate.getDate() + 365);
        var option = {
            useCurrent: false,
            minDate: defaultDate,
            maxDate: maxDate,
            defaultDate: defaultDate,
            showTodayButton: true,
            sideBySide: true,
            useCurrent: true,
            ignoreReadonly: true
        };
        if (format == null) {
            option.format = "DD MMMM YYYY HH:mm";
        } else {
            option.format = format;
        }
        var datetimePicker = $("#" + idDateTo).datetimepicker(option).on('dp.change', function (e) {
            $('#' + idDateFrom).data("DateTimePicker").maxDate(e.date);
        });

        return datetimePicker;
    }

    merachel.Utility.setTimepicker = function (id) {
        return $("#" + id).timepicker({
            defaultTime: 'current',
            template: false,
            showInputs: false,
            minuteStep: 1
        });
    }
    merachel.Utility.getCurrentTime = function () {
        var date = new Date($.now());
        var time = date.getHours() + ":" + date.getMinutes();

        return time;
    }


    merachel.Utility.setCookie = function (name, value, days, path) {
        // generate path
        var path = path || '/';
        path = '; path=' + path;
        // generate expires
        var expires = '';
        if (days) {
            var date = new Date();
            date.setTime(date.getTime() + (days * 24 * 60 * 60 * 1000));
            expires = '; expires=' + date.toGMTString();
        }
        document.cookie = name + '=' + value + expires + path;
    };
    merachel.Utility.getCookie = function (name) {
        var nameEQ = name + '=';
        var ca = document.cookie.split(';');
        for (var i = 0; i < ca.length; i++) {
            var c = ca[i];
            while (c.charAt(0) === ' ') c = c.substring(1, c.length);
            if (c.indexOf(nameEQ) === 0) return c.substring(nameEQ.length, c.length);
        }
        return null;
    };
    merachel.Utility.getCharIndex = function (word, character, n) {
        var count = 0, i = 0;
        while (count < n && (i = word.indexOf(character, i) + 1)) {
            count++;
        }
        if (count == n) return i - 1;
        return NaN;
    };
    merachel.Utility.eraseCookie = function (name) {
        merachel.Utility.setCookie(name, "", -1);
    };

    merachel.Utility.getUTCDate = function (value) {
        if (value) {
            var date = new Date(value);
            return moment.utc(date).format();
        }
    }

    merachel.Utility.getLocalDate = function (value) {
        if (value) {
            let date = value;
            var offset = moment().utcOffset();
            return moment.utc(date).utcOffset(offset).format();
        }
        return null;
    }

    /* Autofill cookie */
    /* **************************************************************************** */
    /* Desc: To update "autofill" cookie data from the control(s) of the given container 
     * Param:
     *      containerId (mandatory) : id of div/form (any container) which holds autofilled controls
     *      controlId (optional)    : id of autofilled controll
                                      If this is provided means the function will update the "autofill" cookies with only from this control
     */
    merachel.Utility.saveAutofillData = function (containerId, controlId) {
        var screenName = merachel.Configuration.screenType;
        var cookieStr = merachel.Utility.getCookie("autofill");
        var autofillData = (cookieStr == null) ? {} : JSON.parse(cookieStr);

        var formData = {};
        // Get value from the all control in form
        if (typeof controlId === 'undefined' || controlId === null) {
            $.each($("#" + containerId + " .merachel-autofill"), function (i, control) {
                $control = $(this);
                controlId = $control.attr("id");
                var value = null;
                if (controlId !== null && controlId !== "" && $control.css("display") !== "none") {
                    formData[controlId] = merachel.Utility.getAutofillValue($(this));
                }
            });
        }
            // get value from the one control only
        else {
            var $control = $("#" + containerId + " #" + controlId + ".merachel-autofill");
            if ($control.length > 0 && $control.css("display") !== "none")
                formData[controlId] = merachel.Utility.getAutofillValue($control);
        }

        if (typeof autofillData[screenName] === 'undefined' || autofillData[screenName] == null)
            autofillData[screenName] = {};
        if (typeof autofillData[screenName][containerId] === 'undefined' || autofillData[screenName][containerId] == null)
            autofillData[screenName][containerId] = {};
        autofillData[screenName][containerId] = $.extend(true, autofillData[screenName][containerId], formData);
        merachel.Utility.setCookie("autofill", JSON.stringify(autofillData));
    }

    /* Desc: Used by  merachel.Utility.saveAutofillData  to get value from control based on the control type
     */
    merachel.Utility.getAutofillValue = function ($control) {
        var controlId = $control.attr("id");
        var value = null;
        // TODO: Stephanie lengkapi type control
        if ($control.hasClass('hasDatepicker') || $control.hasClass('datepicker')) {
            var date = $control.datepicker('getDate');
            value = date != null ? merachel.Utility.FormatDate(date, "dd MM yyyy") : null;
        }
        if ($control.is("input")) {
            var inputType = $control.attr("type");
            if (inputType == "radio" || inputType == "checkbox")
                value = $control.is(":checked");
            else {
                value = $control.val();
                if (value.indexOf(',') != -1)  // Untuk mengcover cookie di safari yang ada comma
                    value = value.replace(',', '|')
            }
        }
        else if ($control.is("select")) {
            if ($control.hasClass("select2-hidden-accessible")) {
                if (typeof $control.select2('data')[0] !== 'undefined' && $control.select2('data')[0] != null)
                    value = $control.select2('data')[0].id;
            }
            else
                value = $control.find("option:selected").val();
        }
        else
            value = "";
        return value;
    }

    merachel.Utility.getDateFormat = function ()
    {
        var jsDate = new Date();
        var jsMonth = jsDate.getMonth() + 1 < 10 ? "0" + (jsDate.getMonth() + 1) : jsDate.getMonth() + 1;
        var jsDay = jsDate.getDate() < 10 ? "0" + jsDate.getDate() : jsDate.getDate();
        var jsFormat = '_' + [jsDate.getDate(), , jsDate.getFullYear()].join("") + [jsDate.getHours(), jsDate.getMinutes(), jsDate.getMilliseconds()].join("");
        return jsFormat;
    }

    merachel.Utility.getFileName = function (id) {
        var fullPath = $('#' + id).val();
        var filename = null;
        if (fullPath) {
            var startIndex = (fullPath.indexOf('\\') >= 0 ? fullPath.lastIndexOf('\\') : fullPath.lastIndexOf('/'));
            filename = fullPath.substring(startIndex);
            if (filename.indexOf('\\') === 0 || filename.indexOf('/') === 0) {
                filename = filename.substring(1);
            }
        }
        return filename;
    }

    merachel.Utility.GuidGenerator = function () {
        var S4 = function () {
            return (((1 + Math.random()) * 0x10000) | 0).toString(16).substring(1);
        };
        return (S4() + S4() + "-" + S4() + "-" + S4() + "-" + S4() + "-" + S4() + S4() + S4());
    }

    /* Desc: To set default autofill value from the "autofill" cookie to the control in the given container  
     * Param:
     *      containerId (mandatory) : id of div/form (any container) which holds autofilled controls
     *      controlId (optional)    : id of autofilled controll
                                      If this is provided means the function will only autofill / set value to this control
                                      This param usualy used for give default to control that need to be populated by ajax 
                                      (therefore it has to be done control by control as the ajax done)
     */
    merachel.Utility.setAutofillForm = function (containerId, controlId) {
        var screenName = merachel.Configuration.screenType;
        var cookieStr = merachel.Utility.getCookie("autofill");
        if (cookieStr !== null) {
            var autofillData = JSON.parse(cookieStr);
            // Fill the whole form
            if (typeof controlId === 'undefined' || controlId === null) {
                if ((typeof autofillData[screenName] !== 'undefined' && autofillData[screenName] !== null)
                    && (typeof autofillData[screenName][containerId] !== 'undefined' && autofillData[screenName][containerId] !== null)) {
                    var formData = autofillData[screenName][containerId];
                    $.each(formData, function (key, value) {
                        var $control = $("#" + containerId + " #" + key + ".merachel-autofill");
                        merachel.Utility.setAutofillControlWithValue($control, value);
                    });
                }
            }
                // Fill the control only
            else {
                if ((typeof autofillData[screenName] !== 'undefined' && autofillData[screenName] !== null)
                               && (typeof autofillData[screenName][containerId] !== 'undefined' && autofillData[screenName][containerId] !== null)
                               && (typeof autofillData[screenName][containerId][controlId] !== 'undefined' && autofillData[screenName][containerId][controlId] !== null)) {
                    var value = autofillData[screenName][containerId][controlId];
                    var $control = $("#" + containerId + " #" + controlId + ".merachel-autofill");
                    if ($control.length > 0)
                        merachel.Utility.setAutofillControlWithValue($control, value);
                }
            }
        }
    }

    /* Desc: Used by  merachel.Utility.setAutofillForm  to set value to control according to the control type
     */
    merachel.Utility.setAutofillControlWithValue = function ($control, value) {
        // TODO: Stephanie lengkapi type control

        if ($control.hasClass('datepicker')) {
            $(element).datepicker("setDate", new Date(value));
        }
        else if ($control.is("input")) {
            var inputType = $control.attr("type");
            if (inputType == "radio" || inputType == "checkbox") {
                $control.prop("checked", value);
                $control.trigger("change");
            }
            else {
                if (value.indexOf('|') != -1) // Untuk mengcover cookie di safari yang ada comma
                    value = value.replace('|', ',');
                $control.val(value);
            }
        }
        else if ($control.is("select")) {
            $.each($control.find("option"), function (i, option) {
                if (value.trim() === $(option).val().trim()) {
                    $control.val(value);
                    $control.trigger('change');
                }
            });
        }
    }

    /* Desc: To get specifict autofill data for the given control in the given container  
     * Param:
     *      containerId (mandatory) : id of div/form (any container) which holds autofilled controls
     *      controlId (mandatory)   : id of autofilled controll
     */
    merachel.Utility.getAutofillData = function (containerId, controlId) {
        var value = null;
        var screenName = merachel.Configuration.screenType;
        var cookieStr = merachel.Utility.getCookie("autofill");
        if (cookieStr !== null) {
            var autofillData = JSON.parse(cookieStr);
            if ((typeof autofillData[screenName] !== 'undefined' && autofillData[screenName] !== null)
                && (typeof autofillData[screenName][containerId] !== 'undefined' && autofillData[screenName][containerId] !== null)) {
                value = autofillData[screenName][containerId][controlId];
                if (value.indexOf('|') != -1) // Untuk mengcover cookie di safari yang ada comma
                    value = value.replace('|', ',');
            }
        }
        return value;
    }

    /* Desc: To reset specifict autofill data in the cookie for the given container
     * Param:
     *      containerId (mandatory) : id of div/form (any container) which holds autofilled controls
     */
    merachel.Utility.resetAutofillData = function (containerId) {
        var screenName = merachel.Configuration.screenType;
        var cookieStr = merachel.Utility.getCookie("autofill");
        var autofillData = (cookieStr == null) ? {} : JSON.parse(cookieStr);

        if (typeof autofillData[screenName] === 'undefined' || autofillData[screenName] !== null)
            autofillData[screenName] = {};
        autofillData[screenName][containerId] = null;
        merachel.Utility.setCookie("autofill", JSON.stringify(autofillData));
    }
    /* **************************************************************************** */

    merachel.Utility.setSelectedLanguage = function (selectedLanguage) {
        merachel.Utility.setCookie(merachel.Configuration.cookieNameUserLanguage, selectedLanguage, 3650);
        //window.location.href = window.location.href.replace('#', '');
        window.location.reload();  //change page behaviour to refresh instead of changing # to ''
    };

    merachel.Utility.displaySelectedLanguage = function () {
        var selectedLanguage = merachel.Configuration.userLanguage;
        var htmlAvailableLanguages = '';
        var supportedLanguage = JSON.parse(decodeURIComponent($('#hiddenSupportedLanguage').val()));

        $.each(supportedLanguage, function (key, item) {
            var className = '';
            if (item.code == selectedLanguage) {
                // Display selected language.
                $('#aSelectedLanguage').text(item.description.toUpperCase());
                className = 'active';
            }
            htmlAvailableLanguages += '<li class="' + className + '"><a href="javascript:merachel.Utility.setSelectedLanguage(\'' + item.code + '\');void(0);">' + item.description.toUpperCase() + (className ? '<i class="fa fa-check"></i>' : '') + '</a></li>';
        });

        // Add element in the dropdown list so that suer could change language.
        $('.topbar .languages').html(htmlAvailableLanguages);
    };

    merachel.Utility.displayLoginUserName = function () {
        // If user has login then we have 'user' object.
        if (merachel.Configuration.sessionInfo != null) {
            $('#spSessionName').text('Welcome, ' + merachel.Configuration.sessionInfo.user.userFullName.toUpperCase());
            if ($.trim(merachel.Configuration.sessionInfo.user.photo == '')) {
                $('login-image').attr('src', 'Content/img/no-image.png');
            }
            else {
                $('login-image').attr('src', 'Content/img/avatar/' + merachel.Configuration.sessionInfo.user.photo);
            }

            //$('.topbar .loginbar > li:last').after('<li class="topbar-devider"></li><li class="hoverSelector"><a href="javascript:void(0);">' + merachel.Configuration.userInfo.user.name + '</a><ul class="languages hoverSelectorBlock"><li><a href="' + merachel.Configuration.trivelioUrl + '/myprofile"><i class="fa fa-user merachel-margin-right-15" aria-hidden="true"></i>' + merachel.Utility.translateInfo('Profil Saya', 'My Profile') + '</a></li><li><a href="javascript:merachel.Utility.logoff();void(0);"><i class="fa fa-sign-out merachel-margin-right-15" aria-hidden="true"></i>' + merachel.Utility.translateInfo('Keluar', 'Logoff') + '</a></li></ul></li>');
        }
    };

    merachel.Utility.displayMyBookingSideBar = function () {
        var isProfilePage = merachel.Configuration.screenType == "profile";
        var isMyBookingPage = merachel.Configuration.screenType == "my_booking";
        var icon = isMyBookingPage ? "list" : "user";

        // Generate sidebard
        var htmlSideBar = '<div class="col-md-12 text-center hidden-sm hidden-xs"><i class="icon-custom icon-lg rounded-x icon-bg-grey merachel-mybooking-icon fa fa-' + icon + '"></i></div>'
                           + '<ul class="list-group sidebar-nav-v1 margin-bottom-40 merachel-sidebar-mybooking hidden-sm hidden-xs">'
                           + '<li class="list-group-item' + (isProfilePage ? ' active"' : '') + '"><a href="' + (isProfilePage ? "#" : merachel.Configuration.trivelioUrl + '/myprofile') + '" aria-expanded="true"><i class="fa fa-user"></i> ' + merachel.Utility.translateInfo('Profil', 'Profile') + '</a></li>'
                           + '<li class="list-group-item' + (isMyBookingPage ? ' active"' : '') + '"><a href="' + (isMyBookingPage ? "#" : merachel.Configuration.trivelioUrl + '/mybooking') + '" aria-expanded="false"><i class="fa fa-list"></i> ' + merachel.Utility.translateInfo('Pesanan Saya', 'My Booking') + ' </a></li>'
                        + '</ul>';
        $('#divSideBar').html(htmlSideBar);
    }

    merachel.Utility.setFormDisabled = function (formId, value) {
        $("#" + formId + " :input").prop("disabled", value);
        $("#" + formId + " select").prop("disabled", value);
    };

    merachel.Utility.logoff = function () {
        $.ajax({
            url: merachel.Configuration.merachelUrl + '/Shared/SetSignOut',
            type: 'POST',
            data: JSON.stringify(send),
            dataType: "html",
            success: function (data) {
                window.location.href = merachel.Configuration.merachelUrl;
            }
        })
    };

    merachel.Utility.getAuthorizationToken = function () {
        return merachel.Configuration.authorizationToken;
    };

    merachel.Utility.translateInfo = function (id, en) {
        var selectedLanguage = $('#aSelectedLanguage').text();
        var wording = '';
        switch (selectedLanguage) {
            case 'INDONESIA':
                wording = id;
                break;
            default:
                wording = en;
                break;
        }
        return wording;
    };

    merachel.Utility.startTranslation = function () {
        var currentCulture = merachel.Configuration.userLanguage;
        if (currentCulture != merachel.Configuration.defaultLanguage) {
            // Set culture for globalization and kendo.
            Globalize.culture(currentCulture);

            // Loop all elements that support localization.
            $('[data-translation]').each(function () {
                var element = $(this);
                var key = $(this).data('translation');
                var value;
                if (key) {
                    switch (this.tagName) {
                        case 'INPUT':
                            value = Globalize.localize(key, currentCulture);
                            if (value) {
                                element.attr('placeholder', value);
                            }
                            break;

                        case 'TITLE':
                        case 'A':
                            value = Globalize.localize(key, currentCulture);
                            if (value) {
                                element.text(value);
                            }
                            break;
                        case 'HEADER':
                            value = Globalize.localize(key, currentCulture);
                            if (value) {
                                element.text(value);
                            }
                            break;
                        case 'B':
                            value = Globalize.localize(key, currentCulture);
                            if (value) {
                                element.text(value);
                            }
                            break;
                        case 'TH':
                        case 'H1':
                        case 'H2':
                        case 'H3':
                            value = Globalize.localize(key, currentCulture);
                            if (value) {
                                element.text(value);
                            }
                            break;
                        case 'H4':
                        case 'H5':
                            value = Globalize.localize(key, currentCulture);
                            if (value) {
                                element.text(value);
                            }
                            break;
                        case 'DIV':
                        case 'BUTTON':
                            value = Globalize.localize(key, currentCulture);
                            if (value) {
                                element.text(value);
                            }
                            break;
                        case 'SPAN':
                            value = Globalize.localize(key, currentCulture);
                            if (value) {
                                element.text(value);
                            }
                            break;
                        case 'LABEL':
                            value = Globalize.localize(key, currentCulture);
                            if (value) {
                                element.text(value);
                            }
                            break;
                        case 'STRONG':
                            value = Globalize.localize(key, currentCulture);
                            if (value) {
                                element.text(value);
                            }
                            break;
                        case 'P':
                            value = Globalize.localize(key, currentCulture);
                            if (value) {
                                element.html(value);
                            }
                            break;
                    }
                }
            });
        }
    };

    merachel.Utility.getTranslation = function (key, defaulmerachelalue) {
        var value = Globalize.localize(key, merachel.Configuration.userLanguage)
        if (!value) {
            value = defaulmerachelalue;
        }
        return value;
    };

    merachel.Utility.setListBoxAsLoading = function ($element) {
        $element.prop('disabled', true);
        $element.find('option').remove();
        $element.append($('<option>').text(merachel.Utility.getTranslation('merachel-loading', 'loading...')).val(''));
    }

    merachel.Utility.populateListBox = function ($element, data, isAllOptionVisible, isSelectOptionVisible) {
        $element.find('option').remove();

        if (isAllOptionVisible) {
            $element.append($('<option>').text(merachel.Utility.getTranslation('merachel-all', '(All)')).val(''));
        }

        if (isSelectOptionVisible) {
            $element.append($('<option>').text(merachel.Utility.getTranslation('merachel-select', '(Select)')).val(''));
        }

        // Populate items.
        if (data) {
            $.each(data, function (key, item) {
                $element.append($('<option>').text(item.name).val(item.id));
            });
        }
        $element.prop('disabled', false);
    }

    merachel.Utility.setButtonProperties = function (properties, value) {
        $("button").prop(properties, value);
    };

    // Populate configuration object.
    merachel.Configuration = JSON.parse(decodeURIComponent($('#hdConfig').val()));

    // If cookie is ready then we need to read it and populate into merachel.Configuration object.
    //if (merachel.Configuration.isCookieReady) {

    //    // Read config from cookie and copy all configuration properties.
    //    var config = JSON.parse(merachel.Configuration.cookieValue);
    //    $.each(config, function (key, value) {
    //        merachel.Configuration[key] = value;
    //    });
    //    merachel.Configuration.userRoles = config.userRoles;
    //    merachel.Configuration.user = config.user;
    //}

    // Support translation by default.
    merachel.Utility.startTranslation();

    // Display selected language in the top bar.
    //merachel.Utility.displaySelectedLanguage();

    // Display current logon user.
    merachel.Utility.displayLoginUserName();

    // Utility to disable all button


    // Form utility
    merachel.Utility.ValidateFormForParam = function (formID) {
        var isValid = false;
        $.each($("#" + formID + " input"), function (i, input) {
            if ($(input).is(":visible") && $(input).closest(":hidden").length == 0) {
                if ($.trim($(this).val()).length >= 0)
                    isValid = true;
            }
        });

        $.each($("#" + formID + " select"), function (i, input) {
            if ($(input).is(":visible") && $(input).closest(":hidden").length == 0) {
                if ($(this).find("option:selected").val() != '')
                    isValid = true;
            }
        });

        if (!isValid) {
            $(".alert-warning").remove();
            var alert = '<div class="alert alert-warning"><strong>Warning!</strong> Please fill at least 1 field of search parameter.</div>';
            $("#" + formID).closest(".panel").after(function () {
                return alert;
            });
        } else {
            $(".alert-warning").remove();
        }

        return isValid;
    }
    merachel.Utility.ClearForm = function (formID) {

        var form = formID;
        if (formID != null && typeof formID === "string")
            form = $("#" + formID);

        $(form).find('input:not([type="radio"]):not([type="checkbox"])').val("");
        $(form).find('input:checkbox').prop('checked', false);
        $(form).find('textarea').val("");
        $(form).find('select').val("");
        $(form).find('input:radio').prop('checked', false);
        $(form).find('input.datepicker').datepicker("setDate", new Date());
        $(form).find('input.datepicker.month-picker').datepicker('option', 'defaultDate', null);
        $(form).find('span[data-lookup-field]').html("-");
        $(form).find('span[data-lookup-rel]').html("-");

        $.each($(form).find('input'), function (i, element) {
            var dataDuplicate = $(this).attr('data-duplicate');
            var dataFrom = $(this).attr('data-from');
            var dataTo = $(this).attr('data-to');

            if (typeof dataDuplicate !== typeof undefined && dataDuplicate !== false)
                $(this).attr('data-duplicate', '');
            if (typeof dataFrom !== typeof undefined && dataFrom !== false)
                $(element).datepicker("option", "minDate", null);
            if (typeof dataTo !== typeof undefined && dataTo !== false)
                $(element).datepicker("option", "maxDate", null);


            if ($(element).is('input:text')) {
                if ($(element).is(":visible") && $(element).closest(":hidden").length == 0)
                    $(element).trigger("blur");
            }
        });
    }
    merachel.Utility.CapitalizeWord = function (str) {
        return str.toLowerCase().split(' ').map(function (word) {
            return (word.charAt(0).toUpperCase() + word.slice(1));
        }).join(' ');
    }
    merachel.Utility.FormatMoney = function (numbers) {
        // TODO: Stephanie clean up change to Globalize
        //if (numbers != null && numbers != '' && numbers != undefined) {
        //    return (numbers + '').replace(/(\d)(?=(\d\d\d)+(?!\d))/g, "$1,");
        //}
        //else {
        //    return "";
        //}
        return Globalize.format(numbers, "n0");
    }
    merachel.Utility.FormatDateTime = function (date) {
        return moment(date).format('DD MMMM YYYY HH:mm')
    }
    merachel.Utility.FormatDate = function (date) {
        return moment(date).format('DD MMMM YYYY')
    }
    merachel.Utility.FormatTime = function (date) {
        return moment(date).format("HH:mm");
    }
    merachel.Utility.FillForm = function (formID, resultData) {
        var form = formID;
        if (formID != null && typeof formID === "string")
            form = $("#" + formID);

        $.each($(form).find('input.datepicker, input.hasDatepicker'), function (i, element) {
            if (!$(element).hasClass('month-picker')) {
                var dataFrom = $(this).attr('data-from');
                var dataTo = $(this).attr('data-to');
                if (typeof dataFrom !== typeof undefined && dataFrom !== false)
                    $(element).datepicker("option", "minDate", null);
                if (typeof dataTo !== typeof undefined && dataTo !== false)
                    $(element).datepicker("option", "maxDate", null);
            }
        });

        var sendValueToElement = function (element, result, fieldName) {

            if (fieldName != null && fieldName != "" && result[fieldName] != null) {
                var displayValue = result[fieldName];
                if (!$(element).is('input:checkbox') && !$(element).is('input:radio')) {
                    $(element).val(displayValue);
                }
                if ($(element).is('span'))
                    $(element).html(displayValue);
                $(element).attr("data-duplicate", displayValue);

                if ($(element).is('label'))
                    $(element).html(displayValue);
                $(element).attr("data-duplicate", displayValue);

                if ($(element).is('div'))
                    $(element).html(displayValue);
                $(element).attr("text", displayValue);

                if ($(element).is('input:radio')) {
                    $(element).prop('checked', $(element).val() == result[fieldName]);
                    $(element).trigger("change");
                }
                if ($(element).is('select'))
                    $(element).trigger("change");
                if ($(element).is('input:checkbox'))
                    $(element).prop('checked', result[fieldName]);
                if ($(element).hasClass('lookup-desc')) {
                    $(element).show();
                }
                // Untuk jxq widget
                if ($(element).hasClass('jqx-datetimeinput')) {
                    $(element).jqxDateTimeInput("setDate", FACE.Utils.SqlDateConverter(result[fieldName]));
                }
            }
        }
        $.each($(form).find("[data-lookup-field]"), function () {
            var fieldName = $(this).attr("data-lookup-field");

            sendValueToElement(this, resultData, fieldName);
        });
        $.each($(form).find("[data-lookup-rel]"), function () {
            var fieldName = $(this).attr("data-lookup-rel");
            sendValueToElement(this, resultData, fieldName);
        });
    }
    merachel.Utility.HtmlEncode = function (value) {
        return $('<div/>').text(value).html();
    }
    merachel.Utility.HtmlDecode = function (value) {
        return $('<div/>').html(value).text();
    }
    merachel.Utility.GetUtcDate = function (selectedDate) {
        if (Object.prototype.toString.call(selectedDate) === '[object Date]' && moment != undefined) {
            //use momentjs library
            return moment.utc([selectedDate.getFullYear(), selectedDate.getMonth(), selectedDate.getDate()]).toDate();
        }
        else {
            return selectedDate;
        }
    }

    // datatable
    merachel.Utility.ShowHideSearchResult = function ($tableResult, isShow) {
        var tableId = $tableResult.attr("id");
        $('.empty-result-alert[data-table="' + tableId + '"]').remove();
        if (isShow) {
            $tableResult.closest(".search-result").show();
            if ($tableResult.DataTable() !== null)
                $tableResult.DataTable().columns.adjust().draw();
        } else {
            $tableResult.closest(".search-result").hide();
            var alert = '<div data-table="' + tableId
                        + '" class="alert alert-info empty-result-alert">No data is available. Please refine your search parameter.</div>';
            $tableResult.closest(".search-result").after(function () {
                return alert;
            });
        }
    }

    merachel.Utility.GetSelectedRow = function (tableId) {
        var table = $('#' + tableId).DataTable();
        var idxs = table.rows('.selected')[0];
        if (idxs.length == 0) {
            return [];
        } else {
            var arr = [];
            $.each(idxs, function (i, idx) {
                arr.push(table.row(idx).data());
            });
            return arr;
        }
    }

    // Checkbox list
    merachel.Utility.SetCheckboxList = function ($list) {
        $($list).find('.list-group-item').each(function () {

            // Settings
            var $widget = $(this),
                $checkbox = $('<input type="checkbox" class="hidden" value="' + $widget.data('value') + '" />'),
                color = ($widget.data('color') ? $widget.data('color') : "primary"),
                style = ($widget.data('style') == "button" ? "btn-" : "list-group-item-"),
                settings = {
                    on: {
                        icon: 'glyphicon glyphicon-check'
                    },
                    off: {
                        icon: 'glyphicon glyphicon-unchecked'
                    }
                };

            $widget.css('cursor', 'pointer')
            $widget.append($checkbox);

            // Event Handlers
            $widget.on('click', function () {
                $checkbox.prop('checked', !$checkbox.is(':checked'));
                $checkbox.triggerHandler('change');
                merachel.Utility.UpdateCheckboxListItem($widget);
            });
            $checkbox.on('change', function () {
                merachel.Utility.UpdateCheckboxListItem($widget);
            });

            // Initialization
            function init() {

                if ($widget.data('checked') == true) {
                    $checkbox.prop('checked', !$checkbox.is(':checked'));
                }

                merachel.Utility.UpdateCheckboxListItem($widget);

                // Inject the icon if applicable
                if ($widget.find('.state-icon').length == 0) {
                    $widget.prepend('<span class="state-icon ' + settings[$widget.data('state')].icon + '"></span>');
                }
            }
            init();
        });
    }

    merachel.Utility.UpdateCheckboxListItem = function ($widget) {
        var $checkbox = $widget.find("input:checkbox"),
            settings = {
                on: {
                    icon: 'glyphicon glyphicon-check'
                },
                off: {
                    icon: 'glyphicon glyphicon-unchecked'
                }
            };

        var isChecked = $checkbox.is(':checked');

        // Set the button's state
        $widget.data('state', (isChecked) ? "on" : "off");

        // Set the button's icon
        $widget.find('.state-icon')
            .removeClass()
            .addClass('state-icon ' + settings[$widget.data('state')].icon);
    }

    merachel.Utility.SetRadioList = function ($list, radioName) {
        $($list).find('.list-group-item').each(function (i, radioItem) {

            // Settings
            var $widget = $(this),
                $radio = $('<input type="radio" name="' + radioName + '" class="hidden" value="' + $widget.data('value') + '" />'),
                color = ($widget.data('color') ? $widget.data('color') : "primary"),
                style = ($widget.data('style') == "button" ? "btn-" : "list-group-item-");

            $widget.css('cursor', 'pointer')
            $widget.append($radio);

            // Event Handlers
            $widget.on('click', function () {
                if (!$radio.is(':checked')) {
                    $radio.prop('checked', !$radio.is(':checked'));
                    $radio.triggerHandler('change');
                    merachel.Utility.UpdateRadioListItem($widget);
                }
            });
            $radio.on('change', function () {
                merachel.Utility.UpdateRadioListItem($widget);
            });

            // Initialization
            function init() {
                // Inject the icon if applicable
                if ($widget.find('.state-icon').length == 0) {
                    $widget.prepend('<span class="state-icon"></span>');
                }
            }
            init();
        });
    }

    merachel.Utility.UpdateRadioListItem = function ($widget) {
        var $radio = $widget.find("input:radio");
        var isChecked = $radio.is(':checked');

        // set other radio to off
        $widget.closest("ul").find("li").data("off");
        $widget.closest("ul").find("li").find('.state-icon').removeClass().addClass('state-icon');

        // Set the button's icon
        $widget.find('.state-icon').removeClass().addClass('state-icon fa fa-check');
    }

    // Set default ajax behavior.
    $.ajaxSetup({
        type: "POST",
        dataType: "json",
        contentType: "application/json;charset=utf-8",
        crossDomain: true,
        xhrFields: {
            withCredentials: true
        },
    });

    $.ajaxSetup({
        beforeSend: function (xhr) {
            xhr.setRequestHeader('merachelAuthorizationToken', merachel.Utility.getAuthorizationToken());
        }
    });

    merachel.Utility.Pad = function (str, max) {
        str = str.toString();
        return str.length < max ? merachel.Utility.Pad("0" + str, max) : str;
    }

    merachel.Utility.Dialog = function (options) {
        var templates = {
            dialog:
              '<div class="modal fade" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">' +
                '<div class="modal-dialog modal-md">' +
                  '<div class="modal-content">' +
                    '<div class="modal-body merachel-modal-body"></div>' +
                  '</div>' +
                '</div>' +
              '</div>',
            header:
              '<div class="modal-header merachel-modal-header">' +
                '<img src=' + merachel.Configuration.merachelUrl + '/Content/img/logo_small.png' + ' />' +
              '</div>',
            footer:
              '<div class="modal-footer merachel-modal-footer"></div>',
            closeButton:
              '<button type="button" class="km-messagebox-close-button close close-custom">&times;</button>'
        };

        var dialog = $(templates.dialog);
        var body = dialog.find(".modal-body");
        var buttons = options.buttons || [];
        var buttonbuilder = [];
        var callbacks = {
            onEscape: options.onEscape
        };

        // build buttons
        $.each(buttons, function (index, button) {
            var icon = '';
            if (button.icon) {
                icon = '<i class="' + button.icon + '"></i> ';
            }
            if (button.className) {
                buttonbuilder.push("<button data-km-handler='" + index + "' type='button' class='btn " + button.className + "'>" + icon + button.label + "</button>");
            }
            else {
                buttonbuilder.push("<button data-km-handler='" + index + "' type='button' class='btn btn-text-info'>" + icon + button.label + "</button>");
            }

            callbacks[index] = button.callback;
        });

        body.before(templates.header);

        // note: ptfi modal always has a title
        var titleMessage = '<h4 class="modal-title padding-bottom-5"></h4>';
        if (options.title) {
            titleMessage = '<h4 class="modal-title padding-bottom-5"><b>' + options.title + '</b></h4>';
            //var modaltitle = options.title;
            //if (options.titleIcon) {
            //    modaltitle = '<i class="' + options.titleIcon + '"></i> ' + modaltitle;
            //}
            //dialog.find(".modal-title").html(modaltitle);
        }

        // set message
        body.html(titleMessage + '<p>' + options.message + '</p>');

        // set animation, mostly this would be set to true
        if (options.animate === true) {
            dialog.addClass("fade");
        }

        // set additional classname to the dialog
        if (options.className) {
            dialog.addClass(options.className);
        }

        // note: ptfi modal always has a cloase button
        if (options.closeButton) {
            var closeButton = $(templates.closeButton);

            if (options.title) {
                dialog.find(".modal-header").prepend(closeButton);
            } else {
                closeButton.css("margin-top", "-10px").prependTo(body);
            }
        }

        // append the generated buttons that we build earlier
        if (buttonbuilder.length) {
            body.after(templates.footer);
            dialog.find(".modal-footer").html(buttonbuilder.join(''));
        }

        // Bootstrap event listeners. Use new namespaces event in bs 3.0
        dialog.on("hidden.bs.modal", function (e) {
            if (e.target === this) {
                dialog.remove();
            }
        });

        dialog.on("shown.bs.modal", function () {
            //dialog.find(".btn-primary:first").focus();
            dialog.find(".btn-info:first").focus();
        });

        //jQuery event listeners
        function processCallback(e, dialog, callback) {
            e.preventDefault();

            var preserveDialog = $.isFunction(callback) && callback(e) === false;
            if (!preserveDialog) {
                dialog.modal("hide");
            }
        }

        dialog.on("click", ".modal-footer button", function (e) {
            var callbackKey = $(this).data("km-handler");

            processCallback(e, dialog, callbacks[callbackKey]);
        });

        dialog.on("click", ".km-messagebox-close-button", function (e) {
            processCallback(e, dialog, callbacks.onEscape);
        });

        dialog.on("keyup", function (e) {
            if (e.which === 27) {
                //dialog.trigger("escape.close.bb");
                processCallback(e, dialog, callbacks.onEscape);
            }
        });

        // add dialog to the body
        $("body").append(dialog);

        var dialogoption = {
            backdrop: options.backdrop,
            keyboard: false,
            show: false
        };
        if (options.modaloptions) {
            dialogoption = $.extend({}, dialogoption, options.modaloptions);
        }

        dialog.modal(dialogoption);

        if (options.show) {
            dialog.modal("show");
        }

        return dialog;
    };

    merachel.Utility.DialogError = function (options) {
        var templates = {
            dialog:
              '<div class="modal fade" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">' +
                '<div class="modal-dialog modal-md">' +
                  '<div class="modal-content-error">' +
                    '<div class="modal-body modal-body-error"></div>' +
                  '</div>' +
                '</div>' +
              '</div>',
            footer:
              '<div class="modal-footer merachel-modal-footer"></div>',
            closeButton:
              '<button type="button" class="km-messagebox-close-button close close-custom">&times;</button>'
        };

        var dialog = $(templates.dialog);
        var body = dialog.find(".modal-body");
        var buttons = options.buttons || [];
        var buttonbuilder = [];
        var callbacks = {
            onEscape: options.onEscape
        };

        // build buttons
        $.each(buttons, function (index, button) {
            var icon = '';
            if (button.icon) {
                icon = '<i class="' + button.icon + '"></i> ';
            }
            if (button.className) {
                buttonbuilder.push("<button data-km-handler='" + index + "' type='button' class='btn " + button.className + "'>" + icon + button.label + "</button>");
            }
            else {
                buttonbuilder.push("<button data-km-handler='" + index + "' type='button' class='btn btn-text-info'>" + icon + button.label + "</button>");
            }

            callbacks[index] = button.callback;
        });

        body.before(templates.header);

        // note: ptfi modal always has a title
        var titleMessage = '<h4 class="modal-title-error padding-bottom-5">Oops! You got an error!</h4>';
        var messageDesc = '<textarea rows="7" cols="5" class="form-control" readonly>' + options.message + '</textarea>';
        // set message
        body.html(titleMessage + '<p>Please contact your <b>SUPPORT CENTER</b> by including screenshot of detail information of the problem below.</p><p>' + messageDesc + '</p>');

        // set animation, mostly this would be set to true
        if (options.animate === true) {
            dialog.addClass("fade");
        }

        // set additional classname to the dialog
        if (options.className) {
            dialog.addClass(options.className);
        }

        // note: ptfi modal always has a cloase button
        if (options.closeButton) {
            var closeButton = $(templates.closeButton);

            if (options.title) {
                dialog.find(".modal-header").prepend(closeButton);
            } else {
                closeButton.css("margin-top", "-10px").prependTo(body);
            }
        }

        // append the generated buttons that we build earlier
        if (buttonbuilder.length) {
            body.after(templates.footer);
            dialog.find(".modal-footer").html(buttonbuilder.join(''));
        }

        // Bootstrap event listeners. Use new namespaces event in bs 3.0
        dialog.on("hidden.bs.modal", function (e) {
            if (e.target === this) {
                dialog.remove();
            }
        });

        dialog.on("shown.bs.modal", function () {
            //dialog.find(".btn-primary:first").focus();
            dialog.find(".btn-info:first").focus();
        });

        //jQuery event listeners
        function processCallback(e, dialog, callback) {
            e.preventDefault();

            var preserveDialog = $.isFunction(callback) && callback(e) === false;
            if (!preserveDialog) {
                dialog.modal("hide");
            }
        }

        dialog.on("click", ".modal-footer button", function (e) {
            var callbackKey = $(this).data("km-handler");

            processCallback(e, dialog, callbacks[callbackKey]);
        });

        dialog.on("click", ".km-messagebox-close-button", function (e) {
            processCallback(e, dialog, callbacks.onEscape);
        });

        dialog.on("keyup", function (e) {
            if (e.which === 27) {
                //dialog.trigger("escape.close.bb");
                processCallback(e, dialog, callbacks.onEscape);
            }
        });

        // add dialog to the body
        $("body").append(dialog);

        var dialogoption = {
            backdrop: options.backdrop,
            keyboard: false,
            show: false
        };
        if (options.modaloptions) {
            dialogoption = $.extend({}, dialogoption, options.modaloptions);
        }

        dialog.modal(dialogoption);

        if (options.show) {
            dialog.modal("show");
        }

        return dialog;
    };

    merachel.Utility.formatMoney = function (numbers) {
        if (numbers != null && numbers != '' && numbers != undefined) {
            return ('Rp ' + numbers + '').replace(/(\d)(?=(\d\d\d)+(?!\d))/g, "$1,");
        }
        else {
            return "";
        }
    }


    merachel.Error = {};
    merachel.Error.getErrorException = function (jqXHR, thrownError) {
        return new merachel.Exception(jqXHR, thrownError);
    };

    merachel.Exception = function (jqXHR, thrownError) {
        var self = this;
        if (typeof jqXHR.responseJSON == "object") {
            self.Message = (jqXHR.responseJSON.Message ? jqXHR.responseJSON.Message : '') + (jqXHR.responseJSON.ExceptionMessage ? ' ' + jqXHR.responseJSON.ExceptionMessage : '');
            self.ExceptionType = (jqXHR.responseJSON.ExceptionType ? jqXHR.responseJSON.ExceptionType : '');
            self.StackTrace = (jqXHR.responseJSON.StackTrace ? jqXHR.responseJSON.StackTrace : '');
        }
        else if (typeof thrownError == "object") {
            self.Message = thrownError.message;
            self.ExceptionType = 'ERROR';
            self.StackTrace = thrownError.stack;
        }
        else {
            self.Message = thrownError;
            self.ExceptionType = 'HTML';
            self.StackTrace = jqXHR.responseText;
        }

        self.toString = function () {
            return 'MESSAGE: ' + self.Message + '\n' +
                'EXCEPTION TYPE: ' + self.ExceptionType + '\n' +
                'STACK TRACE: ' + self.StackTrace + '\n';
        };
    };

    merachel.MessageBox = {};
    merachel.MessageBox.alert = function (message, title, callback, options) {
        var labelOk = "Dismiss";

        if (options) {
            labelOk = options.labelOK || labelOk;
        }

        return merachel.Utility.Dialog({
            title: title || 'Info'
            , message: message
            , show: true
            , onEscape: true
            , closeButton: true
            , animate: true
            , backdrop: 'static'
            , buttons: [{ className: 'btn-text-info', label: labelOk, callback: callback || true }]
        });

    };
    merachel.MessageBox.confirm = function (title, message, callback, options) {
        var labelOk = "SUBMIT";
        var labelCancel = "DISMISS";

        if (options) {
            labelOk = options.labelOK || labelOk;
            labelCancel = options.labelCancel || labelCancel;
        }

        var cancelCallback = function () {
            if (typeof callback === 'function') {
                return callback(false);
            }
        };

        var confirmCallback = function () {
            if (typeof callback === 'function') {
                return callback(true);
            }
        };

        return merachel.Utility.Dialog({
            title: title || 'SUBMIT'
            , message: message
            , show: true
            , onEscape: true
            , closeButton: true
            , animate: true
            , backdrop: 'static'
            , buttons: [
                { className: 'btn-text-success', label: labelOk, callback: confirmCallback },
                { className: 'btn-text-default', label: labelCancel, callback: cancelCallback }
            ]
        });
    };
    merachel.MessageBox.error = function (errorText, callback) {
        var modaldialog = merachel.Utility.DialogError({
            show: false
            , message: errorText
            , onEscape: true
            , closeButton: false
            , animate: true
            , backdrop: 'static'
            , buttons: [{ className: 'btn-u btn-u-sea', label: 'Dismiss', callback: callback || true }]
        });

        //modaldialog.find('.modal-content-error').append('<div class="km-modal-error-detail collapse"><textarea rows="7" cols="5" class="form-control">' + errorText + '</textarea></div>');
        //modaldialog.find('.km-modal-error-detail').collapse({ toggle: true });
        //modaldialog.find('.km-modal-error-detail').on('show.bs.collapse', function () {
        //    modaldialog.find('.btn-toggle-collapse').html('<i class="icon-caret-up"></i> Hide Details');
        //});
        //modaldialog.find('.km-modal-error-detail').on('hide.bs.collapse', function () {
        //    modaldialog.find('.btn-toggle-collapse').html('<i class="icon-caret-down"></i> Show Details');
        //});
        modaldialog.modal("show");
    };

    merachel.Utility.RenderSelect2Ajax = function (options) {
        if (!options.id) {
            return;
        }
        if (!options.placeholderName) {
            options.placeholderName = 'Select';
        }

        $("#" + options.id).select2({
            placeholder: options.placeholderName,
            theme: "classic",
            allowClear: true,
            width: '100%',
            data: options.data,
            templateResult: formatRepo,
            templateSelection: formatRepo
        }).on('change', function (e) {
            if (typeof (options.onSelect) !== 'undefined') {
                options.onSelect();
            }
        });;

        $("#" + options.id).val(null).trigger('change');

        function formatRepo(repo) {
            return repo.name || repo.text;
        }
    }

    merachel.Utility.RenderSelect2 = function (options, isPerson) {
        if (!options.id) {
            return;
        }
        if (!options.webApiUrl) {
            return;
        }
        if (!options.placeholderName) {
            options.placeholderName = 'Select';
        }

        $("#" + options.id).select2({
            placeholder: options.placeholderName,
            theme: "classic",
            allowClear: true,
            ajax: {
                url: merachel.Configuration.merachelUrl + options.webApiUrl,
                dataType: 'json',
                delay: 250,
                data: function (params) {
                    return {
                        filterText: params.term,
                        parentId: options.otherValue,
                        page: params.page
                    };
                },
                processResults: function (data, params) {
                    params.page = params.page || 1;
                    return {
                        results: data.items,
                        pagination: {
                            more: (params.page * 30) < data.totalCount
                        }
                    };
                },
                cache: true
            },
            escapeMarkup: function (markup) { return markup; }, // let our custom formatter work
            minimumInputLength: 1,
            templateResult: formatRepo,
            templateSelection: formatRepoSelection

        }).on('change', function (e) {
            if (typeof (options.onSelect) !== 'undefined') {
                options.onSelect();
            }
        });

        function formatRepoSelection(repo) {
            window[options.result] = repo;
            return repo.name || repo.text;
        }

        function formatRepo(repo) {
            if (repo.loading) { return repo.text; }
            if (isPerson) {
                var markup =
              '<section class="profile profile-select2">' +
                    '<div class="panel panel-profile no-background-color">' +
                        '<div class="panel-body no-padding" data-mcs-theme="minimal-dark">' +
                            '<div class="comment">' +
                                '<img src="' + merachel.Configuration.merachelUrl + '/Content/img/avatar/' + repo.foto + '" alt="" onerror="loadDefaultImage(this)">' +
                                '<div class="overflow-h">' +
                                    '<strong>' + repo.name + '</strong>' +
                                    '<p>' + repo.nomorInduk + ' - ' + repo.departmentName + '</p>' +
                                '</div>' +
                            '</div>' +
                        '</div>' +
                    '</div>' +
                '</section>'
                ;
                return markup;
            }
            else {
                return repo.name || repo.text;
            }
        };
    }

    merachel.Utility.Select2Person = function (options) {
        merachel.Utility.RenderSelect2(options, true);
    }
    merachel.Utility.Select2 = function (options) {
        merachel.Utility.RenderSelect2(options, false);
    }
    merachel.Utility.Select2Ajax = function (options) {
        merachel.Utility.RenderSelect2Ajax(options);
    }

    merachel.Utility.DataAjax = function (options) {
        if (!options.uri) {
            return;
        }

        $.ajax({
            url: merachel.Configuration.merachelUrl + options.uri,
            data: [],
            type: 'GET'
        })
        .done(function (data, textStatus, jqXHR) {
            if (typeof (options.done) !== 'undefined') {
                options.done(data);
            }
        })
        .fail(function (jqXHR, textStatus, errorThrown) {
            merachel.MessageBox.alert(errorThrown);
        });
    }

    merachel.Utility.LookupSelect = function (category, selectId) {
        $.ajax({
            url: merachel.Configuration.merachelUrl + '/api/v1/lookup/Data',
            data: {
                category: category
            },
            type: 'GET'
        })
        .done(function (data, textStatus, jqXHR) {
            var collection = [];
            if (data.length > 0) {
                for (var i = 0; i < data.length; i++) {
                    collection.push({
                        id: data[i].code,
                        text: data[i].value
                    });
                }
                merachel.Utility.Select2Ajax({
                    id: selectId,
                    placeholderName: 'Select...',
                    data: collection
                });
            };
        })
        .fail(function (jqXHR, textStatus, errorThrown) {
            merachel.MessageBox.alert(errorThrown);
        });
    }

    merachel.Utility.GetPhotoUrl = function (value) {
        if (value) {
            return merachel.Configuration.merachelUrl + '/Content/img/avatar/' + value;
        }
        else {
            return merachel.Configuration.merachelUrl + '/Content/img/no-image.png';
        }
    }

    merachel.Utility.LoadPhoto = function (id, value) {
        $("#" + id).attr('src', merachel.Utility.GetPhotoUrl(value));
    }

    loadDefaultImage = function (id) {
        $(id).attr('src', merachel.Utility.GetPhotoUrl());
    }

    //merachel.Utility.rangeDatepicker = function (start, end) {
    //    var date = new Date();

    //    $('#' + start).datepicker({
    //        changeMonth: true,
    //        changeYear: true,
    //        yearRange: "-100:+1",
    //        dateFormat: dateFormat,
    //        prevText: '<i class="fa fa-angle-left"></i>',
    //        nextText: '<i class="fa fa-angle-right"></i>',
    //        showButtonPanel: true
    //    }).on("change", function () {
    //        $('#' + end).datepicker('option', 'minDate', getDate(this));
    //    }).datepicker("setDate", null);

    //    $('#' + end).datepicker({
    //        changeMonth: true,
    //        changeYear: true,
    //        yearRange: "-100:+1",
    //        dateFormat: dateFormat,
    //        prevText: '<i class="fa fa-angle-left"></i>',
    //        nextText: '<i class="fa fa-angle-right"></i>',
    //        showButtonPanel: true
    //    }).on("change", function () {
    //        $('#' + start).datepicker('option', 'maxDate', getDate(this));
    //    }).datepicker("setDate", null);





    //    function getDate(element) {
    //        var date;
    //        try {
    //            date = $.datepicker.parseDate(dateFormat, element.value);
    //        } catch (error) {
    //            date = null;
    //        }

    //        return date;
    //    }
    //}

    merachel.Utility.CleanDatepickerHover = function () {
        $('.ui-datepicker-prev').hover(function () {
            $(this).attr('title', 'Previous Month');
        });

        $('.ui-datepicker-next').hover(function () {
            $(this).attr('title', 'Next Month');
        });
    };

    merachel.Shared.GetViolationHistory = function (id) {
        $.ajax({
            url: merachel.Configuration.merachelUrl + '/api/v1/shared/GetViolationHistory?suspectedId=' + id,
            type: 'POST'
        })
        .done(function (data, textStatus, jqXHR) {
            var table = $('#tblViolationHistory').DataTable();
            table.clear().rows.add(data).draw();
        })
        .fail(function (jqXHR, textStatus, errorThrown) {
            merachel.MessageBox.alert(errorThrown);
        });
    }

    /********************************************** Internal On Ready handler  *********************************************/
    $(document).ready(function () {
        $.support.cors = true;
        var ajaxRequestList = []; // holds all ajax requests

        // default ajax 
        $.ajaxSetup({
            type: "POST",
            dataType: "json",
            contentType: "application/json;charset=utf-8",
            cache: "false", //bimbas 31 jan: set cache to false to make sure in IE API always call to server
            crossDomain: true,
            xhrFields: {
                withCredentials: true
            }
        });
        $(document).ajaxStart(function () {

            //merachel.showProgressBar();
            //var x;
        });
        $(document).ajaxStop(function () {
            //merachel.hideProgressBar();
            //var x;
        });
        $(document).ajaxSend(function (event, XMLHttpRequest, ajaxOptions) {

            if (ajaxOptions.suppressProgressBar || ajaxOptions.dataType == "iframe json") {
                // TODO: iframe json is to handle jquery upload, maybe we need to revisit this again when we implemented jquery upload
                return;
            }
            else {
                ajaxRequestList.push(XMLHttpRequest);
                //merachel.ProgressBar.show();
            }

        });
        $(document).ajaxComplete(function (event, XMLHttpRequest, ajaxOptions) {

            if (ajaxOptions.suppressProgressBar) {
                return;
            }
            else {
                ajaxRequestList = jQuery.grep(ajaxRequestList, function (value) {
                    return value != XMLHttpRequest;
                });
                if (ajaxRequestList.length == 0) {
                    //merachel.ProgressBar.hide();
                    //console.log(ajaxRequestList);
                }
            }
        });
        $(document).ajaxError(function (event, jqXHR, ajaxSettings, thrownError) {
            if (typeof jqXHR.responseText !== 'undefined' && jqXHR.responseText.indexOf("session.expired") > 0) {
                location.reload();
                return;
            }

            if (ajaxSettings.suppressErrorMessageBox) {
                return;
            }
            var ex = merachel.Error.getErrorException(jqXHR, thrownError);

            // Modified by Candra: 2017 June 15 - Display a simple caller
            //console.log(ex);
            //merachel.MessageBox.error(ex.toString());
        });

        window.onerror = function (msg, url, line) {
            // this is to handle if there is an error in application ajax done event
            ajaxRequestList = jQuery.grep(ajaxRequestList, function (value) {
                return value.readyState != 4;
            });
            if (ajaxRequestList.length == 0) {
                //merachel.ProgressBar.hide();
            }

            merachel.MessageBox.error("Error: " + msg + "\nurl: " + url + "\nline #: " + line);

            // TODO: Report this error via ajax so you can keep track
            //       of what pages have JS issues

            var suppressErrorAlert = true;
            // If you return true, then error alerts (like in older versions of 
            // Internet Explorer) will be suppressed.
            return suppressErrorAlert;
        };

    });

}(jQuery, merachel));

$(document).ready(function () {

    jQuery.validator.addMethod("lettersOnly", function (value, element) {
        return this.optional(element) || /^[a-zA-Z\s]+$/i.test(value);
    }, "Please enter letters only");

    jQuery.validator.addMethod("alphanumeric", function (value, element) {
        return this.optional(element) || /^[a-zA-Z0-9\/\.\-]+$/.test(value);
    }, "Only 0-9,a-z or A-Z, '/', '.' and '-' are allowed.");

    // Equal Height Columns
    function handleEqualWidthButtons() {
        var EqualWidthButtons = function () {
            $(".equal-width-buttons").each(function () {
                widths = [];
                $(".equal-width-button", this).each(function () {
                    $(this).removeAttr("style");
                    widths.push($(this).width()); // write column's heights to the array
                });
                $(".equal-width-button", this).width(Math.max.apply(Math, widths)); //find and set max
            });
        }

        EqualWidthButtons();
        $(window).resize(function () {
            EqualWidthButtons();
        });
        $(window).on('load', function () {
            EqualWidthButtons();
        });
    }

    handleEqualWidthButtons();

    if (!$('img').attr('src')) {
        $('img').attr('src', merachel.Configuration.merachelUrl + '/Content/img/no-image.png')
    }

    if (merachel.Configuration.sessionInfo) {
        $('#imgLoginPhoto').attr('src', merachel.Utility.GetPhotoUrl(merachel.Configuration.sessionInfo.user.photo));
    }

    $('.form-hidden').removeClass('hidden');
    $('.form-hidden').hide();
    $('.panel-search-result').removeClass('hidden');
    $('.panel-search-result').hide();
    $('.panel-search-info').removeClass('hidden');
    $('.panel-search-info').hide();


    //$(window).resize(function () {
    //    var bodyHeight = $(window).height() - parseInt($('.breadcrumbs').height()) - parseInt($('.header-sticky').height());
    //    $('.body-content').height(bodyHeight);
    //});

    //$('.search').click(function () {
    //    $('.panel-search-begin').hide();
    //});

    $('.clear-datepicker-button').each(function () {
        $(this).unbind().click(function () {
            $('input[data-clear=' + $(this).attr('id') + ']').each(function () {
                $(this).val('');
            });
        });
    });

    $('#ui-datepicker-div').hover(function () {
        merachel.Utility.CleanDatepickerHover();
    });

});
