using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.RegularExpressions;

namespace WebApplication.Entities
{
    public class CreditCard
    {
        private string ProtectedCreditCardNumber;

        [Display(Name = "Número do Cartão de Crédito")]
        [Required(ErrorMessage = "Obrigatório informar {0}.")]
        public string CreditCardNumber
        {
            get
            {
                return ProtectedCreditCardNumber;
            }

            set
            {
                Regex obj = new Regex(@"[^\d]");
                ProtectedCreditCardNumber = obj.Replace(value, "");
            }
        }

        public CreditCard()
        {
            CreditCardNumber = string.Empty;
        }

        public CreditCard(string value)
        {
            CreditCardNumber = value;
        }

        public string CardType
        {
            get
            {
                switch (CreditCardNumber.Length)
                {
                    case 13:
                        if (CreditCardNumber.Substring(0, 1) == "4")
                            return "Visa";
                        break;
                    case 15:
                        if (CreditCardNumber.Substring(0, 2) == "31" || CreditCardNumber.Substring(0, 2) == "37")
                            return "AMEX";
                        break;
                    case 16:
                        if (CreditCardNumber.Substring(0, 1) == "4")
                            return "Visa";
                        if (CreditCardNumber.Substring(0, 4) == "6011")
                            return "Discover";
                        if (CreditCardNumber.Substring(0, 2) == "51" || CreditCardNumber.Substring(0, 2) == "55")
                            return "MasterCard";
                        break;
                    default:
                        break;
                }

                return "Desconhecido";
            }
        }

        public bool isValid
        {
            get
            {
                bool doubleDigit = true;
                int digit = 0;
                int sum = (int)Char.GetNumericValue(CreditCardNumber.LastOrDefault());

                foreach (char c in CreditCardNumber.Reverse().Skip(1))
                {
                    digit = (int)Char.GetNumericValue(c);

                    if (doubleDigit)
                        digit = digit * 2;

                    if (digit > 9)
                        digit -= 9;

                    sum += digit;

                    doubleDigit = !doubleDigit;
                }

                return sum % 10 == 0 ? true : false;
            }
        }
    }
}