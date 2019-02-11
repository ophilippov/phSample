using System;
using System.Windows.Media.Media3D;
using HelixToolkit.Wpf;

namespace phSample
{
    /// <summary>
    /// A class that provides basic handling files of the type *.obj
    /// </summary>
    public class ObjFileService : IFileService<Model3DGroup>
    {
        /// <summary>
        /// Reads a file
        /// </summary>
        /// <param name="filePath">The file path</param>
        /// <returns>Return the data of the <see cref="Model3DGroup"/> type</returns>
        public Model3DGroup Open(string filePath)
        {
            var objLoader = new ObjReader();
            return objLoader.Read(filePath);
        }

        /// <summary>
        /// Saves a file
        /// </summary>
        /// <param name="filePath">The file path</param>
        /// <param name="data">A data to save</param>
        public void Save(string filePath, Model3DGroup data)
        {
            throw new NotImplementedException();
        }
    }
}
