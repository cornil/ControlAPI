namespace Core.Entities
{
    public class StationDTO
    {
        //id
        public int Id { get; set; }
        //nom_station
        public string Name { get; set; }
        //implantation_station
        public string Description { get; set; }
        //adresse_station
        public string Address { get; set; }
        //consolidated_commune
        public string City { get; set; }
        //puissance_nominale
        public float Power { get; set; }
        //gratuit
        public bool Free { get; set; }
        //condition_acces
        public string AccessCondition { get; set; }
        //horaires
        public string OpeningHours { get; set; }
    }    
}
