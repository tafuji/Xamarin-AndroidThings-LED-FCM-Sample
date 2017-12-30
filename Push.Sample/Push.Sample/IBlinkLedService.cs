using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Push.Sample
{
    public interface IBlinkLedService
    {
        Task BlinkLed(int interval);
    }
}
