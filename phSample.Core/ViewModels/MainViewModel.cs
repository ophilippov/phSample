using System;
using System.Collections.Generic;
using System.Text;

namespace phSample.Core
{
    /// <summary>
    /// The main view model of the application
    /// </summary>
    public class MainViewModel:BaseViewModel
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

        #endregion

    }
}
