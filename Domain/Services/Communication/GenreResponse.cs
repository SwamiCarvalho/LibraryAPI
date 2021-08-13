using LibraryAPI.Domain.Models;

namespace Supermarket.API.Domain.Services.Communication
{
    public class GenreResponse : BaseResponse
    {
        public Genre Genre { get; private set; }

        private GenreResponse(bool success, string message, Genre genre) : base(success, message)
        {
            Genre = genre;
        }

        /// <summary>
        /// Creates a success response.
        /// </summary>
        /// <param name="genre">Saved category.</param>
        /// <returns>Response.</returns>
        public GenreResponse(Genre genre) : this(true, string.Empty, genre)
        { }

        /// <summary>
        /// Creates am error response.
        /// </summary>
        /// <param name="message">Error message.</param>
        /// <returns>Response.</returns>
        public GenreResponse(string message) : this(false, message, null)
        { }
    }
}