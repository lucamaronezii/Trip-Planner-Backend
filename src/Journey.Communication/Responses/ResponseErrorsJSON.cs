namespace Journey.Communication.Responses
{
    public class ResponseErrorsJson
    {
        public IList<string> Errors { get; set; } = [];

        public ResponseErrorsJson(IList<string> errors)
        {
            Errors = new List<string>(errors);
        }
    }
}
