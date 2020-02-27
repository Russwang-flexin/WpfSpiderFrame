using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using System.Windows.Media;

namespace MySelfProject
{
    class LoginBoxWidget : UserControl
    {
        Border border = new Border() { Margin = new System.Windows.Thickness(1) };
        DockPanel wrap = new DockPanel();
        StackPanel stack;

        public LoginBoxWidget()
        {
            border.BorderThickness = new Thickness(1);
            border.BorderBrush = new SolidColorBrush(Colors.Red);
            CreateDefaultLayout();
            border.Child = wrap;
            Content = border;
        }

        void CreateDefaultLayout()
        {
            Image img = new Image() { /*MaxWidth = 340*/};
            img.Source = new BitmapImage(new Uri("/images/huang.jpg", UriKind.Relative));
            wrap.AddChild(img, Dock.Left);
            stack = new StackPanel() { VerticalAlignment = VerticalAlignment.Center, HorizontalAlignment = HorizontalAlignment.Center };
            stack.Children.Add(new CreateWholeFrame("账号：", inputType.Normal));
            stack.Children.Add(new CreateWholeFrame("密码：", inputType.Password));
            Button btn = new Button() { Content = "登录"};
            btn.Click += Btn_Click;
            stack.Children.Add(btn);
            wrap.AddChild(stack, Dock.Left);
        }

        private void Btn_Click(object sender, RoutedEventArgs e)
        {
            
        }
    }

    public enum inputType
    {
        Normal,
        Password,
    }

    public class CreateWholeFrame : UserControl
    {
        DockPanel dock = new DockPanel();
        UIElement box;
        public CreateWholeFrame(string Name, inputType type)
        {
            Label label = new Label()
            {
                Content = Name,
                FontSize = 14,
                Padding = new System.Windows.Thickness(2),
            };
            if (type == inputType.Password)
            {
                box = new PasswordBox() { MaxHeight = 20, MaxLength = 150, MinWidth = 100 };
                (box as PasswordBox).PasswordChar = '*';
            }
            else
            {
                box = new TextBox() { MaxHeight = 20, MaxLength = 150 , MinWidth = 100 };
            }
            dock.AddChild(label, Dock.Left);
            dock.AddChild(box, Dock.Left);
            Content = dock;
            Margin = new Thickness(5);
        }
    }

}
