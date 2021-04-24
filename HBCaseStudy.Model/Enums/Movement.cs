using System.ComponentModel.DataAnnotations;

namespace HBCaseStudy.Model
{
    /// <summary>
    /// Rotate Rover or Move Forward Commands
    /// </summary>
    public enum Movement
    {
        [Display(Name = "Turn Left 90 Degree")]
        L = 1,

        [Display(Name = "Turn Right 90 Degree")]
        R,

        [Display(Name = "Move Forward +1")]
        M
    }
}