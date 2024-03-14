using OOPBugerKing_3Tekrar.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPBugerKing_3Tekrar.Models
{
    public class Siparis : BaseEntity
    {
        public Siparis(string ad) // Bu içerisine Aldığı string Ad Base Entitydeki Ad'ı temsil edecek içerisinde ve Siparişi yazdırırken bunu kullanacağız.
        {
            Malzemeleri = new List<EkstraMalzeme>(); // Ekstra Malzeme listesinin instancesini aldık null referens exception'dan kurtulmak için.
            Ad = ad;
        }

        public HamburgerMenusu SecilenMenu { get; set; } // Her Siparişin Bir Hamburger'i olacağı için Bunu property olarak ekledik.

        public decimal Adet { get; set; } // Hamburgerin Adedini'de seçeceği için Bunu'da property olarak ekledik.

        public Boyut Boyut { get; set; } // Seçilen Hamburgerin Boyutu'da olacağı için Ve bu Boyutlandırmaları Enum'dan alacağı için onu da ekledik.

        public List<EkstraMalzeme> Malzemeleri { get; set; } // Burada array yerine list kullanma nedenimiz ilgilendiğimiz property'nin içerisine alacağı elemanalrın sayısının değişebilir olmasıdır. Yani buradaki koleksiyon fixed değildir.. Eğer Array kullansaydık bu array sürekli modifiye edilmek zorunda kalacak ve hem sisteme hem de bize yük çıkarıcaktır.. List bizi bu durumdan kurtarmış oldu.

        public void TutarHesapla()
        {
            Fiyat = SecilenMenu.Fiyat; // Siparişimiz , Bir HamburgerMenusu tipindeli property'si aracılığıyla kullanıcı tarafından seçilen menünün fiyatına ulaşıp kendi fiyat'ına önce o seçilen menünun fiyatının atamasını sağlıyor. Yani TutarHesapla metodu çalıştığında ilk görev SeçilenMenu'nün fiyat property'si nin Sipariş'in fiyat property'sine atanması olacak

            switch (Boyut)
            {
                case Boyut.Orta:
                    Fiyat += 1;
                    break;
                case Boyut.Buyuk:
                    Fiyat += 2;
                    break;
            }

            foreach (EkstraMalzeme item in Malzemeleri) // Malzemeler listesinde dönüyoruz her gelen eleman bize ibr Esktra Malzeme olarak geliyor.
            {
                Fiyat += item.Fiyat; // Fiyat'ımıza Extramalzemenin Fiyatnı Ekliyoruz.
            }
            Fiyat *= Adet; // Fiyat = Fiyat * Adet demektir. 
        }

        public override string ToString()
        {
            if (Malzemeleri.Count < 1)
            {
                //Eğer kullanıcı malzeme seçmemişse bu malzemeler yazılmadan direkt menü yazdırılsın istiyoruz.

                return $" {Ad} Kişisine : {SecilenMenu.Ad} Menüsü , X {Adet} , {Boyut} boy , Toplam : {Fiyat:C2}";
            }

            // Kullanıcının seçtiği ekstra malzemelerin (Seçtiyse) isimlerini göstermek istiyoruz 
            string malzemesi = null;

            //Döngümüz burada koleksiyondaki malzemelerin isimlerini yakalayarak yukarıdaki metinsel tipteki değişlenimize atıyacak

            foreach (EkstraMalzeme item in Malzemeleri)
            {
                // Her gelen item bir EkstraMalzeme Tipindedir.
                malzemesi += $"{item.Ad} ,"; 
            }
            // ketçap , mayonez , acısos, -> Şeklinde Bir Çıktıya Sahip Olacak.
            malzemesi = malzemesi.TrimEnd(',') ; // TrimEnd metodu bir metnin sonunadki bir char karakteri silmekle görevliddir.

            return $" {Ad} Kişisine : {SecilenMenu.Ad} Menüsü , X {Adet} , {Boyut} Boy , Sos Tercihleri : ({malzemesi}) Toplam : {Fiyat:C2} ";
        }                                                                // Buradaki Boyut Zaten Enum'ın içerisinde 3'e ayrılıyor Enum'dan Seçmiş Olacağız.

    }
}
