using FluentValidation;
using FluentValidation.Results;
using MinimalApi.Library.Net7.Endpoints.Internal;
using MinimalApi.Library.Net7.Models;
using MinimalApi.Library.Net7.Services;

namespace MinimalApi.Library.Net7.Endpoints
{
    public class LibraryEndpoints : IEndpoints
    {
        private const string ContentType = "application/json";
        private const string Tag = "Books";
        private const string BaseRoute = "books";
        private const string Slash = "/";

        public static void AddServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton<IBookService, BookService>();
        }

        public static void DefineEndpoints(IEndpointRouteBuilder app)
        {
            var books = app.MapGroup(BaseRoute)
                .WithTags(Tag);

            books.MapPost(Slash, CreateBookAsync)
                .WithName("CreateBook")
                .Accepts<Book>(ContentType)
                .Produces<Book>(201).Produces<IEnumerable<ValidationFailure>>(400);

            books.MapGet(Slash, GetAllBooksAsync)
                .WithName("GetBooks")
                .Produces<IEnumerable<Book>>(200);

            books.MapGet($"{Slash}{{isbn}}", GetBookByIsbnAsync)
                .WithName("GetBook")
                .Produces<Book>(200).Produces(404);

            books.MapPut($"{Slash}{{isbn}}", UpdateBookAsync)
                .WithName("UpdateBook")
                .Accepts<Book>(ContentType)
                .Produces<Book>(200).Produces<IEnumerable<ValidationFailure>>(400);

            books.MapDelete($"{Slash}{{isbn}}", DeleteBookAsync)
                .WithName("DeleteBook")
                .Produces(204).Produces(404);
        }

        internal static async Task<IResult> CreateBookAsync(
            Book book, IBookService bookService, IValidator<Book> validator)
        {
            var validationResult = await validator.ValidateAsync(book);
            if (!validationResult.IsValid)
            {
                return Results.BadRequest(validationResult.Errors);
            }

            var created = await bookService.CreateAsync(book);
            if (!created)
            {
                return Results.BadRequest(new List<ValidationFailure>
                {
                    new("Isbn", "A book with this ISBN-13 already exists")
                });
            }

            return Results.Created($"/{BaseRoute}/{book.Isbn}", book);
        }

        internal static async Task<IResult> GetAllBooksAsync(
        IBookService bookService, string? searchTerm)
        {
            if (searchTerm is not null && !string.IsNullOrWhiteSpace(searchTerm))
            {
                var matchedBooks = await bookService.SearchByTitleAsync(searchTerm);
                return Results.Ok(matchedBooks);
            }

            var books = await bookService.GetAllAsync();
            return Results.Ok(books);
        }

        internal static async Task<IResult> GetBookByIsbnAsync(
            string isbn, IBookService bookService)
        {
            var book = await bookService.GetByIsbnAsync(isbn);
            return book is not null ? Results.Ok(book) : Results.NotFound();
        }

        internal static async Task<IResult> UpdateBookAsync(
            string isbn, Book book, IBookService bookService,
            IValidator<Book> validator)
        {
            book.Isbn = isbn;
            var validationResult = await validator.ValidateAsync(book);
            if (!validationResult.IsValid)
            {
                return Results.BadRequest(validationResult.Errors);
            }

            var updated = await bookService.UpdateAsync(book);
            return updated ? Results.Ok(book) : Results.NotFound();
        }

        internal static async Task<IResult> DeleteBookAsync(
            string isbn, IBookService bookService)
        {
            var deleted = await bookService.DeleteAsync(isbn);
            return deleted ? Results.NoContent() : Results.NotFound();
        }
    }
}
