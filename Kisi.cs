namespace todo_uygulamasi
{
    public class Kisi
    {
        int kisiID;
        string isim;
        string soyisim;
        string takim;

        public int KisiId { get => kisiID; }
        public string Isim { get => isim; }
        public string Soyisim { get => soyisim; }
        public string Takim { get => takim; }
        public Kisi(int kisiID, string isim, string soyisim, string takim)
        {
            this.kisiID = kisiID;
            this.isim = isim;
            this.soyisim = soyisim;
            this.takim = takim;
        }
        public Kisi()
        {

        }
    }
}