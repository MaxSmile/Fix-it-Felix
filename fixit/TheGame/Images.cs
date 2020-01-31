using System;
namespace fixit.TheGame
{
    public class Images
    {
        private static Images _instance = null;
        public Images Instance
        {
            get
            {
                if (_instance == null) _instance = new Images();
                return _instance;
            }
        }
        private Images()
        {
        }
    }
}
