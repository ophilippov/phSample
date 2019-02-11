using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace phSample.Core
{
    /// <summary>
    /// A view model for the item of the list of tasks
    /// </summary>
    public class TasksListItemViewModel:BaseViewModel
    {

        #region Private members

        /// <summary>
        /// The name of the task
        /// </summary>
        private string mTaskName;

        /// <summary>
        /// Indicates if this task item is currently selected
        /// </summary>
        private bool mIsSelected = false;

        #endregion

        #region Public properties

        /// <summary>
        /// The name of the task
        /// </summary>
        public string TaskName
        {
            get => mTaskName;
            set
            {
                mTaskName = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// Indicates if this task item is currently selected    
        /// </summary>
        public bool IsSelected
        {
            get => mIsSelected;
            set
            {
                mIsSelected = value;
                OnPropertyChanged();
            }
        }

        #endregion

        #region Public commands

        /// <summary>
        /// A command to select this task item
        /// </summary>
        public ICommand SelectCommand { get; set; }

        /// <summary>
        /// A command to unselect this task item
        /// </summary>
        public ICommand UnselectCommand { get; set; }
        #endregion

        #region Constructor

        /// <summary>
        /// A default constructor
        /// </summary>
        public TasksListItemViewModel()
        {
            //Initialize commands
            SelectCommand = new RelayCommand(Select);
            UnselectCommand = new RelayCommand(Unselect);
        }
        #endregion

        #region Public methods

        /// <summary>
        /// Selects current task item
        /// </summary>
        public void Select() => IsSelected = true;


        /// <summary>
        /// Selects current task item
        /// </summary>
        public void Unselect() => IsSelected = false;
        #endregion

    }
}
