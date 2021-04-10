using Iti.Business;
using Iti.Domain.Entities;
using Iti.Domain.Validation;
using Xunit;
using FluentAssertions;
using Iti.Domain.Interfaces;
using Iti.Infra.Data.Repositories;
using System.Diagnostics.CodeAnalysis;

namespace Iti.Tests.UnitTests
{
    [ExcludeFromCodeCoverage]
    public class ValidationPasswordTests
    {
        private readonly IPasswordValidator _passwordValidator;
        private readonly ValidationService _validationPasswordService;
        private readonly IPasswordValidationRepository _passwordValidationRepository;

        public ValidationPasswordTests()
        {
            _passwordValidator = new PasswordValidator();
            _passwordValidationRepository = new PasswordValidationRepository(_passwordValidator);
            _validationPasswordService = new ValidationService(_passwordValidationRepository);
        }

        [Theory]
        [InlineData("!1234Abcd")]
        [InlineData("Abcd.1234")]
        [InlineData("1234!abcD")]
        [InlineData("1234@abcD")]
        [InlineData("1234$abcD")]
        [InlineData("1234%abcD")]
        [InlineData("1234^abcD")]
        [InlineData("1234&abcD")]
        [InlineData("1234*abcD")]
        [InlineData("1234(abcD")]
        [InlineData("1234)abcD")]
        [InlineData("1234+abcD")]
        [InlineData("1234-abcD")]
        public void Should_Return_True_When_Valid_Password_Is_Provided(string password)
        {
            //Arrange
            EntityPassword validPassword = new EntityPassword();
            validPassword.Password = password;

            //Act
            bool result = _validationPasswordService.IsValid(validPassword);

            //Assert            
            result.Should().BeTrue();
        }

        [Fact]
        public void Should_Return_False_When_Trying_To_Submit_Null_Password()
        {
            //Arrange
            EntityPassword password = null;

            //Act
            bool result = _validationPasswordService.IsValid(password);

            //Assert            
            result.Should().BeFalse();
        }

        [Theory]
        [InlineData("00000000")]
        [InlineData("Abcd.123")]
        public void Should_Return_False_When_Trying_To_Submit_Less_Then_Nine_Characters(string password)
        {
            //Arrange
            EntityPassword passwordRequest = new EntityPassword();
            passwordRequest.Password = password;

            //Act
            bool result = _passwordValidator.IsValid(passwordRequest);

            //assert
            result.Should().BeFalse();
        }

        [Theory]
        [InlineData("Abcd.abcd")]
        [InlineData("abc.!!abc")]
        public void Should_Return_False_When_Trying_To_Submit_Password_No_Digit(string password)
        {
            //Arrange
            EntityPassword passwordRequest = new EntityPassword();
            passwordRequest.Password = password;

            //Act
            bool result = _passwordValidator.IsValid(passwordRequest);

            //assert
            result.Should().BeFalse();
        }

        [Theory]
        [InlineData("abcd.abcd")]
        [InlineData("abcd.1234")]
        public void Should_Return_False_When_Trying_To_Submit_No_Upper_Case(string password)
        {
            //Arrange
            EntityPassword passwordRequest = new EntityPassword();
            passwordRequest.Password = password;

            //Act
            bool result = _passwordValidator.IsValid(passwordRequest);

            //assert
            result.Should().BeFalse();
        }

        [Theory]
        [InlineData("ABCD.ABCD")]
        [InlineData("ABCD.1234")]
        public void Should_Return_False_When_Trying_To_Submit_No_Lower_Case(string password)
        {
            //Arrange
            EntityPassword passwordRequest = new EntityPassword();
            passwordRequest.Password = password;

            //Act
            bool result = _passwordValidator.IsValid(passwordRequest);

            //assert
            result.Should().BeFalse();
        }

        [Theory]
        [InlineData("Abcd12d35")]
        [InlineData("AbcdAbcde")]
        public void Should_Return_False_When_Trying_To_Submit_No_Special_Characters(string password)
        {
            //Arrange
            EntityPassword passwordRequest = new EntityPassword();
            passwordRequest.Password = password;

            //Act
            bool result = _passwordValidator.IsValid(passwordRequest);

            //assert
            result.Should().BeFalse();
        }

        [Theory]
        [InlineData("AAcd12356")]
        [InlineData("Abcd..123")]
        public void Should_Return_False_When_Trying_To_Submit_Password_With_Duplicated_Characters(string password)
        {
            //Arrange
            EntityPassword passwordRequest = new EntityPassword();
            passwordRequest.Password = password;

            //Act
            bool result = _passwordValidator.IsValid(passwordRequest);

            //assert
            result.Should().BeFalse();
        }
    }
}
