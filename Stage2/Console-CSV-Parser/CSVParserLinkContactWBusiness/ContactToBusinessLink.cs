using CsvHelper.Configuration.Attributes;

namespace CSVParserLinkContactWBusiness
{
    class ContactToBusinessLink
    {
        [Name("contact_id")]
        public int ContactId { get; set; }
        [Name("business_id")]
        public int BusinessId { get; set; }
    }
}
