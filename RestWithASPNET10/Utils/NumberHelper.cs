namespace RestWithASPNET10.Utils
{
    public class NumberHelper
    {
        public decimal ConvertToDecimal(string number)
        {
            decimal decimalValue;
            if (decimal.TryParse(
                number,
                System.Globalization.NumberStyles.Any,
                System.Globalization.NumberFormatInfo.InvariantInfo,
                out decimalValue))
            {
                return decimalValue;
            }
            return 0;
        }

        public bool IsNumeric(string strNumber)
        {
            decimal decimalValue;
            bool isNumber = decimal.TryParse(
                strNumber,
                System.Globalization.NumberStyles.Any,
                System.Globalization.NumberFormatInfo.InvariantInfo,
                out decimalValue);
            return isNumber;
        }
    }
}
