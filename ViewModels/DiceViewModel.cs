using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Avalonia.Media.Imaging;
using Dice_Roll_MVVM.Views;
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Dice_Roll_MVVM.Models;

namespace Dice_Roll_MVVM.ViewModels
{
    public class DiceViewModel : ViewModelBase, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private DiceModel model;
        private string tb_turns = "Player1's turn";
        public string TB_Turns
        {
            get { return tb_turns; }
            set { SetProperty(ref tb_turns, value); }
        }

        private string tb_p1 = "0";
        public string TB_P1
        {
            get { return tb_p1; }
            set { SetProperty(ref tb_p1, value); }
        }

        private string tb_p2 = "0";
        public string TB_P2
        {
            get { return tb_p2; }
            set { SetProperty(ref tb_p2, value); }
        }

        private Image img = new Image();
        public Image Img
        {
            get => img;
            set => SetProperty(ref img, value);
        }

        private ObservableCollection<Image> diceImages;
        private bool p1_turn = true;
        private int p1_score = 0;
        private int p2_score = 0;

        public DiceViewModel()
        {
            model = new DiceModel();
            diceImages = model.Eyes();
        }

        public ICommand BT_Roll_Click => ReactiveCommand.Create(() =>
        {
            Random rnd = new Random();
            int random = rnd.Next(0, 6);
            if (p1_turn)
            {
                TB_Turns = "Player 2's turn";
                p1_turn = false;
                p1_score += (random + 1);
                TB_P1 = p1_score.ToString();
            }
            else
            {
                TB_Turns = "Player 1's turn";
                p2_score += (random + 1);
                p1_turn = true;
                TB_P2 = p2_score.ToString();
            }

            if (p1_score > 39)  //Logika wygrywania
            {
                OnGameEnded?.Invoke("Player 1 wins!");
            }
            else if (p2_score > 39)
            {
                OnGameEnded.Invoke("Player 2 wins!");
            }

            Img = diceImages[random];
        });
        public event Action OnBackButtonClicked;

        public ICommand BT_Back_Click => ReactiveCommand.Create(() =>
        {
            OnBackButtonClicked?.Invoke();
        });

        public event Action<string> OnGameEnded;

        protected void SetProperty<T>(ref T storage, T value, [CallerMemberName] string propertyName = null)
        {
            if (!EqualityComparer<T>.Default.Equals(storage, value))
            {
                storage = value;
                OnPropertyChanged(propertyName);
            }
        }

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
