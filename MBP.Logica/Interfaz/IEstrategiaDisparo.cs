using MBP.CapaTransversal.ModelsMVC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MBP.Logica
{
    public interface IEstrategiaDisparo
    {
        int procesarDisparoOnline(DisparoModel disparo);
    }
}
