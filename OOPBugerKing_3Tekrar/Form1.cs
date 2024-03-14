using OOPBugerKing_3Tekrar.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OOPBugerKing_3Tekrar
{

    /*
     
                Tag Property'si 

        İstisnasız her kontrol'ün bir Tag Property'si vardır.. Bu property Kontrollere özgü özel bir veri saklamak istediğimizde çok işimize yarar.

        Tag property'sine biz bu örneğimizde 0.50 yazdık ama bilgisayarın diline ve diğer özelliklerine göre değişebileceği için onu , olarak'ta değiştirebiiliriz mesela türkçe olan bilgisayarlarda , kullanmazsak 50 gibi görebiliyor.
    
    */

    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //HamburgerMenusu hm = new HamburgerMenusu();
            //hm.Ad = "Texas SmokeHouse";

            //HamburgerMenusu hm = new HamburgerMenusu
            //{
            //    Ad = "Texas SmokeHouse"
            //};

            //HamburgerMenusu listemizi Object Initializer yöntemi ile instance'lıyoruz

            List<HamburgerMenusu> menuler = new List<HamburgerMenusu>()
            {
                new HamburgerMenusu{Ad = "Texsas SmokedHouse " , Fiyat = 140 , Açıklama = "Gurme menüsünden kızartılmış barbekülü müthiş bir lezzet"},

                new HamburgerMenusu{Ad = "Barbekü Brioche" , Fiyat = 190 , Açıklama = "Meksikalı bir barbekü ateşine hazır mısınız ?"},

                new HamburgerMenusu{Ad = "Crisp Chicken" , Fiyat = 170 , Açıklama = "Tavuklar hiç bu kadar çıtır olmamıştı "} , 

                new HamburgerMenusu{Ad = "Steak House ", Fiyat = 210.10M , Açıklama = "O kadar beğeneceksiniz ki daha fazla ödemek isteyeceksiniz"},

                new HamburgerMenusu {Ad = "Tender Crisp" , Fiyat = 200 , Açıklama = "Hem çıtırı hem de acıyı aldık karşınıza getirdik" }

            };

            //foreach (HamburgerMenusu item in menuler)
            //{
            //    cmbMenuler.Items.Add(item);
            //}

            // Normal şartlarda bunu combo boxa eklemek için foreach ile dönmemiz gerekiyor ama artık yeni bir şey öğreniyoruz.

            cmbMenuler.DataSource = menuler; // Bu kod ile direkt içerisine eklemiş oluyoruz.
            cmbMenuler.SelectedIndex = -1; // Bu kodu yazmamızın sebebi ise direkt olarak hazır olanlardan biri seçili geliyor ve biz bu seçili olarak gelmesin istedik.


        }

        private void cmbMenuler_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbMenuler.SelectedIndex > -1)
            {
                
                lblAciklama.Text = (cmbMenuler.SelectedItem as HamburgerMenusu).Açıklama;
            }

            else lblAciklama.Text = ""; // Bu kodu yazmamızın sebebi bir şey seçili değilken açıklama menüsü boş olsun istememiz

        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            if (cmbMenuler.SelectedIndex < 0)
            {
                MessageBox.Show("Lütfen Bir Menü Seçiniz");
                return;
            }

            Siparis s = new Siparis(txtIsim.Text); // Sipariş Veren Kişinin Adını Sipariş class'ımıza Gönderdik.
            s.SecilenMenu = cmbMenuler.SelectedItem as HamburgerMenusu;
            s.Adet = Convert.ToDecimal(nmrAdet.Value);

            if (rdbBuyuk.Checked) s.Boyut = Enums.Boyut.Buyuk;
            else if (rdbOrta.Checked) s.Boyut = Enums.Boyut.Orta;

            //Unutmayın ki foreach döngü mekanizması döngü parantezleri icerisinde implicit cast yapabilme özelligine sahiptir...Eger casting'te hata almayacagınız bir durum söz konusu ise (Mesela mevcut durumda koleksiyonda sadece CheckBox vardır dolayısıyla hata alınmaz) rahatca bu implicit casting'i kullanabilirsiniz

            foreach (CheckBox item in groupBox1.Controls)
            {
                if (item.Checked)
                {
                    EkstraMalzeme eks = new EkstraMalzeme(); // Ekstra malzmee sınıfının insatancini aldık..
                    eks.Ad = item.Text;
                    eks.Fiyat = Convert.ToDecimal(item.Tag); // Fiyatı checkbox kontrolünün Tag property'sinden aldık.. Tag özelliği bir kontrolün içerisinde istediğimiz tipte (object tipte değer aldığı için) değer tutmamızı sağlar. O kontrolün değer taşıyabileceği özel bir alanı olarak düşünebiliriz. Ancak object olduğu için boxing ve unboxing olayını unutmamamız gerekir...
                    s.Malzemeleri.Add(eks);
                }
            }

            s.TutarHesapla(); // Siparişin Tutarını Hesaplanamsı için bunu yapmalıyız Yoksa hesaplanmaz.
            lstSiparisler.Items.Add(s); // Buradak ise siparişleri list boxa yazdırdık. 

        }

        private void btnCiro_Click(object sender, EventArgs e)
        {
            decimal ciro = 0;
            foreach (Siparis item in lstSiparisler.Items) ciro += item.Fiyat;
            MessageBox.Show($" Bu Günün Cirosu = {ciro} ");
        }
    }
}
