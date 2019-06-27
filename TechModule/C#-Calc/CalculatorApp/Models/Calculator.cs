﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CalculatorApp.Models
{
    public class Calculator
    {
        public decimal LeftOperand { get; set; }
        public string Operator { get; set; }
        public decimal RightOperand { get; set; }
        public decimal Result { get; set; }

        public Calculator()
        {
            this.Result = 0;
        }

        public void CalculateResult()
        {
            switch (this.Operator)
            {
                case "+":
                    Result = this.LeftOperand + this.RightOperand;
                    break;
                case "-":
                    Result = this.LeftOperand - this.RightOperand;
                    break;
                case "*":
                    Result = this.LeftOperand * this.RightOperand;
                    break;
                case "/":
                    Result = this.LeftOperand / this.RightOperand;
                    break;
            }

        }


    }
}
