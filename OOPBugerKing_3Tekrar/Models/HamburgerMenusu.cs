using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPBugerKing_3Tekrar.Models
{
    public class HamburgerMenusu:BaseEntity
    {
        public string Açıklama { get; set; }

        public override string ToString()
        {
            return $" {Ad} => {Fiyat:C2} "; // Fiyat C2 : ifadesi fiyat proprty'sinin yanında işletim sistemimizin nation'ına göre döviz işareti çıkarmasını sağlar... Decimal'ın özelliğidir.
            // Burdaki Polymorphisim ComboBox'ta yazıırken nasıl görüneceğini göstermek için Kullanılmıştır.
        }
    }
}
