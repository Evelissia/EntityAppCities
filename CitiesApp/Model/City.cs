namespace CitiesApp.Model
{
    public class City
    {
        public int Id { get; set; }
        public string district { get; set; }
        public string name { get; set; }
        public int population { get; set; }
        public string subject { get; set; }
        public Coords coords { get; set; }
    }
}
