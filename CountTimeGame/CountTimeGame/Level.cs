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
    class Level
    {
        public int number { get; set; }
        public int maxScore { get; set; }
        public int numberOfrounds { get; set; }
        public double time { get; set; }
        
        public Level(int _number)
        {
            number = _number;
            numberOfrounds = number + 3;
            maxScore = number * 100;
            Random rand = new Random();
            time = rand.Next(300, 1500);
        }

        public Level GenerateLevel(int number)
        {
            return new Level(number);
        }
    }
}