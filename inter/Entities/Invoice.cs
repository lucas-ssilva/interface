using System;
using System.Collections.Generic;
using System.Text;
using System.Globalization;
using inter.Services;

namespace inter.Entities
{
    class Invoice
    {
        public double BasicPayment { get; set; }
        public double Tax { get; set; }

        public Invoice(double basicPayment, double tax)
        {
            BasicPayment = basicPayment;
            Tax = tax;
        }

        public double TotalPayment
        {
            get { return BasicPayment + Tax; }
        }

        public override string ToString()
        {
            return "Basic Payment: " + BasicPayment.ToString("N2", CultureInfo.InvariantCulture) + "\nTax: " + Tax.ToString("N2", CultureInfo.InvariantCulture) + "\nTotal Payment: " + TotalPayment.ToString("N2", CultureInfo.InvariantCulture);
        }
    }
}
