using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyConsole
{
    class EventClass<T>
    {
        public delegate void MyEventHandler(T name);
        public event MyEventHandler eventHandler;
        
        public void OnEvent(object o,T t)
        {
            eventHandler?.Invoke(t);
        }

    }
}
