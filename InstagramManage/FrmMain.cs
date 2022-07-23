using InstagramApiSharp.API;
using InstagramApiSharp.Classes.Models;
using InstagramManage.InstagramCore;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

namespace InstagramManage
{
    public partial class FrmMain : Form
    {
        const string AppName = "Instagram Manage";
        private static IInstaApi InstaApi;

        public FrmMain()
        {
            InitializeComponent();
            Load += FrmMain_Load;
        }
        private void FrmMain_Load(object sender, EventArgs e)
        {

        }
        private async void bgwCheckAccount_DoWork(object sender, DoWorkEventArgs e)
        {
            int CorrectAccount = 0;
            int WrongAccount = 0;
            int CountAccountList = _lbAccountList.Items.Count;
            string[] UserPass;

            var InstaLogin = new InstaLogin();
            var InstaOperation = new InstaOperation();

            string path = Application.StartupPath + $"\\File\\Account\\{DateTime.Now.ToString("yyyyMMddHHmm")}.txt";

            try
            {
                for (int i = 0; i < CountAccountList; i++)
                {
                    if (bgwCheckAccount.CancellationPending == true)
                    {
                        e.Cancel = true;
                        return;
                    }
                    UserPass = _lbAccountList.Items[i].ToString().Split(':');

                    InstaApi = await InstaLogin.SinginAsync(UserPass[0], UserPass[1]);

                    if (InstaApi == null)
                    {
                        _lbAccountList.Invoke((MethodInvoker)delegate
                        {
                            _lbAccountList.Items[i] = _lbAccountList.Items[i].ToString() + ":Failed";
                        });
                        _lblWrongAccount.Invoke((MethodInvoker)delegate
                        {
                            _lblWrongAccount.Text = (++WrongAccount).ToString();
                        });
                    }
                    else if (!InstaApi.IsUserAuthenticated)
                    {
                        _lbAccountList.Invoke((MethodInvoker)delegate
                        {
                            _lbAccountList.Items[i] = _lbAccountList.Items[i].ToString() + ":Failed";
                        });
                        _lblWrongAccount.Invoke((MethodInvoker)delegate
                        {
                            _lblWrongAccount.Text = (++WrongAccount).ToString();
                        });
                    }
                    else
                    {
                        _lbAccountList.Invoke((MethodInvoker)delegate
                        {
                            _lbAccountList.Items[i] = _lbAccountList.Items[i].ToString() + ":Success";
                        });

                        _lblCorrectAccount.Invoke((MethodInvoker)delegate
                        {
                            _lblCorrectAccount.Text = (++CorrectAccount).ToString();
                        });

                        using (StreamWriter file = new StreamWriter(path, true))
                        {
                            file.WriteLine($"{UserPass[0]}:{UserPass[1]}");
                        }


                        #region SwitchToBusinessAccount
                        //var _switchAccount = await InstaOperation.SwitchToBusinessAccount(InstaApi);
                        //_lbAccountList.Invoke((MethodInvoker)delegate
                        //{
                        //    _lbAccountList.Items[i] = _lbAccountList.Items[i].ToString() + ":" + _switchAccount;
                        //});
                        #endregion

                        #region SwitchToBusinessAccount
                        var _followUser = await InstaOperation.FollowUser(InstaApi);
                        _lbAccountList.Invoke((MethodInvoker)delegate
                        {
                            _lbAccountList.Items[i] = _lbAccountList.Items[i].ToString() + ":" + _followUser;
                        });
                        #endregion

                        #region InsetBioAccount
                        var _bioAccount = await InstaOperation.EditProfile(InstaApi);
                        _lbAccountList.Invoke((MethodInvoker)delegate
                        {
                            _lbAccountList.Items[i] = _lbAccountList.Items[i].ToString() + ":" + _bioAccount;
                        });

                        #endregion

                        #region ChangeProfilePicture
                        var _currentUser = await InstaOperation.GetUserAsync(InstaApi);
                        if (_currentUser != null)
                        {
                            if (_currentUser.ProfilePictureId == "unknown")
                            {
                                var result = await InstaOperation.ChangeProfilePicture(InstaApi, 2);
                                if (result.flag)
                                {
                                    _lbAccountList.Invoke((MethodInvoker)delegate
                                    {
                                        _lbAccountList.Items[i] = _lbAccountList.Items[i].ToString() + ":Change Profile";
                                    });

                                    #region PostMedia
                                    var _postMedia = await InstaOperation.UploadMediaPost(InstaApi, result.picturePath);
                                    _lbAccountList.Invoke((MethodInvoker)delegate
                                    {
                                        _lbAccountList.Items[i] = _lbAccountList.Items[i].ToString() + ":" + _postMedia;
                                    });
                                    #endregion
                                }
                            }
                        }
                        #endregion
                    }
                }

                btnStart.Invoke((MethodInvoker)delegate
                {
                    btnStart.Enabled = true;
                });
                btnStop.Invoke((MethodInvoker)delegate
                {
                    btnStop.Enabled = true;
                });

                MessageBox.Show("Finish", "Important Message");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            if (_lbAccountList.Items.Count > 0)
            {
                btnStart.Enabled = false;
                btnStop.Enabled = true;
                bgwCheckAccount.RunWorkerAsync();
            }
            else
                MessageBox.Show("Fill in all the items.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            if (bgwCheckAccount.WorkerSupportsCancellation == true)
            {
                bgwCheckAccount.CancelAsync();
            }

            btnStart.Enabled = true;
            btnStop.Enabled = false;
        }

        private void btnLoadAccount_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Filter = "All File txt|*.txt";
            if (open.ShowDialog() == DialogResult.OK)
            {
                //string[] lines = File.ReadAllLines(open.FileName);
                //File.WriteAllLines(open.FileName, lines.Distinct().ToArray());

                StreamReader read = new StreamReader(open.FileName);
                while (read.Peek() > -1)
                {
                    string mobile = read.ReadLine();
                    _lbAccountList.Items.Add(mobile);
                }
                read.Close();
                _lblCount.Text = (_lbAccountList.Items.Count).ToString();

            }
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (_lbAccountList.SelectedIndex != -1)
            {
                _lbAccountList.Items.RemoveAt(_lbAccountList.SelectedIndex);
                _lblCount.Text = (_lbAccountList.Items.Count).ToString();
            }
            else
                MessageBox.Show("No Item For Remove", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnClear_Click(object sender, EventArgs e)
        {

        }

        private void bgwCheckAccount_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {

        }

        private void bgwCheckAccount_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if ((e.Cancelled == true))
            {
                return;
            }
        }
    }
    public static class DebugUtils
    {
        public static string PrintMedia(string header, InstaMedia media)
        {
            var content = $"{header}: {media.Caption?.Text.Truncate(30)}, {media.Code}";
            Debug.WriteLine(content);
            return content;
        }
        public static string Truncate(this string value, int maxChars)
        {
            return value.Length <= maxChars ? value : value.Substring(0, maxChars) + "...";
        }
    }
}
