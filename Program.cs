namespace todo_uygulamasi
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Clear();
            Board board = new Board();
            Console.WriteLine("Lütfen yapmak istediğiniz işlemi seçiniz :)");
            Console.WriteLine("*******************************************");
            Console.WriteLine("(1) Board Listelemek");
            Console.WriteLine("(2) Board'a Kart Eklemek");
            Console.WriteLine("(3) Board'da Kart Güncelle");
            Console.WriteLine("(4) Board'dan Kart Silmek");
            Console.WriteLine("(5) Kart Taşımak");
            string islem = Console.ReadLine();
            switch (islem)
            {
                case "1":
                    board.Listele();
                    break;
                case "2":
                    board.KartEkle();
                    break;
                case "3":
                    board.KartGuncelle();
                    break;
                case "4":
                    board.KartSil();
                    break;
                case "5":
                    board.KartTasi();
                    break;
                default:
                    Console.WriteLine("Lütfen 1-5 arası bir değer giriniz.");
                    break;
            }
        }
    }
}