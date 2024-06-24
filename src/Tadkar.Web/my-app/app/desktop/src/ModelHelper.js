Ext.define('MyExtGenApp.ModelHelper', {
    singleton: true,

    delete: function (record, container) {
        var messageBox = Ext.create('Ext.window.MessageBox', {
            constrain: true,
            closeAction: 'destroy'
        });
        var displayName = record.getId();

        container = container || MyExtGenApp.getApplication().getMainView();
        container.add(messageBox);

        return new Ext.Promise(function (resolve, reject) {
            messageBox.show({
                title: ProjectX.Resources.Confirmation,
                message: `${MyExtGenApp.Resources.AreYouSureToDelete} ${displayName} ?`,
                buttons: Ext.Msg.YESNO,
                icon: Ext.Msg.QUESTION,
                fn: function (btn) {
                    if (btn !== 'yes') return;

                    container.setLoading(MyExtGenApp.Resources.Deleting);
                    record.dropped = true;

                    record.save({
                        callback: function () {
                            container.setLoading(false);
                        },
                        success: function () {
                            MyExtGenApp.Notification.showSuccess(MyExtGenApp.Resources.SuccessfullyDeleted);
                            resolve();
                        },
                        failure: function () {
                            MyExtGenApp.Notification.showError(MyExtGenApp.Resources.CannotDeleteRecord);
                            record.dropped = false;
                            reject();
                        }
                    });
                }
            });
        });
    }
});