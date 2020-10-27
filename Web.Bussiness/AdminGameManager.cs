using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using Web.Core.Message;
using Web.DataAccess.Abstract;
using Web.Entity;
using Web.Entity.ModelView.Panel;

namespace Web.Business
{
    public class AdminGameManager
    {
        IUnitOfWork repo;
        UserManager<ApplicationUser> userManager;
        public AdminGameManager(UserManager<ApplicationUser> _userManager, IUnitOfWork _repo)
        {
            userManager = _userManager;
            repo = _repo;
        }

        public ErrorMessage CreateGame(PanelGameModel model, bool update)
        {
            ErrorMessage message = new ErrorMessage();
            Games newgame = new Games()
            {
                Description = model.Content,
                Name = model.Name,
                Img = model.Image
            };
            List<GameRole> role = new List<GameRole>();
            for (int i = 0; i < model.Roles.Count(); i++)
            {
                role.Add(new GameRole() { Games = newgame, RolesID = model.Roles[i] });
            }
            List<GameRank> rank = new List<GameRank>();
            for (int i = 0; i < model.Ranks.Count(); i++)
            {
                rank.Add(new GameRank() { Games = newgame, RankID = model.Ranks[i] });
            }
            List<GameTags> tag = new List<GameTags>();
            for (int i = 0; i < model.Tags.Count(); i++)
            {
                tag.Add(new GameTags() { Games = newgame, TagsID = model.Tags[i] });
            }
            newgame.GameRanks = rank;
            newgame.GameRoles = role;
            newgame.GameTags = tag;
            if (update)
            {

                Games games = repo.Games.Find(x => x.Name == model.Name).FirstOrDefault();
                newgame.ID = games.ID;
                newgame.Name = model.Name;
                newgame.Img = model.Image;
                newgame.Description = model.Content;

                var result = repo.Games.Update(newgame);
                if (result > 0)
                {
                    message.AddErrors(ErrorMessageCode.AddGameSuccess, "Güncelleme Başarılı");
                    return message;
                }
                message.AddErrors(ErrorMessageCode.AddGameError, "Kayıt Sırasında Sorun Oluştu");
                return message;
            }
            else
            {
                var result = repo.Games.Create(newgame);
                if (result > 0)
                {
                    message.AddErrors(ErrorMessageCode.AddGameSuccess, "Kayıt Başarılı");
                    return message;
                }
                message.AddErrors(ErrorMessageCode.AddGameError, "Kayıt Sırasında Sorun Oluştu");
                return message;
            }

        }

        public ErrorMessage CreateOrUpdate(PanelGameModel model, bool update, int? ID)
        {
            Games Gamemodel = new Games()
            {
                Description = model.Content,
                ID = model.ID,
                Img = model.Image,
                Name = model.Name
            };
            List<GameRole> role = new List<GameRole>();
            for (int i = 0; i < model.Roles.Count(); i++)
            {
                role.Add(new GameRole { Games = Gamemodel, GamesID = Gamemodel.ID, RolesID = model.Roles[i] });
            }
            List<GameRank> rank = new List<GameRank>();
            for (int i = 0; i < model.Ranks.Count(); i++)
            {
                rank.Add(new GameRank { Games = Gamemodel, GamesID = Gamemodel.ID, RankID = model.Ranks[i] });
            }
            List<GameTags> tag = new List<GameTags>();
            for (int i = 0; i < model.Tags.Count(); i++)
            {
                tag.Add(new GameTags { Games = Gamemodel, GamesID = Gamemodel.ID, TagsID = model.Tags[i] });
            }
            Gamemodel.GameRanks = rank;
            Gamemodel.GameRoles = role;
            Gamemodel.GameTags = tag;
            ErrorMessage message = new ErrorMessage();
            if (update)
            {
                var games = repo.Games.FindGameWithAllByID((int)ID);
                games.Img = Gamemodel.Img;
                games.Name = Gamemodel.Name;
                games.Description = Gamemodel.Description;
                games.GameRanks = rank;
                games.GameRoles = role;
                games.GameTags = tag;
                var updatecontrol = repo.Games.Update(games);
                if (updatecontrol > 0)
                    message.AddErrors(ErrorMessageCode.AddGameSuccess, "Güncelleme Başarılı");
                else
                    message.AddErrors(ErrorMessageCode.AddGameError, "Güncelleme Sırasında Bir Sorun Oluştu");

            }
            else
            {
                var createcontrol = repo.Games.Create(Gamemodel);
                if (createcontrol > 0)
                    message.AddErrors(ErrorMessageCode.AddGameSuccess, "Kayıt Başarılı");
                else
                    message.AddErrors(ErrorMessageCode.AddGameError, "Kayıt Sırasında Bir Sorun Oluştu");
            }
            return message;
        }
        public bool ControlGame(string gamename)
        {
            var game = repo.Games.Find(x => x.Name == gamename).Select(a => a.Name).FirstOrDefault();
            if (game != null)
            {
                return false;
            }
            return true;
        }
        public PanelGameModel GetGameByName(string gamename)
        {

            var game = repo.Games.FindGameWithAll(gamename);
            List<int> taglist = new List<int>();
            List<int> rolelist = new List<int>();
            List<int> ranklist = new List<int>();

            foreach (var ranks in game.GameRanks)
            {
                ranklist.Add(ranks.RankID);
            }

            foreach (var roles in game.GameRoles)
            {
                rolelist.Add(roles.RolesID);
            }

            foreach (var tags in game.GameTags)
            {
                taglist.Add(tags.TagsID);
            }
            PanelGameModel model = new PanelGameModel()
            {
                ID = game.ID,
                Content = game.Description,
                Image = game.Img,
                Name = game.Name,
                Ranks = ranklist.ToArray(),
                Roles = rolelist.ToArray(),
                Tags = taglist.ToArray(),
            };

            return model;
        }

