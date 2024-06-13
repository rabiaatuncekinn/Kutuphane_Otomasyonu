using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
namespace kutuphane_otomasyonu
{
    public class Kitap
    {
        public string ISBN { get; set; }
        public string kitapAdi { get; set; }
        public string yazar { get; set; }
        public int yayinYili { get; set; }
        public bool mevcutMu { get; set; }





    }
    public class Kullanici
    {

        public string kullaniciAdi { get; set; }
        public string kullaniciSoyadi { get; set; }
        public string kullaniciID { get; set; }


        public static List<Kitap> OduncAlinanlar;


        public static Kullanici kullanici = new Kullanici();

        public Kullanici()
        {
            OduncAlinanlar = new List<Kitap>();
        }





        public void AlınanKitapListesi()
        {
            if (Kullanici.OduncAlinanlar.Count == 0)
            {
                Console.WriteLine("Liste Boş");
            }
            foreach (var item in Kullanici.OduncAlinanlar)
            {
                Console.WriteLine(item);
            }

        }




    }
    public class Kutuphane
    {
        //Listeler
        public List<Kitap> Kitaplar;
        public List<Kullanici> Kullanicilar;


        public Kutuphane()
        {
            Kitaplar = new List<Kitap>();
            Kullanicilar = new List<Kullanici>();

        }

        //Fonksiyonlar
        public void kitapEkleme()
        {
            Kitap kitap = new Kitap();

            //Kullanıcıdan Kitap İle İlgili Bilgiler İstenir
            Console.WriteLine("Lütfen eklemek istediğiniz kitabın adını giriniz :");
            kitap.kitapAdi = Console.ReadLine();
            Console.WriteLine("Lütfen kitabın yazarının adını giriniz :");
            kitap.yazar = Console.ReadLine();
            Console.WriteLine("Lütfen kitabın yayın yılını giriniz :");
            kitap.yayinYili = int.Parse(Console.ReadLine());
            Console.WriteLine("Lütfen kitabın ISBN numarasını giriniz :");
            kitap.ISBN = Console.ReadLine();


            //Sisteme Kitap Eklendiğinde Otomatik Olarak Kütüphane Envanterinde Kitap Mevcut Durumu Oluşur
            kitap.mevcutMu = true;

            // Burda Kullanıcı Listesine Eklenecek
            Kitaplar.Add(kitap);

            //Sistem Geri Bildirimi
            Console.WriteLine($"\n-Yeni Kitap Ekeleme Başarılı- \nISBN: {kitap.ISBN}, Kitap Adı: {kitap.kitapAdi}, Yazar: {kitap.yazar}, Yayın Yılı: {kitap.yayinYili}, Mevcut Durumu: {kitap.mevcutMu}");


        }


        public void kitapListeleme()
        {
            //Eğer Listede Birşey Kayıtlı Değilse Bunun Geri Bildirimi Verilir
            if (Kitaplar.Count == 0)
            {
                Console.WriteLine("Listelenecek kitap yok.");

                return;
            }
            //Sistemdeki Kitaplar Liste Yöntemiyle, Listeye Ekleme Sırasına Göre Tek Tek Sıralanır
            foreach (var item in Kitaplar)
            {
                Console.WriteLine($"{Kitaplar.IndexOf(item) + 1}. ISBN: {item.ISBN}, Kitap Adı: {item.kitapAdi}, Yazar: {item.yazar}, Yayın Yılı: {item.yayinYili} , Mevcut Durumu: {item.mevcutMu}");
            }

        }

        public void kullaniciEkleme()
        {
            Kullanici kullanici = new Kullanici();

            //Kullanıcıdan, Kullanıcı İle İlgili Bilgileri İstenir
            Console.WriteLine("Lütfen kullanıcının adını giriniz :");
            kullanici.kullaniciAdi = Console.ReadLine();
            Console.WriteLine("Lütfen kullanıcının soyadını giriniz :");
            kullanici.kullaniciSoyadi = Console.ReadLine();
            Console.WriteLine("Lütfen kullanıcının ID'sini belirleyin :");
            kullanici.kullaniciID = Console.ReadLine();

            // Burda Kullanıcı Listesine Eklenecek
            Kullanicilar.Add(kullanici);

            //Sistem Geri Bildirimi
            Console.WriteLine($"\n-Yeni Kullanıcnı Ekleme Başarılı- \nID: {kullanici.kullaniciID}, Ad: {kullanici.kullaniciAdi}, Soyad: {kullanici.kullaniciSoyadi} ");
        }


