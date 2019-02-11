using System;
using System.Windows.Input;

namespace phSample
{
    /// <summary>
    /// A view model for the item of the list of tasks
    /// </summary>
    public class TasksListItemViewModel : BaseViewModel
    {

        #region Private members

        /// <summary>
        /// The currently selected item
        /// </summary>
        private static TasksListItemViewModel mCurrentlySelectedItem = null;
        

        /// <summary>
        /// The name of the task
        /// </summary>
        private string mTaskName;

        /// <summary>
        /// Indicates if this task item is currently selected
        /// </summary>
        private bool mIsSelected = false;

        #endregion

        #region Public events

        /// <summary>
        /// The event that is fired when item selection is changed
        /// </summary>
        public static event EventHandler SelectionChanged;

        #endregion

        #region Public properties

        /// <summary>
        /// The name of the task
        /// </summary>
        public string Name
        {
            get => mTaskName;
            set
            {
                mTaskName = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// The type of the task
        /// </summary>
        public TaskType Type { get; set; }

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


        #endregion

        #region Constructor

        /// <summary>
        /// A default constructor
        /// </summary>
        public TasksListItemViewModel()
        {
            //Initialize commands
            SelectCommand = new RelayCommand(Select);
            
        }
        #endregion

        #region Public methods

        /// <summary>
        /// Selects current task item
        /// </summary>
        public void Select()
        {

            //If this item is currently selected, do nothing
            if (mCurrentlySelectedItem == this)
                return;

            //Unselect previous item
            if (mCurrentlySelectedItem != null)
                mCurrentlySelectedItem.IsSelected = false;


            //Set this item to be currently selected
            IsSelected = true;
            mCurrentlySelectedItem = this;

            OnSelectionChanged();


        }
        #endregion

        #region Protected methods

        /// <summary>
        /// Call this to fire a <see cref="SelectionChanged"/> event
        /// </summary>
        protected void OnSelectionChanged()
        {
            SelectionChanged?.Invoke(this, EventArgs.Empty);
        }
        #endregion

    }
}
