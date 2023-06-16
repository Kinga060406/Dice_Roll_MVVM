using Avalonia.Controls;
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Avalonia.Media.Imaging;
using System.Collections.ObjectModel;

namespace Dice_Roll_MVVM.Models
{
    public class DiceModel : ReactiveObject
    {
        public ObservableCollection<Image> Eyes()
        {
            ObservableCollection<Image> diceImages = new();

            for (int i = 1; i < 7; i++)
            {
                Image diceImage = new Image();
                diceImage.Source = new Bitmap(string.Format("../../../Assets/dice{0}.png", i));
                diceImages.Add(diceImage);
            }

            return diceImages;
        }
    }
}