        public void kullaniciListeleme()
        {
            if (Kullanicilar.Count == 0)
            {
                Console.WriteLine("Listelenecek Kullanıcı yok.");

                return;
            }
            //Sistemdeki Kitaplar Liste Yöntemiyle, Listeye Ekleme Sırasına Göre Tek Tek Sıralanır
            foreach (var item in Kullanicilar)
            {
                Console.WriteLine($"{Kullanicilar.IndexOf(item) + 1}. Kullanıcı ID: {item.kullaniciID}, Ad: {item.kullaniciAdi}, Soyad: {item.kullaniciSoyadi}");
            }


        }

        public void kitapAlma()
        {

            Kitap kitap = new Kitap();

            Console.WriteLine("Lütfen Kullanıcı ID'nizi giriniz :");
            string OduncID = Console.ReadLine();
            Kullanici kullanici = Kullanicilar.FirstOrDefault(k => k.kullaniciID == OduncID);
            if (!Kullanicilar.Any(k => k.kullaniciID == OduncID))
            {
                Console.WriteLine("Girdiğiniz ID ile eşleşen bir kullanıcı bulunamamıştır.");
                return;
            }

            Console.WriteLine("Lütfen ödünç almak istediğiniz kitabın ISBN bilgisini giriniz :");
            string OduncISBN = Console.ReadLine();
            Kitap kitap1 = Kitaplar.FirstOrDefault(k => k.ISBN == OduncISBN);
            if (!Kitaplar.Any(k => k.ISBN == OduncISBN))
            {
                Console.WriteLine("Girdiğiniz ISBN ile eşleşen bir kitap bulunamamıştır.");
                return;
            }

            if (!kitap1.mevcutMu)
            {
                Console.WriteLine("Aradığınız kitap şu an mevcut değil.");
                return;
            }
            else
            {
                kitap1.mevcutMu = false;
                Console.WriteLine("-Kitap Ödünç Alma Başarılı-");
                Console.WriteLine($"{kitap1.kitapAdi} kitabı {kullanici.kullaniciAdi} {kullanici.kullaniciSoyadi} kullanıcısına ödünç verildi");



                Kullanici.OduncAlinanlar.Add(kitap1);


            }
        }

        public void kitapIade()
        {
            Console.WriteLine("Lütfen iade etmek istediğiniz kitabın ISBN bilgisini giriniz:");
            string iadeISBN = Console.ReadLine();

            // Kitaplar listesinden ISBN ile kitabı buluyoruz
            Kitap kitap2 = Kitaplar.FirstOrDefault(k => k.ISBN == iadeISBN);

            // Kitap bulunamadıysa uyarı mesajı gösteriyoruz
            if (kitap2 == null)
            {
                Console.WriteLine("\nGirdiğiniz ISBN bilgisi yanlış veya kitap bulunamadı. Lütfen geçerli bir değer giriniz.");
                return;
            }

            // Kullanıcının ödünç aldığı kitaplar listesinde bu kitabın olup olmadığını kontrol ediyoruz
            if (Kullanici.OduncAlinanlar.Contains(kitap2))
            {
                kitap2.mevcutMu = true; // Kitabın stok durumunu güncelliyoruz
                Kullanici.OduncAlinanlar.Remove(kitap2); // Kitabı kullanıcının ödünç listesinden çıkarıyoruz
                Console.WriteLine("\n-Kitap İade İşlemi Başarılı-");
                Console.WriteLine($"{kitap2.kitapAdi} adlı kitap iade edilmiştir. Güncel stok durumu (True/False): {kitap2.mevcutMu}");
            }
            else
            {
                // Kitap kullanıcının ödünç aldığı kitaplar arasında bulunmuyorsa uyarı mesajı gösteriyoruz
                Console.WriteLine("\nBu kitabı ödünç almadığınız için iade edemezsiniz.");
            }
        }


