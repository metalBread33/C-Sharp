﻿using PP.Library.Services;
using PP.Library.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices; //needed for [CallerMemberName]
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace PP.Maui.ViewModels
{
    internal class Add_Edit_ClientVM : INotifyPropertyChanged
    {


        /*This make INotifyPropertyChange works*/
        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
