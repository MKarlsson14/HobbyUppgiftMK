using HobbyUppgiftMK.Command;
using HobbyUppgiftMK.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HobbyUppgiftMK.ViewModels
{
    class HobbyVM : ViewModelBase
    {
           
        private HobbyItemVM selectedHobby;

        public HobbyItemVM SelectedHobby
        {
            get { return selectedHobby; }
            set
            {
                selectedHobby = value;
                RaisePropertyChanged();
            }
        }

        private string hobbyName;
        public string HobbyName
        {
            get { return hobbyName; }
            set
            {
                if (hobbyName != value) { hobbyName = value; }
                RaisePropertyChanged();
            }
        }

        private ObservableCollection<HobbyItemVM> hobbies = new();
        public ObservableCollection<HobbyItemVM> Hobbies
        {
            get { return hobbies; }
            set
            {
                hobbies = value;
                RaisePropertyChanged();
            }
        }

        public DelegateCommand AddCommand { get; }
        public DelegateCommand RemoveCommand { get; }

        public HobbyVM()
        {
            hobbies.Add(new HobbyItemVM(new Hobby() { Name = "Fotboll" }));
            hobbies.Add(new HobbyItemVM(new Hobby() { Name = "Hockey" }));
            hobbies.Add(new HobbyItemVM(new Hobby() { Name = "Golf" }));
            AddCommand = new DelegateCommand(AddHobby, CanAdd);
            RemoveCommand = new DelegateCommand(RemoveHobby, CanRemove);
        }

        public async Task LoadAsync()
        {
            if (Hobbies.Any()) return;
        }

        private bool CanAdd(object? parameter) => !string.IsNullOrWhiteSpace(HobbyName);


        private void AddHobby(object? parameter)
        {
            var hobby = new Hobby() { Name = HobbyName };
            Hobbies.Add(new HobbyItemVM(hobby));
            HobbyName = string.Empty;
        }
        private bool CanRemove(object? parameter)
        {
            if (SelectedHobby is not null) return true;            
            else return false;

        }

        private void RemoveHobby(object? parameter)
        {
            hobbies.Remove(SelectedHobby);
        }

    }
}
