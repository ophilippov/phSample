

namespace phSample
{
    /// <summary>
    /// A interface that provides basic file handling features
    /// </summary>
    /// <typeparam name="T">The type of the data to handle</typeparam>
    public interface IFileService<T>
    {
        /// <summary>
        /// Reads a file
        /// </summary>
        /// <param name="filePath">The file path</param>
        /// <returns>Return the data of the <typeparamref name="T"/> type</returns>
        T Open(string filePath);

        /// <summary>
        /// Saves a file
        /// </summary>
        /// <param name="filePath">The file path</param>
        /// <param name="data">A data to save</param>
        void Save(string filePath, T data);
    }
}
