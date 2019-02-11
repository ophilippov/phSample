using System;
using System.Windows.Input;

namespace phSample.Core

{

    /// <summary>
    /// A basic command to run an Action
    /// </summary>
    public class RelayCommand : ICommand
    {
        #region Public members

        /// <summary>
        /// The action to run
        /// </summary>
        private readonly Action mActionExecute = null;

        /// <summary>
        /// The condition (predicate) indicating when the action could be runned
        /// </summary>
        private readonly Predicate<object> mCanExecute = null;
        #endregion

        #region Public events

        /// <summary>
        /// The event that is fired when changes occur that affect 
        /// whether or not the command should execute
        /// </summary>
        public event EventHandler CanExecuteChanged;

        #endregion

        #region Constructors

        /// <summary>
        /// Creates a command that can always be executed
        /// </summary>
        /// <param name="action">The action to execute</param>
        public RelayCommand(Action action)
            : this(action, null) { }

        /// <summary>
        /// Creates a command that can be executed when <paramref name="canExecute"/> is set to true
        /// </summary>
        /// <param name="action">The action to execute</param>
        /// <param name="canExecute">The condition (predicate) indicating when the action could be runned</param>
        public RelayCommand(Action action, Predicate<object> canExecute)
        {
            mActionExecute = action;
            mCanExecute = canExecute;
        }
        #endregion

        #region Command Methods

        /// <summary>
        /// The method that determines whether the command can execute in its current state
        /// </summary>
        /// <param name="parameter"> Data used by the command.
        /// If the command does not require data to be passed,
        /// this object can be set to null</param>
        /// <returns>Returns true if the action can be executed, otherwise false</returns>
        public bool CanExecute(object parameter)
        {
            return mCanExecute != null ? mCanExecute(parameter) : true;
        }


        /// <summary>
        /// The method to be called when the command is invoked
        /// </summary>
        /// <param name="parameter"> Data used by the command.
        /// If the command does not require data to be passed,
        /// this object can be set to null</param>
        public void Execute(object parameter)
        {
            mActionExecute?.Invoke();
        }


        /// <summary>
        ///  Call this to fire a<see cref="CanExecuteChanged"/> event
        /// </summary>
        public void OnCanExecuteChanged()
        {
            CanExecuteChanged?.Invoke(this, EventArgs.Empty);
        }
        
        #endregion


    }
}
