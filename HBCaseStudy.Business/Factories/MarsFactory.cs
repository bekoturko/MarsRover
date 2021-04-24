using HBCaseStudy.Business.Abstract.Factories;
using HBCaseStudy.Model;
using HBCaseStudy.Model.Entities;
using System;
using System.Collections.Generic;

namespace HBCaseStudy.Business.Factories
{
    public class MarsFactory : IMarsFactory
    {
        #region ctor & member

        public MarsFactory()
        {
        }

        #endregion

        public IEnumerable<int> CreatePlateauRectangle(int width, int height)
        {
            return new List<int> { width, height };
        }

        public Rover CreateRover(string roverName, int startPointHorizontal, int startPointVertical, string direction)
        {
            return new Rover
            {
                RoverName = roverName,
                Horizontal = startPointHorizontal,
                Vertical = startPointVertical,
                Direction = (Direction)Enum.Parse(typeof(Direction), direction)
            };
        }
    }
}