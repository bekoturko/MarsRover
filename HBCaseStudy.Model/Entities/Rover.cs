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

        public void SetDirectionNorth()
        {
            Direction = Direction.N;
        }

        public void SetDirectionSouth()
        {
            Direction = Direction.S;
        }

        public void SetDirectionEast()
        {
            Direction = Direction.E;
        }

        public void SetDirectionWest()
        {
            Direction = Direction.W;
        }

        public void SetVerticalIncrease()
        {
            Vertical += 1;
        }

        public void SetVerticalDecrease()
        {
            Vertical -= 1;
        }

        public void SetHorizontalIncrease()
        {
            Horizontal += 1;
        }

        public void SetHorizontalDecrease()
        {
            Horizontal -= 1;
        }

        #endregion
    }
}