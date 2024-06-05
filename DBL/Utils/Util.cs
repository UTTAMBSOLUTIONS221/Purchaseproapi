using PhoneNumbers;

namespace DBL
{
    public class Util
    {
        public static string FormatPhoneNo(string phoneNo, string zipCode)
        {
            PhoneNumber phoneNumber = null;
            PhoneNumberUtil phoneNumberUtil = PhoneNumberUtil.GetInstance();
            string finalNumber = "";
            zipCode = zipCode.Replace("+", "");
            string isoCode = phoneNumberUtil.GetRegionCodeForCountryCode(Convert.ToInt32(zipCode));
            bool isValid = false;
            PhoneNumberType isMobile = PhoneNumberType.MOBILE;
            try
            {
                phoneNumber = phoneNumberUtil.Parse(phoneNo, isoCode);
                isValid = phoneNumberUtil.IsValidNumber(phoneNumber);
                isMobile = phoneNumberUtil.GetNumberType(phoneNumber);

            }
            catch (NumberParseException e)
            {

            }
            catch (Exception e)
            {
                //e.printStackTrace();
            }

            if (isValid && (PhoneNumberType.MOBILE == isMobile ||
                    PhoneNumberType.FIXED_LINE_OR_MOBILE == isMobile))
            {
                finalNumber = phoneNumberUtil.Format(phoneNumber, PhoneNumberFormat.E164);//.substring(1);
            }

            return finalNumber;

        }
        public static void LogError(string logFile, string userName, Exception ex, bool isError = true)
        {
            try
            {
                if (string.IsNullOrEmpty(logFile))
                    return;

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
