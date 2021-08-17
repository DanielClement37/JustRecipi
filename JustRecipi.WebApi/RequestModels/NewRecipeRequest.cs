using System.Collections.Generic;

namespace JustRecipi.WebApi.RequestModels
{
    public class NewRecipeRequest
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public int PrepTime { get; set; }
        public int CookTime { get; set; }
        public int NumServings { get; set; }
        public List<string> Ingredients { get; set; }
        public List<string> Instructions { get; set; }
    }
}