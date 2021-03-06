﻿using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Cirrious.Conference.Core.Converters;
using Cirrious.MvvmCross.Localization.Converters;
using Cirrious.MvvmCross.Plugins.Visibility;
using Cirrious.MvvmCross.WindowsPhone.Platform.Converters;

namespace Cirrious.Conference.UI.WP7.NativeConverters
{
    public class LanguageBinderConverter : MvxNativeValueConverter<MvxLanguageBinderConverter>
    {        
    }

    public class VisibilityConverter : MvxNativeValueConverter<MvxVisibilityConverter>
    {
    }

    public class SimpleDateConverter : MvxNativeValueConverter<SimpleDateValueConverter>
    {
    }

    public class SessionSmallDetailsConverter : MvxNativeValueConverter<SessionSmallDetailsValueConverter>
    {
    }

    public class SponsorImageConverter : MvxNativeValueConverter<SponsorImageValueConverter>
    {
    }

    public class TimeAgoConverter : MvxNativeValueConverter<TimeAgoValueConverter>
    {
    }
}
