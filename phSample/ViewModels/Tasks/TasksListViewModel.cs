using System;
using System.Collections.Generic;
using System.Text;

namespace phSample
{
    /// <summary>
    /// A view model for the list of tasks
    /// </summary>
    public class TasksListViewModel : BaseViewModel
    {
        #region Private members

        /// <summary>
        /// The list of tasks
        /// </summary>
        private List<TasksListItemViewModel> mTasks = null;


        #endregion

        #region Public events

        /// <summary>
        /// The event that is fired when item selection is changed
        /// </summary>
        public event EventHandler SelectionChanged;

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
            TasksListItemViewModel.SelectionChanged += TaskListItemSelectionChanged;
        }

        #endregion

        #region Protected methods

        /// <summary>
        /// Call this to fire a <see cref="SelectionChanged"/> event
        /// </summary>
        /// <param name="item">Selected item</param>
        /// <param name="e"></param>
        protected void OnSelectionChanged(TasksListItemViewModel item, EventArgs e)
        {
            SelectionChanged?.Invoke(item, e);
        }

        #endregion

        #region Private methods

        /// <summary>
        /// Fires off <see cref="SelectionChanged"/> event
        /// when <see cref="TasksListItemViewModel.SelectionChanged"/> is fired
        /// </summary>
        /// <param name="sender">Selected item</param>
        /// <param name="e"></param>
        private void TaskListItemSelectionChanged(object sender, EventArgs e)
        {
            if (sender is TasksListItemViewModel)
                OnSelectionChanged(sender as TasksListItemViewModel, e);
        }

        #endregion



    }
}
