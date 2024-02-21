namespace MatchManagementApiDemo.Models.DTO.APIResponseDTO
{
    /// <summary>
    /// Represents a standardized API response containing information about the success of an operation,
    /// the associated data, and an optional error message.
    /// </summary>
    /// <typeparam name="T">The type of data to be included in the API response.</typeparam>
    public class ApiResponse<T>
    {
        /// <summary>
        /// Gets or sets a value indicating whether the API operation was successful.
        /// </summary>
        public bool Success { get; set; }

        /// <summary>
        /// Gets or sets the data associated with the API response.
        /// </summary>
        public T Data { get; set; }

        /// <summary>
        /// Gets or sets the error message in case the API operation was not successful.
        /// </summary>
        public string ErrorMessage { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="ApiResponse{T}"/> class with a default success status.
        /// </summary>
        public ApiResponse()
        {
            Success = true;
        }

        /// <summary>
        /// Creates a new instance of <see cref="ApiResponse{T}"/> representing a successful API response.
        /// </summary>
        /// <param name="data">The data to include in the API response.</param>
        /// <returns>An instance of <see cref="ApiResponse{T}"/> with the specified data.</returns>
        public static ApiResponse<T> SuccessResponse(T data)
        {
            return new ApiResponse<T>
            {
                Data = data
            };
        }

        /// <summary>
        /// Creates a new instance of <see cref="ApiResponse{T}"/> representing an unsuccessful API response with an error message.
        /// </summary>
        /// <param name="errorMessage">The error message to include in the API response.</param>
        /// <returns>An instance of <see cref="ApiResponse{T}"/> with the specified error message and a failure status.</returns>
        public static ApiResponse<T> ErrorResponse(string errorMessage)
        {
            return new ApiResponse<T>
            {
                Success = false,
                ErrorMessage = errorMessage
            };
        }
    }
}
