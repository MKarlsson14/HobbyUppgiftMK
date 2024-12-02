using HobbyUppgiftMK.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HobbyUppgiftMK.ViewModels
{
    class HobbyItemVM : ViewModelBase
    {
        private readonly Hobby model;

        public HobbyItemVM(Hobby model)
        {
            this.model = model;
        }

        public string Name
        {
            get { return model.Name; }
            set
            {
                model.Name = value;
                RaisePropertyChanged();
            }
        }
    }
}
