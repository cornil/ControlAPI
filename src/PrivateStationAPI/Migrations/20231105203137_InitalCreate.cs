using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace PrivateStationAPI.Migrations
{
    /// <inheritdoc />
    public partial class InitalCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Stations",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    nom_amenageur = table.Column<string>(type: "text", nullable: true),
                    siren_amenageur = table.Column<float>(type: "real", nullable: true),
                    contact_amenageur = table.Column<string>(type: "text", nullable: true),
                    nom_operateur = table.Column<string>(type: "text", nullable: true),
                    contact_operateur = table.Column<string>(type: "text", nullable: true),
                    telephone_operateur = table.Column<string>(type: "text", nullable: true),
                    nom_enseigne = table.Column<string>(type: "text", nullable: true),
                    id_station_itinerance = table.Column<string>(type: "text", nullable: true),
                    id_station_local = table.Column<string>(type: "text", nullable: true),
                    nom_station = table.Column<string>(type: "text", nullable: true),
                    implantation_station = table.Column<string>(type: "text", nullable: true),
                    adresse_station = table.Column<string>(type: "text", nullable: true),
                    code_insee_commune = table.Column<string>(type: "text", nullable: true),
                    coordonneesXY = table.Column<string>(type: "text", nullable: true),
                    nbre_pdc = table.Column<int>(type: "integer", nullable: true),
                    id_pdc_itinerance = table.Column<string>(type: "text", nullable: true),
                    id_pdc_local = table.Column<string>(type: "text", nullable: true),
                    puissance_nominale = table.Column<float>(type: "real", nullable: true),
                    prise_type_ef = table.Column<string>(type: "text", nullable: true),
                    prise_type_2 = table.Column<string>(type: "text", nullable: true),
                    prise_type_combo_ccs = table.Column<string>(type: "text", nullable: true),
                    prise_type_chademo = table.Column<string>(type: "text", nullable: true),
                    prise_type_autre = table.Column<string>(type: "text", nullable: true),
                    gratuit = table.Column<string>(type: "text", nullable: true),
                    paiement_acte = table.Column<string>(type: "text", nullable: true),
                    paiement_cb = table.Column<string>(type: "text", nullable: true),
                    paiement_autre = table.Column<string>(type: "text", nullable: true),
                    tarification = table.Column<string>(type: "text", nullable: true),
                    condition_acces = table.Column<string>(type: "text", nullable: true),
                    reservation = table.Column<string>(type: "text", nullable: true),
                    horaires = table.Column<string>(type: "text", nullable: true),
                    accessibilite_pmr = table.Column<string>(type: "text", nullable: true),
                    restriction_gabarit = table.Column<string>(type: "text", nullable: true),
                    station_deux_roues = table.Column<string>(type: "text", nullable: true),
                    raccordement = table.Column<string>(type: "text", nullable: true),
                    num_pdl = table.Column<string>(type: "text", nullable: true),
                    date_mise_en_service = table.Column<string>(type: "text", nullable: true),
                    observations = table.Column<string>(type: "text", nullable: true),
                    date_maj = table.Column<string>(type: "text", nullable: true),
                    cable_t2_attache = table.Column<bool>(type: "boolean", nullable: true),
                    last_modified = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    datagouv_dataset_id = table.Column<string>(type: "text", nullable: true),
                    datagouv_resource_id = table.Column<string>(type: "text", nullable: true),
                    datagouv_organization_or_owner = table.Column<string>(type: "text", nullable: true),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    consolidated_longitude = table.Column<float>(type: "real", nullable: true),
                    consolidated_latitude = table.Column<float>(type: "real", nullable: true),
                    consolidated_code_postal = table.Column<int>(type: "integer", nullable: true),
                    consolidated_commune = table.Column<string>(type: "text", nullable: true),
                    consolidated_is_lon_lat_correct = table.Column<bool>(type: "boolean", nullable: false),
                    consolidated_is_code_insee_verified = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stations", x => x.id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Stations");
        }
    }
}
