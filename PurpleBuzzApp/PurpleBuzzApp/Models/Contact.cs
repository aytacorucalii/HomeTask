namespace PurpleBuzzApp.Models;

public class Contact
{

    public int Id { get; set; }
    public string MediaContact { get; set; }
    public string MediaName {get; set; }
    public int MediaNumber { get; set; }
    public string TechnicalContact { get; set; }
    public string TechnicalName { get; set; }
    public int TechnicalNumber { get; set; }
    public string BillingContact { get; set; }
    public string BillingName { get; set; }
    public int BillingNumber { get; set; }
}
