using Xunit;

namespace SEDOLValidation.Test
{
    public class SEDOLValidationTest
    {
        #region Null, empty string or string other than 7 characters long
        [Fact]
        public void StringEmpty_SEDOL()
        {
            // Arrange
            var sedolValidator = new SedolValidator();
            string expected = "";
            string expectedDetails = "Input string was not 7-characters long";
            // Act
            var result = sedolValidator.ValidateSedol("");
            Assert.False(result.IsUserDefined);
            Assert.False(result.IsValidSedol);
            Assert.Equal(result.InputString, expected);
            Assert.Equal(result.ValidationDetails, expectedDetails);
        }
        [Fact]
        public void StringLessThanSeven_SEDOL()
        {
            // Arrange
            var sedolValidator = new SedolValidator();
            string expected = "12";
            string expectedDetails = "Input string was not 7-characters long";
            // Act
            var result = sedolValidator.ValidateSedol("12");
            Assert.False(result.IsUserDefined);
            Assert.False(result.IsValidSedol);
            Assert.Equal(result.InputString, expected);
            Assert.Equal(result.ValidationDetails, expectedDetails);
        }
        [Fact]
        public void StringNull_SEDOL()
        {
            // Arrange
            var sedolValidator = new SedolValidator();
            string expected = null;
            string expectedDetails = "Input string was not 7-characters long";
            // Act
            var result = sedolValidator.ValidateSedol(null);
            Assert.False(result.IsUserDefined);
            Assert.False(result.IsValidSedol);
            Assert.Equal(result.InputString, expected);
            Assert.Equal(result.ValidationDetails, expectedDetails);
        }
        [Fact]
        public void StringGreterThanSeven_SEDOL()
        {
            // Arrange
            var sedolValidator = new SedolValidator();
            string expected = null;
            string expectedDetails = "Input string was not 7-characters long";
            // Act
            var result = sedolValidator.ValidateSedol(null);
            Assert.False(result.IsUserDefined);
            Assert.False(result.IsValidSedol);
            Assert.Equal(result.InputString, expected);
            Assert.Equal(result.ValidationDetails, expectedDetails);
        }
        #endregion

        #region Invalid Checksum non user defined SEDOL
        [Fact]
        public void InvalidChecksum_SEDOL()
        {
            // Arrange
            var sedolValidator = new SedolValidator();
            string expected = "1234567";
            string expectedDetails = "Checksum digit does not agree with the rest of the input";
            // Act
            var result = sedolValidator.ValidateSedol("1234567");
            Assert.False(result.IsUserDefined);
            Assert.False(result.IsValidSedol);
            Assert.Equal(result.InputString, expected);
            Assert.Equal(result.ValidationDetails, expectedDetails);
        }
        #endregion

        #region Valid non user define SEDOL
        [Fact]
        public void ValidNonUserNumericChecksum_SEDOL()
        {
            // Arrange
            var sedolValidator = new SedolValidator();
            string expected = "0709954";
            string expectedDetails = null;
            // Act
            var result = sedolValidator.ValidateSedol("0709954");
            Assert.False(result.IsUserDefined);
            Assert.True(result.IsValidSedol);
            Assert.Equal(result.InputString, expected);
            Assert.Equal(result.ValidationDetails, expectedDetails);
        }
        [Fact]
        public void ValidNonUserAlphaNumericChecksum_SEDOL()
        {
            // Arrange
            var sedolValidator = new SedolValidator();
            string expected = "B0YBKJ7";
            string expectedDetails = null;
            // Act
            var result = sedolValidator.ValidateSedol("B0YBKJ7");
            Assert.False(result.IsUserDefined);
            Assert.True(result.IsValidSedol);
            Assert.Equal(result.InputString, expected);
            Assert.Equal(result.ValidationDetails, expectedDetails);
        }
        #endregion

        #region InValid user define SEDOL
        [Fact]
        public void InValidUserDefineNumericChecksum_SEDOL()
        {
            // Arrange
            var sedolValidator = new SedolValidator();
            string expected = "9123451";
            string expectedDetails = "Checksum digit does not agree with the rest of the input";
            // Act
            var result = sedolValidator.ValidateSedol("9123451");
            Assert.True(result.IsUserDefined);
            Assert.False(result.IsValidSedol);
            Assert.Equal(result.InputString, expected);
            Assert.Equal(result.ValidationDetails, expectedDetails);
        }
        [Fact]
        public void InValidUserDefineAlphaNumericChecksum_SEDOL()
        {
            // Arrange
            var sedolValidator = new SedolValidator();
            string expected = "9ABCDE8";
            string expectedDetails = "Checksum digit does not agree with the rest of the input";
            // Act
            var result = sedolValidator.ValidateSedol("9ABCDE8");
            Assert.True(result.IsUserDefined);
            Assert.False(result.IsValidSedol);
            Assert.Equal(result.InputString, expected);
            Assert.Equal(result.ValidationDetails, expectedDetails);
        }
        #endregion

        #region Invaid characters found
        [Fact]
        public void InvalidcharactersNumericChecksum_SEDOL()
        {
            // Arrange
            var sedolValidator = new SedolValidator();
            string expected = "9123_51";
            string expectedDetails = "SEDOL contains invalid characters";
            // Act
            var result = sedolValidator.ValidateSedol("9123_51");
            Assert.False(result.IsUserDefined);
            Assert.False(result.IsValidSedol);
            Assert.Equal(result.InputString, expected);
            Assert.Equal(result.ValidationDetails, expectedDetails);
        }
        [Fact]
        public void InvalidcharactersAlphaNumericChecksum_SEDOL()
        {
            // Arrange
            var sedolValidator = new SedolValidator();
            string expected = "VA.CDE8";
            string expectedDetails = "SEDOL contains invalid characters";
            // Act
            var result = sedolValidator.ValidateSedol("VA.CDE8");
            Assert.False(result.IsUserDefined);
            Assert.False(result.IsValidSedol);
            Assert.Equal(result.InputString, expected);
            Assert.Equal(result.ValidationDetails, expectedDetails);
        }
        #endregion

        #region Valid User define SEDOL
        [Fact]
        public void ValidUserDefineNumericChecksum_SEDOL()
        {
            // Arrange
            var sedolValidator = new SedolValidator();
            string expected = "9123458";
            string expectedDetails = null;
            // Act
            var result = sedolValidator.ValidateSedol("9123458");
            Assert.True(result.IsUserDefined);
            Assert.True(result.IsValidSedol);
            Assert.Equal(result.InputString, expected);
            Assert.Equal(result.ValidationDetails, expectedDetails);
        }
        [Fact]
        public void ValidUserDefineAlphaNumericChecksum_SEDOL()
        {
            // Arrange
            var sedolValidator = new SedolValidator();
            string expected = "9ABCDE1";
            string expectedDetails = null;
            // Act
            var result = sedolValidator.ValidateSedol("9ABCDE1");
            Assert.True(result.IsUserDefined);
            Assert.True(result.IsValidSedol);
            Assert.Equal(result.InputString, expected);
            Assert.Equal(result.ValidationDetails, expectedDetails);
        }
        #endregion
    }
}
