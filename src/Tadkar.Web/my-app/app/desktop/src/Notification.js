Ext.define('MyExtGenApp.Notification', {
    requires: ['Ext.window.Toast'],

    singleton: true,

    showSuccess: function (message) {
        this.showMessage(message, 'success');
    },

    showError: function (message) {
        this.showMessage(message, 'error');
    },

    showWarn: function (message) {
        this.showMessage(message, 'warn');
    },

    showMessage: function (message, cls) {
        Ext.defer(function () {
            Ext.toast({
                paddingY: 45,
                bodyPadding: 0,
                align: 'tr',
                html: `<div class ="notification ${cls}">
                        <strong>${message}</strong>
                    </div>`,
                style: {
                    borderRadius: '0',
                    borderWidth: '0'
                }
            });
        }, 1);
    }
});