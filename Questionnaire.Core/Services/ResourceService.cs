using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Windows.ApplicationModel.Resources;
using Windows.System.UserProfile;

namespace Questionnaire.Core.Services
{
    public class ResourceService
    {
        private readonly IList<string> supportLang = new[] {"en-GB"}; 


        public ResourceService()
        {
            string lang = GlobalizationPreferences.Languages[0];

            if (!supportLang.Any(l => l == lang))
                lang = supportLang.First();

            CultureInfo ci = new CultureInfo(GlobalizationPreferences.Languages[0]);


            var data = new ResourceLoader("Questionnaire.Core/en-GB");
        }
    }
}
