using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CalculatorManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI ShowText;
    private string inputList;
    public void GetUserInput(string value)
    {
        Debug.Log($"Calc In {value}");
        ShowText.text += value;
        inputList += value;
    }
    public void AllClear()
    {
        ShowText.text = "";
        inputList = "";
    }
    public void Calculate()
    {
        double answer = EvaluateExpression(inputList);
        AllClear();
        ShowText.text = answer.ToString();

    }
    private double EvaluateExpression(string value)
    {
        string number = "";
        List<double> numbers = new();
        List<char> operators = new();

        foreach (char c in value)
        {
            if (char.IsDigit(c) || c == '.')
            {
                number += c;
            }
            else
            {
                numbers.Add(double.Parse(number));
                number = "";
                operators.Add(c);
            }
        }
        if (number != "")
        {
            numbers.Add(double.Parse(number));
        }
        string test = "";
        for (int i = 0; i < numbers.Count; i++) {
            test += numbers[i];
        }
        Debug.Log($"Calc numbers {test}");
        test = "";
        for (int i = 0; i < operators.Count; i++)
        {
            test += operators[i];
        }
        Debug.Log($"Calc operators {test}");
        for (int i = 0; i < operators.Count; i++)
        {
            if (operators[i] == 'X' || operators[i] == '/')
            {
                double left = numbers[i];
                double right = numbers[i + 1];
                double res = 0;
                if (operators[i] == 'X')
                {
                    res = left * right;
                }
                else
                {
                    res = left / right;
                }

                numbers[i] = res;
                numbers.RemoveAt(i + 1);
                operators.RemoveAt(i);

                i--;
            }
        }

        double finalResult = numbers[0];
        for (int i = 0; i < operators.Count; i++)
        {
            if (operators[i] == '+')
                finalResult += numbers[i + 1];
            else if (operators[i] == '-')
                finalResult -= numbers[i + 1];
        }

        return finalResult;
    }
}
