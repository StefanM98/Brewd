namespace Public.GetBreweryList
{
    public class Request
    {
        public string BreweryType { get; set; }
        public string PostalCode { get; set; }
        public string City { get; set; }
    }

    public class Validator : Validator<Request>
    {
        public Validator()
        {

        }
    }

    public class Response
    {
        public string Message { get; set; }
    }
}