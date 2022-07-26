using System;
using Avalonia.Controls;
using Avalonia.Controls.Templates;
using App.ViewModels;
using App.Views.Pages;
using ReactiveUI;

namespace App
{
    public class ViewLocator : IDataTemplate, IViewLocator
    {
        public IControl Build(object data)
        {
            var name = data.GetType().FullName!.Replace("ViewModel", "View");
            var type = Type.GetType(name);

            if (type != null)
            {
                return (Control) Activator.CreateInstance(type)!;
            }

            return new TextBlock {Text = "Not Found: " + name};
        }

        public bool Match(object data)
        {
            return data is ViewModelBase;
        }
        
        public IViewFor ResolveView<T>(T viewModel, string? contract = null) => viewModel switch
        {
            MainMenuPageViewModel context => new MainMenuPage { DataContext = context },
            _ => throw new ArgumentOutOfRangeException(nameof(viewModel))
        };
    }
}