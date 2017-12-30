using System;
using System.Collections.Generic;
using System.Text;

namespace Push.Sample
{
    public interface ILogService
    {
        void Info(string TAG, string message);
    }
}
