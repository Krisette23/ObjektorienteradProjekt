using BookU_ClassLibrary.Models;
using BookU_GUILayer.ViewModels.Command.HomeCommand;

namespace BookU_GUILayer.ViewModels.ForUserControls
{
    class FriendViewModel : ViewModelBase
    {
        public FriendViewModel(User user)
        {
            Name = user.Name;
            Profile_Btn = new Profile_btnCommand(user);
        }
        public string Name { get; }
        public Profile_btnCommand Profile_Btn { get; set; }
    }
}
