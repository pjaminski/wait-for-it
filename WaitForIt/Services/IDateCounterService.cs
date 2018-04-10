using WaitForIt.Models;

namespace WaitForIt.Services
{
    public interface IDateCounterService
    {
        CurrentMessageViewModel GetCurrentMessage();
    }
}
