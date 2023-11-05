namespace PrivateStationAPI.Entities
{
        public class StationDAO
        {
            public int? id { get; set; }
            public string? nom_amenageur { get; set; }
            public float? siren_amenageur { get; set; }
            public string? contact_amenageur { get; set; }
            public string? nom_operateur { get; set; }
            public string? contact_operateur { get; set; }
            public string? telephone_operateur { get; set; }
            public string? nom_enseigne { get; set; }
            public string? id_station_itinerance { get; set; }
            public string? id_station_local { get; set; }
            public string? nom_station { get; set; }
            public string? implantation_station { get; set; }
            public string? adresse_station { get; set; }
            public string? code_insee_commune { get; set; }
            public string? coordonneesXY { get; set; }
            public int? nbre_pdc { get; set; }
            public string? id_pdc_itinerance { get; set; }
            public string? id_pdc_local { get; set; }
            public float? puissance_nominale { get; set; }
            public string? prise_type_ef { get; set; }
            public string? prise_type_2 { get; set; }
            public string? prise_type_combo_ccs { get; set; }
            public string? prise_type_chademo { get; set; }
            public string? prise_type_autre { get; set; }
            public string? gratuit { get; set; }
            public string? paiement_acte { get; set; }
            public string? paiement_cb { get; set; }
            public string? paiement_autre { get; set; }
            public string? tarification { get; set; }
            public string? condition_acces { get; set; }
            public string? reservation { get; set; }
            public string? horaires { get; set; }
            public string? accessibilite_pmr { get; set; }
            public string? restriction_gabarit { get; set; }
            public string? station_deux_roues { get; set; }
            public string? raccordement { get; set; }
            public string? num_pdl { get; set; }
            public string? date_mise_en_service { get; set; }
            public string? observations { get; set; }
            public string? date_maj { get; set; }
            public bool? cable_t2_attache { get; set; }
            public DateTime last_modified { get; set; }
            public string? datagouv_dataset_id { get; set; }
            public string? datagouv_resource_id { get; set; }
            public string? datagouv_organization_or_owner { get; set; }
            public DateTime created_at { get; set; }
            public float? consolidated_longitude { get; set; }
            public float? consolidated_latitude { get; set; }
            public int? consolidated_code_postal { get; set; }
            public string? consolidated_commune { get; set; }
            public bool consolidated_is_lon_lat_correct { get; set; }
            public bool consolidated_is_code_insee_verified { get; set; }
        }
}
