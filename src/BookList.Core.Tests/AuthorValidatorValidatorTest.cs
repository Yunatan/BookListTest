using NUnit.Framework;
using BookList.Core.Validators;
using FluentValidation.TestHelper;

namespace BookList.Core.Tests
{
    [TestFixture]
    public class AuthorValidatorValidatorTest : ValidatorTestBase
    {
        private AuthorValidator authorValidator;

        [SetUp]
        public void Setup()
        {
            authorValidator = new AuthorValidator();
        }

        [Test]
        public void Should_HaveError_When_FirstNameIsNull()
        {
            authorValidator.ShouldHaveValidationErrorFor(author => author.FirstName, null as string);
        }

        [Test]
        public void Should_HaveError_When_FirstNameIsEmpty()
        {
            authorValidator.ShouldHaveValidationErrorFor(author => author.FirstName, string.Empty);
        }

        [Test]
        public void Should_HaveError_When_FirstNameIsLongerThan20Chars()
        {
            authorValidator.ShouldHaveValidationErrorFor(author => author.FirstName, CreateStringWithLength(21));
        }

        [Test]
        public void Should_NotHaveError_When_FirstNameIsShorterOrEqualTo20Chars()
        {
            authorValidator.ShouldNotHaveValidationErrorFor(author => author.FirstName, CreateStringWithLength(20));
            authorValidator.ShouldNotHaveValidationErrorFor(author => author.FirstName, CreateStringWithLength(7));
        }

        [Test]
        public void Should_HaveError_When_LastNameIsNull()
        {
            authorValidator.ShouldHaveValidationErrorFor(author => author.LastName, null as string);
        }

        [Test]
        public void Should_HaveError_When_LastNameIsEmpty()
        {
            authorValidator.ShouldHaveValidationErrorFor(author => author.LastName, string.Empty);
        }

        [Test]
        public void Should_HaveError_When_LastNameIsLongerThan20Chars()
        {
            authorValidator.ShouldHaveValidationErrorFor(author => author.LastName, CreateStringWithLength(21));
        }

        [Test]
        public void Should_NotHaveError_When_LastNameIsShorterOrEqualTo20Chars()
        {
            authorValidator.ShouldNotHaveValidationErrorFor(author => author.LastName, CreateStringWithLength(20));
            authorValidator.ShouldNotHaveValidationErrorFor(author => author.LastName, CreateStringWithLength(7));
        }
    }
}
