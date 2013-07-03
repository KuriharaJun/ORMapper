using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KORMapper
{
    public class Injector
    {
        public Injector(Type bind)
        {
            // bindより依存Modelの情報取得
        }

        public IDBMapper GetMapping()
        {
            return null;
        }

        public T GetMapping<T>() where T : new()
        {
            return default(T);
        }
    }
}
