using System;
namespace IntranetApi.CoreObjects.DTOs
{
	public class CheckBookUser
	{
		public string? Name { get; set; }
        public string? AccountNumber { get; set; }
        public string? Oderdate { get; set; }
        public string? BranchCode { get; set; }
        public string? BranchName { get; set; }
        public string? BranchAddress { get; set; }
        public string? NumberOfleaves { get; set; }
        public string? DeliveryBranch { get; set; }
        public string? SortCode { get; set; }
        public string? Currency { get; set; }
        public string? RangeStart { get; set; }
        public string? RangeEnd { get; set; }
        public string? CheckType { get; set; }
        public string? ShemeCode { get; set; }
    }
}

