using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace Dice_Roll_MVVM.Views;

public partial class MessageBox : Window
{
    public MessageBox()
    {
        InitializeComponent();
    }
    public MessageBox(string message) : this()
    {
        this.FindControl<TextBlock>("Message").Text = message;
    }

    private void InitializeComponent()
    {
        AvaloniaXamlLoader.Load(this);
    }

    private void OKButton_Click(object sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        this.Close(true);
    }
}
