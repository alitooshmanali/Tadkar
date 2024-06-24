Ext.define('MyExtGenApp.controller.personnel.PersonnelWizardController', {
   extend: 'Ext.app.ViewController',

   alias: 'controller.wizard-panel-personnel',

   boxReady: function () {
        this.focusFirstField();
    },

    focusFirstField: function () {
        var fields = this.getView().query('field');
        if (fields.length === 0) return;

        fields[0].focus();
    },

    finalize: function () {
        this.getView().close();
    },

    submit: function () {
        const me = this;
        var form = me.getView().down('form');
        if (!form.isValid()) return;

        const record = me.getViewModel().get('record');
        if (!record.dirty) {
            me.finalize();
            return;
        }

        form.setLoading(MyExtGenApp.Resources.Saving);
        var isCreate = record.phantom;
        record.save({
            callback: function () {
                form.setLoading(false);
            },
            success: function (createdRecord) {
                if (me.fireEvent('save', createdRecord) !== false) {
                    var message = isCreate
                        ? MyExtGenApp.Resources.SuccessfullyCreated
                        : MyExtGenApp.Resources.SuccessfullyUpdated;

                        MyExtGenApp.Notification.showSuccess(message);

                    me.finalize();
                }
            }
        });
    },

    onSubmitClicked: function () {
        this.submit();
    },

    onCancelClicked: function () {
        this.finalize();
    },

    onEnterPressed: function () {
        this.submit();
    },

    onEsc: function (e) {
        e.stopEvent();
        return;
    },
});
