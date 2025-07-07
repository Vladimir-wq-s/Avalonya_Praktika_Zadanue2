using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonya_Praktika_Zadanue2.Views;
using Avalonia.Markup.Xaml; // Добавлено

namespace Avalonya_Praktika_Zadanue2;

public partial class App : Application
{
    public override void Initialize()
    {
        AvaloniaXamlLoader.Load(this);
    }

    public override void OnFrameworkInitializationCompleted()
    {
        if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
        {
            desktop.MainWindow = new MainWindow();
        }

        base.OnFrameworkInitializationCompleted();
    }
}