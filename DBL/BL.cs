using DBL.Entities;
using DBL.Helpers;
using DBL.Models;
using DBL.Mpesamodels;
using DBL.UOW;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Mpesa;
using MPesaAPI;
using MPesaAPI.Enums;
using MPesaAPI.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.Json.Nodes;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace DBL
{
    public class BL
    {
        private UnitOfWork db;
        private string _connString;
        static bool mailSent = false;
        Encryptdecrypt sec = new Encryptdecrypt();
        Stringgenerator str = new Stringgenerator();
        EmailSenderHelper emlsnd = new EmailSenderHelper();
        IConfiguration _config;
        public string LogFile { get; set; }
        public BL(string connString, IConfiguration config)
        {
            this._connString = connString;
            db = new UnitOfWork(connString);
            _config = config;
        }

        #region Verify and Validate And Manage System Staff
        public Task<IEnumerable<SystemStaffModel>> Getsystemstaffsdata(long TenantId)
        {
            return Task.Run(() =>
            {
                var Resp = db.SecurityRepository.Getsystemstaffsdata(TenantId);
                return Resp;
            });
        }
        public Task<Genericmodel> Registersystemtaff(Systemstaffs Obj)
        {
            return Task.Run(() =>
            {
                string passwordraw = str.RandomString(8);
                string PassHash = str.RandomString(12);
                Obj.Passwords = sec.Encrypt(passwordraw, PassHash);
                Obj.Passwordharsh = PassHash;
                var Resp = db.SecurityRepository.Registersystemtaff(JsonConvert.SerializeObject(Obj));
                if (Resp.RespStatus == 0)
                {
                    string EmailBody = "Dear " + Resp.Data3 + " , <br> Your username is: " + Resp.Data4 + " and your one time password is: " + sec.Decrypt(Resp.Data5, Resp.Data6) + "<br>. Kindly Login and set your preferred Password";
                    bool data = emlsnd.UttambsolutionssendemailAsync(Resp.Data4, Resp.Data3, "Shop and Staff Registration", EmailBody);
                }
                return Resp;
            });
        }
        public Task<Systemstaffs> Getsystemstaffdatabyid(long StaffId)
        {
            return Task.Run(() =>
            {
                var Resp = db.SecurityRepository.Getsystemstaffdatabyid(StaffId);
                return Resp;
            });
        }
        public Task<Genericmodel> Resendstaffpassword(long StaffId)
        {
            return Task.Run(() =>
            {
                var Resp = db.SecurityRepository.Getsystemstaffdatabyid(StaffId);
                Genericmodel model = new Genericmodel();
                if (Resp.Staffid > 0)
                {
                    string EmailBody = "Dear " + Resp.Firstname + " , <br> Your username is: " + Resp.Emailaddress + " and your one time password is: " + sec.Decrypt(Resp.Passwords, Resp.Passwordharsh) + ". <br> Kindly Login and set your preferred Password";
                    bool response = emlsnd.UttambsolutionssendemailAsync(Resp.Emailaddress, Resp.Firstname, "Resend Staff Password", EmailBody);
                    if (response)
                    {
                        model.RespStatus = 0;
                        model.RespMessage = "Email sent to " + Resp.Emailaddress;
                    }
                    else
                    {
                        model.RespStatus = 1;
                        model.RespMessage = "Email not sent. Kind contact admin to help!";
                    }
                }
                return model;
            });
        }
        public Task<UsermodelResponce> ValidateSystemStaff(string userName, string password)
        {
            return Task.Run(async () =>
            {
                UsermodelResponce userModel = new UsermodelResponce { };
                var resp = db.SecurityRepository.VerifySystemStaff(userName);
                if (resp.RespStatus == 0)
                {
                    Encryptdecrypt sec = new Encryptdecrypt();
                    string descpass = sec.Decrypt(resp.Usermodel.Passwords, resp.Usermodel.Passharsh);
                    if (password == descpass)
                    {

                        userModel.RespStatus = 200;
                        userModel.RespMessage = "";

                        var claims = new[] {
                        new Claim(JwtRegisteredClaimNames.Sub, _config["Jwt:Subject"]),
                        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                        new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),
                        new Claim("UserId", resp.Usermodel.Staffid.ToString()),
                    };
                        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
                        var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
                        var token = new JwtSecurityToken(_config["Jwt:Issuer"], _config["Jwt:Audience"], claims, expires: DateTime.UtcNow.AddMinutes(30), signingCredentials: signIn);
                        userModel = new UsermodelResponce
                        {
                            RespStatus = 200,
                            RespMessage = "Ok",
                            Token = new JwtSecurityTokenHandler().WriteToken(token),
                            Usermodel = resp.Usermodel
                        };
                        return userModel;
                    }
                    else
                    {
                        userModel = new UsermodelResponce
                        {
                            RespStatus = 401,
                            RespMessage = "Incorrect Password!",
                            Token = "",
                            Usermodel = new UsermodeldataResponce()
                        };
                    }
                }
                else
                {
                    userModel = new UsermodelResponce
                    {
                        RespStatus = 401,
                        RespMessage = resp.RespMessage,
                        Token = "",
                        Usermodel = new UsermodeldataResponce()
                    };
                }
                return userModel;
            });
        }
        public Task<Genericmodel> Resetuserpasswordpost(Staffresetpassword JsonObj)
        {
            return Task.Run(() =>
            {
                string EncryptionKey = str.RandomString(12);
                string Encryptedpassword = sec.Encrypt(JsonObj.Passwords, EncryptionKey);
                JsonObj.Passwords = Encryptedpassword;
                JsonObj.Passwordhash = EncryptionKey;
                var Resp = db.SecurityRepository.Resetuserpasswordpost(JsonConvert.SerializeObject(JsonObj));
                return Resp;
            });
        }
        public Task<IEnumerable<SystemUserRoles>> GetSystemRoles()
        {
            return Task.Run(() =>
            {
                var Resp = db.SecurityRepository.GetSystemRoles();
                return Resp;
            });
        }
        public Task<Genericmodel> RegisterSystemStaffRole(string JsonObj)
        {
            return Task.Run(() =>
            {
                var Resp = db.SecurityRepository.RegisterSystemStaffRole(JsonObj);
                return Resp;
            });
        }
        public Task<Systemuserroledetail> GetSystemRoleDetailData(long RoleId)
        {
            return Task.Run(() =>
            {
                var Resp = db.SecurityRepository.GetSystemRoleDetailData(RoleId);
                return Resp;
            });
        }

        #endregion

        #region System Permissions
        public Task<IEnumerable<Systempermissions>> Getsystempermissiondata()
        {
            return Task.Run(() =>
            {
                var Resp = db.MaintenanceRepository.Getsystempermissiondata();
                return Resp;
            });
        }
        public Task<Genericmodel> Registersystempermissiondata(string obj)
        {
            return Task.Run(() =>
            {
                var Resp = db.MaintenanceRepository.Registersystempermissiondata(obj);
                return Resp;
            });
        }
        public Task<Systempermissions> Getsystempermissiondatabyid(long Permissionid)
        {
            return Task.Run(() =>
            {
                var Resp = db.MaintenanceRepository.Getsystempermissiondatabyid(Permissionid);
                return Resp;
            });
        }
        #endregion

        #region System Vehicle Makes
        public Task<IEnumerable<Systemvehiclemakes>> Getsystemvehiclemakedata()
        {
            return Task.Run(() =>
            {
                var Resp = db.MaintenanceRepository.Getsystemvehiclemakedata();
                return Resp;
            });
        }
        public Task<Genericmodel> Registersystemvehiclemakedata(string obj)
        {
            return Task.Run(() =>
            {
                var Resp = db.MaintenanceRepository.Registersystemvehiclemakedata(obj);
                return Resp;
            });
        }
        public Task<Systemvehiclemakes> Getsystemvehiclemakedatabyid(long Vehiclemakeid)
        {
            return Task.Run(() =>
            {
                var Resp = db.MaintenanceRepository.Getsystemvehiclemakedatabyid(Vehiclemakeid);
                return Resp;
            });
        }
        #endregion

        #region System Vehicle Models
        public Task<IEnumerable<Systemvehiclemodeldata>> Getsystemvehiclemodeldata()
        {
            return Task.Run(() =>
            {
                var Resp = db.MaintenanceRepository.Getsystemvehiclemodeldata();
                return Resp;
            });
        }
        public Task<Genericmodel> Registersystemvehiclemodeldata(string obj)
        {
            return Task.Run(() =>
            {
                var Resp = db.MaintenanceRepository.Registersystemvehiclemodeldata(obj);
                return Resp;
            });
        }
        public Task<Systemvehiclemodels> Getsystemvehiclemodeldatabyid(long Vehiclemodelid)
        {
            return Task.Run(() =>
            {
                var Resp = db.MaintenanceRepository.Getsystemvehiclemodeldatabyid(Vehiclemodelid);
                return Resp;
            });
        }
        #endregion

        #region System Tenants
        public Task<IEnumerable<Systemtenantdatamodel>> Getsystemtenantdata()
        {
            return Task.Run(() =>
            {
                var Resp = db.MaintenanceRepository.Getsystemtenantdata();
                return Resp;
            });
        }
        public Task<Genericmodel> Registersystemtenantdata(string obj)
        {
            return Task.Run(() =>
            {
                var Resp = db.MaintenanceRepository.Registersystemtenantdata(obj);
                return Resp;
            });
        }
        public Task<Systemtenants> Getsystemtenantdatabyid(long Tenantid)
        {
            return Task.Run(() =>
            {
                var Resp = db.MaintenanceRepository.Getsystemtenantdatabyid(Tenantid);
                return Resp;
            });
        }
        #endregion

        #region System Customers
        public Task<IEnumerable<Systemcustomerdatamodel>> Getsystemcustomerdata(long TenantId)
        {
            return Task.Run(() =>
            {
                var Resp = db.CustomerRepository.Getsystemcustomerdata(TenantId);
                return Resp;
            });
        }
        public Task<Genericmodel> Registersystemcustomerdata(string obj)
        {
            return Task.Run(() =>
            {
                var Resp = db.CustomerRepository.Registersystemcustomerdata(obj);
                return Resp;
            });
        }
        public Task<Genericmodel> Createsystemcustomeruserdata(Systemcustomerdetail Obj)
        {
            return Task.Run(() =>
            {
                string passwordraw = str.RandomString(8);
                string PassHash = str.RandomString(12);
                Obj.Passwords = sec.Encrypt(passwordraw, PassHash);
                Obj.Passwordharsh = PassHash;
                var Resp = db.SecurityRepository.Registersystemcustomeruserdata(JsonConvert.SerializeObject(Obj));
                if (Resp.RespStatus == 0)
                {
                    string EmailBody = "Dear " + Resp.Data3 + " , <br> Your username is: " + Resp.Data4 + " and your one time password is: " + sec.Decrypt(Resp.Data5, Resp.Data6) + "<br>. Kindly Login and set your preferred Password";
                    bool data = emlsnd.UttambsolutionssendemailAsync(Resp.Data4, Resp.Data3, "Staff Registration", EmailBody);
                }
                return Resp;
            });
        }
        public Task<Systemcustomerdetail> Getsystemcustomerdetaildatabyid(long CustomerId)
        {
            return Task.Run(() =>
            {
                var Resp = db.CustomerRepository.Getsystemcustomerdetaildatabyid(CustomerId);
                return Resp;
            });
        }
        public Task<Genericmodel> Registersystemcustomerloandetaildata(string obj)
        {
            return Task.Run(() =>
            {
                var Resp = db.CustomerRepository.Registersystemcustomerloandetaildata(obj);
                return Resp;
            });
        }
        public Task<Systemcustomerdetaildatamodel> Getsystemcustomerloandetaildata(long CustomerId)
        {
            return Task.Run(() =>
            {
                var Resp = db.CustomerRepository.Getsystemcustomerloandetaildata(CustomerId);
                return Resp;
            });
        }
        public Task<Genericmodel> Payloaninvoiceitemdata(string obj)
        {
            return Task.Run(() =>
            {
                var Resp = db.CustomerRepository.Payloaninvoiceitemdata(obj);
                return Resp;
            });
        }
        #endregion

        #region System Assets
        public Task<IEnumerable<Systemassetdatamodel>> Getsystemassetsdata()
        {
            return Task.Run(() =>
            {
                var Resp = db.MaintenanceRepository.Getsystemassetsdata();
                return Resp;
            });
        }
        public Task<Genericmodel> Registersystemassetdata(string obj)
        {
            return Task.Run(() =>
            {
                var Resp = db.MaintenanceRepository.Registersystemassetdata(obj);
                return Resp;
            });
        }
        public Task<Systemassets> Getsystemassetdatabyid(long Assetid)
        {
            return Task.Run(() =>
            {
                var Resp = db.MaintenanceRepository.Getsystemassetdatabyid(Assetid);
                return Resp;
            });
        }
        #endregion

        #region Delete,Deactivate System Columns
        public Task<Genericmodel> DeactivateorDeleteTableColumnData(string obj)
        {
            return Task.Run(() =>
            {
                var Resp = db.GeneralRepository.DeactivateorDeleteTableColumnData(obj);
                return Resp;
            });
        }
        public Task<Genericmodel> RemoveTableColumnData(string obj)
        {
            return Task.Run(() =>
            {
                var Resp = db.GeneralRepository.RemoveTableColumnData(obj);
                return Resp;
            });
        }
        #endregion

        #region Customer Summary Reports
        public Task<Systemreportdataandparameters> Getsystemloanrepaymentdata(long TenantId, long Customerid, long Assetdetailid, long Loanstatus, DateTime Startdate, DateTime Enddate)
        {
            return Task.Run(() =>
            {
                var Resp = db.ReportManagementRepository.Getsystemloanrepaymentdata(TenantId, Customerid, Assetdetailid, Loanstatus, Startdate, Enddate);
                return Resp;
            });
        }
        #endregion

        #region System Mpesa Transactions
        public async Task<RegisterC2BUrlResponseData> MpesaRegisterValidationURL(C2BConfirmData Obj)
        {
            return await Task.Run(() =>
            {
                RegisterC2BUrlResponseData resp = new RegisterC2BUrlResponseData { ResponseCode = "1", ResponseDescription = "Request was not processed!" };

                //---- Get service settings
                var settings = db.CustomerPaymentRepository.GetExprSettings(Obj.BusinessShortCode);
                if (settings.RespStatus != 0)
                {
                    resp.ResponseDescription = settings.RespMessage;
                    return resp;
                }

                string payUrl = settings.Data1;
                string authUrl = settings.Data2;
                string consumerKey = settings.Data3;
                string consumerSecret = settings.Data4;
                string passKey = settings.Data5;
                string validationURL = settings.Data10 + Obj.BillRefNumber;
                string confirmationURL = settings.Data11 + Obj.BillRefNumber;
                string shortCode = settings.Data8;
                string partyB = settings.Data8;
                string mpesaRegUrl = settings.Data9;

                string txnRef = "";
                string newRef = "";
                string message = "";
                int Status = 0;

                //---- Get Mpesa auth token
                MPesaApi mpesaApi = new MPesaApi();
                var authToken = mpesaApi.GetMPesaAuthToken(authUrl, consumerKey, consumerSecret);
                if (string.IsNullOrEmpty(authToken))
                    return new RegisterC2BUrlResponseData
                    {
                        ResponseCode = "1",
                        ResponseDescription = "Failed to generate M-Pesa authorization details!"
                    };
                string timestamp = DateTime.Now.ToString("yyyyMMddHHmmss");
                string password = shortCode + passKey + timestamp;

                //----Encode the password to Base64
                Encoding iso = Encoding.GetEncoding("ISO-8859-1");
                Encoding utf8 = Encoding.UTF8;
                byte[] utfBytes = utf8.GetBytes(password);
                byte[] isoBytes = Encoding.Convert(Encoding.UTF8, iso, utfBytes);
                password = Convert.ToBase64String(isoBytes);

                RegisterC2BUrlRequestData validationURLReq = new RegisterC2BUrlRequestData
                {
                    ShortCode = Obj.BusinessShortCode.ToString(),
                    ValidationURL = validationURL,
                    ConfirmationURL = confirmationURL,
                    ResponseType = "Completed",
                };
                var payResp = mpesaApi.RegisterC2BUrl(mpesaRegUrl, validationURLReq, authToken);
                if (payResp.Status == ResponseStatus.Success)
                {
                    Status = 1;
                    newRef = (string)payResp.Data;
                    resp.OriginatorCoversationID = payResp.StatusNo;
                    resp.ResponseCode = "0";
                    resp.ResponseDescription = payResp.Message;
                }
                else
                {
                    Status = 3;
                    message = payResp.Message.Replace("Error!", "").Trim();

                    resp.ResponseDescription = "We have an error!";
                }
                return resp;
            });
        }
        public void ProcessC2BConfirmation(string AccountNumber, string jsonData)
        {
            Task.Run(() =>
            {
                var results = JsonConvert.DeserializeObject<C2BConfirmData>(jsonData);

                if (results != null)
                {
                    Payment payment = new Payment();
                    payment.ServiceCode = results.BusinessShortCode;
                    payment.AccountNo = results.MSISDN;
                    payment.AccountName = results.FirstName;
                    payment.Amount = results.TransAmount;
                    payment.PType = (int)PaymentType.C2B;
                    payment.TPRef = "";
                    payment.ExtRef = results.TransID;
                    payment.Extra1 = results.BillRefNumber;
                    payment.Extra2 = results.TransTime;
                    payment.Extra3 = AccountNumber;
                    payment.Extra4 = results.OrgAccountBalance + "";
                    payment.PStatus = 2;//--- Completed


                    db.GeneralRepository.Registermpesaapiresponselog("C2B Mpesa Transaction", 0, true, JsonConvert.SerializeObject(payment), DateTime.Now);

                    //---- Create payment
                    var resp = db.CustomerPaymentRepository.CreatePayment(payment);
                    db.Reset();

                    if (resp.RespStatus == 0)
                    {
                        if (!string.IsNullOrEmpty(resp.Data1))
                        {
                            PaymentNotificationData notificationData = new PaymentNotificationData
                            {
                                AccountBalance = results.OrgAccountBalance,
                                PayAccountNo = results.BillRefNumber,
                                Amount = results.TransAmount,
                                CustomerName = results.FirstName,
                                CustomerNo = results.MSISDN,
                                ReferenceNo = results.TransID,
                                SourceRef = results.BusinessShortCode.ToString()
                            };

                            //---- Update 3rd party application
                            SendPaymentNotifTo3P(resp.Data1, notificationData, resp.Data2);
                        }
                    }
                    else
                    {
                        throw new Exception(resp.RespMessage);
                    }
                }
                else
                {
                    throw new Exception("Invalid confirmation data!");
                }

            });
        }

        public async Task<PayResponse> MakeExpressPayment(PesaAppRequestData requestData)
        {
            return await Task.Run(() =>
            {
                PayResponse resp = new PayResponse { Status = 1, Message = "Request was not processed!" };

                //---- Get service settings
                var settings = db.CustomerPaymentRepository.GetExprSettings(requestData.ServiceCode);
                if (settings.RespStatus != 0)
                {
                    resp.Message = settings.RespMessage;
                    return resp;
                }

                string? payUrl = settings.Data1;
                string? authUrl = settings.Data2;
                string? consumerKey = settings.Data3;
                string? consumerSecret = settings.Data4;
                string? passKey = settings.Data5;
                string callbackUrl = settings.Data6 + requestData.ServiceCode;
                string shortCode = requestData.ServiceCode.ToString();
                string? partyB = settings.Data10;

                string txnRef = "";
                string newRef = "";
                string message = "";
                int Status = 0;

                //---- Get Mpesa auth token
                MPesaApi mpesaApi = new MPesaApi();
                var authToken = mpesaApi.GetMPesaAuthToken(authUrl, consumerKey, consumerSecret);
                if (string.IsNullOrEmpty(authToken))
                    return new PayResponse
                    {
                        Status = 1,
                        Message = "Failed to generate M-Pesa authorization details!"
                    };

                string phoneNo = Util.FormatPhoneNo(requestData.Data.Phonenumber, "254").Replace("+", "");

                //---- Save the payment to the DB
                Payment payment = new Payment();
                payment.ServiceCode = requestData.ServiceCode;
                payment.AccountNo = phoneNo;
                payment.AccountName = "";
                payment.Amount = requestData.Data.Recievedamount;
                payment.PType = (int)PaymentType.Express;
                payment.TPRef = requestData.AccountNumber;
                payment.TPStat = 2;
                payment.ExtRef = "";
                payment.Extra1 = requestData.AccountNumber;
                payment.Extra2 = string.IsNullOrEmpty(requestData.Data.Paymentmemo) ? requestData.Data.Paymentmemo : "Self Initiated Payemnt";
                payment.Extra3 = string.IsNullOrEmpty(requestData.Data.Createdby.ToString()) ? requestData.Data.Createdby.ToString() : "0";
                payment.PStatus = 0;//--- Pending

                //---- Create payment
                var result = db.CustomerPaymentRepository.CreatePayment(payment);
                db.Reset();

                if (result.RespStatus == 0)
                {
                    txnRef = result.Data1;

                    string timestamp = DateTime.Now.ToString("yyyyMMddHHmmss");
                    string password = shortCode + passKey + timestamp;

                    //----Encode the password to Base64
                    Encoding iso = Encoding.GetEncoding("ISO-8859-1");
                    Encoding utf8 = Encoding.UTF8;
                    byte[] utfBytes = utf8.GetBytes(password);
                    byte[] isoBytes = Encoding.Convert(Encoding.UTF8, iso, utfBytes);
                    password = Convert.ToBase64String(isoBytes);

                    //---- Initiate payment to M-Pesa
                    ExprPaymentData exprData = new ExprPaymentData
                    {
                        Amount = Math.Round(requestData.Data.Recievedamount, 0).ToString(),
                        AccountReference = requestData.AccountNumber,
                        BusinessShortCode = shortCode,
                        CallBackURL = callbackUrl,
                        PartyA = phoneNo,
                        PartyB = shortCode,
                        Password = password,
                        PhoneNumber = phoneNo,
                        Timestamp = timestamp,
                        TransactionDesc = "Mpesa invoice payment",
                        TransactionType = "CustomerPayBillOnline"
                    };

                    //---- Log data
                    string myData = JsonConvert.SerializeObject(exprData);
                    Util.LogError(this.LogFile, "Bl.MakeExpressPayment", new Exception(myData), false);

                    var payResp = mpesaApi.MakeExprPayment(payUrl, exprData, authToken);
                    //---- Update DB
                    if (payResp.Status == ResponseStatus.Success)
                    {
                        Status = 1;
                        newRef = (string)payResp.Data;

                        resp.Status = 0;
                        resp.Message = "Payment initiated successfully.";
                    }
                    else
                    {
                        Status = 3;
                        message = payResp.Message.Replace("Error!", "").Trim();

                        resp.Message = "Initiating payment record failed!";
                    }

                    var updateResp = db.CustomerPaymentRepository.UpdateMPesa(txnRef, Status, message, newRef);
                    db.Reset();
                }
                else
                {
                    if (result.RespStatus == 1)
                        resp.Message = "Failed to create the payment record! " + result.RespMessage;
                    else
                        throw new Exception(result.RespMessage);
                }

                //---- Respond back to the caller

                return resp;
            });
        }

        public void ProcessMPesaSTKCallback(int serviceCode, string content)
        {
            Task.Run(() =>
            {
                Genericmodel result = null;
                ExprCallbackModel dataModel = JsonConvert.DeserializeObject<ExprCallbackModel>(content);
                if (dataModel != null)
                {
                    ExprCallbackDataModel callbackData = new ExprCallbackDataModel
                    {
                        CheckoutRequestID = dataModel.CallbackBody.CallbackContent.CheckoutRequestID,
                        ResultCode = dataModel.CallbackBody.CallbackContent.ResultCode,
                        ResultDesc = dataModel.CallbackBody.CallbackContent.ResultDesc,
                        CustomerDets = ""
                    };

                    if (dataModel.CallbackBody.CallbackContent.ResultCode == 0)
                    {
                        var item = dataModel.CallbackBody.CallbackContent.CallbackData.CallbackValues
                        .Where(x => x.ItemName == "MpesaReceiptNumber").FirstOrDefault();
                        if (item != null)
                            callbackData.RefNo = item.ItemValue;

                        item = dataModel.CallbackBody.CallbackContent.CallbackData.CallbackValues
                        .Where(x => x.ItemName == "TransactionDate").FirstOrDefault();
                        if (item != null)
                            callbackData.TxnDate = item.ItemValue;

                        item = dataModel.CallbackBody.CallbackContent.CallbackData.CallbackValues
                        .Where(x => x.ItemName == "PhoneNumber").FirstOrDefault();
                        if (item != null)
                            callbackData.PhoneNo = item.ItemValue;

                        item = dataModel.CallbackBody.CallbackContent.CallbackData.CallbackValues
                        .Where(x => x.ItemName == "Amount").FirstOrDefault();
                        if (item != null)
                            callbackData.Amount = Convert.ToDecimal(item.ItemValue);
                    }
                    db.GeneralRepository.Registermpesaapiresponselog("Mpesa STK Push", 0, true, JsonConvert.SerializeObject(callbackData), DateTime.Now);

                    result = db.CustomerPaymentRepository.ProcessExprCallback(serviceCode, callbackData);
                    db.Reset();

                    if (result.RespStatus == 0)
                    {
                        //---- Notify 3rd party client
                        if (!string.IsNullOrEmpty(result.Data1))
                        {
                            PaymentNotificationData notificationData = new PaymentNotificationData
                            {
                                AccountBalance = callbackData.Balance,
                                PayAccountNo = result.Data4,
                                Amount = callbackData.Amount,
                                CustomerName = callbackData.CustomerDets,
                                CustomerNo = callbackData.PhoneNo,
                                ReferenceNo = callbackData.RefNo,
                                SourceRef = result.Data3
                            };

                            //---- Update 3rd party application
                            //SendPaymentNotifTo3P(result.Data1, notificationData, result.Data2);
                            db.CustomerPaymentRepository.UpdatePayment3PStatus(result.Data2, 3, "Success");
                        }

                    }
                }
            });
        }
        #endregion

        #region System customer account Validation
        public Task<Genericmodel> Validateexistenceoftheaccount(string AssetNumber)
        {
            return Task.Run(() =>
            {
                return db.CustomerRepository.Getsystemcustomerdetaildatabyassetnumber(AssetNumber);
            });
        }
        #endregion

        #region Other methods
        public Task<IEnumerable<ListModel>> GetListModel(ListModelType listType)
        {
            return Task.Run(() =>
            {
                return db.GeneralRepository.GetListModel(listType);
            });
        }
        public Task<IEnumerable<ListModel>> GetListModelById(ListModelType listType, long Id)
        {
            return Task.Run(() =>
            {
                return db.GeneralRepository.GetListModelbycode(listType, Id);
            });
        }
        #endregion

        #region Private methods
        private void SendPaymentNotifTo3P(string url, PaymentNotificationData notifData, string paymentRef)
        {
            //---- Update 3rd party application
            CustomHttpClient httpClient = new CustomHttpClient(url, CustomHttpClient.RequestType.Post);
            string jsonData = JsonConvert.SerializeObject(notifData);

            Exception ex;
            int status = 0;
            string message = "";
            var notifResp = httpClient.SendRequest(jsonData, out ex);
            if (ex != null)
            {
                status = 2;
                message = ex.Message;
            }
            else
            {
                var respData = JsonConvert.DeserializeObject<ThirdPartyPaymentResponse>(notifResp);
                if (respData == null)
                {
                    status = 2;
                    message = "Failed to understand the received response!";
                }
                else
                {
                    status = respData.Status == 0 ? 1 : 2;
                    message = respData.Message;
                }
            }
            //---- Update payment status
            db.CustomerPaymentRepository.UpdatePayment3PStatus(paymentRef, status, message);
        }
        #endregion
    }
}