using System;
using Microsoft.Extensions.Options;
using WaitForIt.Models;

namespace WaitForIt.Services
{
    public class DateCounterService : IDateCounterService
    {
        private readonly FinalDateSettings _finalDateSettings;

        public DateCounterService(IOptions<FinalDateSettings> finalDateSettings)
        {
            _finalDateSettings = finalDateSettings.Value;
        }

        public CurrentMessageViewModel GetCurrentMessage()
        {
            var currentMessageViewModel = new CurrentMessageViewModel
            {
                RemainingDays = GetRemainingDays()
            };
        
            if (currentMessageViewModel.RemainingDays > 0)
            {
                currentMessageViewModel.CurrentMessage = "Do szczególnego dnia pozostało dni: ";
                currentMessageViewModel.ImageUrl = "..\\images\\calendar.gif";
            }
            else if (currentMessageViewModel.RemainingDays < 0)
            {
                currentMessageViewModel.CurrentMessage = "Od szczególnego dnia minęło dni: ";
                currentMessageViewModel.ImageUrl = "..\\images\\after.gif";
                currentMessageViewModel.RemainingDays = currentMessageViewModel.RemainingDays * -1;
            }
            else
            {
                currentMessageViewModel.CurrentMessage = "Ten dzień to dziś!";
                currentMessageViewModel.ImageUrl = "..\\images\\after.gif";
            }

            return currentMessageViewModel;
        }

        private int GetRemainingDays()
        {
            return (_finalDateSettings.FinalDate - DateTime.Today).Days;
        }
    }
}