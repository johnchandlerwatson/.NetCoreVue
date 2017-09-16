namespace Vue.Domain
{
    public abstract class Tax 
    {
        public string Name { get; set; }
        public double Percent { get; set; }
    }

    public class FederalTax : Tax
    {

    }

    public class StateTax : Tax
    {
        public string StateAbbr { get; set; }
    }
}