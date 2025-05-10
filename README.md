<p align = "center">
  <img src = "assets/rd1.gif" width = "1920" height = "500" alt="LogoInsert"> 
</p>

📐 BASIC CALCULATOR

Lab 4 - CS 222: Advanced Object-Oriented Programming

📌 Project Description and Features

The Basic Calculator is a console-based application that provides essential arithmetic operations with an intuitive input interface. It supports clearing entries, decimal calculations, and displays results in real time.

✨ Features:

🆑 C (Clear): Resets the entire current calculation.

🔙 CE (Clear Entry): Clears the last entered number or operation.

➕ Addition

➖ Subtraction

✖️ Multiplication

➗ Division

➰ Decimal Point: Allows floating-point calculations.

📟 Display: Shows the current input, operations, and results.

▶️ Instructions on Running the App

Open the project in Visual Studio or your preferred C# IDE.

Ensure Program.cs and Calculator.cs are in the same project.

Press F5 or run the application.

Use the console menu or key presses to:

Enter digits (0–9)

Press . for decimal point

Use +, -, *, / for operations

Press CE to clear the last entry

Press C to clear all

Press = to calculate and display the result

Press Esc or choose Exit to close the calculator

🗂 File Structure

/ Lab_4__Basic_Calculator
│
├── Program.cs      // Main loop and user interaction
├── Calculator.cs   // Calculator class: core logic and state management
├── Bin             // Contains project binaries
└── README.md       // This file

👨‍💻 Team Members

Balmes, Genrique Sean Arkin D.

Gonda, Paul Raimiel C.

Rivera, Irish D.

Sta. Teresa, David Kalel D.

🧪 Sample Output

------------------------------------
|   BASIC CALCULATOR (CS 222 Lab 4)  |
------------------------------------
Display: 0

Enter key: 7
Display: 7

Enter key: .
Display: 7.

Enter key: 5
Display: 7.5

Enter key: +
Display: 7.5 +

Enter key: 2
Display: 2

Enter key: =
Result: 9.5

Enter key: CE
Display: 0

Enter key: C
Display: 0

Enter key: Esc
Exiting calculator. Goodbye!

📝 Source Code

Program.cs

using System;

namespace BasicCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            var calculator = new Calculator();
            bool running = true;

            Console.WriteLine("------------------------------------");
            Console.WriteLine("|   BASIC CALCULATOR (CS 222 Lab 4)  |");
            Console.WriteLine("------------------------------------");

            while (running)
            {
                Console.WriteLine($"Display: {calculator.GetDisplay()}");
                Console.Write("Enter key: ");
                string input = Console.ReadLine();

                switch (input.ToUpper())
                {
                    case "C":
                        calculator.PressClear();
                        break;
                    case "CE":
                        calculator.PressClearEntry();
                        break;
                    case "+":
                    case "-":
                    case "*":
                    case "/":
                    case "=":
                        calculator.PressOperator(input);
                        break;
                    case ".":
                        calculator.PressDecimal();
                        break;
                    case "ESC":
                        running = false;
                        break;
                    default:
                        if (int.TryParse(input, out int digit))
                            calculator.PressDigit(digit);
                        break;
                }

                if (input == "=")
                    Console.WriteLine($"Result: {calculator.GetDisplay()}");
            }

            Console.WriteLine("Exiting calculator. Goodbye!");
        }
    }
}

Calculator.cs

using System;

namespace BasicCalculator
{
    public class Calculator
    {
        private string currentInput = "0";
        private double? accumulator = null;
        private string lastOperator = null;
        private bool resetOnNextDigit = false;

        public void PressDigit(int digit)
        {
            if (resetOnNextDigit || currentInput == "0")
            {
                currentInput = digit.ToString();
                resetOnNextDigit = false;
            }
            else
            {
                currentInput += digit;
            }
        }

        public void PressDecimal()
        {
            if (!currentInput.Contains("."))
                currentInput += ".";
        }

        public void PressOperator(string op)
        {
            if (double.TryParse(currentInput, out double value))
            {
                if (accumulator == null)
                {
                    accumulator = value;
                }
                else if (lastOperator != null)
                {
                    accumulator = Calculate(accumulator.Value, value, lastOperator);
                }

                currentInput = accumulator.ToString();
            }

            if (op == "=")
            {
                lastOperator = null;
                resetOnNextDigit = true;
            }
            else
            {
                lastOperator = op;
                resetOnNextDigit = true;
            }
        }

        public void PressClear()
        {
            currentInput = "0";
            accumulator = null;
            lastOperator = null;
            resetOnNextDigit = false;
        }

        public void PressClearEntry()
        {
            currentInput = "0";
        }

        public string GetDisplay()
        {
            return currentInput;
        }

        private double Calculate(double a, double b, string op)
        {
            return op switch
            {
                "+" => a + b,
                "-" => a - b,
                "*" => a * b,
                "/" => b != 0 ? a / b : double.NaN,
                _ => b,
            };
        }
    }
}


---

## 🙏 Acknowledgement
Special thanks to our CS 222 instructor, Ms. Fatima Marie P. Agdon, for guiding us in our AOOP Course.
