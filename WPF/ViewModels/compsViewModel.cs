﻿using System;
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
                !(comp.Id.ToString() ?? string.Empty).ToLower().Contains(FindText.ToLower())
                )
            {
                result = false;
            }
            return result;
        }

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
                ConnectionOptions options = new ConnectionOptions();
                options.Username = "BEFL\\god";
                options.Password = "Yt<jubUjhirbJ,;buf.n!";
                string path = "\\\\" + comp.NetName + "\\root\\CIMV2";

                //ManagementScope scope =
                //new ManagementScope(
                //"\\root\\CIMV2");
                ManagementScope scope =
                new ManagementScope(
                path, options);
                scope.Connect();

                ObjectQuery query = new ObjectQuery(
                           "SELECT * FROM Win32_Processor");
                ManagementObjectSearcher searcher8 =
                    new ManagementObjectSearcher(scope, query);
                string cpu = string.Empty;
                foreach (ManagementObject queryObj in searcher8.Get())
                {
                    cpu = cpu + "" 
                        + queryObj["Name"] 
                        + "; " + queryObj["NumberOfCores"] 
                        + "; " + queryObj["ProcessorId"];
                }
                comp.CpuName = cpu;

                ObjectQuery query1 = new ObjectQuery(
                           "SELECT * FROM Win32_PhysicalMemory");
                ManagementObjectSearcher searcher9 =
                 new ManagementObjectSearcher(scope, query1);

                Console.WriteLine("------------- Win32_PhysicalMemory instance --------");
                string mem = string.Empty;
                foreach (ManagementObject queryObj in searcher9.Get())
                {

                    mem = mem + queryObj["BankLabel"] +"; " + Math.Round(System.Convert.ToDouble(queryObj["Capacity"]) / 1024 / 1024 / 1024, 2) + " Gb; " + queryObj["Speed"] +"\n";
                    //Console.WriteLine("BankLabel: {0} ; Capacity: {1} Gb; Speed: {2} ", queryObj["BankLabel"],
                    //                  Math.Round(System.Convert.ToDouble(queryObj["Capacity"]) / 1024 / 1024 / 1024, 2),
                    //                   queryObj["Speed"]);
                }
                comp.Memory = mem;





                ObjectQuery queryHDD = new ObjectQuery(
                           "SELECT * FROM Win32_Volume");
                ManagementObjectSearcher searcherHDD =
                    new ManagementObjectSearcher(scope, query);
                string hdd = string.Empty;

                foreach (ManagementObject queryObj in searcherHDD.Get())
                {
                    Console.WriteLine("-----------------------------------");
                    Console.WriteLine("Win32_Volume instance");
                    Console.WriteLine("-----------------------------------");
                    Console.WriteLine("Capacity: {0}", queryObj["Capacity"]);
                    Console.WriteLine("Caption: {0}", queryObj["Caption"]);
                    Console.WriteLine("DriveLetter: {0}", queryObj["DriveLetter"]);
                    Console.WriteLine("DriveType: {0}", queryObj["DriveType"]);
                    Console.WriteLine("FileSystem: {0}", queryObj["FileSystem"]);
                    Console.WriteLine("FreeSpace: {0}", queryObj["FreeSpace"]);
                }

                Console.Write("Press any key to continue . . . ");
                Console.ReadKey(true);



            }
        }

        public bool CanExecuteSysInfoUpdateCommand(object parametr)
        {
            if (Selected != null)
                if ((Selected as BL.Comp).NetName != string.Empty) return true;
                else return false;
            else return false;
        }
        #endregion SysInfoUpdate


    }
}
