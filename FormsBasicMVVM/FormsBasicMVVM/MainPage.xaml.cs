﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace FormsBasicMVVM
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            BindingContext = new ClockViewModel();
            InitializeComponent();
        }
    }
}
