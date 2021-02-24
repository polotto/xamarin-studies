﻿using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace Navigation
{
    public partial class MainView : ContentPage
    {
        public MainView(MainViewModel viewModel)
        {
            InitializeComponent();
            BindingContext = viewModel;
        }
    }
}
