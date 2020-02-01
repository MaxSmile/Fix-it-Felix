using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace fixit
{
    public partial class MenuPage : ContentPage
    {
        public MenuPage()
        {
            InitializeComponent();


            btnPlay.Clicked += (sender, args) => { _ = Navigation.PopModalAsync(true); };
            btnScores.Clicked += (sender, args) => { _ = Navigation.PopModalAsync(true); };
            btnRules.Clicked += (sender, args) => { _ = Navigation.PopModalAsync(true); };
            btnAbout.Clicked += (sender, args) => { _ = Navigation.PopModalAsync(true); };
        }
    }
}
