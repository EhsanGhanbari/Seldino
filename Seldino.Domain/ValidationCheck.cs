using System;

namespace Seldino.Domain
{
    public sealed class ValidationCheck
    {
        public static void That(bool assertion, Action exceptionToThrow)
        {
            if (!assertion)
                exceptionToThrow.Invoke();
        }

        public static void IsNotNull(Object value, Action exceptionToThrow)
        {
            That(value != null, exceptionToThrow);
        }

        public static void ThatIsNotAnEmptyString(string value, Action exceptionToThrow)
        {
            That(!String.IsNullOrEmpty(value) && !String.IsNullOrWhiteSpace(value), exceptionToThrow);
        }

        public static void IsGreaterThan(int numberToCompare, int quantity, Action exceptionToThrow)
        {
            That(quantity >= numberToCompare, exceptionToThrow);
        }
    }
}
