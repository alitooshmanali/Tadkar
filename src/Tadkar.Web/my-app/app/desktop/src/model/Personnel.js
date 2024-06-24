Ext.define('MyExtGenApp.model.Personnel', {
    extend: 'MyExtGenApp.model.Base',

    fields: [
        {
            name: 'id',
            type: 'int',
        },
        {
            name: 'firstName',
            type: 'string'
        },
        {
            name: 'lastName',
            type: 'string'
        },
        {
            name: 'address',
            type: 'string'
        }
    ]
});