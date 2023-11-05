# How to add data to the project

## Run a postgres container

In the docker-compose file add :

```yml
  # database
  postgres_db:
    image: postgres
    ports:
      - "5432:5432"   
    environment:
      POSTGRES_PASSWORD: postgres
      POSTGRES_USER: postgres
      POSTGRES_DB: postgres
```

and run the command

```sh
docker-compose up -d
```

try to connect with any tool to your database.

If you don't have any, launch a pgAdmin container and go to http://localhost:5050

```yml
  # pgamdin
  pgadmin:
    image: dpage/pgadmin4
    environment:
      PGADMIN_DEFAULT_EMAIL: admin@admin.com
      PGADMIN_DEFAULT_PASSWORD: postgres
    ports:
      - "5050:80"
```

## Keep data between restart

Because we are in container, data will be lost at restart.

To keep them, just add a volume in your postgres container

```yml
volumes:
    - ./volume/postgres_data:/var/lib/postgresql/data/
```

you can do the same with pgAdmin, to keep your settings.

Here is the final docker-compose.yml

```yml
  # database
  postgres_db:
    image: postgres
    volumes:
      - ./volume/postgres_data:/var/lib/postgresql/data/
    ports:
      - "5432:5432"   
    environment:
      POSTGRES_PASSWORD: postgres
      POSTGRES_USER: postgres
      POSTGRES_DB: postgres

  # pgamdin
  pgadmin:
    image: dpage/pgadmin4
    volumes:
      - ./volume/pgadmin_data:/var/lib/pgadmin
    environment:
      PGADMIN_DEFAULT_EMAIL: admin@admin.com
      PGADMIN_DEFAULT_PASSWORD: postgres
    ports:
      - "5050:80"
```

## Create table

There is a lot of way to load data, here a kick one, using a python script

```python
import pandas as pd
from sqlalchemy import create_engine
df = pd.read_csv('../../data/consolidation-etalab-schema-irve-statique-v-2.2.0-20231031.csv')
engine = create_engine('postgresql://postgres:postgres@localhost:5432/postgres')
df.to_sql('Stations', engine)
```

With this script, pandas will choose column name and type and load data in our database

But in most case it will be more difficult to maintain in the future, especially if you need to maintain multiple environment, and want to upgrade or downgrade your database between versions, and have more controls on the column type.

I choose to use entity framework migration, to automate this part. The setup more complex but update are easier.

go to the doc for detailled information : https://learn.microsoft.com/en-us/ef/core/managing-schemas/migrations/?tabs=dotnet-core-cli

First we need these package :
 - Microsoft.EntityFrameworkCore
 - Microsoft.EntityFrameworkCore.Design
 - Npgsql.EntityFrameworkCore.PostgreSQL

Add the connection string in config file

```json
"ConnectionStrings": {
  "DefaultConnection": "Host=localhost;Database=postgres;Username=postgres;Password=postgres"
}
```

add a context class :

```c#
 public class StationContext : DbContext
 {
     public StationContext(DbContextOptions<StationContext> options)
         : base(options)
     {
     }

     public DbSet<StationDAO> Stations { get; set; }
 }
```

Add a reference in Program.cs

```c#
builder.Services.AddDbContext<StationContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));
```

and finally our Data Access Object (DAO) class :

```C#
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
```

Now run the tool

```sh
dotnet tool install -g dotnet-ef
cd .\src\PrivateStationAPI
dotnet ef migrations add InitialCreate
dotnet ef database update
```

## Load data

Now that the table is created load the data with the tool you want.

Here an exemple in python with pandas

```python
import pandas as pd
from sqlalchemy import create_engine
df = pd.read_csv('../../data/consolidation-etalab-schema-irve-statique-v-2.2.0-20231031.csv')
engine = create_engine('postgresql://postgres:postgres@localhost:5432/postgres')
df.to_sql('Stations', engine, if_exists='append', index=True, index_label='id')
```

## Query data

Now update your repository class to query the data

```C#
private readonly StationContext _context;

public StationRepository(StationContext context)
{
    _context = context;
}

public async Task<IEnumerable<StationDAO>> GetAllStationsAsync(int pageNumber = 1, int pageSize = 10)
{
    return await _context.Stations.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToListAsync();
}
```

I also choose to return a different entity to my consumers so I add some mapping in my service

I put my entity in a different project to have access in all my others project

```C#
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
```

```C#
public class StationService : IStationService
{
    private readonly IStationRepository _stationRepository;
    public StationService(IStationRepository stationRepository)
    {
        _stationRepository = stationRepository;
    }

    public async Task<IEnumerable<StationDTO>> GetAll()
    {
        var dbStation = await _stationRepository.GetAllStationsAsync();
        var station = dbStation.Select(MapStationDAOToDTO);
        return station;
    }

    public StationDTO MapStationDAOToDTO(StationDAO stationDAO)
    {
        var stationDTO = new StationDTO
        {
            Id = stationDAO.id.Value,
            Name = stationDAO.nom_station,
            Description = stationDAO.implantation_station,
            Address = stationDAO.adresse_station,
            City = stationDAO.consolidated_commune,
            Power = stationDAO.puissance_nominale.Value,
            Free = stationDAO.gratuit.ToLower() == "true",
            AccessCondition = stationDAO.condition_acces,
            OpeningHours = stationDAO.horaires
        };

        return stationDTO;
    }
}
```

## Bonus

### Data exloration

Check the data_exploration notebook, python have great data libraries, to show some stats, or display the station on a map !

We can also see some strange data, for exemple the "gratuit" boolean column have 9 different values possible

```python 
df['gratuit'].unique()
# array(['TRUE', 'false', 'FALSE', 'true', nan, 'False', '1', '0', 'True'], dtype=object)
```

So we know that we introduce a bug in the mapping code by writing

```C#
Free = stationDAO.gratuit.ToLower() == "true"
```

Just write a unit test to fail the case stationDAO.gratuit = 1 and we expect Free to be true then fix it !

```C#
// test MapStationDAOToDTO
// StationDAO.gratuit can have values 'TRUE', 'false', 'FALSE', 'true', nan, 'False', '1', '0', 'True'
[Theory(DisplayName = "MapStationDAOToDTO Should Return StationDTO")]
[InlineData("TRUE", true)]
[InlineData("True", true)]
[InlineData("true", true)]
[InlineData("1", true)]
[InlineData("FALSE", false)]
[InlineData("False", false)]
[InlineData("false", false)]
[InlineData("0", false)]
[InlineData("nan", false)]
public void MapStationDAOToDTO_ShouldReturnStationDTO(string gratuit, bool expected)
{
    // Arrange
    var stationDAO = new StationDAO
    {
        id = 1,
        nom_station = "Station 1",
        gratuit = gratuit
    };
    // Act
    var result = SUT.MapStationDAOToDTO(stationDAO);
    // Assert
    Assert.NotNull(result);
    Assert.Equal(expected, result.Free);
}
```