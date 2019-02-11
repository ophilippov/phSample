
using System;
using System.Collections.Generic;
using System.Text;

namespace phSample
{
    /// <summary>
    /// The main view model of the application
    /// </summary>
    public class MainViewModel : BaseViewModel
    {
        #region Private members

        /// <summary>
        /// A view model for the currently selected task
        /// </summary>
        private BaseViewModel mSelectedTaskViewModel;


        #endregion


        #region Public properties

        /// <summary>
        /// A view model for the currently selected task
        /// </summary>
        public BaseViewModel SelectedTaskViewModel
        {
            get => mSelectedTaskViewModel;
            set
            {
                mSelectedTaskViewModel = value;
                OnPropertyChanged();
            }
        }


        /// <summary>
        /// The view model for the list of tasks
        /// </summary>
        public TasksListViewModel TaskListViewModel { get; private set; }

        #endregion

        #region Constructor

        /// <summary>
        /// A default constructor
        /// </summary>
        public MainViewModel()
        {
            TaskListViewModel = new TasksListViewModel
            {
                Tasks = new List<TasksListItemViewModel>
                {
                    new TasksListItemViewModel
                    {
                        Name = "task 3",
                        Type = TaskType.Task3
                    },
                    new TasksListItemViewModel
                    {
                        Name = "task 4",
                        Type = TaskType.Task4
                    },
                    new TasksListItemViewModel
                    {
                        Name = "task 5",
                        Type = TaskType.Task5
                    }
                }
            };

            //Hook into the SelectionChanged event 
            TaskListViewModel.SelectionChanged += UpdateSelectedTaskViewModel;
        }

        /// <summary>
        /// Updates the task view model according to the currently selected item in the tasks list
        /// </summary>
        /// <param name="sender">Selected tasks list item</param>
        /// <param name="e"></param>
        private void UpdateSelectedTaskViewModel(object sender, EventArgs e)
        {
            if (sender is TasksListItemViewModel)
            {
                var item = sender as TasksListItemViewModel;
                switch (item.Type)
                {
                    case TaskType.Task3:
                        SelectedTaskViewModel = new ThirdTaskViewModel();
                        break;
                    case TaskType.Task4:
                        SelectedTaskViewModel = new FourthTaskViewModel();
                        break;
                    case TaskType.Task5:
                        SelectedTaskViewModel = new FifthTaskViewModel();
                        break;
                    default:
                        SelectedTaskViewModel = new ThirdTaskViewModel();
                        break;
                }
            }
        }

        #endregion

    }
}
