using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HerosAndGoblins.AI
{
    public interface AIBase
    {
        void Execute(EntityCharacter character, Form form);

        void ExecuteTick(EntityCharacter character, Form form);
    }
}
