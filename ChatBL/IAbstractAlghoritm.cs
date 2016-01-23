using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatBL
{
    
    public interface IAbstractAlghoritm
    {
        string Encoding(string text,int k);
        string Decoding(string text,int k);
    }
}
