using System.Windows;
using System.Windows.Controls;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using System.Windows.Data;
using System.Linq;
using TradeWars.Db;
using System.Windows.Documents;

namespace Editor;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class Main : Window
{
    private readonly TradeWarsDB _context = new();

    private CollectionViewSource menuitemsViewSource;

    public Main()
    {
        InitializeComponent();

        menuitemsViewSource = (CollectionViewSource)FindResource(nameof(menuitemsViewSource));


        //MainTextBox.AppendText("Hello World!\n\n");

        //using (var db = new TradeWarsDB())
        //{
        //}
    }

    private void Window_Loaded(object sender, RoutedEventArgs e)
    {
        // load the entities into EF Core
        _context.MenuItems
            .OrderBy(m => m.Name)
            .Load();

        // bind to the source
        menuitemsViewSource.Source = _context.MenuItems.Local.ToObservableCollection();
    }

    protected override void OnClosing(CancelEventArgs e)
    {
        // clean up database connections
        _context.Dispose();
        base.OnClosing(e);
    }


    //private void PageCB_DropDownClosed(object sender, System.EventArgs e)
    private void PageCB_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        if (PageCB.SelectedValue != null)
        {
            //TradeWars.Db.MenuItem Selected = (TradeWars.Db.MenuItem)PageCB.SelectedValue;
            //var Page = _context.MenuItems.Find(Selected.MenuItemId);
            var Page = _context.MenuItems.Find(PageCB.SelectedValue);
            if (Page != null)
            {
                //MainTextBox.AppendText($"{Page.Name} {Page.MenuId} \n\n");
                MainTextBox.Document.Blocks.Clear(); ;
                MainTextBox.AppendText(Page.PageData);
            }
        }
        //foreach (var Page in Pages)
        //{
        //    MainTextBox.AppendText($"{Page.Name} {Page.MenuId} \n\n");
        //}

    }

    private void SaveButton_Click(object sender, RoutedEventArgs e)
    {
        TextRange textRange = new TextRange(
            MainTextBox.Document.ContentStart,
            MainTextBox.Document.ContentEnd
        );

        var Page = _context.MenuItems.Find(PageCB.SelectedValue);
        Page.PageData = textRange.Text;
        _context.SaveChanges();
    }
}
