using InstagramApiSharp.API;
using InstagramApiSharp.API.Builder;
using InstagramApiSharp.Classes;
using InstagramApiSharp.Classes.SessionHandlers;
using InstagramApiSharp.Logger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InstagramManage.InstagramCore
{
    public class InstaLogin
    {
        private static IInstaApi InstaApi;
        public async Task<IInstaApi> SinginAsync(string Username, string Password)
        {
            var userSession = new UserSessionData
            {
                UserName = Username,
                Password = Password
            };

            string StateFile = $"{Application.StartupPath}\\File\\Stream\\{userSession.UserName.ToLower()}.bin";

            var InstaApi = InstaApiBuilder.CreateBuilder()
                .SetUser(userSession)
                .UseLogger(new DebugLogger(LogLevel.All))
                .SetRequestDelay(RequestDelay.FromSeconds(0, 1))
                // Session handler, set a file path to save/load your state/session data
                .SetSessionHandler(new FileSessionHandler() { FilePath = StateFile })
                .Build();
            //Text = $"{AppName} Connecting";
            //Load session
            LoadSession();
            if (!InstaApi.IsUserAuthenticated)
            {
                // Call this function before calling LoginAsync
                await InstaApi.SendRequestsBeforeLoginAsync();
                // wait 5 seconds
                await Task.Delay(5000);
                var logInResult = await InstaApi.LoginAsync();
       
                if (logInResult.Succeeded)
                {
                    //Text = $"{AppName} Connected";

                    // Call this function after a successful login
                    await InstaApi.SendRequestsAfterLoginAsync();

                    // Save session 
                    SaveSession();
                }
                else
                {
                    if (logInResult.Value == InstaLoginResult.ChallengeRequired)
                    {
                        var challenge = await InstaApi.GetChallengeRequireVerifyMethodAsync();
                        if (challenge.Succeeded)
                        {
                            if (challenge.Value.SubmitPhoneRequired)
                            {

                            }
                            else
                            {
                                if (challenge.Value.StepData != null)
                                {
                                    if (!string.IsNullOrEmpty(challenge.Value.StepData.PhoneNumber))
                                    {

                                    }
                                    if (!string.IsNullOrEmpty(challenge.Value.StepData.Email))
                                    {

                                    }
                                }
                            }
                        }
                        //else
                            //MessageBox.Show(challenge.Info.Message, "ERR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                //Text = $"{AppName} Connected";
            }
            return InstaApi;
        }

        void LoadSession()
        {
            InstaApi?.SessionHandler?.Load();
        }
        void SaveSession()
        {
            if (InstaApi == null)
                return;
            if (!InstaApi.IsUserAuthenticated)
                return;
            InstaApi.SessionHandler.Save();
        }
    }

}
