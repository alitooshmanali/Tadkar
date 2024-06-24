Ext.define('MyExtGenApp.controller.personnel.Personnel',{
    extend: 'Ext.panel.Panel',

    xtype: 'browse-panel-personnel',

    controller: 'browse-panel-personnel',

    viewModel: 'browse-panel-personnel',

    layout: 'fit',

    keyMap: {
        ESC: 'onEsc'
    },

    config: {
        columns: [
            {
                xtype: 'rownumberer'
            },
            {
                dataIndex: 'name',
                xtype: 'resource-context-desriptablecolumn',
                header: ProjectX.Resources.Name,
                flex: 1
            }
        ],
        cplValue: null,
        customActions: []
    },

    dockedItems: [
        {
            xtype: 'toolbar',
            itemId: 'tlbAction',
            dock: 'top',
            defaultButtonUI: 'plain-toolbar',
            overflowHandler: 'menu',
            border: true,
            bind: {
                hidden: '{!showToolbar}',
                disabled: '{disabledActions}'
            },
            items: [
                {
                    text: MyExtGenApp.Resources.Add,
                    handler: 'onAddClicked',
                    bind: {
                        disabled: '{selection}'
                    }
                },
            
                {
                    text: MyExtGenApp.Resources.Edit,
                    handler: 'onEditClicked',
                    bind: {
                        disabled: '{!selection}',
                    }
                },            
                {
                    text: MyExtGenApp.Resources.Delete,
                    handler: 'onDeleteClicked',
                    bind: {
                        disabled: '{!selection}',
                    }
                }
            ]
        }
    ],

    items: [
        {
            xtype: 'grid',
            border: true,
            viewConfig: {
                preserveScrollOnRefresh: true
            },
            columns: {
                defaults: {
                    menuDisabled: true
                },
                items: [
                    {
                        xtype: 'rownumberer'
                    },
                    {
                        dataIndex: 'firstName',
                        header: ProjectX.Resources.FirstName,
                        flex: 1
                    },
                    {
                        dataIndex: 'lastName',
                        header: ProjectX.Resources.LastName,
                        flex: 1
                    },
                    {
                        dataIndex: 'address',
                        header: ProjectX.Resources.Address,
                        flex: 1
                    }
                ]
            },
            bind: {
                store: '{data}',
                selection: '{selection}'
            }
        }
    ],

    initComponent: function () {
        const me = this;
        me.callParent(arguments);
    }
})