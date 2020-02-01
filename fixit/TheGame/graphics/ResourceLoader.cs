using System;
using System.IO;
using System.Reflection;
using SkiaSharp;

namespace fixit.TheGame.graphics
{
    public class ResourceLoader
    {
        private static ResourceLoader _instance = null;
        public static ResourceLoader Instance
        {
            get
            {
                if (_instance == null) _instance = new ResourceLoader();
                return _instance;
            }
        }
        Assembly assembly;
        private ResourceLoader()
        {
            assembly = GetType().GetTypeInfo().Assembly;
        }

        public SKBitmap LoadImage(string resourceID)
        {
            SKBitmap resourceBitmap;
            using (Stream stream = assembly.GetManifestResourceStream(resourceID))
            {
                resourceBitmap = SKBitmap.Decode(stream);
            }
            return resourceBitmap;
        }
    }
}
