using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace CountTimeGame
{
    class Game
    {
        public int levelNumber { get; set; }

        public void newGame(Level level)
        {
            levelNumber = level.number;
            level.GenerateLevel(levelNumber);


            while (level.number <= levelNumber)
            {
                int i = 1;
                while (i <= level.numberOfrounds)
                {
                    i++;
                }



                levelNumber++;
            }
           
        }




    }
}