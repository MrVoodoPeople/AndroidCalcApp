﻿using Avalonia.Controls;
using Avalonia.Interactivity;

namespace AndroidCalculator.Views;

public partial class MainView : UserControl
{
    private float _lastValue = 0;
    private string _currentOperation = "";
    private float _repeatValue = 0;
    private bool _isClear = false;
    private bool _isOperationRepeated = false;
    private string _lastOperation= "";
    private bool _isZero = false;
    
    public MainView()
    {
        InitializeComponent();
        ResultTextBox.IsReadOnly = true;
    }

    #region
    private float Add(float a, float b)
    {
        return a + b;
    }
    private float Subtract(float a, float b)
    {
        return a - b;
    }
    private float Mult(float a, float b)
    {
        return a * b;
    }
    private float Div(float a, float b)
    {
            return a / b;
    }
    #endregion

    private void OnNumberClick(object? sender, RoutedEventArgs e)
    {
        if(_isZero)
        {
            Clear();
            UnblockOperationButton();
        }
        if (_isClear)
        {
            ResultTextBox.Text = "";
            _isClear = false;
        }
        var button = (Button)sender;
        if (ResultTextBox.Text != "0") 
            ResultTextBox.Text += button.Content.ToString();
        else
        {
            ResultTextBox.Text = button.Content.ToString();
        }
        _isZero = false;

    }
    //OnCommaClick
    private void OnCommaClick(object? sender, RoutedEventArgs e)
    {
        if (_isZero)
        {
            Clear();
            UnblockOperationButton();
        }
        if (_isClear)
        {
            ResultTextBox.Text = "0";
            _isClear = false;
        }
        var button = (Button)sender;
        if (!ResultTextBox.Text.Contains(","))
            ResultTextBox.Text += button.Content.ToString();

    }

    private void OnAddClick(object? sender, RoutedEventArgs e)
    {

        /*if (!string.IsNullOrEmpty(_currentOperation) && _currentOperation != "+")
        {
            PerformOperation();
        }*/
        if (float.TryParse(ResultTextBox.Text, out _lastValue))
        {
            _currentOperation = "+";
            _isClear = true;
            _isOperationRepeated = false;
        }
    }
    private void OnSubtractClick(object? sender, RoutedEventArgs e)
    {

        /*if (!string.IsNullOrEmpty(_currentOperation) && _currentOperation != "-")
        {
            PerformOperation();
        }*/
        if (float.TryParse(ResultTextBox.Text, out _lastValue))
        {
            _currentOperation = "-";
            _isClear = true;
            _isOperationRepeated = false;
        }
    }

    //mult func
    private void OnMultClick(object? sender, RoutedEventArgs e)
    {
        /*if (!string.IsNullOrEmpty(_currentOperation) && _currentOperation != "*")
        {
            PerformOperation();
        }*/
        if (float.TryParse(ResultTextBox.Text, out _lastValue))
        {
            _currentOperation = "*";
            _isClear = true;
            _isOperationRepeated = false;
        }
    }
    //div func
    private void OnDivClick(object? sender, RoutedEventArgs e)
    {
        /*if (!string.IsNullOrEmpty(_currentOperation) && _currentOperation  != "/")
        {
            PerformOperation();
        }*/
        if (float.TryParse(ResultTextBox.Text, out _lastValue))
        {
            _currentOperation = "/";
            _isClear = true;
            _isOperationRepeated = false;
        }
    }
 /*   private void OnSinClick(object? sender, RoutedEventArgs e)
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
*/
    private void OnEqualsClick(object sender, RoutedEventArgs e)
    {
        if (!string.IsNullOrEmpty(_lastOperation) && _isOperationRepeated)
        {
            RepeatLastOperation(_repeatValue);
            return;
        }
        if (_currentOperation == "+" && float.TryParse(ResultTextBox.Text, out float _currentValue))
        {
            ResultTextBox.Text = Add(_lastValue, _currentValue).ToString();
            _lastValue = float.Parse(ResultTextBox.Text);
            _repeatValue = _currentValue;
        }
        if (_currentOperation == "-" && float.TryParse(ResultTextBox.Text, out _currentValue))
        {
            ResultTextBox.Text = Subtract(_lastValue, _currentValue).ToString();
            _lastValue = float.Parse(ResultTextBox.Text);
            _repeatValue = _currentValue;
        }
        if (_currentOperation == "*" && float.TryParse(ResultTextBox.Text, out _currentValue))
        {
            ResultTextBox.Text = Mult(_lastValue, _currentValue).ToString();
            _lastValue = float.Parse(ResultTextBox.Text);
            _repeatValue = _currentValue;
        }
        if (_currentOperation == "/" && float.TryParse(ResultTextBox.Text, out _currentValue))
        {
            if (_currentValue == 0)
            {
                ResultTextBox.Text = "На ноль делить нельзя";
                _isZero= true;
                BlockOperationButton();
                return;
            }
            else
            {
                ResultTextBox.Text = Div(_lastValue, _currentValue).ToString();
                _lastValue = float.Parse(ResultTextBox.Text);
                _repeatValue = _currentValue;
            }
        }
        /*        if (_operation == "Sin" && float.TryParse(ResultTextBox.Text, out _currentlyValue))
                {
                    ResultTextBox.Text = Math.Sin(Convert.ToDouble(_currentlyValue) * Math.PI / 180).ToString();
                    _operation = "";
                }*/
        _lastOperation = _currentOperation;
        _currentOperation = "";
        _isClear = true;
        _isOperationRepeated = true;
        
        

    }
    private void OnClearClick(object sender, RoutedEventArgs e)
    {
       Clear();
    }

