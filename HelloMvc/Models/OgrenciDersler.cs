namespace HelloMvc.Models
{
    public class OgrenciDersler
    {
        public int Ogrenciid { get; set; }
        public Ogrenci Ogrenci { get; set; }
        public int Dersid { get; set; }
        public Ders ders { get; set; }
    }
}
