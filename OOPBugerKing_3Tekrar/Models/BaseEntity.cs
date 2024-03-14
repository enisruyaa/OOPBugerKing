using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPBugerKing_3Tekrar.Models
{
    public abstract class BaseEntity
    {
        public string Ad { get; set; }

        public decimal Fiyat { get; set; }

        // Her üründe ürünün adı ve fiyatı olacağı için base entity adında bir abstract sınıf açtık ve bunun tek görevi bizim diğer sınıflarımıza miras göndermektir.

    }
}
