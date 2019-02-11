using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace phSample.Core
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

    }
}
