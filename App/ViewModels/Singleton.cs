using App.Models;

namespace App.ViewModels;

public static class Singleton
{
    private static ApplicationContext? _instance;
    
    public static ApplicationContext GetInstance()
    {
        return _instance ??= new ApplicationContext();
    }
}