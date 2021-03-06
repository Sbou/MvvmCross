﻿// MvxConsoleView.cs
// (c) Copyright Cirrious Ltd. http://www.cirrious.com
// MvvmCross is licensed using Microsoft Public License (Ms-PL)
// Contributions and inspirations noted in readme.md and license.txt
// 
// Project Lead - Stuart Lodge, @slodge, me@slodge.com

using System;
using Cirrious.MvvmCross.Console.Interfaces;
using Cirrious.MvvmCross.ExtensionMethods;
using Cirrious.MvvmCross.Interfaces.ServiceProvider;
using Cirrious.MvvmCross.Interfaces.ViewModels;

namespace Cirrious.MvvmCross.Console.Views
{
    public class MvxConsoleView<T>
        : IMvxConsoleView
          , IMvxServiceConsumer
        where T : IMvxViewModel
    {
        public T ViewModel { get; set; }

        public Type ViewModelType
        {
            get { return typeof (T); }
        }

#warning Need to get the Console implementation level with the mobile implementations again - HackSetViewModel is a Hack
        public void HackSetViewModel(object viewModel)
        {
            ViewModel = (T) viewModel;
            OnViewModelChanged();
        }

        public virtual bool HandleInput(string input)
        {
            return false;
        }

        protected virtual void OnViewModelChanged()
        {
        }

        public bool IsVisible
        {
			get { return this.GetService<IMvxConsoleCurrentView>().CurrentView == this; }
        }
    }
}