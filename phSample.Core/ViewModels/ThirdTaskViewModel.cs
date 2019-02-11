using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace phSample.Core
{
    /// <summary>
    /// The view model of the Third task
    /// </summary>
    public class ThirdTaskViewModel:BaseViewModel
    {
        #region Public commands

        /// <summary>
        /// A command to load a 3D model
        /// </summary>
        public ICommand LoadCommand { get; set; }

        /// <summary>
        /// A command to clear the ViewPort from previous data
        /// </summary>
        public ICommand ClearCommand { get; set; }

        #endregion

        #region Constructor

        /// <summary>
        /// A default constructor
        /// </summary>
        public ThirdTaskViewModel()
        {
            //Initialize commands
            LoadCommand = new RelayCommand(LoadModel);
            ClearCommand = new RelayCommand(ClearViewport);
            
        }
        #endregion

        #region Public methods

        /// <summary>
        /// Loads a 3D model to the Viewport
        /// </summary>
        public void LoadModel()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Clears the Viewport from previous data
        /// </summary>
        public void ClearViewport()
        {
            throw new NotImplementedException();
        }
        #endregion

    }
}
