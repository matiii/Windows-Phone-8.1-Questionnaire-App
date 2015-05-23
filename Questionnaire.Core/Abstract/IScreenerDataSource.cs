using Questionnaire.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Questionnaire.Core.Abstract
{
    public interface IScreenerDataSource
    {
        IList<string> GetAllNames();
        IList<Event> GetAllEvents();
    }
}
