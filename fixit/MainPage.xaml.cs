using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using SkiaSharp;
using SkiaSharp.Views.Forms;

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

            // DRAWING TEXT

            //// create the paint for the text
            //var textPaint = new SKPaint
            //{
            //    IsAntialias = true,
            //    Style = SKPaintStyle.Fill,
            //    Color = SKColors.Orange,
            //    TextSize = 80
            //};
            //// draw the text (from the baseline)
            //canvas.DrawText("Repair it!", 60, 160 + 80, textPaint);


    
        }

    }


}
