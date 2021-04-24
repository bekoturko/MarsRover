using HBCaseStudy.Model.Entities;
using System.Collections.Generic;

namespace HBCaseStudy.Business.Abstract.Factories
{
    public interface IMarsFactory
    {
        /// <summary>
        /// Create Plateau Rectangle Grid Area
        /// </summary>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <returns></returns>
        IEnumerable<int> CreatePlateauRectangle(int width, int height);

        /// <summary>
        /// Create Rover with starting position
        /// </summary>
        /// <param name="roverName"></param>
        /// <param name="startPointHorizontal"></param>
        /// <param name="startPointVertical"></param>
        /// <param name="direction"></param>
        /// <returns></returns>
        Rover CreateRover(string roverName, int startPointHorizontal, int startPointVertical, string direction);
    }
}