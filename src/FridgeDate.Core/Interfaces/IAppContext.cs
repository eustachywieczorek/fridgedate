using System.ComponentModel;
using FridgeDate.Core.Models;

namespace FridgeDate.Core.Interfaces
{
    public interface IAppContext : INotifyPropertyChanged
    {
        User CurrentUser { get; set; }
    }
}