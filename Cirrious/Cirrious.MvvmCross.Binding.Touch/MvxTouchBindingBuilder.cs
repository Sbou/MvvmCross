// MvxTouchBindingBuilder.cs
// (c) Copyright Cirrious Ltd. http://www.cirrious.com
// MvvmCross is licensed using Microsoft Public License (Ms-PL)
// Contributions and inspirations noted in readme.md and license.txt
// 
// Project Lead - Stuart Lodge, @slodge, me@slodge.com

using System;
using Cirrious.MvvmCross.Binding.Bindings.Target.Construction;
using Cirrious.MvvmCross.Binding.Interfaces.Binders;
using Cirrious.MvvmCross.Binding.Interfaces.Bindings.Target.Construction;
using Cirrious.MvvmCross.Binding.Touch.Target;
using MonoTouch.UIKit;

namespace Cirrious.MvvmCross.Binding.Touch
{
    public class MvxTouchBindingBuilder
        : MvxBaseBindingBuilder
    {
        private readonly Action<IMvxTargetBindingFactoryRegistry> _fillRegistryAction;
        private readonly Action<IMvxValueConverterRegistry> _fillValueConvertersAction;

        public MvxTouchBindingBuilder(Action<IMvxTargetBindingFactoryRegistry> fillRegistryAction,
                                      Action<IMvxValueConverterRegistry> fillValueConvertersAction)
        {
            _fillRegistryAction = fillRegistryAction;
            _fillValueConvertersAction = fillValueConvertersAction;
        }

        protected override void FillTargetFactories(IMvxTargetBindingFactoryRegistry registry)
        {
            base.FillTargetFactories(registry);

            RegisterPropertyInfoBindingFactory(registry, typeof (MvxUISliderValueTargetBinding), typeof (UISlider),
                                               "Value");
            RegisterPropertyInfoBindingFactory(registry, typeof (MvxUITextFieldTextTargetBinding), typeof (UITextField),
                                               "Text");
            RegisterPropertyInfoBindingFactory(registry, typeof (MvxUISwitchOnTargetBinding), typeof (UISwitch), "On");
            registry.RegisterFactory(new MvxCustomBindingFactory<UIButton>("Title",
                                                                           (button) =>
                                                                           new MvxUIButtonTitleTargetBinding(button)));
            RegisterPropertyInfoBindingFactory(registry, typeof(MvxUISearchBarTextTargetBinding), typeof(UISearchBar),
                                               "Text");

            if (_fillRegistryAction != null)
                _fillRegistryAction(registry);
        }

        protected virtual void RegisterPropertyInfoBindingFactory(IMvxTargetBindingFactoryRegistry registry,
                                                                  Type bindingType, Type targetType, string targetName)
        {
            registry.RegisterFactory(new MvxSimplePropertyInfoTargetBindingFactory(bindingType, targetType, targetName));
        }

        protected override void FillValueConverters(IMvxValueConverterRegistry registry)
        {
            base.FillValueConverters(registry);

            if (_fillValueConvertersAction != null)
                _fillValueConvertersAction(registry);
        }
    }
}