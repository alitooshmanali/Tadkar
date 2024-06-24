Ext.define('MyExtGenApp.controller.personnel.PersonnelController',{
    extend: 'Ext.app.ViewController',

    alias: 'controller.browse-panel-personnel',

    listen: {
        controller: {
            'browse-panel-personnel': {
                change: 'onChanged'
            },
            'wizard-panel-personnel': {
                save: 'onSaved'
            }
        }
    },

    boxReady: function () {
        this.getStore('data').on({
            load: this.onStoreLoaded,
            scope: this
        });
    },

    showPersonnelWizard: function (record) {
        var personnelWizard = new MyExtGenApp.controller.personnel.PersonnelWizard({
            modal: true
        });

        this.getView().add(personnelWizard);
        personnelWizard.setRecord(record);
        personnelWizard.show();
        personnelWizard.center();
    },

    onSaved: function () {
        this.getStore('data').reload();
    },

    onChanged: function () {
        this.getStore('data').reload();
    },

    onEsc: function (e) {
        e.stopEvent();
        return;
    },

    onAddClicked: function () {
        var personnel = new MyExtGenApp.model.Personnel();
        this.showPersonnelWizard(personnel);
    },

    onEditClicked: function () {
        var personnelSelection = this.getViewModel().get('selection');
        var personnel = new MyExtGenApp.model.Personnel(personnelSelection.getData());

        personnel.set('phantom', false);
        this.showPersonnelWizard(personnel);
    },

    onDeleteClicked: function () {
        var me = this;
        var store = me.getStore('data');
        var selection = this.getViewModel().get('selection');

        MyExtGenApp.ModelHelper.delete(selection, me.getView()).then(function () {
            me.fireEvent('change', selection);
            store.remove(selection);
        });
    },

    onStoreLoaded: function (store, records, success, operation) {
        if (!success) {
            MyExtGenApp.Notification.showError(ProjectX.Resources.UnableToFetchData)
            return;
        }

        var rowNumber = this.getView().query('rownumberer')[0];
        var currentPage = store.currentPage;
        var totalCount = store.getTotalCount();
        var count;

        if (pageSize * currentPage > totalCount) {
            count = parseInt(totalCount / 10);
            rowNumber.setWidth((count.toString().length + 1) * 12.5);
        } else {
            count = pageSize * currentPage;
            rowNumber.setWidth(count.toString().length * 12.5);
        }
    }
})