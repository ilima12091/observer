using System.Collections.Generic;

namespace Observer
{
    public interface IObserver
    {
        void Update(Temperature temperature);
    }
}