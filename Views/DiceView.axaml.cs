using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using System.Collections.ObjectModel;
using System;
using Avalonia.Media.Imaging;
using Avalonia.Input.TextInput;
using System.ComponentModel;
using Dice_Roll_MVVM.ViewModels;
using Avalonia.VisualTree;
using System.Windows.Input;

namespace Dice_Roll_MVVM.Views;

public partial class DiceView : UserControl
{
    private DiceViewModel viewModel;

    public DiceView()
    {
        InitializeComponent();
        DataContext = new DiceViewModel();
        viewModel = (DiceViewModel)DataContext;
        viewModel.OnBackButtonClicked += Back;
        viewModel.OnGameEnded += ShowDialog;
    }

    private async void ShowDialog(string message)
    {
        var myMessageBox = new MessageBox(message);
        var result = await myMessageBox.ShowDialog<bool?>(this.GetVisualRoot() as Window);

        if (result == true)
        {
            MainMenu mainMenu = new MainMenu();
            this.Content = mainMenu;
        }
    }

    private void Back()
    {
        MainMenu mainMenu = new MainMenu();
        this.Content = mainMenu;
    }

    private void InitializeComponent()
    {
        AvaloniaXamlLoader.Load(this);
    }
}