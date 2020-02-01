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
            TheGame.Game.Instance.startGame(()=>{
                SurfaceView.InvalidateSurface();
            });
            btnBottom.Clicked += (sender, args) => { KeyBoard.down = true; };
            btnTop.Clicked += (sender, args) => { KeyBoard.up = true; };
            btnRight.Clicked += (sender, args) => { KeyBoard.right = true; };
            btnLeft.Clicked += (sender, args) => { KeyBoard.left = true; };
            btnCancel.Clicked += (sender, args) => { KeyBoard.pause = true; };
            btnOK.Clicked += (sender, args) => { KeyBoard.fix = true; };
            btnOK.Clicked += (sender, args) => { KeyBoard.hitBox = true; };
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

            TheGame.Game.Instance.OnDraw(canvas);

           
    
        }

    }


}
