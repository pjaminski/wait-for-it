using System;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Options;
using WaitForIt.Models;

namespace WaitForIt.Services
{
    public class DateCounterService : IDateCounterService
    {
        private readonly FinalDateSettings _finalDateSettings;
        private readonly IStringLocalizer _localizer;

        public DateCounterService(IOptions<FinalDateSettings> finalDateSettings, IStringLocalizerFactory stringLocalizerFactory)
        {
            _finalDateSettings = finalDateSettings.Value;
            _localizer = stringLocalizerFactory.Create("Messages",
                System.Reflection.Assembly.GetExecutingAssembly().GetName().Name);
        }

        public CurrentMessageViewModel GetCurrentMessage()
        {
            var currentMessageViewModel = new CurrentMessageViewModel
            {
                RemainingDays = GetRemainingDays()
            };
        
            if (currentMessageViewModel.RemainingDays > 0)
            {
                currentMessageViewModel.CurrentMessage = $"{_localizer["BeforeDateMessage"]}:";
                currentMessageViewModel.ImageUrl = "..\\images\\calendar.gif";
            }
            else if (currentMessageViewModel.RemainingDays < 0)
            {
                currentMessageViewModel.CurrentMessage = $"{_localizer["AfterDateMessage"]}:";
                currentMessageViewModel.ImageUrl = "..\\images\\after.gif";
                currentMessageViewModel.RemainingDays = currentMessageViewModel.RemainingDays * -1;
            }
            else
            {
                currentMessageViewModel.CurrentMessage = _localizer["ThisDateMessage"];
                currentMessageViewModel.ImageUrl = "..\\images\\heart.gif";
            }

            return currentMessageViewModel;
        }

        private int GetRemainingDays()
        {
            return (_finalDateSettings.FinalDate - DateTime.Today).Days;
        }
    }
}