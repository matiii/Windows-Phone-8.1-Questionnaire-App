using System.Collections.Generic;
using System.Linq;
using System.Resources;
using Questionnaire.Core.Abstract;
using Questionnaire.Core.Model;
using Windows.ApplicationModel.Resources;
using Windows.System.UserProfile;
using System.Globalization;

namespace Questionnaire.Core.Dal
{
    public class ScreenerDataSource: IScreenerDataSource
    {
        public IList<string> GetAllNames()
        {
            return new[] { "Mateusz", "Lesio", "Adam" }.ToList();
        }

        public IList<Event> GetAllEvents()
        {
            
            string value = data.GetString("Demo");
            return new[] { 
                new Event { Id = 1, Name = "Demo 1" },
                new Event { Id = 2, Name = "Cemo 1" },
                new Event { Id = 3, Name = "Eemo 1" },
                new Event { Id = 4, Name = "Femo 2" }
            }.ToList();
        }
    }
}
