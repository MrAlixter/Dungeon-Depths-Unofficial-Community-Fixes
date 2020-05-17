using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scripts
{
    public interface IPlayerHealthMaster
    {
        void update_health_bar();
        void update_mana_bar();
        void update_hunger_bar();
        void update_all_bars();
    }
}
