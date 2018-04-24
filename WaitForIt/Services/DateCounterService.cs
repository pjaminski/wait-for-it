using System;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Options;
using WaitForIt.Models;

namespace WaitForIt.Services
{
    public class DateCounterService : IDateCounterService
    {
        private readonly CustomSettings _customSettings;
        private readonly IStringLocalizer _localizer;

        public DateCounterService(IOptions<CustomSettings> finalDateSettings, IStringLocalizerFactory stringLocalizerFactory)
        {
            _customSettings = finalDateSettings.Value;
            _localizer = stringLocalizerFactory.Create("Messages",
                System.Reflection.Assembly.GetExecutingAssembly().GetName().Name);
        }

        public CurrentMessageViewModel GetCurrentMessage()
        {
            var currentMessageViewModel = new CurrentMessageViewModel
            {
                RemainingDays = GetRemainingDays(),
                AdditionalMessage = _customSettings.AdditionalMessage,
                FinalDate = _customSettings.FinalDate.ToString("dd.MM.yyyy")
            };
        
            if (currentMessageViewModel.RemainingDays > 0)
            {
                currentMessageViewModel.CurrentMessage = $"{_localizer["BeforeDateMessage"]}:";
                currentMessageViewModel.ImageUrl = _customSettings.BeforeDateImg;
            }
            else if (currentMessageViewModel.RemainingDays < 0)
            {
                currentMessageViewModel.CurrentMessage = $"{_localizer["AfterDateMessage"]}:";
                currentMessageViewModel.ImageUrl = _customSettings.AfterDateImg;
                currentMessageViewModel.RemainingDays = currentMessageViewModel.RemainingDays * -1;
            }
            else
            {
                currentMessageViewModel.CurrentMessage = _localizer["ThisDateMessage"];
                currentMessageViewModel.ImageUrl = _customSettings.ThisDateImg;
            }

            return currentMessageViewModel;
        }

        private int GetRemainingDays()
        {
            return (_customSettings.FinalDate - DateTime.Today).Days;
        }
    }
}