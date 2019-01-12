﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace MedGame.UI.WPF
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        LoadingCircleWindow loadingCircle = new LoadingCircleWindow();


        public App()
        {
            LoadingCircleWindow.timer.Start();
        }
    }
}
