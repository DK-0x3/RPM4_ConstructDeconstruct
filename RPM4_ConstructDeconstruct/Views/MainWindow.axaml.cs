using System;
using System.Collections.ObjectModel;
using Avalonia.Controls;
using Avalonia.Interactivity;
using RPM4_ConstructDeconstruct.Models;

namespace RPM4_ConstructDeconstruct.Views;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
    }

    private void AddProduct(object? sender, RoutedEventArgs e)
    {
        bool isValid = true;

        if (string.IsNullOrWhiteSpace(NameInput.Text))
        {
            NameError.Text = "Название товара обязательно.";
            isValid = false;
        }
        else
        {
            NameError.Text = "";
        }

        if (!double.TryParse(PriceInput.Text, out double price) || price <= 0)
        {
            PriceError.Text = "Введите корректную цену.";
            isValid = false;
        }
        else
        {
            PriceError.Text = "";
        }

        int quantity = 0;
        if (!string.IsNullOrWhiteSpace(QuantityInput.Text) &&
            (!int.TryParse(QuantityInput.Text, out quantity) || quantity < 0))
        {
            QuantityError.Text = "Введите корректное количество (целое число).";
            isValid = false;
        }
        else
        {
            QuantityError.Text = "";
        }

        if (isValid)
        {
            var product = new Product(NameInput.Text, price, quantity);
            ProductList.Items.Add(product);

            ClearInputs();
        }
    }

    private void DeconstructProduct(object? sender, RoutedEventArgs e)
    {
        if (ProductList.SelectedItem is Product selectedProduct)
        {
            var (name, price, quantity) = selectedProduct;

            DeconstructedInfo.Text = $"Название: {name}\nЦена: {price}\nКоличество: {quantity}";
        }
        else
        {
            DeconstructedInfo.Text = "! Выберите товар для деконструкции.";
        }
    }

    private void ClearInputs()
    {
        NameInput.Text = "";
        PriceInput.Text = "";
        QuantityInput.Text = "";
    }
}