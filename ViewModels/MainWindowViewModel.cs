using Avalonya_Praktika_Zadanue2.Models;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using System.Globalization;

namespace Avalonya_Praktika_Zadanue2.ViewModels;

public partial class MainWindowViewModel : ViewModelBase
{
    public ObservableCollection<Currency> Currencies { get; } = new();

    [ObservableProperty]
    private Currency? selectedFromCurrency;

    [ObservableProperty]
    private Currency? selectedToCurrency;

    [ObservableProperty]
    private string amount = string.Empty;

    [ObservableProperty]
    private string result = string.Empty;

    [ObservableProperty]
    private string errorMessage = string.Empty;

    public MainWindowViewModel()
    {
        // Загрузка валюты
        foreach (var c in CurrencyService.GetAllCurrencies())
        {
            Currencies.Add(c);
        }

        // По умолчанию USD -> EUR
        SelectedFromCurrency = Currencies[0];
        SelectedToCurrency = Currencies.Count > 1 ? Currencies[1] : Currencies[0];
    }

    [RelayCommand]
    private void Convert()
    {
        ErrorMessage = string.Empty;
        Result = string.Empty;

        if (SelectedFromCurrency == null || SelectedToCurrency == null)
        {
            ErrorMessage = "Пожалуйста, выберите обе валюты.";
            return;
        }

        if (string.IsNullOrWhiteSpace(Amount))
        {
            ErrorMessage = "Введите сумму для конвертации.";
            return;
        }

        // Парсиинг суммы с учётом локали (разрешаем только числа)
        if (!double.TryParse(Amount, NumberStyles.Number, CultureInfo.CurrentCulture, out double amountValue))
        {
            ErrorMessage = "Введите корректное числовое значение суммы.";
            return;
        }

        if (amountValue < 0)
        {
            ErrorMessage = "Сумма не может быть отрицательной.";
            return;
        }

        try
        {
            double converted = CurrencyService.Convert(amountValue, SelectedFromCurrency, SelectedToCurrency);
            Result = $"{amountValue} {SelectedFromCurrency.Code} = {converted:F4} {SelectedToCurrency.Code}";
        }
        catch (System.Exception ex)
        {
            ErrorMessage = "Ошибка конвертации: " + ex.Message;
        }
    }
}
