using System;
using System.Text.RegularExpressions;

namespace SEDOLValidation
{
    public class SedolValidator : ISedolValidator
    {
        public ISedolValidationResult ValidateSedol(string input)
        {
            SedolValidationResult sedolValidationResult = new SedolValidationResult();
            sedolValidationResult.InputString = input;
            sedolValidationResult.IsUserDefined = false;
            sedolValidationResult.IsValidSedol = false;

            if (String.IsNullOrEmpty(input) || input.Trim().Length != 7)
            {
                sedolValidationResult.ValidationDetails = SEDOLConst.ERROR_SEDOLSTRINGLENGTH;
            }
            else if (!Regex.IsMatch(input, "^[a-zA-Z0-9]*$"))
            {
                sedolValidationResult.ValidationDetails = SEDOLConst.ERROR_SEDOLSTRING;
            }
            else
            {
                var charArray = input.ToUpper().ToCharArray();
                var weightedsum = GetWeightedSum(charArray);
                int lastcharvalue = GetCharNumer(charArray[6]);
                sedolValidationResult.IsValidSedol = ((10 - (weightedsum % 10)) % 10) == (lastcharvalue % 10);
                sedolValidationResult.IsUserDefined = (charArray[0] == '9');
                if (!sedolValidationResult.IsValidSedol)
                {
                    sedolValidationResult.ValidationDetails = SEDOLConst.ERROR_SEDOLSTRINGVALIDATION;// "Checksum digit does not agree with the rest of the input";
                }
            }
            return sedolValidationResult;
        }
        private int GetWeightedSum(char[] charArray)
        {
            int sum = 0;
            for (int i = 0; i < (charArray.Length - 1); i++)
            {
                sum += GetNumberWeight(i, charArray[i]);
            }
            return sum;
        }
        private int GetNumberWeight(int index, int numbe)
        {
            index = (index % 7);
            int[] waight = { 1, 3, 1, 7, 3, 9 };
            numbe = GetCharNumer(numbe);
            return waight[index] * numbe;
        }
        private int GetCharNumer(int numbe)
        {
            if ((numbe >= 'A' && numbe <= 'Z'))
            {
                numbe = ((numbe - 64) + 9);
            }
            else if (numbe >= '0' && numbe <= '9')
            {
                numbe = (numbe - 48);
            }
            return numbe;
        }
    }
}
