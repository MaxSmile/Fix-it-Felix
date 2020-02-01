using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Xamarin.Forms;

namespace fixit
{
    public partial class ScorePage : ContentPage
    {
        int newScore = 0;
        // if score <=0 - not asking for the name
        public ScorePage(int score)
        {
            newScore = score;
            InitializeComponent();
            if(Application.Current.Properties.ContainsKey("scores"))
            {
                string jsonScores = (string)Application.Current.Properties["scores"];
                if (!String.IsNullOrEmpty(jsonScores))
                {
                    JObject pairs = (JObject)JsonConvert.DeserializeObject(jsonScores);
                    foreach(var prop in pairs)
                    {
                        _scoreList.Add(prop.Key, prop.Value.ToString());
                    }
                }
            }
            
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            Application.Current.MainPage.SetValue(NavigationPage.BarBackgroundColorProperty, Color.FromHex("#EB5757"));
            Application.Current.MainPage.SetValue(NavigationPage.BarTextColorProperty, Color.White);

            Task.Run(async()=> {
                await Task.Yield();
                Device.BeginInvokeOnMainThread(async ()=> {
                    if(newScore>0)
                    {
                        string result = null;
                        do
                        {
                            result = await DisplayPromptAsync("Congratulations!", "What's your name?");
                        } while (String.IsNullOrEmpty(result));
                        
                        AddUserScore(result, newScore);
                    }
                    if (UsersScores.Count > 0)
                    {
                        string result = "Scores: \r\n";
                        foreach (KeyValuePair<string, string> entry in UsersScores)
                        {
                            result += entry.Key + ": " + entry.Value+"\r\n";
                        }
                        tempLabel.Text = result;
                    }
                });
            });

            
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