        public void kitaplari_dosyaya_yazma()
        {

            if (Kitaplar.Count != 0)
            {
                string dizin = @"C:\Kutuphane Sistemi Listeler Kayit";
                bool dizinVarmi = Directory.Exists(dizin);
                if (!dizinVarmi)
                {
                    Directory.CreateDirectory(dizin);
                }
                string altDizin = @"C:\Kutuphane Sistemi Listeler Kayit\Kitaplar";
                bool altDizinVarmi = Directory.Exists(altDizin);
                if (!altDizinVarmi)
                {
                    Directory.CreateDirectory(altDizin);
                }
                string Kitaplar_txt = @"C:\Kutuphane Sistemi Listeler Kayit\Kitaplar\Kitaplar.txt";

                using (var sw = new StreamWriter(Kitaplar_txt, false))
                {
                    foreach (var item in Kitaplar)
                    {
                        sw.WriteLine($"{Kitaplar.IndexOf(item) + 1}. ISBN: {item.ISBN}, Kitap Adı: {item.kitapAdi}, Yazar: {item.yazar}, Yayın Yılı: {item.yayinYili} , Mevcut Durumu: {item.mevcutMu}");
                    }
                }
                Console.WriteLine("Kitaplar başarıyla kaydedildi.");
            }
            else
            {
                Console.WriteLine("-İşlem Gerçekleştirilemedi-\nLütfen Öncelikle Sisteme Kitap Ekleyiniz");
            }
        }

        public void kitaplari_dosyadan_okuma()
        {
            using (StreamReader sr = new StreamReader(@"C:\Kutuphane Sistemi Listeler Kayit\Kitaplar\Kitaplar.txt", false))
            {
                while (sr.Peek() >= 0)
                {
                    Console.WriteLine(sr.ReadLine());
                }
            }
        }

        public void kullanicilari_dosyaya_yazma()
        {
            if (Kullanicilar.Count != 0)
            {
                string dizin = @"C:\Kutuphane Sistemi Listeler Kayit";
                bool dizinVarmi = Directory.Exists(dizin);
                if (!dizinVarmi)
                {
                    Directory.CreateDirectory(dizin);
                }
                string altDizin = @"C:\Kutuphane Sistemi Listeler Kayit\Kullanicilar";
                bool altDizinVarmi = Directory.Exists(altDizin);
                if (!altDizinVarmi)
                {
                    Directory.CreateDirectory(altDizin);
                }
                string Kullanicilar_txt = @"C:\Kutuphane Sistemi Listeler Kayit\Kullanicilar\Kullanicilar.txt";

                using (var sw = new StreamWriter(Kullanicilar_txt, false))
                {
                    foreach (var item in Kullanicilar)
                    {
                        sw.WriteLine($"{Kullanicilar.IndexOf(item) + 1}. Kullanıcı ID: {item.kullaniciID}, Ad: {item.kullaniciAdi}, Soyad: {item.kullaniciSoyadi}");
                    }
                }
                Console.WriteLine("Kullanıcılar başarıyla kaydedildi.");
            }
            else
            {
                Console.WriteLine("-İşlem Gerçekleştirilemedi-\nLütfen Öncelikle Sisteme Kullanıcı Ekleyiniz");
            }
        }

        public void kullanicilari_dosyadan_okuma()
        {
            using (StreamReader sr = new StreamReader(@"C:\Kutuphane Sistemi Listeler Kayit\Kullanicilar\Kullanicilar.txt", false))
            {
                while (sr.Peek() >= 0)
                {
                    Console.WriteLine(sr.ReadLine());

                }
            }
        }



    }
    public class Program
    {
        public static Kullanici kullanici = new Kullanici();
        public static Kutuphane kutuphane = new Kutuphane();

