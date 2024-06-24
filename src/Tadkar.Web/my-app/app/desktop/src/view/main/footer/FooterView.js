Ext.define('MyExtGenApp.view.main.footer.FooterView', {
    extend: 'Ext.Toolbar',
    xtype: 'footerview',
    cls: 'footerview',
    viewModel: {},
    items: [
        {
            xtype: 'container',
            cls: 'footerviewtext',
        html: 'شرکت فنی مهندسی تدکار - تیر ماه 1400 '
            //bind: { html: '{name} footer' }
        }
    ]
});
