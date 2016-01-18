using NUnit.Framework;
using BookList.Core.Validators;
using FluentValidation.TestHelper;
using System.Drawing;

namespace BookList.Core.Tests
{
    [TestFixture]
    public class BookValidatorValidatorTest : ValidatorTestBase
    {
        private BookValidator bookValidator;

        [SetUp]
        public void Setup()
        {
            bookValidator = new BookValidator();
        }

        [Test]
        public void Should_HaveError_When_TitleIsNull()
        {
            bookValidator.ShouldHaveValidationErrorFor(book => book.Title, null as string);
        }

        [Test]
        public void Should_HaveError_When_TitleIsEmpty()
        {
            bookValidator.ShouldHaveValidationErrorFor(book => book.Title, string.Empty);
        }

        [Test]
        public void Should_HaveError_When_TitleIsLongerThan30Chars()
        {
            bookValidator.ShouldHaveValidationErrorFor(book => book.Title, CreateStringWithLength(31));
        }

        [Test]
        public void Should_NotHaveError_When_TitleIsShorterOrEqualTo30Chars()
        {
            bookValidator.ShouldNotHaveValidationErrorFor(book => book.Title, CreateStringWithLength(30));
            bookValidator.ShouldNotHaveValidationErrorFor(book => book.Title, CreateStringWithLength(7));
        }

        [Test]
        public void Should_HaveError_When_PageCountLessOrEqualToZero()
        {
            bookValidator.ShouldHaveValidationErrorFor(book => book.Pages, -1);
            bookValidator.ShouldHaveValidationErrorFor(book => book.Pages, 0);
        }

        [Test]
        public void Should_HaveError_When_PageCountGreaterThan10000()
        {
            bookValidator.ShouldHaveValidationErrorFor(book => book.Pages, 10001);
        }

        [Test]
        public void Should_NotHaveError_When_PageCountLessOrEqualTo10000()
        {
            bookValidator.ShouldNotHaveValidationErrorFor(book => book.Pages, 10000);
            bookValidator.ShouldNotHaveValidationErrorFor(book => book.Pages, 42);
        }

        [Test]
        public void Should_NotHaveError_When_PublisherNameIsNull()
        {
            bookValidator.ShouldNotHaveValidationErrorFor(book => book.Publisher, null as string);
        }

        [Test]
        public void Should_HaveError_When_PublisherNameIsEmpty()
        {
            bookValidator.ShouldHaveValidationErrorFor(book => book.Publisher, string.Empty);
        }

        [Test]
        public void Should_HaveError_When_PublisherNameIsLongerThan30Chars()
        {
            bookValidator.ShouldHaveValidationErrorFor(book => book.Publisher, CreateStringWithLength(31));
        }

        [Test]
        public void Should_NotHaveError_When_PublisherNameIsShorterOrEqualTo30Chars()
        {
            bookValidator.ShouldNotHaveValidationErrorFor(book => book.Publisher, CreateStringWithLength(30));
            bookValidator.ShouldNotHaveValidationErrorFor(book => book.Publisher, CreateStringWithLength(7));
        }

        [Test]
        public void Should_HaveError_When_PublishDatetEarlierThan1800()
        {
            bookValidator.ShouldHaveValidationErrorFor(book => book.PublishDate, 1776);
        }

        [Test]
        public void Should_NotHaveError_When_PublishDatetLaterThan1800()
        {
            bookValidator.ShouldNotHaveValidationErrorFor(book => book.PublishDate, 1996);
        }

        [Test]
        public void Should_HaveError_When_IsbnIsInvalid()
        {
            bookValidator.ShouldHaveValidationErrorFor(book => book.Isbn, "2-266-11156-9");
            bookValidator.ShouldHaveValidationErrorFor(book => book.Isbn, "0-136-09181-2");
        }

        [Test]
        public void Should_NotHaveError_When_IsbnIsValid()
        {
            bookValidator.ShouldNotHaveValidationErrorFor(book => book.Isbn, "2-266-11156-6");
            bookValidator.ShouldNotHaveValidationErrorFor(book => book.Isbn, "0-136-09181-4");
        }

        [Test]
        public void Should_NotHaveError_When_ImageNameIsNull()
        {
            bookValidator.ShouldNotHaveValidationErrorFor(book => book.Image, null as Image );
        }
    }
}
