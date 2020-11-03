using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace WpfApp.Models
{
    public class ApplicationContext
    {
        private ApplicationContext()
        {

        }

        private static ApplicationContext _instance;

        private object _locker = new object();

        public ApplicationContext GetInstance()
        {
            lock (_locker)
            {
               if (_instance == null)
                    _instance = new ApplicationContext();
                return _instance;
            }
        }

        //public ApplicationContext Instance { get; } = new ApplicationContext();
    }
}
