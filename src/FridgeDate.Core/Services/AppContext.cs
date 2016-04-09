using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FridgeDate.Core.Interfaces;
using FridgeDate.Core.Models;

namespace FridgeDate.Core.Services
{
    public class AppContext: IAppContext
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private User _currentUser;

        public User CurrentUser
        {
            get { return _currentUser; } 
            set {
                if (value != _currentUser)
                {
                    _currentUser = value;
                    OnPropertyChanged("User");
                }
            }
        }

        public virtual void OnPropertyChanged(string propertyName)
        {
            var propertyChanged = PropertyChanged;
            if (propertyChanged != null)
            {
                propertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
