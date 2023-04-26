namespace core_application.Models.Environment
{
    public class ConstantsInjectionModel
    {
        public string DatabaseFilename { get; set; }
        public string DatabasePath { get; set; }

        public ConstantsInjectionModel(string databaseFilename, string databasePath)
        {
            DatabaseFilename = databaseFilename;
            DatabasePath = databasePath;
        }
    }
}
