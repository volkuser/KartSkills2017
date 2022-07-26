using System;
using ReactiveUI;

namespace App.ViewModels
{
    public class ViewModelBase : ReactiveObject, IRoutableViewModel
    {
        public IScreen HostScreen { get; }
        public string UrlPathSegment { get; } = Guid.NewGuid().ToString().Substring(0, 5);

        protected ViewModelBase(IScreen screen) => HostScreen = screen;
    }
}