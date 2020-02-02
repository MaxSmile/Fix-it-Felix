using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using SkiaSharp;
using SkiaSharp.Views.Forms;
using fixit.TheGame.input;

namespace fixit
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            // When the Game needs to display the Score Page
            TheGame.Game.Instance.OnNeedToSartScorePage = (int score) =>
            {
                Navigation.PushAsync(new ScorePage(score));
            };

            // Start the Game and provide call back which does Surface Invalidate
            TheGame.Game.Instance.startGame(()=>{
                SurfaceView.InvalidateSurface();
            });


            // Button clicks events
            btnCancel.Clicked += (sender, args) => { KeyBoard.pause = true; };
            //btnOK.Clicked += (sender, args) => { KeyBoard.fix = true; };
            //btnOK.Clicked += (sender, args) => {
            //    KeyBoard.hitBox = true;
            //};


            // TODO: navigating buttons have to implement touch down and touch up
            btnBottom.Clicked += (sender, args) => { KeyBoard.down = true; };
            btnTop.Clicked += (sender, args) => { KeyBoard.up = true; };
            btnRight.Clicked += (sender, args) => { KeyBoard.right = true; };
            btnLeft.Clicked += (sender, args) => { KeyBoard.left = true; };


            Task.Run(async () =>
            {
                await Task.Yield();
                Device.BeginInvokeOnMainThread(() =>
                {
                    //DisplayAlert(Application.Current.ToString(), "SurfaceView(" + SurfaceView.Width + "," + SurfaceView.Height + ")","OK");
                    Navigation.PushModalAsync(new MenuPage());
                });
            });
        }


        private void OnCanvasDraw(object sender, SKPaintSurfaceEventArgs e)
        {
            // CLEARING THE SURFACE

            // we get the current surface from the event args
            var surface = e.Surface;
            // then we get the canvas that we can draw on
            var canvas = surface.Canvas;
            // clear the canvas / view
            canvas.Clear(SKColors.Black);

            // Lets assume that more or less most of the modern devices have 600x1000 points (in pixels its more)

            TheGame.Game.Instance.OnDraw(canvas);

           
    
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            Application.Current.MainPage.SetValue(NavigationPage.BarBackgroundColorProperty, Color.FromHex("#661D08"));
            Application.Current.MainPage.SetValue(NavigationPage.BarTextColorProperty, Color.White);
            
        }


    }
}
