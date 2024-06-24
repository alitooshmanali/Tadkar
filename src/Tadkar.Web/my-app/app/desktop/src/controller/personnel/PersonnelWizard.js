Ext.define('MyExtGenApp.controller.personnel.PersonnelWizard', {
   extend: 'Ext.window.Window',

   xtype: 'wizard-panel-personnel',

   controller: 'wizard-panel-personnel',

   viewModel: 'wizard-panel-personnel',

   layout: 'fit',

   width: 400,

   keyMap: {
       ESC: 'onEsc'
   },

   bind: {
       title: '{record.phantom ? @MyExtGenApp.Resources.New : @MyExtGenApp.Resources.Edit}'
   },

   items: [
       {
           xtype: 'form',
           layout: 'fit',
           modelValidation: true,
           items: {
               xtype: 'container',
               defaults: {
                   margin: 5,
                   labelWidth: 70
               },
               layout: {
                   type: 'vbox',
                   align: 'stretch'
               },
               items: [
                    {
                        xtype: 'textfield',
                        bind: '{record.firstName}',
                        fieldLabel: MyExtGenApp.Resources.FirstName,
                        allowBlank: false
                    },
                    {
                        xtype: 'textfield',
                        fieldLabel: MyExtGenApp.Resources.LastName,
                        bind: '{record.lastName}',
                        allowBlank: false
                    },
                    {
                        xtype: 'textfield',
                        fieldLabel: MyExtGenApp.Resources.Address,
                        bind: '{record.address}'
                    }
               ]
           },
           buttons: {
               ui: 'tools',
               items: [
                   '->',
                   {
                        reference: 'submit',
                        ui: 'action',
                        handler: 'onSubmitClicked',
                        formBind: true,
                        bind: {
                            text: '{record.phantom ? @MyExtGenApp.Resources.Create : @MyExtGenApp.Resources.Save}'
                        }
                    },
                    {
                        reference: 'cancel',
                        ui: 'flat',
                        text: MyExtGenApp.Resources.Cancel,
                        handler: 'onCancelClicked'
                    }
               ]
           }
       }
   ],

   setRecord: function (record) {
        var viewModel = this.getViewModel();
        if (viewModel.get('record')) return;

        this.getViewModel().set('record', record);
    }
});
