$(document).ready(function () {
    $('#PageFirstLogin').removeClass('hidden');
    $('#PageFirstLogin').hide();

    User.Init();

    $('#btLogin').unbind().bind('click', function (e) {
        User.Login.Submit();
    });

    $('#tbPassword').keypress(function (e) {
        var key = e.which;

        if (key == 13) {
            $('#btLogin').click();
            return false;
        }
    });

    $("#tbUsername").focus();
});


var User = {
    Init: function () {
        if (merachel.Configuration.userInfo != null) {
            //User.Goto.Flight();
        }

        $("#formLogon").validate({
            invalidHandler: function (form, validator) {
                var errors = validator.numberOfInvalids();
                if (errors) {
                    validator.errorList[0].element.focus();

                    /* resolve bug some error messages not showing up */
                    for (var i = 0; i < errors; i++)
                        $("#formLogon label.error").eq(i).show();
                } else {
                    $("#formLogon label.error").hide();
                }
            },
            rules: {
                tbUsername: {
                    required: true
                },
                tbPassword: {
                    required: true
                }
            }
        });

        $("#formFirstTime").validate({
            invalidHandler: function (form, validator) {
                var errors = validator.numberOfInvalids();
                if (errors) {
                    validator.errorList[0].element.focus();

                    /* resolve bug some error messages not showing up */
                    for (var i = 0; i < errors; i++)
                        $("#formFirstTime label.error").eq(i).show();
                } else {
                    $("#formFirstTime label.error").hide();
                }
            },
            rules: {
                tbNewPassword: {
                    required: true
                },
                tbConfirmPassword: {
                    required: true
                }
            }
        });
    },
    Login: {
        Submit: function () {
            function addRequestVerificationToken(data) {
                data.__RequestVerificationToken = $('input[name=__RequestVerificationToken]').val();
                return data;
            };

            var l = Ladda.create(document.querySelector('#btLogin'));

            if ($('#formLogon').valid()) {
                var userName = $.trim($('#tbUsername').val());
                var userPassword = $.trim($('#tbPassword').val());

                // Save login
                if ($('#chRememberMe').is(":checked"))
                    merachel.Utility.saveAutofillData("PageLogin");
                else
                    merachel.Utility.resetAutofillData("PageLogin");

                var str = userName + '!@#' + userPassword;
                var key = CryptoJS.enc.Utf8.parse('8080808080808080');
                var iv = CryptoJS.enc.Utf8.parse('8080808080808080');

                var encrypted = CryptoJS.AES.encrypt(str, key,
                {
                    keySize: 128 / 8,
                    iv: iv,
                    mode: CryptoJS.mode.CBC,
                    padding: CryptoJS.pad.Pkcs7
                });

                var token = $("[name='__RequestVerificationToken']").val();
                var send = {
                    cipher: encrypted.toString(),
                    rememberMe: $('#chRememberMe').is(":checked")
                };


                $.ajax({
                    url: merachel.Configuration.merachelUrl + '/Home/Logon',
                    type: 'POST',
                    dataType: "json",
                    contentType: "application/json",
                    headers: { __RequestVerificationToken: token },
                    data: JSON.stringify(addRequestVerificationToken(send)),
                    cache: false,
                    beforeSend: function (xhr) {
                        merachel.Utility.setFormDisabled('formLogon', true);
                        //$('#divLoader').show();
                        l.start();
                    }
                })
                .done(function (data, textStatus, jqXHR) {
                    l.stop();
                    merachel.Configuration.SessionInfo = data;

                    if (data.Exception.ErrorCode != 0) {
                        merachel.Utility.setFormDisabled('formLogon', false);

                        if (data.Exception.ErrorCode == 20011) {
                            $('.login-failed').text(translate(data.Exception.ErrorDesc.replace("Your account have been blocked due to login attempt limitation, please try again in ", 'Akun anda diblock karena ada pembatasan jumlah percobaan login masuk, silahkan coba lagi dalam ').replace(' minute(s)', ' menit'), data.Exception.ErrorDesc));
                        }
                        else {
                            merachel.MessageBox.alert("User name and/or password is not valid. Please try again.", 'Warning', null);
                        }

                    }
                    else {
                        merachel.Utility.setFormDisabled('formLogon', false);
                        if (data.User.IsFirstTimeUser == 1) {
                            $('#PageLogin').hide('fast');
                            $('#PageFirstLogin').show('slow');
                        }
                        else {
                            window.location.href = merachel.Configuration.merachelUrl + '/Dashboard';
                        }
                    }
                })
                .fail(function (jqXHR, textStatus, errorThrown) {
                    l.stop();
                    merachel.Utility.setFormDisabled('formLogon', false);
                })
            }
            else {
                l.stop();
            }
        }
    },
    Confirmation: {
        Submit: function () {
            if ($('#formSubmit').valid()) {
                var l = Ladda.create(document.querySelector('#buttonSubmit'));
                var newPassword = $.trim($('#textNewPassword').val());
                var confirmPassword = $.trim($('#textConfirmPassword').val());

                var str = newPassword + '!@#' + confirmPassword;
                var key = CryptoJS.enc.Utf8.parse('8080808080808080');
                var iv = CryptoJS.enc.Utf8.parse('8080808080808080');

                var encrypted = CryptoJS.AES.encrypt(str, key,
                {
                    keySize: 128 / 8,
                    iv: iv,
                    mode: CryptoJS.mode.CBC,
                    padding: CryptoJS.pad.Pkcs7
                });

                var send = {
                    userId: ods.Configuration.tokenRegister,
                    cipher: encrypted.toString()
                };

                $.ajax({
                    url: ods.Configuration.odsUrl + '/Confirmation/' + ods.Configuration.tokenRegister + '/Activate/' + ods.Configuration.queryString,
                    type: 'POST',
                    dataType: "json",
                    contentType: "application/json",
                    data: JSON.stringify(send),
                    beforeSend: function (xhr) {
                        ods.Utility.setFormDisabled('formSubmit', true);
                        //$('#divLoader').show();
                        l.start();
                    }
                })
                .done(function (data, textStatus, jqXHR) {
                    if (data.Error.Index != 0) {
                        //$('#divLoader').hide();
                        l.stop();
                        ods.Utility.setFormDisabled('formSubmit', false);
                        if (data.Error.Index == 20008) {
                            var errorMessage = data.Error.Message;
                            var lengthPassword = errorMessage.match(/(\d+)/g).length > 0 ? errorMessage.match(/(\d+)/g)[0] : 6;
                            ods.MessageBox.alert('Warning', translate(errorMessage.replace("Password does not meet the minimum requirement length. Minimum length is " + lengthPassword + " characters", 'Kata sandi tidak sesuai dengan panjang persyaratan minimal. Minimal panjang kata sandi adalah ') + lengthPassword + " karakter.", data.Error.Message), null);//errLanguage(data.Error.Index)
                        }
                        else {
                            ods.MessageBox.alert('Warning', errLanguage(data.Error.Index), null);
                        }

                    }
                    else {
                        ods.Utility.setFormDisabled('formSubmit', false);
                        ods.MessageBox.alert('Info', ods.Utility.translateInfo('Kata sandi berhasil diubah. Anda akan di arahkan ke halaman Login', "Password successfully changed. You will be redirect to Login page."), function () {
                            window.location.href = ods.Configuration.odsUrl;
                        });
                    }
                })
                .fail(function (jqXHR, textStatus, errorThrown) {
                    //$('#divLoader').hide();
                    l.stop();
                    ods.Utility.setFormDisabled('formSubmit', false);
                    ods.MessageBox.alert('Warning', textStatus, null);
                })
            }
        }
    },
    Password: {
        New: function () {

        }
    },
    Goto: {
        Home: function () {
            window.location.href = merachel.Configuration.merachelUrl;
        },
        Dashboard: function () {
            window.location.href = merachel.Configuration.merachelUrl + '/Dashboard';
        }
    }
};