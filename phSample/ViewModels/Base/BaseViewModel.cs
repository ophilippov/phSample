using System;
using System.ComponentModel;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace phSample
{
    /// <summary>
    /// A base view model that fires PropertyChanged events as needed
    /// </summary>
    public class BaseViewModel : INotifyPropertyChanged
    {

        /// <summary>
        /// The event that is fired when any child property changes its value
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Call this to fire a <see cref="PropertyChanged"/> event
        /// </summary>
        /// <param name="propertyName">The name of the property</param>
        protected void OnPropertyChanged([CallerMemberName]string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #region Command helpers

        /// <summary>
        /// Runs a command if the updating flag isn`t set
        /// Once the action is finished if it was run, then the flag is reset to false
        /// </summary>
        /// <param name="updatingFlag">The boolean property flag defines if the command is already running</param>
        /// <param name="action">The action to run if the command is not alresy running</param>
        /// <returns></returns>
        protected async Task RunCommand(Expression<Func<bool>> updatingFlag, Func<Task> action)
        {

            //Check if the flag property is true (meaning the function is alredy running 
            if (updatingFlag.GetPropertyValue()) return;

            //Set the updating flag to true to indicate we are running
            updatingFlag.SetPropertyValue(true);

            try
            {
                //Run the passed in action
                await action();
            }
            finally
            {
                //Set the updating flag back false now it`s finished
                updatingFlag.SetPropertyValue(false);
            }

        }

        /// <summary>
        /// Runs a command if the updating flag isn`t set
        /// Once the action is finished if it was run, then the flag is reset to false
        /// </summary>
        /// <param name="updatingFlag">The boolean property flag defines if the command is already running</param>
        /// <param name="action">The action to run if the command is not alresy running</param>
        /// <returns></returns>
        protected async Task RunCommandAsync(Expression<Func<bool>> updatingFlag, Func<Task> action)
        {

            //Check if the flag property is true (meaning the function is alredy running 
            if (updatingFlag.GetPropertyValue()) return;

            //Set the updating flag to true to indicate we are running
            updatingFlag.SetPropertyValue(true);

            try
            {
                //Run the passed in action
                await action();
            }
            finally
            {
                //Set the updating flag back false now it`s finished
                updatingFlag.SetPropertyValue(false);
            }

        }
        #endregion


    }
}
