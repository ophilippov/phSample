
using System;
using System.Windows;
using Microsoft.Win32;

namespace phSample
{
    /// <summary>
    /// A class that provides basic dialog interaction features for file handling
    /// using Win32 approach
    /// </summary>
    public class DefaultDialogService : IDialogService
    {
        /// <summary>
        /// A path to the file to proceed
        /// </summary>
        public string FilePath { get; set; }

        /// <summary>
        /// Shows a dialog to open the file
        /// </summary>
        /// <returns>True if the OpenFileDialog is successfully completed, otherwise false</returns>
        public bool OpenFileDialog(string initialDirectory = "", string filter = "", int filterIndex = 1)
        {
           
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = string.IsNullOrWhiteSpace(initialDirectory) ? @"e:\" : initialDirectory;
            openFileDialog.Filter = string.IsNullOrWhiteSpace(filter) ? @"All files (*.*)|*.*" : filter;
            openFileDialog.FilterIndex = filterIndex;
            openFileDialog.Multiselect = false;

            try
            {
                if (openFileDialog.ShowDialog() == true)
                {
                    FilePath = openFileDialog.FileName;
                    return true;
                }
                return false;
            }
            catch(Exception ex)
            {
                ShowMessage($"An exception was occured during the file opening operation. {ex.Message}");
                return false;
            }
            

        }

        /// <summary>
        /// Shows a dialog to save the file
        /// </summary>
        /// <returns>True if the SaveFileDialog is successfully completed, otherwise false</returns>
        public bool SaveFileDialog(string initialDirectory = "", string filter = "", int filterIndex = 1)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.InitialDirectory = string.IsNullOrWhiteSpace(initialDirectory) ? @"e:\" : initialDirectory;
            saveFileDialog.Filter = string.IsNullOrWhiteSpace(filter) ? @"All files (*.*)|*.*" : filter;
            saveFileDialog.FilterIndex = filterIndex;

            try
            {
                if (saveFileDialog.ShowDialog() == true)
                {
                    FilePath = saveFileDialog.FileName;
                    return true;
                }
                return false;
            }
            catch(Exception ex)
            {
                ShowMessage($"An exception was occured during the file saving operation. {ex.Message}");
                return false;
            }
        }

        /// <summary>
        /// Shows a message to the user
        /// </summary>
        /// <param name="message">The message to show</param>
        public void ShowMessage(string message)
        {
            MessageBox.Show(message);
        }
    }
}
