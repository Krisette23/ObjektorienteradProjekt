using BookU_ClassLibrary.Models;
using BookU_GUILayer.ViewModels.Command.UserCommand;
using System;

namespace BookU_GUILayer.ViewModels.ForUserControls
{
    public class UserViewModel : ViewModelBase
    {
        public User ThisUser { get; set; }
        private AddFriend_btnCommand _addFriend_Btn;
        public AddFriend_btnCommand AddFriend_Btn
        {
            get => _addFriend_Btn;
            set
            {
                _addFriend_Btn = value;
                OnPropertyChanged("AddFriend_Btn");
            }
        }

        private RemoveFriend_btnCommand _removeFriend_Btn;
        public RemoveFriend_btnCommand RemoveFriend_Btn
        {
            get => _removeFriend_Btn;
            set
            {
                _removeFriend_Btn = value;
                OnPropertyChanged("RemoveFriend_Btn");
            }
        }

        public UserViewModel(User user)
        {
            ThisUser = user;
            AddFriend_Btn = new AddFriend_btnCommand(this);
            RemoveFriend_Btn = new RemoveFriend_btnCommand(this);
        }

        public string Name => ThisUser.Name;
        public DateTime Birthday => ThisUser.BirthDate;
        public string SNum => ThisUser.SNumber;
        public string Attending => ThisUser.AttendingProgram;
    }
}
