namespace Seldino.Infrastructure.Domain
{
    /// <summary>
    /// To check the validity of domain entity prior to persistence
    /// </summary>
    public class BusinessRule
    {
        private string _property;
        private string _rule;

        public BusinessRule(string property, string rule)
        {
            _property = property;
            _rule = rule;
        }
        public string Property
        {
            get { return _property; }
            set { _property = value; }
        }
        public string Rule
        {
            get { return _rule; }
            set { _rule = value; }
        }
    }
}
