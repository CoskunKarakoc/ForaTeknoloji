namespace ForaTeknoloji.Entities.ComplexType
{
    public class GelenGelmeyen_PasifKullanici
    {
        public int ID { get; set; }
        public string Kart_ID { get; set; }
        public string Adi { get; set; }
        public string Soyadi { get; set; }
        public string TCKimlik { get; set; }
        public string SirketAdi { get; set; }
        public string DepartmanAdi { get; set; }
        public string AltDepartmanAdi { get; set; }
        public string BolumAdi { get; set; }
        public string Plaka { get; set; }
        public string BlokAdi { get; set; }
        public int? Daire { get; set; }
        public string Grup_Adi { get; set; }
        public string Global_Bolge_Adi { get; set; }
    }
}
