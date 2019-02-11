using System;
using System.Collections.Generic;


namespace phSample
{
    /// <summary>
    /// An interface that provides basic dialog interaction features for file handling
    /// </summary>
    public interface IDialogService
    {
        /// <summary>
        /// Shows a message to the user
        /// </summary>
        /// <param name="message">The message to show</param>
        void ShowMessage(string message);

        /// <summary>
        /// A path to the file to proceed
        /// </summary>
        string FilePath { get; set; }

        /// <summary>
        /// Shows a dialog to open the file
        /// </summary>
        /// <returns>True if the OpenFileDialog is successfully completed, otherwise false</returns>
        bool OpenFileDialog(string initialDirectory = "", string filter = "", int filterIndex=1);

        /// <summary>
        /// Shows a dialog to save the file
        /// </summary>
        /// <returns>True if the SaveFileDialog is successfully completed, otherwise false</returns>
        bool SaveFileDialog(string initialDirectory = "", string filter = "", int filterIndex = 1);

    }
}
