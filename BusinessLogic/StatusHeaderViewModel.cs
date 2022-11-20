using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Common;

namespace BusinessLogic
{
    public enum Status
    {
        UpToDate,
        Updating,
        Error,
    }
    public interface IStatusHeaderViewModel
    {
        Status Status { get; }
    }
    public class StatusHeaderViewModel : ViewModelBase, IStatusHeaderViewModel
    {
        private Status _status;
        public ActionCommand UpdateCommand { get; }

        public Status Status
        {
            get => _status;
            set
            {
                _status = value;
                OnPropertyChanged();
            }
        }

        public StatusHeaderViewModel()
        {
            UpdateCommand = new ActionCommand(OnUpdate);
        }

        private async void OnUpdate(object obj)
        {
            if (Status == Status.Updating)
                return;
            Status = Status.Updating;
            try
            {
                await OnUpdate();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                Status = Status.Error;
            }
            Status = Status.UpToDate;
        }

        private async Task OnUpdate()
        {
            //emulate some async procedure
            await Task.Delay(3000);
        }
    }
}
