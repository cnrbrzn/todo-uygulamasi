namespace todo_uygulamasi
{
    public class Kart
    {
        int kartId;
        string baslik;
        string icerik;
        Kisi atananKisi;
        Buyukluk buyukluk;

        public Kart(string baslik, string icerik, Kisi atananKisi, Buyukluk buyukluk, int id)
        {
            this.baslik = baslik;
            this.icerik = icerik;
            this.atananKisi = atananKisi;
            this.buyukluk = buyukluk;
            this.kartId = id;
        }

        public string Baslik { get => baslik; set => baslik = value; }
        public string Icerik { get => icerik; set => icerik = value; }
        public Kisi AtananKisi { get => atananKisi; set => atananKisi = value; }
        public Buyukluk Buyukluk { get => buyukluk; set => buyukluk = value; }
        public int Id { get => kartId; set => kartId = value; }

        public Kart()
        {
            
        }
    }
}