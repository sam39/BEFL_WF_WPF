using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight.Messaging;
using WPF.Infrastrucrure;
using System.Windows.Input;
using System.Management;

namespace WPF.ViewModels
{
    public class compsViewModel: ViewModelBase<BL.Comp>
    {
        protected override bool Filter(object item)
        {
            BL.Comp comp = item as BL.Comp;
            bool result = true;
            if (!string.IsNullOrWhiteSpace(FindText) &&
                !(comp.NetName ?? string.Empty).ToLower().Contains(FindText.ToLower()) &&
                !(comp.CompTypeName ?? string.Empty).ToLower().Contains(FindText.ToLower()) &&
                !(comp.EmpLastName ?? string.Empty).ToLower().Contains(FindText.ToLower()) &&
                !(comp.Id.ToString() ?? string.Empty).ToLower().Contains(FindText.ToLower())
                )
            {
                result = false;
            }
            return result;
        }

        #region Команды
        #region Выбор пользователя
        RelayCommand _setEmp;
        public ICommand SetEmp
        {
            get
            {
                if (_setEmp == null)
                    _setEmp = new RelayCommand(ExecuteSetEmpCommand, CanExecuteSetEmpCommand);
                return _setEmp;
            }
        }

        public void ExecuteSetEmpCommand(object parameter)
        {
            Messenger.Default.Send<PageMessage>
                (new PageMessage { Action = MessageAction.Select, PageType = typeof(View.emps) });


            Messenger.Default.Register(this, new Action<BL.Emp>(SetDepForCurrentEmp));
        }

        private void SetDepForCurrentEmp(BL.Emp emp)
        {
            if (Selected != null)
            {
                if (emp != null)
                {
                    BL.Comp comp = Selected as BL.Comp;
                    //Получаем объект из локального репозитория
                    BL.Emp emp_local = UoW.EmpRepository.GetByID(emp.Id);
                    comp.Emp = emp_local;
                }
                //Отписываемся от сообщения
                Messenger.Default.Unregister(this, new Action<BL.Emp>(SetDepForCurrentEmp));
            }
        }

        public bool CanExecuteSetEmpCommand(object parametr)
        {
            if (EditMode) return true;
            else return false;
        }
        #endregion Выбор пользователя

        #region Выбор Типа
        RelayCommand _setCompType;
        public ICommand SetCompType
        {
            get
            {
                if (_setCompType == null)
                    _setCompType = new RelayCommand(ExecuteSetCompTypeCommand, CanExecuteSetCompTypeCommand);
                return _setCompType;
            }
        }

        public void ExecuteSetCompTypeCommand(object parameter)
        {
            Messenger.Default.Send<>
                (new PageMessage {Action = MessageAction.Select, PageType = typeof(ViewModels.dicdataViewModel)});

            Messenger.Default.Register(this, new Action<BL.DicData>(SetDD));
        }

        private void SetDD(BL.DicData dd)
        {
            if (Selected != null)
            {
                if (dd != null)
                {
                    switch (dd.Dic.Name)
                    {
                        case "ТипСистемы" :
                            BL.Comp comp = Selected as BL.Comp;
                            //Получаем объект из локального репозитория
                            BL.DicData dd_local = UoW.DicDataRepository.GetByID(dd.Id);
                            comp.CompType = dd_local;
                            break;                      
                        default:
                            break;
                    }
                }
                //Отписываемся от сообщения
                Messenger.Default.Unregister(this, new Action<BL.DicData>(SetDD));
            }
        }

        public bool CanExecuteSetCompTypeCommand(object parametr)
        {
            if (EditMode) return true;
            else return false;
        }
        #endregion Выбор Типа

        #region SysInfoUpdate
        RelayCommand _sysInfpUpdate;
        public ICommand SysInfoUpdate
        {
            get
            {
                if (_sysInfpUpdate == null)
                    _sysInfpUpdate = new RelayCommand(ExecuteSysInfoUpdateCommand, CanExecuteSysInfoUpdateCommand);
                return _sysInfpUpdate;
            }
        }

        public void ExecuteSysInfoUpdateCommand(object parameter)
        {
            BL.Comp comp = Selected as BL.Comp;
            if (comp != null)
            {
                Infrastrucrure.Settings settings = Settings.read();
                ConnectionOptions options = new ConnectionOptions();
                options.Username = settings.LoginAdminWS;
                options.Password = settings.PassAdminWS;
                string path = "\\\\" + comp.NetName + "\\root\\CIMV2";

                ManagementScope scope =
                new ManagementScope(
                path, options);

                try
                {
                    scope.Connect();
                    comp.CpuName = getWmiProp("Win32_Processor", new string[] { "Name", "NumberOfCores"}, scope);
                    comp.Memory = getWmiProp("Win32_PhysicalMemory", new string[] { "BankLabel", "Capacity", "Speed" }, scope);
                    comp.Hdd = getWmiProp("Win32_Volume", new string[] { "DriveLetter", "Capacity", "FileSystem" }, scope);
                    comp.MainBoard = getWmiProp("Win32_BaseBoard", new string[] { "Manufacturer", "Product" }, scope);
                    comp.OS = getWmiProp("Win32_OperatingSystem", new string[] { "Caption", "ServicePackMajorVersion" }, scope);
                    comp.Video = getWmiProp("Win32_VideoController", new string[] { "Description" }, scope);
                    comp.CdRom = getWmiProp("Win32_CDROMDrive", new string[] { "Caption" }, scope);
                    comp.Monitor = getWmiProp("Win32_Desktopmonitor", new string[] { "Caption", "ScreenWidth", "ScreenHeight" }, scope);
                }
                catch
                {
                    System.Windows.MessageBox.Show("Невозможно связаться с " + comp.NetName);
                }

            }
        }

        private string getWmiProp(string key, string[] prop, ManagementScope scope)
        {
            ObjectQuery query = new ObjectQuery("SELECT * FROM " + key);
            ManagementObjectSearcher searcher = new ManagementObjectSearcher(scope, query);
            string result = string.Empty;
            foreach (ManagementObject queryObj in searcher.Get())
            {
                if (result != string.Empty) result += "\n";
                foreach (string pr in prop)
                {
                    if (pr == "Capacity")
                        result += Math.Round(System.Convert.ToDouble(queryObj[pr]) / 1024 / 1024 / 1024, 2) + " Gb; ";
                    else
                        result += queryObj[pr] + "; ";
                }

            }
            return result;
        }

        public bool CanExecuteSysInfoUpdateCommand(object parametr)
        {
            if (Selected != null)
                if ((Selected as BL.Comp).NetName != string.Empty) return true;
                else return false;
            else return false;
        }
        #endregion SysInfoUpdate

        #endregion Команды

        public override bool CanExecuteSaveCommand(object parametr)
        {
            bool result = false;
            if (Selected != null)
            {
                if (EditMode && (Selected as BL.Comp).CompType != null)
                    result = true;
            }
            return result;
        }





    }
}
