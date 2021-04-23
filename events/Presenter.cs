using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace events
{
    public delegate void PresenterEventHandler(object sender, EventArgs e);
    public delegate void PresentEventHandler(object sender, DisplayEventArgs e);
    class Presenter
    {
        public event PresenterEventHandler PresEvent;
        public event PresentEventHandler PrEvent; 
        public Presenter()
        {
        
        }
        public void Display(object sender, CalcEventArgs ev)
        {
            if (ev.Beg == 0 & ev.End == 0 & ev.Result == 0) {
                PrEvent.Invoke(this, new DisplayEventArgs("Вычисление завершено", true));
            }
            else if (ev.Beg == -1 & ev.End == -1) {
                PrEvent.Invoke(this, new DisplayEventArgs("Идет загрузка " + ev.Result + "%", false));
            }
            else {
                PrEvent.Invoke(this, new DisplayEventArgs("Количество полупростых чисел на интервале [" + ev.Beg + "," + ev.End + "] равно " + ev.Result, true));
            }
        }
        public void Stop()
        {
            PresEvent.Invoke(this, new EventArgs());
        }
    }

    public class DisplayEventArgs : EventArgs
    {
        private string info;
        private bool append;
        public DisplayEventArgs(string inf, bool apnd)
        {
            info = inf;
            append = apnd;
        }
        public string Info
        {
            get { return info; }
        }
        public bool Append
        {
            get { return append; }
        }
    }
}
