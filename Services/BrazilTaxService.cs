namespace InterfacesEServices.Services
{
    //Essa realização da interface (QUE NÃO É HERANÇA) NÃO existe na implementação SEM interface!
    public class BrazilTaxService : ITaxService
    {
        public double Tax(double amount)
        {
            if (amount <= 100.0)
            {
                return amount * 0.2;
            }
            else
            {
                return amount * 0.15;
            }
        }
    }
}