        static void Main()
        { 

                Console.WriteLine("....Kütüphane Yönetim Sistemine Hoşgeldiniz.... ");
        
            while (true)
            {


                Console.WriteLine("");

                Console.WriteLine("Yapabileceğiniz İşlemler");

                Console.WriteLine("");

                Console.WriteLine("1.Kitap Ekleme");

                Console.WriteLine("2.Kitapları Listeleme");

                Console.WriteLine("3.Kullanıcı Ekleme");

                Console.WriteLine("4.Kullanıcıları Listeleme");

                Console.WriteLine("5.Kitap Ödünç Alma");

                Console.WriteLine("6.Kitap İade Etme");

                Console.WriteLine("7.Kitapları Dosyaya Yazma");

                Console.WriteLine("8.Kitapları Dosyadan Okuma");

                Console.WriteLine("9.Kullanıcıları Dosyaya Yazma");

                Console.WriteLine("10.Kullanıcıları Dosyadan Okuma");

                Console.WriteLine("0.Çıkış");

                Console.WriteLine();

                Console.Write("Lütfen yapmak istediğiniz işlemi girin:");


                int sayi = Convert.ToInt32(Console.ReadLine());


                if (sayi == 0)
                {
                    return;
                }
                else if (sayi == 1)
                {
                    Console.Clear();

                    kutuphane.kitapEkleme();
                    Console.WriteLine("Ana menüye dönmek için herhangi bir tuşa basın.");
                    Console.ReadKey();
                    Console.Clear();
                }
                else if (sayi == 2)
                {
                    Console.Clear();


                    kutuphane.kitapListeleme();
                    Console.WriteLine("Ana menüye dönmek için herhangi bir tuşa basın.");
                    Console.ReadKey();
                    Console.Clear();
                }
                else if (sayi == 3)
                {
                    Console.Clear();

                    kutuphane.kullaniciEkleme();
                    Console.WriteLine("Ana menüye dönmek için herhangi bir tuşa basın.");
                    Console.ReadKey();
                    Console.Clear();
                }
                else if (sayi == 4)
                {
                    Console.Clear();

                    kutuphane.kullaniciListeleme();
                    Console.WriteLine("Ana menüye dönmek için herhangi bir tuşa basın.");
                    Console.ReadKey();
                    Console.Clear();
                }
                else if (sayi == 5)
                {
                    Console.Clear();

                    kutuphane.kitapAlma();
                    Console.WriteLine("Ana menüye dönmek için herhangi bir tuşa basın.");
                    Console.ReadKey();
                    Console.Clear();
                }
                else if (sayi == 6)
                {
                    Console.Clear();

                    kutuphane.kitapIade();
                    Console.WriteLine("Ana menüye dönmek için herhangi bir tuşa basın.");
                    Console.ReadKey();
                    Console.Clear();
                }
                else if (sayi == 7)
                {
                    Console.Clear();

                    kutuphane.kitaplari_dosyaya_yazma();
                    Console.WriteLine("Ana menüye dönmek için herhangi bir tuşa basın.");
                    Console.ReadKey();
                    Console.Clear();
                }
                else if (sayi == 8)
                {
                    Console.Clear();

                    kutuphane.kitaplari_dosyadan_okuma();
                    Console.WriteLine("Ana menüye dönmek için herhangi bir tuşa basın.");
                    Console.ReadKey();
                    Console.Clear();
                }
                else if (sayi == 9)
                {
                    Console.Clear();

                    kutuphane.kullanicilari_dosyaya_yazma();
                    Console.WriteLine("Ana menüye dönmek için herhangi bir tuşa basın.");
                    Console.ReadKey();
                    Console.Clear();
                }
                else if (sayi == 10)
                {
                    Console.Clear();

                    kutuphane.kullanicilari_dosyadan_okuma();
                    Console.WriteLine("Ana menüye dönmek için herhangi bir tuşa basın.");
                    Console.ReadKey();
                    Console.Clear();
                }
                else
                {
                    Console.WriteLine("");
                    Console.WriteLine("");

                    Console.WriteLine("LÜTFEN GEÇERLİ BİR İŞLEM GİRİNİZ");

                    Console.WriteLine("");
                    Console.WriteLine("");


                }






            }
        }
    }
}


  