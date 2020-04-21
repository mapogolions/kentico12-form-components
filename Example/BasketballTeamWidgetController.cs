using System;
using System.Linq;
using System.Web.Mvc;
using Business.Repository.BasketballPlayers;
using Business.Repository.BasketballCoaches;
using Kentico.PageBuilder.Web.Mvc;
using MedioClinic.Controllers.Widgets;
using MedioClinic.Models.Widgets.BasketballTeamWidget;

[assembly:
    RegisterWidget("MedioClinic.Widget.BasketballTeamWidget",
        typeof(BasketballTeamWidgetController),
        "{$MedioClinic.Widget.TeamBasketballWidget.Name$}",
        Description = "{$MedioClinic.Widget.TeamBasketballWidget.Description$}",
        IconClass = "icon-id-cards")]

namespace MedioClinic.Controllers.Widgets
{
    public class BasketballTeamWidgetController : WidgetController<BasketballTeamWidgetProperties>
    {
        protected IBasketballPlayerRepository PlayerRepository { get; }
        protected IBasketballCoachRepository CoachRepository { get; }

        public BasketballTeamWidgetController(IBasketballPlayerRepository playerRepository,
            IBasketballCoachRepository coachRepository)
        {
            PlayerRepository = playerRepository;
            CoachRepository = coachRepository;
        }

        public ActionResult Index()
        {
            var props = GetProperties();
            var playerIds = string.IsNullOrEmpty(props.PlayerIds)
                ? Array.Empty<string>() : props.PlayerIds.Split(',');

            var coach = CoachRepository.GetCoach(props.CoachId);
            var players = PlayerRepository.GetPlayers(playerIds);

            var model = new BasketballTeamWidgetViewModel
            {
                Name = props.Name,
                Coach = new BasketballCoachViewModel {  FullName = coach.FullName },
                Roster = players.Select(it => new BasketballPlayerViewModel
                {
                    FullName = it.FullName, Position = it.Position, Age = it.Age
                })
            };

            return PartialView("Widgets/_BasketballTeamWidget", model);
        }
    }
}
