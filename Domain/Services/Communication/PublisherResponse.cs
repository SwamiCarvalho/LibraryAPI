using LibraryAPI.Domain.Models;

namespace Supermarket.API.Domain.Services.Communication
{
    public class PublisherResponse : BaseResponse
    {
        public Publisher Publisher { get; private set; }

        private PublisherResponse(bool success, string message, Publisher publisher) : base(success, message)
        {
            Publisher = publisher;
        }

        /// <summary>
        /// Creates a success response.
        /// </summary>
        /// <param name="publisher">Saved category.</param>
        /// <returns>Response.</returns>
        public PublisherResponse(Publisher publisher) : this(true, string.Empty, publisher)
        { }

        /// <summary>
        /// Creates am error response.
        /// </summary>
        /// <param name="message">Error message.</param>
        /// <returns>Response.</returns>
        public PublisherResponse(string message) : this(false, message, null)
        { }
    }
}