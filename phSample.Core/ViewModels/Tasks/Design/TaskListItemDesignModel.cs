
namespace phSample.Core
{
    /// <summary>
    /// A class that provides a design data for the TaskListItemControl
    /// </summary>
    public class TaskListItemDesignModel:TasksListItemViewModel
    {
        #region Singleton

        /// <summary>
        /// A single static instance of this class
        /// </summary>
        public static TaskListItemDesignModel Instance => new TaskListItemDesignModel();

        #endregion

        #region Constructor

        /// <summary>
        /// Public constructor
        /// </summary>
        public TaskListItemDesignModel()
        {
            TaskName = "Some task";
        }

        #endregion

    }
}
