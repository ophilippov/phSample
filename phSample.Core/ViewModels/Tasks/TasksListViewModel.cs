using System;
using System.Collections.Generic;
using System.Text;

namespace phSample.Core
{
    /// <summary>
    /// A view model for the list of tasks
    /// </summary>
    public class TasksListViewModel:BaseViewModel
    {
        #region Private members

        /// <summary>
        /// The list of tasks
        /// </summary>
        private List<TasksListItemViewModel> mTasks = null;

        #endregion

        #region Public properties

        /// <summary>
        /// The list of tasks
        /// </summary>
        public List<TasksListItemViewModel> Tasks
        {
            get => mTasks;
            set
            {
                mTasks = value;
                OnPropertyChanged();
            }
        }

        #endregion

        #region Constructor

        /// <summary>
        /// A default constructor
        /// </summary>
        public TasksListViewModel()
        {

        }
        #endregion


    }
}
