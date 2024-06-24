Ext.define('MyExtGenApp.model.Base', {
    extend: 'Ext.data.Model',

    fields: [
        {
            name: 'phantom',
            persist: false,
            convert: function(value, record) {
                var id = record.getId();
                return !id || (Ext.isString(id) && id.indexOf(record.entityName) == 0);
            }
        }
    ],

    schema: {
        namespace: 'MyExtGenApp.model',
        urlPrefix: 'http://localhost:47307',
        proxy: {
            type: 'rest',
            startParam: null,
            limitParam: 'pageSize',
            pageParam: 'pageIndex',
            enablePaging: false,
            url: '{prefix}/{entityName:pluralize}',
            reader: {
                type: 'json',
                rootProperty: 'values',
                totalProperty: 'totalCount'
            },
            writer: {
                writeAllFields: true,
                writeRecordId: false,
                transform: function (data, request) {
                    return request.config.action === 'destroy' ? null : data;
                }
            }
        }
    },

    commit: function(silent, modifiedFieldNames) {
        this.data.phantom = false;
        this.callParent(arguments);
    },

    getIdentifier: function(){
        return this.getId();
    },

    getDisplayValue: function(){
        return this.getId();
    }
});