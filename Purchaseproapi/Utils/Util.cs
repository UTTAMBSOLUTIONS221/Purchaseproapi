namespace Purchaseproapi
{
    public class Util
    {
        public static string ShareConnectionString(IConfiguration config)
        {
            return config["ConnectionStrings:DatabaseConnection"];
        }
        public static void LogError(string userName, Exception ex, bool isError = true)
        {
            try
            {
                string logDir = Path.Combine(Directory.GetCurrentDirectory(), "logs");

                //---- Create Directory if it does not exist              
                if (!Directory.Exists(logDir))
                {
                    Directory.CreateDirectory(logDir);
                }
                string logFile = Path.Combine(logDir, "ErrorLog.log");
                //--- Delete log if it more than 500Kb
                if (File.Exists(logFile))
                {
                    FileInfo fi = new FileInfo(logFile);
                    if ((fi.Length / 1000) > 500)
                        fi.Delete();
                }
                //--- Create stream writter
                StreamWriter stream = new StreamWriter(logFile, true);
                stream.WriteLine(string.Format("{0}|{1:dd-MMM-yyyy HH:mm:ss}|{2}|{3}",
                    isError ? "ERROR" : "INFOR",
                    DateTime.Now,
                    userName,
                    isError ? ex.ToString() : ex.Message));
                stream.Close();
            }
            catch (Exception e) { }
        }
    }
}
