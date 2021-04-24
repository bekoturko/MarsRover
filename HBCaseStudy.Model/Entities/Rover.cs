namespace HBCaseStudy.Model.Entities
{
    public class Rover
    {
        public Rover()
        {
            Horizontal = 0;
            Vertical = 0;
            Direction = Direction.N;
        }

        public string RoverName { get; set; }

        public int Horizontal { get; set; }

        public int Vertical { get; set; }

        public Direction Direction { get; set; }

        #region factory methods

        public string LocationInfo => $"{Horizontal} {Vertical} {Direction}";

        #endregion
    }
}