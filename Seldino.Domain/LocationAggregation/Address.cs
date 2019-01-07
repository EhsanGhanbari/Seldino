using Seldino.Infrastructure.Domain;

namespace Seldino.Domain.LocationAggregation
{
    public class Address : EntityBase
    {
        public Address()
        {
        }

        public Address(string line, string city, string zipCode)
        {
            ValidationCheck.ThatIsNotAnEmptyString(line, () => { throw new InvalidAddressException("An address must have a street"); });
            ValidationCheck.ThatIsNotAnEmptyString(city, () => { throw new InvalidAddressException("An address must have a city"); });
            ValidationCheck.ThatIsNotAnEmptyString(zipCode, () => { throw new InvalidAddressException("An address must have a zip code."); });

            AddressLine = line;
            City = city;
            ZipCode = zipCode;
        }

        public string AddressLine { get; private set; }
        public string City { get; private set; }
        public string ZipCode { get; private set; }

        protected override void Validate()
        {
            throw new System.NotImplementedException();
        }
    }
}
