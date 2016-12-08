using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPF.Infrastrucrure;
using System.Windows.Input;

namespace WPF.ViewModels
{
    public class settingsViewModel
    {
        private Infrastrucrure.Settings  _settings;
        public Infrastrucrure.Settings  Settings
        {
            get
            {
                if (_settings == null)
                    _settings = Settings.read();
                return _settings;
            }
        }

        #region Сохранить
        RelayCommand _saveCommand;
        public ICommand Save
        {
            get
            {
                if (_saveCommand == null)
                    _saveCommand = new RelayCommand(ExecuteSaveCommand, CanExecuteSaveCommand);
                return _saveCommand;
            }
        }

        public void ExecuteSaveCommand(object parameter)
        {
            if (Settings != null) Settings.save();  
        }

        public bool CanExecuteSaveCommand(object parametr)
        {
            return true;
        }
        #endregion Сохранить
    }
}
