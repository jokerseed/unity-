using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts
{
    class YellowBird:Bird
    {
        public override void showSkill()
        {
            base.showSkill();
            rg.velocity *= 2;
        }
    }
}
