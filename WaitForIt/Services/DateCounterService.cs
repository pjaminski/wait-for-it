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
            var crrentMessageViewModel = new CurrentMessageViewModel
            {
                RemainingDays = GetRemainingDays()
            };
        
            if (crrentMessageViewModel.RemainingDays > 0)
            {

            }
            else if (crrentMessageViewModel.RemainingDays < 0)
            {

            }
            else
            {

            }

            return crrentMessageViewModel;
        }

        private int GetRemainingDays()
        {
            return (_finalDateSettings.FinalDate - DateTime.Today).Days;
        }
    }
}