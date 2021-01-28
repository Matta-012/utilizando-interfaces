using System.Globalization;

namespace InterfacesEServices.Entities
{
    public class Invoice
    {
        public double BasicPayment { get; set; }
        public double Tax { get; set; }

        public Invoice(double basicPayment, double tax)
        {
            BasicPayment = basicPayment;
            Tax = tax;
        }

        //Propriedade com cálculo
        public double TotalPayment
        {
            get { return BasicPayment + Tax; }
        }

        public override string ToString()
        {
            return "Basic payment: " + BasicPayment.ToString("F2", CultureInfo.InvariantCulture) + "\nTax: " + Tax.ToString("F2", CultureInfo.InvariantCulture) + "\nTotal payment: " + TotalPayment.ToString("F2", CultureInfo.InvariantCulture);
        }
    }
}