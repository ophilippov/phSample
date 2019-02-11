
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Media3D;
using HelixToolkit.Wpf;

namespace phSample
{
    /// <summary>
    /// The view model of the Fourth task
    /// </summary>
    public class FourthTaskViewModel : ThirdTaskViewModel
    {
        /// <summary>
        /// Loads and displays a 3D model with its bounding box
        /// </summary>
        /// <returns></returns>
        protected override async Task LoadModelFromFileAsync()
        {
            await base.LoadModelFromFileAsync();
            
            // Create a bounding box around the model
            var box = new BoundingBoxVisual3D {
                BoundingBox = Models[1].Content.Bounds,
                Fill = BrushHelper.CreateGrayBrush(50)
            };
           
            Models.Add(box);

            // TODO: add lines outgoing from the center of each plane of the bounding box 
        }
    }
}
