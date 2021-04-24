namespace HBCaseStudy.Business.Abstract
{
    public interface IRoverService
    {
        /// <summary>
        /// Start runing robotic rover
        /// </summary>
        /// <param name="roverName"></param>
        /// <param name="startPointHorizontal"></param>
        /// <param name="startPointVertical"></param>
        /// <param name="startDirection"></param>
        /// <param name="destinationCommands"></param>
        void Run(string roverName, int startPointHorizontal, int startPointVertical, string startDirection, string destinationCommands);
    }
}