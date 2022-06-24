namespace todo_uygulamasi
{
    public class Board
    {
        private List<Kisi> kisiler = new List<Kisi>();
        private List<Kart> todo = new List<Kart>();
        private List<Kart> inProgress = new List<Kart>();
        private List<Kart> done = new List<Kart>();

        public List<Kisi> Kisiler { get => kisiler; }
        public List<Kart> Todo { get => todo; set => todo = value; }
        public List<Kart> InProgress { get => inProgress; set => inProgress = value; }
        public List<Kart> Done { get => done; set => done = value; }

        public Board()
        {
            kisiler.Add(new Kisi(1, "Ahmet", "Yılmaz", "Yazılım Ekibi"));
            kisiler.Add(new Kisi(2, "Mehmet", "Demir", "Yazılım Ekibi"));
            kisiler.Add(new Kisi(3, "Ayşe", "Çalışkan", "Yazılım Ekibi"));
            kisiler.Add(new Kisi(4, "Buse", "Öztürk", "Yazılım Ekibi"));
            kisiler.Add(new Kisi(5, "Can", "Deniz", "Yazılım Ekibi"));
            kisiler.Add(new Kisi(6, "Yaşar", "Büyük", "Donanım Ekibi"));
            kisiler.Add(new Kisi(7, "Gizem", "Çağdaş", "Donanım Ekibi"));
            kisiler.Add(new Kisi(8, "Umut", "Alp", "Donanım Ekibi"));
            kisiler.Add(new Kisi(9, "Hüseyin", "Kara", "Donanım Ekibi"));
            kisiler.Add(new Kisi(10, "Ramazan", "Türk", "Donanım Ekibi"));
            todo.Add(new Kart("Teknik Servis","Arıza için gelen sayaçların sistemde tutulması",kisiler[0],Buyukluk.S,(todo.Count()+1)));
            inProgress.Add(new Kart("Abone Yönetim Sistemi","Kredi yükleme,silme ve parametre değiştirme vb.",kisiler[1],Buyukluk.M,(inProgress.Count()+1)));
            done.Add(new Kart("Kart Okuma Programı","Kartın içeriğini okuma",kisiler[2],Buyukluk.L,(done.Count()+1)));
        }

        public void Listele()
        {
            Console.Clear();
            Console.WriteLine("TODO Line");
            Console.WriteLine("************************");
            if(Todo.Count()==0)
            {
                Console.WriteLine("~ BOŞ ~");
            }
            else
            {
                foreach (var item in Todo)
                {
                    Console.WriteLine("Başlık      : " + item.Baslik);
                    Console.WriteLine("İçerik      : " + item.Icerik);
                    Console.WriteLine("Atanan Kişi : " + item.AtananKisi.Isim + " " + item.AtananKisi.Soyisim);
                    Console.WriteLine("Büyüklük    : " + item.Buyukluk);
                    if (Todo.Count() > 1 && item != Todo.Last())
                        Console.WriteLine("-");
                }
            }
            Console.WriteLine("\n\nIN PROGRESS Line");
            Console.WriteLine("************************");
            if(InProgress.Count()==0)
            {
                Console.WriteLine("~ BOŞ ~");
            }
            else
            {
                foreach (var item in InProgress)
                {
                    Console.WriteLine("Başlık      : " + item.Baslik);
                    Console.WriteLine("İçerik      : " + item.Icerik);
                    Console.WriteLine("Atanan Kişi : " + item.AtananKisi.Isim + " " + item.AtananKisi.Soyisim);
                    Console.WriteLine("Büyüklük    : " + item.Buyukluk);
                    if (InProgress.Count() > 1 && item != InProgress.Last())
                        Console.WriteLine("-");
                }
            }
            Console.WriteLine("\n\nDONE Line");
            Console.WriteLine("************************");
            if(Done.Count()==0)
            {
                Console.WriteLine("~ BOŞ ~");
            }
            else
            {
                foreach (var item in Done)
                {
                    Console.WriteLine("Başlık      : " + item.Baslik);
                    Console.WriteLine("İçerik      : " + item.Icerik);
                    Console.WriteLine("Atanan Kişi : " + item.AtananKisi.Isim + " " + item.AtananKisi.Soyisim);
                    Console.WriteLine("Büyüklük    : " + item.Buyukluk);
                    if (Done.Count() > 1 && item != Done.Last())
                        Console.WriteLine("-");
                }
            }
        }
        public void KartEkle()
        {
            Console.Clear();
            Listele();
            Kart k = new Kart();
            Console.Write("Başlık Giriniz                                 : ");
            k.Baslik = Console.ReadLine();
            Console.Write("İçerik Giriniz                                 : ");
            k.Icerik = Console.ReadLine();
            Console.Write("Büyüklük Seçiniz -> XS(1),S(2),M(3),L(4),XL(5) : ");
            int buyukluk = int.Parse(Console.ReadLine());
            switch (buyukluk)
            {
                case 1:
                    k.Buyukluk = Buyukluk.XS;
                    break;
                case 2:
                    k.Buyukluk = Buyukluk.S;
                    break;
                case 3:
                    k.Buyukluk = Buyukluk.M;
                    break;
                case 4:
                    k.Buyukluk = Buyukluk.L;
                    break;
                case 5:
                    k.Buyukluk = Buyukluk.XL;
                    break;
                default:
                    Console.WriteLine("Lütfen 1-5 arası bir değer giriniz.");
                    Environment.Exit(0);
                    break;
            }
            foreach(Kisi item in Kisiler)
            {
                Console.WriteLine(item.KisiId+" "+item.Isim+" "+item.Soyisim+" "+item.Takim);
            }
            Console.Write("Kişi Seçiniz                                   : ");
            int id = int.Parse(Console.ReadLine());
            int sonuc = 0;
            foreach (var item in Kisiler)
            {
                if (item.KisiId == id)
                {
                    k.AtananKisi = item;
                    sonuc++;
                }
            }
            if (sonuc == 0)
            {
                Console.WriteLine("Hatalı girişler yaptınız!");
                Environment.Exit(0);
            }
            k.Id = Todo.Count();
            Todo.Add(k);
            Listele();
        }
        public void KartGuncelle()
        {
            Console.Clear();
            Listele();
            int sonuc = 0;
            Console.Write("Lütfen güncellemek istediğiniz kartın başlığını giriniz : ");
            string guncellenecek = Console.ReadLine();
            foreach (Kart item in Todo)
            {
                if (item.Baslik == guncellenecek)
                {
                    sonuc++;
                    Console.Write("Lütfen güncel başlığı giriniz: ");
                    item.Baslik = Console.ReadLine();
                    Console.Write("Lütfen güncel içeriği giriniz: ");
                    item.Icerik = Console.ReadLine();
                    foreach (Kisi kisi in Kisiler)
                    {
                        Console.WriteLine(kisi.KisiId + " " + kisi.Isim + " " + kisi.Soyisim + " " + kisi.Takim);
                    }
                    Console.Write("Lütfen atanacak kişiyi giriniz: ");
                    int id = int.Parse(Console.ReadLine());
                    int sonuc2= 0;
                    foreach (var kisi in Kisiler)
                    {
                        if (kisi.KisiId == id)
                        {
                            item.AtananKisi = kisi;
                            sonuc2++;
                        }
                    }
                    if (sonuc2 == 0)
                    {
                        Console.WriteLine("Hatalı girişler yaptınız!");
                        Environment.Exit(0);
                    }
                    Console.Write("Büyüklük Seçiniz -> XS(1),S(2),M(3),L(4),XL(5) : ");
                    int buyukluk = int.Parse(Console.ReadLine());
                    switch (buyukluk)
                    {
                        case 1:
                            item.Buyukluk = Buyukluk.XS;
                            break;
                        case 2:
                            item.Buyukluk = Buyukluk.S;
                            break;
                        case 3:
                            item.Buyukluk = Buyukluk.M;
                            break;
                        case 4:
                            item.Buyukluk = Buyukluk.L;
                            break;
                        case 5:
                            item.Buyukluk = Buyukluk.XL;
                            break;
                        default:
                            Console.WriteLine("Lütfen 1-5 arası bir değer giriniz.");
                            break;
                    }
                    Listele();
                    break;
                }
            }
            foreach (Kart item in InProgress)
            {
                if (item.Baslik == guncellenecek)
                {
                    sonuc++;
                    Console.Write("Lütfen güncel başlığı giriniz: ");
                    item.Baslik = Console.ReadLine();
                    Console.Write("Lütfen güncel içeriği giriniz: ");
                    item.Icerik = Console.ReadLine();
                    foreach (Kisi kisi in Kisiler)
                    {
                        Console.WriteLine(kisi.KisiId + " " + kisi.Isim + " " + kisi.Soyisim + " " + kisi.Takim);
                    }
                    Console.Write("Lütfen atanacak kişiyi giriniz: ");
                    int id = int.Parse(Console.ReadLine());
                    int sonuc2= 0;
                    foreach (var kisi in Kisiler)
                    {
                        if (kisi.KisiId == id)
                        {
                            item.AtananKisi = kisi;
                            sonuc2++;
                        }
                    }
                    if (sonuc2 == 0)
                    {
                        Console.WriteLine("Hatalı girişler yaptınız!");
                        Environment.Exit(0);
                    }
                    Console.Write("Büyüklük Seçiniz -> XS(1),S(2),M(3),L(4),XL(5) : ");
                    int buyukluk = int.Parse(Console.ReadLine());
                    switch (buyukluk)
                    {
                        case 1:
                            item.Buyukluk = Buyukluk.XS;
                            break;
                        case 2:
                            item.Buyukluk = Buyukluk.S;
                            break;
                        case 3:
                            item.Buyukluk = Buyukluk.M;
                            break;
                        case 4:
                            item.Buyukluk = Buyukluk.L;
                            break;
                        case 5:
                            item.Buyukluk = Buyukluk.XL;
                            break;
                        default:
                            Console.WriteLine("Lütfen 1-5 arası bir değer giriniz.");
                            break;
                    }
                    Listele();
                    break;
                }
            }
            foreach (Kart item in Done)
            {
                if (item.Baslik == guncellenecek)
                {
                    sonuc++;
                    Console.Write("Lütfen güncel başlığı giriniz: ");
                    item.Baslik = Console.ReadLine();
                    Console.Write("Lütfen güncel içeriği giriniz: ");
                    item.Icerik = Console.ReadLine();
                    foreach (Kisi kisi in Kisiler)
                    {
                        Console.WriteLine(kisi.KisiId + " " + kisi.Isim + " " + kisi.Soyisim + " " + kisi.Takim);
                    }
                    Console.Write("Lütfen atanacak kişiyi giriniz: ");
                    int id = int.Parse(Console.ReadLine());
                    int sonuc2= 0;
                    foreach (var kisi in Kisiler)
                    {
                        if (kisi.KisiId == id)
                        {
                            item.AtananKisi = kisi;
                            sonuc2++;
                        }
                    }
                    if (sonuc2 == 0)
                    {
                        Console.WriteLine("Hatalı girişler yaptınız!");
                        Environment.Exit(0);
                    }
                    Console.Write("Büyüklük Seçiniz -> XS(1),S(2),M(3),L(4),XL(5) : ");
                    int buyukluk = int.Parse(Console.ReadLine());
                    switch (buyukluk)
                    {
                        case 1:
                            item.Buyukluk = Buyukluk.XS;
                            break;
                        case 2:
                            item.Buyukluk = Buyukluk.S;
                            break;
                        case 3:
                            item.Buyukluk = Buyukluk.M;
                            break;
                        case 4:
                            item.Buyukluk = Buyukluk.L;
                            break;
                        case 5:
                            item.Buyukluk = Buyukluk.XL;
                            break;
                        default:
                            Console.WriteLine("Lütfen 1-5 arası bir değer giriniz.");
                            break;
                    }
                    Listele();
                    break;
                }
            }
            if (sonuc == 0)
            {
                Console.WriteLine("Aradığınız kriterlere uygun kart board'da bulunamadı. Lütfen bir seçim yapınız.");
                Console.WriteLine("* Güncellemeyi sonlandırmak için  : (1)");
                Console.WriteLine("* Yeniden denemek için            : (2)");
                string secim2 = Console.ReadLine();
                if (secim2 == "2")
                    KartGuncelle();
                else
                    Environment.Exit(0);
            }
        }
        public void KartSil()
        {
            Console.Clear();
            Listele();
            Console.WriteLine("Öncelikle silmek istediğiniz kartı seçmeniz gerekiyor.");
            Console.Write("Lütfen kart başlığını yazınız: ");
            string silinecek = Console.ReadLine();
            int sonuc = 0;
            List<Kart> silinecekler = new List<Kart>();
            foreach (Kart item in Todo)
            {
                if (item.Baslik == silinecek)
                {
                    sonuc++;
                    Console.WriteLine("{0} başlıklı kart board'dan silinmek üzere, onaylıyor musunuz ?(y/n)", item.Baslik);
                    string onay = Console.ReadLine();
                    if (onay == "y")
                    {
                        silinecekler.Add(item);
                    }
                    else if (onay == "n")
                        Environment.Exit(0);
                    Console.Clear();
                    Listele();
                }
            }
            foreach (Kart item in InProgress)
            {
                if (item.Baslik == silinecek)
                {
                    sonuc++;
                    Console.WriteLine("{0} başlıklı kart board'dan silinmek üzere, onaylıyor musunuz ?(y/n)", item.Baslik);
                    string onay = Console.ReadLine();
                    if (onay == "y")
                    {
                        silinecekler.Add(item);
                    }
                    else if (onay == "n")
                        Environment.Exit(0);
                    Console.Clear();
                    Listele();
                }
            }
            foreach (Kart item in Done)
            //for(int i=0;i<Done.Count();i++)
            {
                if (item.Baslik == silinecek)
                {
                    sonuc++;
                    Console.WriteLine("{0} başlıklı kart board'dan silinmek üzere, onaylıyor musunuz ?(y/n)", item.Baslik);
                    string onay = Console.ReadLine();
                    if (onay == "y")
                    {
                        silinecekler.Add(item);
                    }
                    else if (onay == "n")
                        Environment.Exit(0);
                    Console.Clear();
                    Listele();
                }
            }
            if (sonuc > 0)
            {
                silinecekler.ForEach(s =>
                {
                    if (Todo.Contains(s))
                    Todo.Remove(s);
                });
                silinecekler.ForEach(s =>
                {
                    if (InProgress.Contains(s))
                    InProgress.Remove(s);
                });
                silinecekler.ForEach(s =>
                {
                    if (Done.Contains(s))
                    Done.Remove(s);
                });
                Listele();
            }
            else
            {
                Console.WriteLine("Aradığınız kriterlere uygun kart board'da bulunamadı. Lütfen bir seçim yapınız.");
                Console.WriteLine("* Silmeyi sonlandırmak için : (1)");
                Console.WriteLine("* Yeniden denemek için      : (2)");
                string secim = Console.ReadLine();
                if (secim == "2")
                    KartSil();
                else
                    Environment.Exit(0);
            }
        }
        public void KartTasi()
        {
            Console.Clear();
            Listele();
            Console.WriteLine("Öncelikle taşımak istediğiniz kartı seçmeniz gerekiyor.");
            Console.Write("Lütfen kart başlığını yazınız: ");
            string tasinacak = Console.ReadLine();
            int sonuc = 0;
            List<Kart> tasinacaklar = new List<Kart>();
            Console.WriteLine("Bulunan Kart Bilgileri:");
            Console.WriteLine("**************************************");
            for(int i=0;i<Todo.Count();i++)
            {
                if(Todo[i].Baslik == tasinacak)
                {
                    sonuc++;
                    Console.WriteLine("Başlık      : "+Todo[i].Baslik);
                    Console.WriteLine("İçerik      : "+Todo[i].Icerik);
                    Console.WriteLine("Atanan Kişi : "+Todo[i].AtananKisi);
                    Console.WriteLine("Büyüklük    : "+Todo[i].Buyukluk);
                    Console.WriteLine("Line        : TODO");
                    tasinacaklar.Add(Todo[i]);
                }
            }
            for(int i=0;i<InProgress.Count();i++)
            {
                if(InProgress[i].Baslik == tasinacak)
                {
                    sonuc++;
                    Console.WriteLine("\nBaşlık      : "+InProgress[i].Baslik);
                    Console.WriteLine("İçerik      : "+InProgress[i].Icerik);
                    Console.WriteLine("Atanan Kişi : "+InProgress[i].AtananKisi);
                    Console.WriteLine("Büyüklük    : "+InProgress[i].Buyukluk);
                    Console.WriteLine("Line        : INPROGRESS");
                    tasinacaklar.Add(InProgress[i]);
                }
            }
            for(int i=0;i<Done.Count();i++)
            {
                if(Done[i].Baslik == tasinacak)
                {
                    sonuc++;
                    Console.WriteLine("\nBaşlık      : "+Done[i].Baslik);
                    Console.WriteLine("İçerik      : "+Done[i].Icerik);
                    Console.WriteLine("Atanan Kişi : "+Done[i].AtananKisi.Isim+" "+Done[i].AtananKisi.Soyisim);
                    Console.WriteLine("Büyüklük    : "+Done[i].Buyukluk);
                    Console.WriteLine("Line        : DONE");
                    tasinacaklar.Add(Done[i]);
                }
            }
            if(tasinacaklar.Count()>0)
            {
                tasinacaklar.ForEach(s =>
                            {
                                if (Todo.Contains(s))
                                Todo.Remove(s);
                            });
                tasinacaklar.ForEach(s =>
                            {
                                if (InProgress.Contains(s))
                                InProgress.Remove(s);
                            });
                tasinacaklar.ForEach(s =>
                            {
                                if (Done.Contains(s))
                                Done.Remove(s);
                            });
            }
            if(sonuc>0)
            {
                Console.WriteLine("\nLütfen taşımak istediğiniz Line'ı seçiniz:");
                Console.WriteLine("(1) TODO");
                Console.WriteLine("(2) IN PROGRESS");
                Console.WriteLine("(3) DONE");
                string secim3 = Console.ReadLine();
                switch (secim3)
                {
                    case "1":
                        foreach (Kart item in tasinacaklar)
                        {
                            Todo.Add(item);
                        }
                        break;
                    case "2":
                        foreach (Kart item in tasinacaklar)
                        {
                            InProgress.Add(item);
                        }
                        break;
                    case "3":
                        foreach (Kart item in tasinacaklar)
                        {
                            Done.Add(item);
                        }
                        break;
                    default:
                        Console.WriteLine("Hatalı bir seçim yaptınız!");
                        break;
                }
                Listele();
            }
            else
            {
                Console.WriteLine("Aradığınız kriterlere uygun kart board'da bulunamadı. Lütfen bir seçim yapınız.");
                Console.WriteLine("* Taşımayı sonlandırmak için : (1)");
                Console.WriteLine("* Yeniden denemek için      : (2)");
                string secim = Console.ReadLine();
                if (secim == "2")
                    KartTasi();
                else
                    Environment.Exit(0);
            }
        }
    }
}