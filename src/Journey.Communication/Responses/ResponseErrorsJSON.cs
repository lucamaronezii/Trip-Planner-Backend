namespace Journey.Communication.Responses
{
    public class ResponseErrorsJSON
    {
        public IList<string> Errors { get; set; } = [];

        public ResponseErrorsJSON(IList<string> errors)
        {
            Errors = new List<string>(errors);
        }
    }
}
