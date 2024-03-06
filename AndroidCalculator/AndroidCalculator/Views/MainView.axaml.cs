﻿using Avalonia.Controls;
using Avalonia.Interactivity;
using System;

namespace AndroidCalculator.Views;

public partial class MainView : UserControl
{
    private float _currentlyValue;
    private float _lastValue;
    private string _operation = "";
    private bool _isClear = false;
    public MainView()
    {
        InitializeComponent();
    }


    private float Add(float a, float b)
    {
        return a + b;
    }
    private float Subtract(float a, float b)
    {
        return a - b;
    }



    private void OnNumberClick(object? sender, RoutedEventArgs e)
    {
        if (_isClear)
        {
            ResultTextBox.Text = "";
            _isClear = false;
        }
        var button = (Button)sender;
        ResultTextBox.Text += button.Content.ToString();
    }
    private void AddButtonClick(object? sender, RoutedEventArgs e)
    {

        if (!string.IsNullOrEmpty(_operation))
        {
            PerformOperation();
        }
        if (float.TryParse(ResultTextBox.Text, out _lastValue))
        {
            _operation = "+";
            _isClear = true;
        }
    }
    private void OnSubtractClick(object? sender, RoutedEventArgs e)
    {

        if (!string.IsNullOrEmpty(_operation))
        {
            PerformOperation();
            return;
        }
        if (float.TryParse(ResultTextBox.Text, out _lastValue))
        {
            _operation = "-";
            _isClear = true;
        }
    }
    private void OnSinClick(object? sender, RoutedEventArgs e)
    {
        if (!string.IsNullOrEmpty(_operation))
        {
            PerformOperation();
        }
        if (float.TryParse(ResultTextBox.Text, out _lastValue))
        {
            _operation = "Sin";
            _isClear = true;
        }
    }

    private void OnEqualsClick(object sender, RoutedEventArgs e)
    {
        if (_operation == "+" && float.TryParse(ResultTextBox.Text, out _currentlyValue))
        {
            ResultTextBox.Text = Add(_lastValue, _currentlyValue).ToString();
            _lastValue = float.Parse(ResultTextBox.Text);
            _operation = "";
        }
        if (_operation == "-" && float.TryParse(ResultTextBox.Text, out _currentlyValue))
        {
            ResultTextBox.Text = Subtract(_lastValue, _currentlyValue).ToString();
            _lastValue = float.Parse(ResultTextBox.Text);
            _operation = "";
        }
        if (_operation == "Sin" && float.TryParse(ResultTextBox.Text, out _currentlyValue))
        {
            ResultTextBox.Text = Math.Sin(Convert.ToDouble(_currentlyValue) * Math.PI / 180).ToString();
            _operation = "";
        }
        _isClear = true;

    }
    private void OnClearClick(object sender, RoutedEventArgs e)
    {
        ResultTextBox.Text = "";
        _operation = "";
        _lastValue = 0;
        _currentlyValue = 0;
    }

    private void PerformOperation()
    {
        if (_operation == "+")
        {
            if (float.TryParse(ResultTextBox.Text, out float _currentValue))
            {
                _lastValue += _currentValue;
                ResultTextBox.Text = _lastValue.ToString();
            }
        }
        if (_operation == "-")
        {
            if (float.TryParse(ResultTextBox.Text, out float _currentValue))
            {
                _currentValue -= _lastValue;
                ResultTextBox.Text = _currentValue.ToString();
            }
        }
        if (_operation == "Sin")
        {
            if (float.TryParse(ResultTextBox.Text, out float _lastValue))
            {
                ResultTextBox.Text = Math.Sin(Convert.ToDouble(_lastValue) * Math.PI / 180).ToString();
            }
        }

    }
}
