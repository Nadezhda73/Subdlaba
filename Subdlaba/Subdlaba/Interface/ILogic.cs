using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;


namespace Subdlaba.Interface
{
    public interface ILogic<T>
    {
        List<T> Read();
        void Update(T model);
        void Create(T model);
        void Delete(T model);
        T Get(int Id);
    }
}
