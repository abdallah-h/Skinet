namespace API.Errors {
    public class ApiResponse {
        public ApiResponse (int statusCode, string message = null) {
            StatusCode = statusCode;
            Message = message ?? GetDefaultMessageForStatusCode (statusCode);
        }
        public int StatusCode { get; set; }
        public string Message { get; set; }
        private string GetDefaultMessageForStatusCode (int statusCode) {
            return statusCode
            switch {
                400 => "You have made a bad request",
                    401 => "Your not authorized",
                    404 => "No resource found",
                    500 => "Server error",
                    _ => null
            };
        }
    }
}