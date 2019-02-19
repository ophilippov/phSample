
using System;
using System.Threading.Tasks;
using System.Threading;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media.Animation;
using System.Windows.Media.Media3D;

namespace phSample
{
    /// <summary>
    /// The view model of the Fifth task
    /// </summary>
    public class FifthTaskViewModel : ThirdTaskViewModel
    {
        #region Private members

        /// <summary>
        /// A token to cancel runned Animation
        /// </summary>
        private CancellationTokenSource mAnimationCancellationTokenSource;

        /// <summary>
        /// A flag indicating if the animation is running
        /// </summary>
        private bool mAnimationIsRunning = false;
        #endregion

        #region Public properties

        /// <summary>
        /// The offset to start animation with
        /// </summary>
        public double FromOffset { get; set; } = -25;

        /// <summary>
        /// The offset to end animation at
        /// </summary>
        public double ToOffset { get; set; } = 5;
        
        #endregion

        #region Public commands

        /// <summary>
        /// A command to start model animation
        /// </summary>
        public ICommand StartCommand { get; set; }

        /// <summary>
        /// A command to stop model animation
        /// </summary>
        public ICommand StopCommand { get; set; }

        /// <summary>
        /// A flag indicating if the animation is running
        /// </summary>
        public bool AnimationIsRunning
        {
            get => mAnimationIsRunning;
            set
            {
                mAnimationIsRunning = value;
                OnPropertyChanged();
            }
        }
        #endregion

        #region Constructor

        /// <summary>
        /// Default constructor
        /// </summary>
        public FifthTaskViewModel() : base()
        {
            //Initialize commands
            StartCommand = new RelayCommand(async () => await StartAnimation());
            StopCommand = new RelayCommand(StopAnimation);
            
        }
        #endregion

        #region Public methods

        /// <summary>
        /// Performs model animation by Z-axis
        /// </summary>
        /// <returns></returns>
        public async Task StartAnimation()
        {
            AnimationIsRunning = true;
            if (Models.Count > 1 && Models[1] is ModelVisual3D)
            {
                TranslateTransform3D translateTransform = new TranslateTransform3D(0, 0, 0);
                Models[1].Transform = translateTransform;

                DoubleAnimation animation = new DoubleAnimation
                {
                    From = FromOffset,
                    To = ToOffset,
                    Duration = new Duration(new System.TimeSpan(0, 0, 0, 5)),
                    FillBehavior = FillBehavior.Stop,
                    AutoReverse = true,
                    RepeatBehavior = RepeatBehavior.Forever
                };

                translateTransform.BeginAnimation(TranslateTransform3D.OffsetZProperty, animation);

                try
                {
                    mAnimationCancellationTokenSource = new CancellationTokenSource();
                    await Task.Delay(-1, mAnimationCancellationTokenSource.Token);
                }
                catch (OperationCanceledException)
                {
                    if (Models.Count > 1)
                        Models[1].Transform = new TranslateTransform3D(0, 0, translateTransform.OffsetZ);
                }
                finally
                {
                    mAnimationCancellationTokenSource.Dispose();
                    mAnimationCancellationTokenSource = null;
                    AnimationIsRunning = false;
                }

            }
            else
                AnimationIsRunning = false;
            
        }

        /// <summary>
        /// Stops runned animation
        /// </summary>
        public void StopAnimation()
        {

            mAnimationCancellationTokenSource?.Cancel();

        }

        /// <summary>
        /// Clears the Vieport from previous data
        /// </summary>
        public override void ClearViewport()
        {
            StopAnimation();
            base.ClearViewport();
        }

        #endregion 

       
    }
}
