namespace Shopex.Domain.Dto
{
    public class AddressResult
    {
        public List<ExpandedAddress> result { get; set; }
        public int code { get; set; }
        public string message { get; set; }
        public int limit { get; set; }
        public int page { get; set; }
        public int total { get; set; }
    }
    public class ExpandedAddress
    {
        public string postcode { get; set; }
        public string postcode_inward { get; set; }
        public string postcode_outward { get; set; }
        public string post_town { get; set; }
        public string dependant_locality { get; set; }
        public string double_dependant_locality { get; set; }
        public string thoroughfare { get; set; }
        public string dependant_thoroughfare { get; set; }
        public string building_number { get; set; }
        public string building_name { get; set; }
        public string sub_building_name { get; set; }
        public string po_box { get; set; }
        public string department_name { get; set; }
        public string organisation_name { get; set; }
        public int udprn { get; set; }
        public string postcode_type { get; set; }
        public string su_organisation_indicator { get; set; }
        public string delivery_point_suffix { get; set; }
        public string line_1 { get; set; }
        public string line_2 { get; set; }
        public string line_3 { get; set; }
        public string premise { get; set; }
        public double longitude { get; set; }
        public double latitude { get; set; }
        public int eastings { get; set; }
        public int northings { get; set; }
        public string country { get; set; }
        public string traditional_county { get; set; }
        public string administrative_county { get; set; }
        public string postal_county { get; set; }
        public string county { get; set; }
        public string district { get; set; }
        public string ward { get; set; }
        public string uprn { get; set; }
        public string id { get; set; }
        public string country_iso { get; set; }
        public string country_iso_2 { get; set; }
        public string county_code { get; set; }
        public string language { get; set; }
        public string umprn { get; set; }
        public string dataset { get; set; }
    }
}
