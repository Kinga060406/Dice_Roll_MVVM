using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using System;

namespace Dice_Roll_MVVM.Views;

public partial class MainMenu : UserControl
{

    private Button _BT_Menu_Coin;
    private Button _BT_Menu_Dice;
    private Button _BT_Exit;
    public MainMenu()
    {
        InitializeComponent();

        _BT_Menu_Dice = this.FindControl<Button>("BT_Menu_Dice");
        _BT_Exit = this.FindControl<Button>("BT_Exit");

        _BT_Menu_Dice.Click += BT_Menu_Dice_Click;
        _BT_Exit.Click += BT_Exit_Click;
    }
    private void InitializeComponent()
    {
        AvaloniaXamlLoader.Load(this);
    }


    private void BT_Menu_Dice_Click(object sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        DiceView diceView = new DiceView();
        this.Content = diceView;
    }
    private void BT_Exit_Click(object sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        Environment.Exit(0);
    }
    
}