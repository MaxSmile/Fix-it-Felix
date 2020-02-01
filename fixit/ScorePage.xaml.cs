using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Xamarin.Forms;

namespace fixit
{
    public partial class ScorePage : ContentPage
    {
        public ScorePage()
        {
            InitializeComponent();
            if(Application.Current.Properties.ContainsKey("scores"))
            {
                string jsonScores = (string)Application.Current.Properties["scores"];
                if (!String.IsNullOrEmpty(jsonScores))
                {
                    _scoreList = (System.Collections.Generic.Dictionary<string, string>)JsonConvert.DeserializeObject(jsonScores);
                }
            }
        }

        private Dictionary<string,string> _scoreList = new Dictionary<string, string>();

        public Dictionary<string, string> UsersScores
        {
            get
            {
                return _scoreList;
            }
        }

        public void AddUserScore(string user, int score)
        {
            _scoreList.Add("" + user, "" + score);
            string json = JsonConvert.SerializeObject(_scoreList);
            Application.Current.Properties["scores"] = json;
            _= App.Current.SavePropertiesAsync();

        }



    }
}
