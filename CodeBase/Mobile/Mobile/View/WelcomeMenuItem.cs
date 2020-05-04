using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mobile.View
{
    public class WelcomeMenuItem
    {
        public WelcomeMenuItem()
        {
            TargetType = typeof(WelcomeDetail);
        }
        public int Id { get; set; }
        public string Icon { get; set; }
        public string Title { get; set; }

        public Type TargetType { get; set; }
    }
}
