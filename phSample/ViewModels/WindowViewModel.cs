
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace phSample
{
    /// <summary>
    /// The view model for the custom flat window
    /// </summary>
    public class WindowViewModel:BaseViewModel
    {
        #region Private Members

        /// <summary>
        /// The window this view model controls
        /// </summary>
        private Window mWindow;

        /// <summary>
        /// The margin around the window to allow for a drop shadow
        /// </summary>
        private int mOuterMarginSize = 15;

        /// <summary>
        /// The smallest width the window can go to
        /// </summary>
        private double mWindowMinimumWidth = 1000;

        /// <summary>
        /// The smallest height the window can go to
        /// </summary>
        private double mWindowMinimumHeight = 600;

        /// <summary>
        /// The height of the title bar / caption of the window 
        /// </summary>
        private int mTitleHeight = 25;
        #endregion

        #region Public properties

        /// <summary>
        /// The smallest width the window can go to
        /// </summary>
        public double WindowMinimumWidth {
            get => mWindowMinimumWidth;
            set
            {
                mWindowMinimumWidth = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// The smallest height the window can go to
        /// </summary>
        public double WindowMinimumHeight {
            get => mWindowMinimumHeight;
            set
            {
                mWindowMinimumHeight = value;
                OnPropertyChanged();
            }
        }


        /// <summary>
        /// The size of the resize border around the window,
        /// taking into account the outer margin
        /// </summary>
        public int ResizeBorderSize => ((mWindow.WindowState == WindowState.Maximized) ? 0 : 6) + OuterMarginSize;

       
        
        /// <summary>
        /// The margin around the window to allow for a drop shadow
        /// </summary>
        public int OuterMarginSize
        {
            get => mWindow.WindowState == WindowState.Maximized ? 0 : mOuterMarginSize;
            
            set
            {
                mOuterMarginSize = value;
                OnPropertyChanged();
            }
        }

        

        /// <summary>
        /// The height of the title bar / caption of the window 
        /// </summary>
        public int TitleHeight {
            get => mTitleHeight;
            set
            {
                mTitleHeight = value;
                OnPropertyChanged();
            }
        }


        #endregion

        #region Commands

        /// <summary>
        /// The command to minimize the window
        /// </summary>
        public ICommand MinimizeCommand { get; set; }

        /// <summary>
        /// The command to maximize the window
        /// </summary>
        public ICommand MaximizeCommand { get; set; }

        /// <summary>
        /// The command to close the window
        /// </summary>
        public ICommand CloseCommand { get; set; }

     
        #endregion


        #region Constructors
        /// <summary>
        /// The default constructor
        /// </summary>
        public WindowViewModel(Window window)
        {
            mWindow = window;

            // Listen out for the window resizing
            mWindow.StateChanged += (sender, e) =>
            {
                // Fire off events for all properties that are affected by a resize
                OnPropertyChanged(nameof(ResizeBorderSize));
                OnPropertyChanged(nameof(OuterMarginSize));
            };

            // Create commands 
            MinimizeCommand = new RelayCommand(() => mWindow.WindowState = WindowState.Minimized);
            MaximizeCommand = new RelayCommand(() => mWindow.WindowState ^= WindowState.Maximized);
            CloseCommand = new RelayCommand(() => mWindow.Close());

          
        }
        #endregion

    }
}
