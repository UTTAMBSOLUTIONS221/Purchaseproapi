namespace MPesaAPI.Utils
{
    public class Util
    {
        public static void LogRequest(string logFile, string method, string message)
        {
            if (string.IsNullOrEmpty(logFile))
                return;

            Task.Run(() =>
            {
                try
                {
                    //--- Create stream writter
                    StreamWriter stream = new StreamWriter(logFile, true);
                    stream.WriteLine(string.Format("INFOR|{0:dd-MMM-yyyy HH:mm:ss}|{1}|{2}",
                        DateTime.Now,
                        method,
                        message));
                    stream.Close();
                }
                catch (Exception e) { }

            });
        }
    }
}
