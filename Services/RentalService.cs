using System;
using InterfacesEServices.Entities;

namespace InterfacesEServices.Services
{
    public class RentalService
    {
        public double PricePerHour { get; private set; }
        public double PricePerDay { get; private set; }
        /*Implementação sem o uso de INTERFACE, não está correta!
        private BrazilTaxService _brazilTaxService = new BrazilTaxService();
        */
        private ITaxService _taxService;

        //Este construtor NÃO possui o parâmetro ITaxService taxService na implementação SEM interface!
        public RentalService(double pricePerHour, double pricePerDay, ITaxService taxService)
        {
            //Implementação SEM interface.
            PricePerHour = pricePerHour;
            PricePerDay = pricePerDay;
            //Implementação COM interface!
            _taxService = taxService;
        }

        public void ProcessInvoice(CarRental carRental)
        {
            TimeSpan duration = carRental.Finish.Subtract(carRental.Start);

            double basicPayment = 0.0;
            if (duration.TotalHours <= 12.0)
            {
                basicPayment = PricePerHour * Math.Ceiling(duration.TotalHours);
            }
            else
            {
                basicPayment = PricePerDay * Math.Ceiling(duration.TotalDays);
            }

            /* Implementação SEM interface!
            double tax = _brazilTaxService.Tax(basicPayment);
            */
            //Implementação COM interface!
            double tax = _taxService.Tax(basicPayment);

            carRental.Invoice = new Invoice(basicPayment, tax);
        }
    }
}