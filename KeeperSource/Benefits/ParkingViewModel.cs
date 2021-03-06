﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Windows.Input;

using KeeperRichClient.Modules.Employees;
using KeeperRichClient.Infrastructure;

using Microsoft.Practices.Prism.PubSubEvents;
using Microsoft.Practices.ServiceLocation;

using System.Windows.Forms;

using System.Windows.Input;

namespace KeeperRichClient.Modules.Benefits
{
    public class ParkingViewModel : IParkingViewModel, INotifyPropertyChanged
    {
        IEventAggregator _EventAggregator;
        DbContext _DbContext = new DbContext();
        GetEmployeesResult SelectedEmployee;

        public ParkingViewModel()
        {
            _EventAggregator = ApplicationService.Instance.EventAggregator;
            _EventAggregator.GetEvent<EmployeeSelectedEvent>().Subscribe(this._EmployeeSelected, true);
            IsPaidByEmployee = true;
        }

        void _EmployeeSelected(GetEmployeesResult Employee)
        {
            SelectedEmployee = Employee;
            
            Parking CurrentEmpParking = (from pe in _DbContext.ParkingPlacesToEmployees
                                         join pp in _DbContext.ParkingPlaces on pe.ParkingPlaceID equals pp.ParkingPlaceID into pp_join
                                         from pp in pp_join.DefaultIfEmpty()
                                         join p in _DbContext.Parkings on pp.ParkingID equals p.ParkingID
                                         where
                                           pe.EmployeeID == SelectedEmployee.EmployeeID &&
                                           pe.TakingDate == null
                                         select p).SingleOrDefault();                                         

            CurrentParking = CurrentEmpParking;

            ParkingPlace res = (from pe in _DbContext.ParkingPlacesToEmployees
                                join pp in _DbContext.ParkingPlaces on pe.ParkingPlaceID equals pp.ParkingPlaceID into pp_join
                                from pp in pp_join.DefaultIfEmpty()
                                join p in _DbContext.Parkings on pp.ParkingID equals p.ParkingID
                                where
                                  pe.EmployeeID == SelectedEmployee.EmployeeID &&
                                  pe.TakingDate == null
                                select pp).SingleOrDefault();


            CurrentParkingPlace = res;

            //_ClearNewSaveData();

        }
        
        Parking _CurrentParking;
        public Parking CurrentParking
        {
            get
            {
                return _CurrentParking;
            }
            set
            {
                _CurrentParking = value;
                RaisePropertyChanged("CurrentParking");
            }
        }

        ParkingPlace _CurrentParkingPlace;
        public ParkingPlace CurrentParkingPlace
        {
            get
            {
                return _CurrentParkingPlace;
            }
            set
            {
                _CurrentParkingPlace = value;
                RaisePropertyChanged("CurrentParkingPlace");
            }
        }

        fParksWithFreePlacesResult _SelectedParking;
        public fParksWithFreePlacesResult SelectedParking
        {
            get { return _SelectedParking; }
            set 
            {
                _SelectedParking = value;
                RaisePropertyChanged("SelectedParking");
                RaisePropertyChanged("AvailableParkingPlaces");
            }
        }
        ParkingPlace _SelectedParkingPlace;
        public ParkingPlace SelectedParkingPlace
        {
            get { return _SelectedParkingPlace; }
            set
            {
                _SelectedParkingPlace = value;
                RaisePropertyChanged("SelectedParkingPlace");
            }
        }

        bool isPaidByEmployee;
        public bool IsPaidByEmployee
        {
            get { return isPaidByEmployee; }
            set { isPaidByEmployee = value; RaisePropertyChanged("IsPaidByEmployee"); }
        }

        bool isIncludedInLimit;
        public bool IsIncludedInLimit
        {
            get { return isIncludedInLimit; }
            set { isIncludedInLimit = value; RaisePropertyChanged("IsIncludedInLimit"); }
        }

        ObservableCollection<fParksWithFreePlacesResult> _AvailableParkings = null;
        public ObservableCollection<fParksWithFreePlacesResult> AvailableParkings
        {
            get
            {
                return new ObservableCollection<fParksWithFreePlacesResult>(_DbContext.fParksWithFreePlaces());
            }
        }        
        

        ObservableCollection<ParkingPlace> _AvailableParkingPlaces;
        public ObservableCollection<ParkingPlace> AvailableParkingPlaces
        {
            get
            {
                if (SelectedParking != null)
                {
                    _AvailableParkingPlaces = new ObservableCollection<ParkingPlace>(from p in _DbContext.ParkingPlaces
                                                                                     where
                                                                                       p.ParkingID == SelectedParking.ParkingID && !
                                                                                         ((from pe in _DbContext.ParkingPlacesToEmployees
                                                                                           where
                                                                                             p.ParkingPlaceID == pe.ParkingPlaceID &&
                                                                                             pe.TakingDate == null &&
                                                                                             pe.AssignDate != null
                                                                                           select new
                                                                                           {
                                                                                               pe
                                                                                           }).Single() != null)
                                                                                     select p);
                    return _AvailableParkingPlaces;
                }
                else
                    return null;
            }
        }


        ICommand _CallSaveParkingPlace;
        public ICommand CallSaveParkingPlace
        {
            get
            {
                if (_CallSaveParkingPlace == null)
                {
                    _CallSaveParkingPlace = new RelayCommand(action => _SaveParkingPlace(), predicate => this._IsSaveCallable());
                }
                return _CallSaveParkingPlace;
            }
        }

        bool _IsSaveCallable()
        {
            if (SelectedEmployee == null) return false;
            return (this._SelectedParking != null && 
                    this._SelectedParkingPlace != null && 
                    this.SelectedEmployee.EmployeeID != 0
                    );
        }
        void _SaveParkingPlace()
        {
            try
            {
                _DbContext.spSaveParkingPlace(employeeId: SelectedEmployee.EmployeeID, parkingPlaceId: SelectedParkingPlace.ParkingPlaceID, isIncludedInLimit: IsIncludedInLimit);
                _EmployeeSelected(SelectedEmployee);
                _ClearNewSaveData();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }


        void _ClearNewSaveData()
        {
            SelectedParking = null;
            SelectedParkingPlace = null;
            IsIncludedInLimit = true;
        }

        ICommand _CallTakeParkingPlace;
        public ICommand CallTakeParkingPlace
        {
            get
            {
                if (_CallTakeParkingPlace == null)
                {
                    _CallTakeParkingPlace = new RelayCommand(action => this._TakeParkingPlace(), predicate => this._IsTakePlaceCallable());
                }
                return _CallTakeParkingPlace;
            }
        }

        bool _IsTakePlaceCallable()
        {
            return (this.CurrentParking != null && this.CurrentParkingPlace != null);
        }


        void _TakeParkingPlace()
        {
           try 
	{	        
		 _DbContext.spTakeParkingPlace(employeeId: SelectedEmployee.EmployeeID, parkingPlaceId: CurrentParkingPlace.ParkingPlaceID);
            RaisePropertyChanged("AvailableParkings");
            RaisePropertyChanged("AvailableParkingPlaces");
            CurrentParking = null;
            CurrentParkingPlace = null;
	}
	catch (Exception e)
	{
        MessageBox.Show(e.Message);
	}
        }

        
        public event PropertyChangedEventHandler PropertyChanged;
        void RaisePropertyChanged(string PropertyName)
        {
            PropertyChangedEventHandler hand = PropertyChanged;
            if (hand != null) hand(this, new PropertyChangedEventArgs(PropertyName));
        }
    }
}
