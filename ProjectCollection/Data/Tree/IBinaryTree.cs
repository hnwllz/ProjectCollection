using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectCollection.Data
{
    public interface IBinaryTree<T>
    {
        void Add(T value);
        void Remove(T value);
        bool Exists(T value);
    }
}
