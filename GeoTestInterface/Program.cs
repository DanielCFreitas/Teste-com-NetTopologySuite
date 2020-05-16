using GeoTest.Data;
using GeoTest.Data.Model;
using GeoTest.Data.Repository;
using NetTopologySuite.Geometries;
using NetTopologySuite.IO;
using NetTopologySuite.IO.Converters;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Text;

namespace GeoTestInterface
{
    class Program
    {
        static void Main(string[] args)
        {
            ApplicationDbContext dbContext = new ApplicationDbContext();
            Repository<Farm> repository = new Repository<Farm>(dbContext);

            var Farm = repository.Get(new Guid("123e4567-e89b-12d3-a456-426655440000"));

            Console.WriteLine($"Área: {Farm.geometry.Area} \n");
            Console.WriteLine($"Número de Coordenadas: {Farm.geometry.NumPoints} \n");
            Console.WriteLine($"CentroID {Farm.geometry.Centroid}\n");
            Console.WriteLine($"Tipo de Geometria: {Farm.geometry.GeometryType}\n");

            var jsonSerializer = GeoJsonSerializer.Create(Farm.geometry.Factory);
            StringBuilder sb = new StringBuilder();
            StringWriter sw = new StringWriter(sb);
            JsonWriter jsonWriter = new JsonTextWriter(sw);
            jsonSerializer.Serialize(jsonWriter, Farm.geometry);
            Console.WriteLine($"GeoJSON: {sb}");

            Console.ReadKey();
        }
    }
}
