using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MySelfProject
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        double windowWid = 700;
        double windowHei = 400;
        double TextHeight = 20;
        double TextWidth = 80;
        DockPanel mainDock = new DockPanel();

        public MainWindow()
        {
            InitializeComponent();
            ResizeMode = ResizeMode.NoResize;
            Width = windowWid;
            Height = windowHei;
            CreateDeafautLayout();
            Content = mainDock;
        }

        void CreateDeafautLayout()
        {
            Image img = new Image() { Width = windowWid / 2, Height = windowHei};
            img.Source = new BitmapImage(new Uri("/images/huang.jpg", UriKind.Relative)); ;
            mainDock.Children.Add(img);
            DockPanel.SetDock(img, Dock.Left);
            TextBox tx = new TextBox() { Width = TextWidth, Height = TextHeight };
            mainDock.Children.Add(tx);
            DockPanel.SetDock(tx, Dock.Top);

            TextBox tx2 = new TextBox() { Width = TextWidth, Height = TextHeight };
            mainDock.Children.Add(tx2);
            DockPanel.SetDock(tx2, Dock.Top);

            Button Submit = new Button();
            Submit.Tag = "确认";
            mainDock.Children.Add(Submit);
            DockPanel.SetDock(Submit, Dock.Bottom);


            Label response = new Label() {Width = 20, Height = 20, Background = new SolidColorBrush(Colors.Pink) };
            mainDock.Children.Add(response);
            DockPanel.SetDock(response, Dock.Top);

            string username = tx.Text;
            string passwod = tx2.Text;
            var x = new LoginModule(username, passwod);
            Submit.Click += (sender, e) =>
            {
                //Application.Current.Dispatcher.Invoke(new Action(() => 
                //{
                response.Content = x.result;
                //}));
            };

        }

    }
}
