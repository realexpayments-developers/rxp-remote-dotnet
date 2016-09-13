using System;
using System.Linq;
using System.Globalization;
using System.Text.RegularExpressions;
using RealexPayments.Remote.SDK.Domain;

namespace RealexPayments.Remote.SDK.Utils {
    internal static class Luhn {
        public static bool LuhnCheck(this string cardNumber) {
            return LuhnCheck(cardNumber.Select(c => c - '0').ToArray());
        }

        private static bool LuhnCheck(this int[] digits) {
            return GetCheckValue(digits) == 0;
        }

        private static int GetCheckValue(int[] digits) {
            return digits.Select((d, i) => i % 2 == digits.Length % 2 ? ((2 * d) % 10) + d / 5 : d).Sum() % 10;
        }
    }

    public class CardValidationUtils {
        private const string EXPIRY_DATE_PATTERN = "MMyy";
        private const string EXP_DATE_REG_EXP = "[0-9]{4}";

        /**
         * Method to perform a Luhn check on the card number.  This allows the SDK user to perform  
         * basic validation on the card number. The card number may contain whitespace or '-' which will 
         * be stripped before validation.
         * 
         * @param cardNumber
         * 
         * @return true if a valid card number and false otherwise
         */
        public static bool PerformLuhnCheck(string cardNumber) {
            if (string.IsNullOrEmpty(cardNumber)) {
                return false;
            }

            /** If string has alpha characters it is not a valid credit card **/
            if (new Regex("[^0-9]").IsMatch(cardNumber)) {
                return false;
            }

            /** Check Length of credit card is valid (between 12 and 19 digits) **/
            int Length = cardNumber.Length;
            if (Length < 12 || Length > 19) {
                return false;
            }

            /** Perform luhn check **/
            return Luhn.LuhnCheck(cardNumber);
        }

        /**
         * Method to perform an expiry date check.  This allows the SDK user to perform basic validation 
         * on the card number. The expiry date may contain whitespace, '-' or '/' separators, should be 
         * two digits for the month followed by two digits for the year and may not be in the past.
         * 
         * @param expiryDate
         * 
         * @return true if a valid expiry date and false otherwise
         */
        public static bool PerformExpiryDateCheck(string expiryDate) {

            //DateFormat df = new SimpleDateFormat(EXPIRY_DATE_PATTERN);
            //df.setLenient(false);

            //Length should be four digits long
            if (!new Regex(EXP_DATE_REG_EXP).IsMatch(expiryDate)) {
                return false;
            }

            //Expiry date matches the pattern
            DateTime currentCal = DateTime.Now;
            DateTime expiryDateCal;
            if(!DateTime.TryParseExact(expiryDate, EXPIRY_DATE_PATTERN, null, DateTimeStyles.None, out expiryDateCal)) {
                return false;
            }

            // Date is not in the past
            if (expiryDateCal.Year < currentCal.Year) {
                return false;
            }

            if ((expiryDateCal.Month < currentCal.Month) && (expiryDateCal.Year == currentCal.Year)) {
                return false;
            }
            return true;
        }

        /**
         * Method to perform a CVV number check.  The CVV must be 4 digits for AMEX and 3 digits for 
         * all other cards.
         * 
         * @param cvvNumber
         * @param cardType
         * 
         * @return true if a valid CVV number and false otherwise
         */
        public static bool PerformCvvCheck(string cvvNumber, string cardType) {

            /* If string has alpha characters it is not a CVV number */
            if (new Regex("[^0-9]").IsMatch(cvvNumber)) {
                return false;
            }

            /* Length should be four digits long for AMEX */
            if (cardType.Equals(CardType.AMEX, StringComparison.InvariantCultureIgnoreCase)) {
                if (cvvNumber.Length != 4) {
                    return false;
                }
            }
            /* Otherwise the Length should be three digits */
            else if (cvvNumber.Length != 3) {
                return false;
            }

            return true;
        }
    }
}
