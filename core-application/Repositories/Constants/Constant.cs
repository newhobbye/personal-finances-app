namespace core_application.Repositories.Constants
{
    public static class Constant
    {

        public const string DatabaseFilename = "Finance.sqlite";

        public static string DatabasePath
        {
            get
            {
                var basePath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
                return Path.Combine(basePath, DatabaseFilename);
            }
        }
    }

}
