
using System.Collections.Generic;

namespace phSample.Core
{
    /// <summary>
    /// A class that provides a design data for the TasksListControl
    /// </summary>
    public class TaskListDesignModel:TasksListViewModel
    {
        #region Singleton

        /// <summary>
        /// A single static instance of this class
        /// </summary>
        public static TaskListDesignModel Instance => new TaskListDesignModel();

        #endregion

        #region Constructor

        /// <summary>
        /// Public constructor
        /// </summary>
        public TaskListDesignModel()
        {
            Tasks = new List<TasksListItemViewModel>
            {
                new TasksListItemViewModel
                {
                    TaskName="dTask 1",
                    IsSelected=false
                },
                new TasksListItemViewModel
                {
                    TaskName="dTask 2",
                    IsSelected=true
                },
                new TasksListItemViewModel
                {
                    TaskName="dTask 3",
                    IsSelected=false
                },
                new TasksListItemViewModel
                {
                    TaskName="dTask 3",
                    IsSelected=false
                }
            };
        }

        #endregion

    }
}
