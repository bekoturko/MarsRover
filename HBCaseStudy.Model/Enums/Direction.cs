using System.ComponentModel.DataAnnotations;

namespace HBCaseStudy.Model
{
    /// <summary>
    /// Rover Directions
    /// </summary>
    public enum Direction
    {
        [Display(Name = "North")]
        N,

        [Display(Name = "South")]
        S,

        [Display(Name = "East")]
        E,

        [Display(Name = "West")]
        W
    }
}