using Android.App;
using Android.Widget;
using Android.OS;
using Android.Views.InputMethods;
using Android.InputMethodServices;
using System.Text;

namespace CountTimeGame
{
    [Activity(Label = "CountTimeGame", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        InputMethodManager imm;
        TextView welcomeEditText;
        TextView whatsYourNameTextView;
        EditText playerNameEditText;
        Button saveNameBtn;
        Button startGamebtn;
        TextView playerStatsTextView;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);




            welcomeEditText = FindViewById<TextView>(Resource.Id.textViewWelcome);
            whatsYourNameTextView = FindViewById<TextView>(Resource.Id.WhatsYourNameTextView);
            saveNameBtn = FindViewById<Button>(Resource.Id.btnSavePlayerName);
            playerNameEditText = FindViewById<EditText>(Resource.Id.editTextPlayerName);


            playerNameEditText.Touch += delegate
            {
                playerNameEditText.Text = string.Empty;
                imm = (InputMethodManager)GetSystemService(Android.Content.Context.InputMethodService);
                imm.ShowSoftInput(playerNameEditText, InputMethodManager.ShowImplicit);
            };

            saveNameBtn.Click += delegate
            {
                imm = (InputMethodManager)GetSystemService(Android.Content.Context.InputMethodService);
                imm.HideSoftInputFromWindow(playerNameEditText.ApplicationWindowToken, 0);

                welcomeEditText.Visibility = Android.Views.ViewStates.Gone;
                whatsYourNameTextView.Visibility = Android.Views.ViewStates.Gone;
                playerNameEditText.Visibility = Android.Views.ViewStates.Gone;
                saveNameBtn.Visibility = Android.Views.ViewStates.Gone;

                startGamebtn = FindViewById<Button>(Resource.Id.btnStartGame);
                startGamebtn.Visibility = Android.Views.ViewStates.Visible;

                playerStatsTextView = FindViewById<TextView>(Resource.Id.textViewPlayerStats);
                playerStatsTextView.Visibility = Android.Views.ViewStates.Visible;
                playerStatsTextView.Text = "qweqweqwe";
                playerStatsTextView.Text = RenderStats(playerNameEditText.Text, 0, 1).ToString();

                StartGame(playerNameEditText.Text);
            };
        }

        public static void StartGame(string _playerName)
        {
            Player player = new Player();
            player.playerName = _playerName;
            player.score = 0;
            Level l = new Level(1);
            l.GenerateLevel(1);
            Game game = new Game();
            game.newGame(l);
        }

        public static StringBuilder RenderStats(string playerName, int score, int level)
        {
            StringBuilder playerStats = new StringBuilder();
            playerStats.AppendFormat("Player: {0}\n", playerName);
            playerStats.AppendFormat("Score: {0}\n", score);
            playerStats.AppendFormat("Level: {0}", level);
            return playerStats;
        }
    }
}