        public bool DeleteGame(int id)
        {

            try
            {
                var game = repo.Games.FindGameWithAllByID(id);
                var result = repo.Games.Delete(game);
                if (result > 0)
                {
                    return true;
                }
                return false;
            }
            catch (Exception)
            {

                throw;
            }

        }
        public GetContentListModel GetContentList()
        {
            var role = repo.Roles.GetAll().ToList();
            var rank = repo.Ranks.GetAll().ToList();
            var tag = repo.Tag.GetAll().ToList();
            GetContentListModel list = new GetContentListModel()
            {
                Ranks = rank,
                Roles = role,
                Tags = tag
            };
            return list;
        }
        public PanelGameMainModel GetGameMainPage()
        {
            try
            {
                PanelGameMainModel model = new PanelGameMainModel();
                var gamelist = repo.Games.GetAll().Select(a => new PanelTableGameModel()
                {
                    ID = a.ID,
                    Name = a.Name
                }).ToList();
                model.Games = gamelist;
                return model;
            }
            catch (Exception)
            {

                throw;
            }

        }
        public PanelGameRoleModelView GetRolesPage()
        {
            try
            {
                var list = repo.Roles.GetAll().ToList();
                PanelGameRoleModelView model = new PanelGameRoleModelView()
                {
                    Roles = list,

                };
                return model;
            }
            catch (Exception)
            {

                throw;
            }

        }
        public PanelGameRankModelView GetRankPage()
        {
            try
            {
                var list = repo.Ranks.GetAll().ToList();
                PanelGameRankModelView model = new PanelGameRankModelView()
                {
                    Ranks = list,

                };
                return model;
            }
            catch (Exception)
            {

                throw;
            }

        }
        public PanelGameTagModelView GetTagPage()
        {
            try
            {
                var list = repo.Tag.GetAll().ToList();
                PanelGameTagModelView model = new PanelGameTagModelView()
                {
                    Tags = list
                };
                return model;
            }
            catch (Exception)
            {

                throw;
            }

        }
        /* Roles */
        public ErrorMessage AddRoles(string rolename)
        {
            try
            {
                ErrorMessage message = new ErrorMessage();
                Roles role = new Roles();
                role.Role = rolename;
                if (repo.Roles.FindRoles(role))
                {
                    var result = repo.Roles.Create(role);
                    if (result > 0)
                    {
                        message.AddErrors(ErrorMessageCode.AddRoleSuccess, "Kayıt Başarılı");
                        return message;
                    }
                    message.AddErrors(ErrorMessageCode.AddRoleError, "Kayıt Sırasında Bir Sorun Oluştu");
                    return message;

                }
                else
                {
                    message.AddErrors(ErrorMessageCode.AddRoleError, "Böyle Bir Rol Bulunuyor");
                    return message;
                }

            }
            catch (Exception)
            {

                throw;
            }

        }
        public bool DeleteRoles(int[] roleID)
        {
            try
            {
                List<Roles> rolelist = new List<Roles>();
                foreach (var id in roleID)
                {
                    rolelist.Add(repo.Roles.Find(x => x.ID == id).FirstOrDefault());

                }
                repo.Roles.DeleteRolesByID(rolelist);
                return true;
            }
            catch (Exception)
            {

                return false;
            }


        }
        public bool UpdateRoles(PanelGameExtraModel model)
        {
            try
            {
                var roles = repo.Roles.Find(x => x.ID == model.ID).FirstOrDefault();
                roles.Role = model.Name;
                var result = repo.Roles.Update(roles);
                if (result > 0)
                    return true;
                else
                    return false;
            }
            catch (Exception)
            {

                throw;
            }



        }
        /* Rank */
        public ErrorMessage AddRank(string rankname)
        {
            ErrorMessage message = new ErrorMessage();
            try
            {
                Rank rank = new Rank();
                rank.Ranks = rankname;
                if (repo.Ranks.FindRank(rank))
                {
                    var result = repo.Ranks.Create(rank);
                    if (result > 0)
                    {
                        message.AddErrors(ErrorMessageCode.AddRoleSuccess, "Kayıt Başarılı");
                        return message;
                    }
                    message.AddErrors(ErrorMessageCode.AddRoleError, "Kayıt Sırasında Bir Sorun Oluştu");
                    return message;

                }
                else
                {
                    message.AddErrors(ErrorMessageCode.AddRoleError, "Böyle Bir Rol Bulunuyor");
                    return message;
                }
            }
            catch (Exception)
            {

                throw;
            }
            return message;
        }
        public bool DeleteRanks(int[] rankID)
        {
            try
            {
                List<Rank> ranklist = new List<Rank>();
                foreach (var id in rankID)
                {
                    ranklist.Add(repo.Ranks.Find(x => x.ID == id).FirstOrDefault());

                }
                repo.Ranks.DeleteRankByID(ranklist);
                return true;
            }
            catch (Exception)
            {

                return false;
            }


        }
        public bool UpdateRank(PanelGameExtraModel model)
        {
            try
            {
                var rank = repo.Ranks.Find(x => x.ID == model.ID).FirstOrDefault();
                rank.Ranks = model.Name;
                var result = repo.Ranks.Update(rank);
                if (result > 0)
                    return true;
                else
                    return false;
            }
            catch (Exception)
            {

                throw;
            }



        }
        /* Tag */
        public ErrorMessage AddTag(string tagname)
        {
            ErrorMessage message = new ErrorMessage();
            try
            {
                Tags tag = new Tags();
                tag.Tag = tagname;
                if (repo.Tag.FindTag(tag))
                {
                    var result = repo.Tag.Create(tag);
                    if (result > 0)
                    {
                        message.AddErrors(ErrorMessageCode.AddRoleSuccess, "Kayıt Başarılı");
                        return message;
                    }
                    message.AddErrors(ErrorMessageCode.AddRoleError, "Kayıt Sırasında Bir Sorun Oluştu");
                    return message;

                }
                else
                {
                    message.AddErrors(ErrorMessageCode.AddRoleError, "Böyle Bir Tag Bulunuyor");
                    return message;
                }
            }
            catch (Exception)
            {

                throw;
            }
            return message;
        }
        public bool DeleteTags(int[] TagID)
        {
            try
            {
                List<Tags> taglist = new List<Tags>();
                foreach (var id in TagID)
                {
                    taglist.Add(repo.Tag.Find(x => x.ID == id).FirstOrDefault());

                }
                repo.Tag.DeleteTagByID(taglist);
                return true;
            }
            catch (Exception)
            {

                return false;
            }


        }
        public bool UpdateTag(PanelGameExtraModel model)
        {
            try
            {
                var tag = repo.Tag.Find(x => x.ID == model.ID).FirstOrDefault();
                tag.Tag = model.Name;
                var result = repo.Tag.Update(tag);
                if (result > 0)
                    return true;
                else
                    return false;
            }
            catch (Exception)
            {

                throw;
            }
        


        }
    }
}
