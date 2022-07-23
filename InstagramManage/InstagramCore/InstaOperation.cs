using InstagramApiSharp.API;
using InstagramApiSharp.Classes.Models;
using InstagramApiSharp.Enums;
using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InstagramManage.InstagramCore
{
    public class InstaOperation
    {
        public async Task<InstaCurrentUser> GetUserAsync(IInstaApi api)
        {
            var currentUser = await api.GetCurrentUserAsync();
            return currentUser.Value;
        }
        public async Task<(bool flag, string picturePath)> ChangeProfilePicture(IInstaApi api, int? sex = 2)
        {
            string typesex = "";
            if (sex == 1)
                typesex = "Male";
            else
                typesex = "Female";

            var dir = ($"{Application.StartupPath}\\File\\Image\\profile\\" + typesex);

            string[] extensions = new[] { ".jpg", ".png", };
            DirectoryInfo d = new DirectoryInfo(dir); //Assuming Test is your Folder
            FileInfo[] Files = d.GetFiles().Where(f => extensions.Contains(f.Extension.ToLower())).ToArray(); //Getting Text files
            var rand = new Random();
            var SelectFile = Files[rand.Next(Files.Length)];
            var picturePath = Path.Combine(dir, SelectFile.FullName);
            // note: only JPG and JPEG format will accept it in instagram!
            var pictureBytes = File.ReadAllBytes(picturePath);

            var result = await api.AccountProcessor.ChangeProfilePictureAsync(pictureBytes);
            if (result.Succeeded)
            {
                return (true, picturePath);
            }
            else
                return (false, "");
        }

        public async Task<string> GetProfilePicture(IInstaApi api)
        {
            var result = await api.UserProcessor.GetCurrentUserAsync();
            if (result.Succeeded)
            {
                return result.Value.ProfilePicture;
            }
            else
                return result.Info.Message;
        }

        public async Task<string> RemoveProfilePicture(IInstaApi api)
        {
            var result = await api.AccountProcessor.RemoveProfilePictureAsync();
            if (result.Succeeded)
            {
                return "Profile picture removed.";
            }
            else
                return "Error while removing profile picture: " + result.Info.Message;
        }

        public async Task<string> SwitchToBusinessAccount(IInstaApi api)
        {
            var result = await api.AccountProcessor.SwitchToPersonalAccountAsync();

            if (result.Succeeded)
            {
                return "Switch To Business Account.";
            }
            else
                return "Error while switch To Business " + result.Info.Message;
        }

        public async Task<string> BioAccount(IInstaApi api, string bio)
        {
            var result = await api.AccountProcessor.SetBiographyAsync(bio);
            if (result.Succeeded)
            {
                return "Set Biography";
            }
            else
                return "Error while Biography " + result.Info.Message;
        }

        public async Task<string> EditProfile(IInstaApi api)
        {
            string name = null; // leave null if you don't want to change it
            InstaGenderType? gender = InstaGenderType.Female; // leave null if you don't want to change it
            string email = null; // leave null if you don't want to change it
            string url = ""; // leave empty if you have no site/blog | leave null if you don't want to change it
            string phone = null; // leave null if you don't want to change it
            string biography = "Every human being is a book waiting for its reader"; // leave null if you don't want to change it
            string newUsername = ""; // leave empty if you don't want to change your username

            var result = await api.AccountProcessor.EditProfileAsync(name, biography, url, email, phone, gender, newUsername);

            if (result.Succeeded)
            {
                return "Profile changed";
            }
            else
                return ("Error while editing profile: " + result.Info.Message);
        }

        public async Task<string> UploadMediaPost(IInstaApi api, string ImageUrl)
        {
            var mediaImage = new InstaImageUpload
            {
                // leave zero, if you don't know how height and width is it.
                Height = 0,
                Width = 0,
                Uri = ImageUrl
            };

            var result = await api.MediaProcessor.UploadPhotoAsync(mediaImage, "One day you will thank yourself for not giving up");
            if (result.Succeeded)
            {
                return "Media created";
            }
            else
                return ("Unable to upload photo: " + result.Info.Message);
        }

        public async Task<string> FollowUser(IInstaApi api)
        {

            var user1 = await api.UserProcessor.GetUserAsync("instagram");
            var user2 = await api.UserProcessor.GetUserAsync("cristiano");
            var user3 = await api.UserProcessor.GetUserAsync("kimkardashian");
            var user4 = await api.UserProcessor.GetUserAsync("selenagomez");


            var result1 = await api.UserProcessor.FollowUserAsync(user1.Value.Pk);
            var result2 = await api.UserProcessor.FollowUserAsync(user2.Value.Pk);
            var result3 = await api.UserProcessor.FollowUserAsync(user3.Value.Pk);
            var result4 = await api.UserProcessor.FollowUserAsync(user4.Value.Pk);

            if (result1.Succeeded)
            {
                return "Followed";
            }
            else
                return ("Error while Followed: " + result1.Info.Message);
        }
    }
}
