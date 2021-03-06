﻿using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace fixit
{
    public partial class MenuPage : ContentPage
    {
        public MenuPage()
        {
            InitializeComponent();


                btnPlay.Clicked += (sender, args) => {
                    _ = Navigation.PopModalAsync(true);
                    TheGame.Game.Instance.resetGame();
                };
                btnScores.Clicked += (sender, args) => { _ = Navigation.PushModalAsync(new ScorePage(0)); };
                btnRules.Clicked += (sender, args) => {_ = Navigation.PushModalAsync(new RulesPage()); };
                btnAbout.Clicked += (sender, args) => { _ = Navigation.PopModalAsync(true); };
        }
    }

}
