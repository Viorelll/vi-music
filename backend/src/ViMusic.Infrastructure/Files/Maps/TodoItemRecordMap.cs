// using System.Globalization;
// using ViMusic.Application.TodoLists.Queries.ExportTodos;
// using CsvHelper.Configuration;

// namespace ViMusic.Infrastructure.Files.Maps;

// public class SongRecordMap : ClassMap<SongRecord>
// {
//     public SongRecordMap()
//     {
//         AutoMap(CultureInfo.InvariantCulture);

//         Map(m => m.Done).Convert(c => c.Value.Done ? "Yes" : "No");
//     }
// }
