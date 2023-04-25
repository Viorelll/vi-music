// using System.Globalization;
// using ViMusic.Application.Common.Interfaces;
// using ViMusic.Application.TodoLists.Queries.ExportTodos;
// using ViMusic.Infrastructure.Files.Maps;
// using CsvHelper;

// namespace ViMusic.Infrastructure.Files;

// public class CsvFileBuilder : ICsvFileBuilder
// {
//     public byte[] BuildSongsFile(IEnumerable<SongRecord> records)
//     {
//         using var memoryStream = new MemoryStream();
//         using (var streamWriter = new StreamWriter(memoryStream))
//         {
//             using var csvWriter = new CsvWriter(streamWriter, CultureInfo.InvariantCulture);

//             csvWriter.Context.RegisterClassMap<SongRecordMap>();
//             csvWriter.WriteRecords(records);
//         }

//         return memoryStream.ToArray();
//     }
// }
