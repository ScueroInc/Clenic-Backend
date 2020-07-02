namespace MyE.Business.Component.Helpers
{
    public static class ConfigurationBC
    {
        public const string SQL_CONNECTION_STRING = "server=bitperfect.dev;database=Babel_Dev;uid=adminbp;pwd=1adminbp1";

        //public const string FILE_BASE_PATH = @"C:\Babel\Upload";
        public const string FILE_BASE_PATH = "";

        public const string RECAPTCHA_KEY_WEB = "6Le6JsIUAAAAAIs8BiAuhzAmC8bn82GhDsBbfVh4";
        public const string RECAPTCHA_KEY_SECRET = "6Le6JsIUAAAAABH7SUaf1q4mO1CdvgO0D8dMxo45";

        public const double RECAPTCHA_SCORE_THRESHOLD = 0.8D;

        public const string ARCHIVO_EXTENSIONES_PERMITIDAS = "bmp gif jpeg jpg tif tiff png";
        public const int MAX_FILE_SIZE = 5 * 1024 * 1024;

        public const int MAX_ELEMENTS_PER_PAGE = 10;

        public const string AES_IV = "cV%w7AQuIGcpzS0W";
        public const string AES_KEY = "XfCVy*f#^gB$JM7ep@5h}gwD#P{I7A^!";

        public const string API_TOKEN_HEADER = "X-MyE-TOKEN";
    }
}