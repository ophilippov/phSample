
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media.Media3D;
using HelixToolkit.Wpf;

namespace phSample
{
    /// <summary>
    /// The view model of the Third task
    /// </summary>
    public class ThirdTaskViewModel : BaseViewModel
    {
        #region Private members

        /// <summary>
        /// A flag indicating whether or not the loading message must be shown
        /// </summary>
        private bool mLoadingMessageVisibility = false;

        /// <summary>
        /// A flag indicating if the load command is running
        /// </summary>
        private bool mLoadingIsRunning = false; 
        #endregion

        #region Public properties

        /// <summary>
        /// A collection of 3D objects of the scene
        /// </summary>
        public ObservableCollection<ModelVisual3D> Models { get; set; }

        /// <summary>
        /// A flag indicating if the load command is running
        /// </summary>
        public bool LoadingIsRunning
        {
            get => mLoadingIsRunning;
            set
            {
                mLoadingIsRunning = value;
                OnPropertyChanged();
            }

        }

        /// <summary>
        /// A flag indicating whether or not the loading message must be shown
        /// </summary>
        public bool LoadingMessageVisibility
        {
            get => mLoadingMessageVisibility;
            set
            {
                mLoadingMessageVisibility = value;
                OnPropertyChanged();
            }
        }


        #endregion

        #region Public commands

        /// <summary>
        /// A command to load a 3D model to the Viewport
        /// </summary>
        public ICommand LoadCommand { get; set; }

        /// <summary>
        /// A command to clear the Viewport from previous data
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
            Models = new ObservableCollection<ModelVisual3D>();

        }
        #endregion

        #region Public methods

        /// <summary>
        /// Loads the model to the Viewport
        /// </summary>
        public async void LoadModel()
        {
            await RunCommand(() => LoadingIsRunning, LoadModelFromFileAsync);
            
        }



        /// <summary>
        /// Clears the Vieport from previous data
        /// </summary>
        public virtual void ClearViewport()
        {
            Models.Clear();
        }

        #endregion

        #region Protected methods

        /// <summary>
        /// Loads and displays a 3D model
        /// </summary>
        /// <returns></returns>
        protected virtual async Task LoadModelFromFileAsync()
        {

            DefaultDialogService dialog = new DefaultDialogService();
            if (dialog.OpenFileDialog(@"3d models (*.obj)|*.obj|All files (*.*)|*.*") == true)
            {
                Models.Clear();
                LoadingMessageVisibility = true;

                await Task.Run(() =>
                {
                    // Go to the non-UI thread to perform a complex task
                    ObjFileService objFileService = new ObjFileService();
                    Model3DGroup model = objFileService.Open(dialog.FilePath);

                    //Freeze the model, so it can be accessed from another thread
                    model.Freeze();
                    return model;
                }).ContinueWith((t) =>
                {
                    // Once it is done
                    // Return into the UI thread to perform the UI-related stuff
                    Application.Current.Dispatcher.Invoke(() =>
                    {
                        LoadingMessageVisibility = false;
                        var lights = new DefaultLights();
                        Models.Add(lights);

                        ModelVisual3D visualModel = new ModelVisual3D
                        {
                            Content = t.Result
                        };
                        Models.Add(visualModel);
                    });
                });
            }
        } 
        #endregion
    }
}
