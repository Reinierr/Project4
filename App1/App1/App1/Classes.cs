using System;
using CsvHelper;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace App1
{
  public class CSVConnection
  {
    private TextReader connection;
    private string type;
    public List<FietsDiefstal> fietsdiefstallen;
    public List<FietsTrommel> fietstrommels;
    public CSVConnection(string type, TextReader sr)
    {
      this.connection = sr;
      this.type = type;
      var csv = new CsvReader(this.connection);
      csv.Configuration.Delimiter = ";";
      if (type == "fietsdiefstal")
      {
        var records = csv.GetRecords<FietsDiefstal>().ToList();
        this.fietsdiefstallen = records;
      }

      else if (type == "fietstrommel")
      {
        var records = csv.GetRecords<FietsTrommel>().ToList();
        this.fietstrommels = records;
      }
    }

    public Dictionary<int, int> getLinechart()
    {
      Dictionary<int, int> result = new Dictionary<int, int>();
      foreach (var line in fietsdiefstallen
        .GroupBy(fiets => new { fiets.Begindatum.Month })
        .Select(group => new {
          Month = group.Key.Month,
          Count = group.Count()
        })
        .OrderBy(x => x.Month))
      {
        result[line.Month] = line.Count; 
      }
      return result;
    }

    public Dictionary<string, int> getPiechartBrand()
    {
      Dictionary<string, int> result = new Dictionary<string, int>();
      foreach (var line in fietsdiefstallen
        .GroupBy(fiets => new { fiets.merk })
        .Select(group => new
        {
          Brand = group.Key.merk,
          Count = group.Count()
        })
        .OrderByDescending(x => x.Count)
        .Take(5))
      {
        result[line.Brand] = line.Count;
      }
      return result;
    }

    public Dictionary<string, int> getPiechartColor()
    {
      Dictionary<string, int> result = new Dictionary<string, int>();
      foreach (var line in fietsdiefstallen
        .GroupBy(fiets => new { fiets.kleur })
        .Select(group => new
        {
          Color = group.Key,
          Count = group.Count()
        })) ;
      return result;
    }
  }
  
  public class FietsDiefstal
  {
    
    public string Buurt { get; set; }
    public string merk { get; set; }
    public string kleur { get; set; }
    public DateTime Begindatum { get; set; }
    public string type { get; set; }
    public string typef {get; set; }
  }

  public class FietsTrommel
  {
    public string Straat { get; set; }
    public float ycoord { get; set; }
    public float xcoord { get; set; }
    public string Deelgem { get; set; }
    public string Mutdatum { get; set; }
  }
}

