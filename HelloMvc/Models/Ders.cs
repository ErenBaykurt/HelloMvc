namespace HelloMvc.Models
{
    public class Ders
    {
        public int DersId { get; set; }
        public string DersAd { get; set; }
        public string DersKodu { get; set; }

        public ICollection<OgrenciDersler> OgrenciDersleri { get; set; }
    }
}