    #region
    /*private void PerformOperation()
    {
        if (_currentOperation == "+")
        {
            if (float.TryParse(ResultTextBox.Text, out float _currentValue))
            {
                _lastValue += _currentValue;
                ResultTextBox.Text = _lastValue.ToString();
            }
        }
        if (_currentOperation == "-")
        {
            if (float.TryParse(ResultTextBox.Text, out float _currentValue))
            {
                _lastValue -= _currentValue;
                ResultTextBox.Text = _lastValue.ToString();
            }
        }
        if (_currentOperation == "*")
        {
            if (float.TryParse(ResultTextBox.Text, out float _currentValue))
            {
                _currentValue *= _lastValue;
                ResultTextBox.Text = _currentValue.ToString();
            }
        }
        if (_currentOperation == "/")
        {
            if (float.TryParse(ResultTextBox.Text, out float _currentValue))
            {
                _currentValue /= _lastValue;
                ResultTextBox.Text = _currentValue.ToString();
            }
        }
*//*        if (_operation == "Sin")
        {
            if (float.TryParse(ResultTextBox.Text, out float _lastValue))
            {
                ResultTextBox.Text = Math.Sin(Convert.ToDouble(_lastValue) * Math.PI / 180).ToString();
            }
        }*//*

    }*/

    #endregion
    private void RepeatLastOperation(float repeatValue)
    {
        if (_lastOperation == "+")
        {
                _lastValue += repeatValue;
                ResultTextBox.Text = _lastValue.ToString();
        }
        if (_lastOperation == "-")
        {
                _lastValue -= repeatValue;
                ResultTextBox.Text = _lastValue.ToString();
        }
        if (_lastOperation == "*")
        {
                _lastValue *= repeatValue;
                ResultTextBox.Text = _lastValue.ToString();
        }
        if (_lastOperation == "/")
        {
                _lastValue /= repeatValue;
                ResultTextBox.Text = _lastValue.ToString();

        }
/*        if (_operation == "Sin")
        {
            if (float.TryParse(ResultTextBox.Text, out float _lastValue))
            {
                ResultTextBox.Text = Math.Sin(Convert.ToDouble(_lastValue) * Math.PI / 180).ToString();
            }
        }*/
    }
    private void Clear()
    {
        ResultTextBox.Text = "0";
        _currentOperation = "";
        _isOperationRepeated = false;
        _lastValue = 0;
        _isClear = false;
        _lastOperation = "";
    }
    private void BlockOperationButton()
    {   
        bSubtract.IsEnabled = false;
        bAdd.IsEnabled = false;
        bDiv.IsEnabled = false;
        bEquales.IsEnabled = false;
        bMult.IsEnabled = false;
    }
    private void UnblockOperationButton() 
    {
        bSubtract.IsEnabled = true;
        bAdd.IsEnabled = true;
        bDiv.IsEnabled = true;
        bEquales.IsEnabled = true;
        bMult.IsEnabled = true;
    }
}
