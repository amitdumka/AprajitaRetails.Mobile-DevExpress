﻿using System.Windows.Input;

namespace AprajitaRetails.Mobile.ViewModels
{
    public class AboutViewModel : BaseViewModel
    {
        public const string ViewName = "AboutPage";
        public AboutViewModel()
        {
            Title = "About";
            OpenWebCommand = new Command(async () => await Browser.OpenAsync("https://www.aprajitaretails.store:7111/"));
        }

        public ICommand OpenWebCommand { get; }
    }
}