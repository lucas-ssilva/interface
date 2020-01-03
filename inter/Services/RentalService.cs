using System;
using System.Collections.Generic;
using System.Text;
using inter.Entities;

namespace inter.Services
{
    class RentalService
    {
        public double PricePerHour { get;private set; }
        public double priceperDay { get; private set; }

        private ITaxService _taxservice;

        public RentalService(double pricePerHour, double priceperDay,ITaxService taxService)
        {
            PricePerHour = pricePerHour;
            this.priceperDay = priceperDay;
            _taxservice = taxService;
        }

        public void processInvoice(CarRental carRental)
        {
            TimeSpan duration = carRental.Finish.Subtract(carRental.Start);

            double basicpayment = 0;
            if(duration.TotalHours <= 12.0)
            {
                basicpayment = PricePerHour * Math.Ceiling(duration.TotalHours);
            }
            else
            {
                basicpayment = priceperDay * Math.Ceiling(duration.TotalDays); // math ceiling arredonda pra cima 
            }
            double tax = _taxservice.Tax(basicpayment);

            carRental.Invoice = new Invoice(basicpayment, tax);
        }
    }
}
