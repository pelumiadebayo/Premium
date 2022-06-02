using System;
namespace IntranetApi.CoreObjects.Models
{
	public class PosRequest:BaseClass
	{
        public string? NameOfmerchant { get; set; }
        public string? RCNumber { get; set; }
        public string? TradingName { get; set; }
        public string? TradingAddress { get; set; }
        public Enum? BusinessSegment { get; set; }
        public string? PrimaryContactName { get; set; }
        public string? SecondaryContactName { get; set; }
        public string? PrimaryContactDesignation { get; set; }
        public string? SecondaryContactDesignation { get; set; }
        public string? PrimaryContactMobileNumber { get; set; }
        public string? SecondaryContactMobileNumber { get; set; }
        public string? PrimaryContactEmail { get; set; }
        public string? SecondaryContactEmail { get; set; }
        public string? ProductDescription { get; set; }
        public int? POSTerminalQuantity { get; set; }
        public ICollection<ContactPerson>? ContactPerson { get; set; }
        public string? AccountName { get; set; }
        public string? AccountNumber { get; set; }
        public string? AccountType { get; set; }
        public string? EmailAddress { get; set; }
        public bool AllowEmailNotification { get; set; }
        public string? Signature { get; set; }
    }

    public class ContactPerson
    {
        public string? LocationOfTerminal { get; set; }
        public string? ContactPersonForTerminal { get; set; }
        public string? ContactPersonPhoneNumber { get; set; }
    } 
}

