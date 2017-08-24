var search = null;

if (document.querySelector('#btSearch') != null)
    search = Ladda.create(document.querySelector('#btSearch'));

BeforeSendAjaxBehaviour = function (search) {
    if (!search) {
        search = Ladda.create(document.querySelector('#btSearch'));
    }
    search.start();
    merachel.Utility.setButtonProperties('disabled', true);
    //waitingDialog.show();
}

AfterSendAjaxBehaviour = function (search, errorThrown) {
    if (!search) {
        search = Ladda.create(document.querySelector('#btSearch'));
    }

    //waitingDialog.hide();
    search.stop();
    merachel.Utility.setButtonProperties('disabled', false);
    $('.panel-search-begin').hide();

    if (typeof errorThrown != 'undefined') {
        merachel.MessageBox.alert(errorThrown);
    }
}