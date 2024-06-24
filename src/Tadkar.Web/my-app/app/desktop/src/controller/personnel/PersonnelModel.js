Ext.define('MyExtGenApp.controller.personnel.BrowsePanelModel', {
    extend: 'Ext.app.ViewModel',

    alias: 'viewmodel.browse-panel-personnel',

    data: {
        selection: null
    },

    stores: {
        data: {
            type: 'personnels',
            autoLoad: true
        }
    }
});