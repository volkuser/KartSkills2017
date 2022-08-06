using App.Models;

namespace App.ViewModels;

public class Singleton
{
    private static ApplicationContext? instance;
    
    public static ApplicationContext getInstance()
    {
        if (instance == null)
            instance = new ApplicationContext();
        return instance;
    }
}