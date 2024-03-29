﻿using FluentValidation;
using MinimalApi.Library.Net7.Models;

namespace MinimalApi.Library.Net7.Validators
{
    public class BookValidator : AbstractValidator<Book>
    {
        public BookValidator()
        {
            RuleFor(book => book.Isbn)
                .Matches(@"^(?=(?:\D*\d){10}(?:(?:\D*\d){3})?$)[\d-]+$")
                .WithMessage("Value was not a valid ISBN-13");

            RuleFor(book => book.Title).NotEmpty();
            RuleFor(book => book.Author).NotEmpty();
            RuleFor(book => book.ShortDescription).NotEmpty();
            RuleFor(book => book.PageCount).GreaterThan(0);
        }
    }
}
