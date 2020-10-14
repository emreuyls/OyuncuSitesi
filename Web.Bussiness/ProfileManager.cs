using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.InteropServices;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using Web.DataAccess.Abstract;
using Web.Entity;
using Web.Core.Message;
using Web.Entity.ModelView;

namespace Web.Business
{
    public class ProfileManager
    {
        private IUnitOfWork repo;
        private UserManager<ApplicationUser> userManager;
        public ProfileManager(IUnitOfWork _repo, UserManager<ApplicationUser> _usermanager)
        {
            repo = _repo;
            userManager = _usermanager;
        }

        public ProfileModelView FindUser(string name)
        {
            var user = userManager.FindByNameAsync(name);
            ProfileModelView model = new ProfileModelView()
            {
                Username = user.Result.UserName,
                Names = user.Result.Names,
                RegisterDate = user.Result.RegisterDate,
                Gender = user.Result.Gender,
                Birthdate = user.Result.Birthdate,
                Image = user.Result.Image,
                City = user.Result.City,
                Statement = user.Result.Statement,
                SteamLink = user.Result.SteamLink,
                OriginLink = user.Result.OriginLink,
                BattleNetLink = user.Result.BattleNetLink,
                EpicGamesLink = user.Result.EpicGamesLink,
                PsnLink = user.Result.PsnLink,
                XboxLink = user.Result.XboxLink,
                Discord = user.Result.Discord,
                TeamSpeak = user.Result.TeamSpeak
            };
            return model;
        }

        public ProfileSettingsModelView GetProfileSetting(string id)
        {
            var user = userManager.FindByIdAsync(id);
            ProfileSettingsModelView model = new ProfileSettingsModelView()
            {
                Birthdate = user.Result.Birthdate,
                City = user.Result.City,
                Content = user.Result.Statement,
                Email = user.Result.Email,
                Gender = user.Result.Gender,
                Names = user.Result.Names,
            };
            return model;
        }

        public async Task<ProfileSettingsModelView> UpdateProfile(ProfileSettingsModelView model, string userid)
        {
            ErrorMessage error = new ErrorMessage();
            var user = await userManager.FindByIdAsync(userid);
            try
            {
                if (user != null)
                {
                    var SetEmailResult = await userManager.SetEmailAsync(user, model.Email);

                    if (!SetEmailResult.Succeeded)
                    {

                        error.AddErrors(ErrorMessageCode.EmailAlreadyExist, "Bu Email Kullanılmaktadır");
                        model.Error = error.Errors;
                        return model;
                    }
                    user.Names = model.Names;
                    user.Email = model.Email;
                    user.City = model.City;
                    user.Birthdate = model.Birthdate;
                    user.Gender = model.Gender;
                    user.Statement = model.Content;
                }
                await userManager.UpdateAsync(user);
                return model;
            }
            catch (Exception)
            {
                return null;
            }


        }

        public async Task<ErrorMessage> UpdatePassword(SettingPasswordModelView model, string userid)
        {
            ErrorMessage error = new ErrorMessage();
            try
            {
                var user = await userManager.FindByIdAsync(userid);
                if (user != null)
                {
                    var checkpassword = await userManager.CheckPasswordAsync(user, model.NewPassword);
                    if (checkpassword == false)
                    {
                        var token = await userManager.GeneratePasswordResetTokenAsync(user);
                        var result = await userManager.ResetPasswordAsync(user, token, model.NewPassword);
                        if (result.Succeeded)
                        {
                            error.AddErrors(ErrorMessageCode.PasswordUpdatedSuccess, "Şifre Değiştirme Başarılı");
                            return error;
                        }
                    }
                }
            }
            catch (Exception)
            {
                error.AddErrors(ErrorMessageCode.PasswordUpdateError, "Şifre Değiştirirken Bir Hata ile Karşılaşıldı");
                return error;
            }
            error.AddErrors(ErrorMessageCode.PasswordUpdateError, "Şifre Değiştirme Sırasında Bir Sorun Çıktı");
            return error;

        }

        public async Task<PlatformSettingModelView> GetPlatform(string id)
        {

            try
            {
                var user = await userManager.FindByIdAsync(id);


                PlatformSettingModelView model = new PlatformSettingModelView()
                {
                    BattleNet = user.BattleNetLink,
                    Steam = user.SteamLink,
                    Discord = user.Discord,
                    EpicGames = user.EpicGamesLink,
                    TeamSpeak = user.TeamSpeak,
                    Origin = user.OriginLink,
                    Psn = user.PsnLink,
                    Xbox = user.XboxLink
                };
                if (model != null)
                {
                    return model;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return null;
        }
        public async Task<ErrorMessage> UpdatePlatform(PlatformSettingModelView model, string userid)
        {
            ErrorMessage message = new ErrorMessage();
            try
            {
                var user = await userManager.FindByIdAsync(userid);
                if (user == null)
                {
                    message.AddErrors(ErrorMessageCode.UserNotFound, "Kullanıcı Bulunamadı");
                    return message;
                }
                if (user != null)
                {
                    user.Discord = model.Discord;
                    user.TeamSpeak = model.TeamSpeak;
                    user.SteamLink = model.Steam;
                    user.OriginLink = model.Origin;
                    user.BattleNetLink = model.BattleNet;
                    user.EpicGamesLink = model.EpicGames;
                    user.XboxLink = model.Xbox;
                    user.PsnLink = model.Psn;
                    var Control = await userManager.UpdateAsync(user);
                    if (Control.Succeeded)
                    {
                        message.AddErrors(ErrorMessageCode.PlatformUpdateSuccess, "Kayıt Başarılı");
                        return message;
                    }
                }
            }
            catch (Exception ex)
            {
                message.AddErrors(ErrorMessageCode.PlatformUpdateError, "HATA:" + ex.Message);
                return message;
            }
            message.AddErrors(ErrorMessageCode.PlatformUpdateError, "Kayıt Başarısız");
            return message;
        }
    }
}
