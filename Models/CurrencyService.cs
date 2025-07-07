using System.Collections.Generic;

namespace Avalonya_Praktika_Zadanue2.Models;

public static class CurrencyService
{
    private static readonly List<Currency> currencies = new()
    {
        new Currency("USD", "Доллар США", 1.0),
        new Currency("EUR", "Евро", 0.93),
        new Currency("GBP", "Фунт стерлингов", 0.80),
        new Currency("JPY", "Иена", 151.50),
        new Currency("RUB", "Рубль", 92.50)
    };

    public static IReadOnlyList<Currency> GetAllCurrencies() => currencies;

    public static double Convert(double amount, Currency from, Currency to)
    {
        if (from == null) throw new System.ArgumentNullException(nameof(from));
        if (to == null) throw new System.ArgumentNullException(nameof(to));
        if (from.Rate == 0) throw new System.ArgumentException("Курс исходной валюты не может быть равен нулю.");
        if (to.Rate == 0) throw new System.ArgumentException("Курс целевой валюты не может быть равен нулю.");

        return amount * (from.Rate / to.Rate);
    }
}