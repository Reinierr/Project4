using System;
using CsvHelper;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace WindowsFormsApplication1
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

		public List<string> getBuurten() {
			List<string> result = new List<string>();
			foreach (var line in fietsdiefstallen
				.GroupBy(diefstal => new { diefstal.Buurt})
				.Select(group => new { Buurt = group.Key.Buurt})) {
				result.Add(line.Buurt);
			}
			return result;
		}

		public List<string> getBuurtenPlus() {
			List<string> result = new List<string>();
			foreach (var line in fietsdiefstallen
				.GroupBy(diefstal => new { diefstal.Buurt, diefstal.Plaats })
				.Select(group => new { Buurt = group.Key.Buurt, Plaats = group.Key.Plaats})) {
				result.Add(line.Buurt + " - " + line.Plaats);
			}
			return result;
		}
		/// <summary>
		/// Chart filler data
		/// </summary>
		/// <returns></returns>
		public Dictionary<int, int> getLinechart()
    {
      Dictionary<int, int> result = new Dictionary<int, int>();
      foreach (var line in fietsdiefstallen
        .GroupBy(fiets => new { fiets.Begindatum.Month })
        .Select(group => new
        {
          Month = group.Key.Month,
          Count = group.Count()
        })
        .OrderBy(x => x.Month))
      {
        result[line.Month] = line.Count;
      }
      return result;
    }

    public string getBuurt(string action)
    {
      string buurt = "";
      foreach (var line in fietsdiefstallen
        .Where(diefstal => diefstal.Buurt.Contains(action.ToUpper()))
        .GroupBy(diefstal => diefstal.Buurt)
        .Select(group => new { Buurt = group.Key }))
        {
          if(line.Buurt.Length == (action.Length + 3))
          {
            buurt = line.Buurt;
          }
        }
      return buurt;
    }

		public Dictionary<string, int> getBarchart()
    {
      Dictionary<string, int> result = new Dictionary<string, int>();
      foreach (var line in fietstrommels
          .GroupBy(trommel => trommel.Deelgem)
          .Select(group => new
          {
            Count = group.Count(),
            Neighborhood = group.Key
          })
          .OrderByDescending(x => x.Count)
          .Take(5)
          )
      {
        result[line.Neighborhood] = line.Count;
      }
      return result;
    }
    public Dictionary<int, int> getBarchartGroupFD(string buurt)
    {
      Dictionary<int, int> result = new Dictionary<int, int>();
      foreach (var line in fietsdiefstallen
          .Where(diefstal => diefstal.Buurt == buurt)
          .GroupBy(fiets => new { fiets.Begindatum.Month })
          .Select(group => new
          {
            Month = group.Key.Month,
            Count = group.Count()
          })
          .OrderBy(x => x.Month))
      {
        result[line.Month] = line.Count;
      }
      return result;
    }

    public Dictionary<int, int> getBarchartGroupFT(string buurt)
    {
      Dictionary<int, int> result = new Dictionary<int, int>();
      foreach (var line in fietstrommels
          .Where(diefstal => diefstal.Deelgem.ToLower() == buurt)
          .GroupBy(fiets => new { fiets.Mutdatum.Month })
          .Select(group => new
          {
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
        .Where(x => x.typef == "FIETS")
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
        public Dictionary<string, int> getPiechartBrandFull()
        {
            Dictionary<string, int> result = new Dictionary<string, int>();
            foreach (var line in fietsdiefstallen
              .Where(x => x.typef == "FIETS")
              .GroupBy(fiets => new { fiets.merk })
              .Select(group => new
              {
                  Brand = group.Key.merk,
                  Count = group.Count()
              })
              .OrderByDescending(x => x.Count))
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
          Color = group.Key.kleur,
          Count = group.Count()
        })
        .OrderByDescending(x => x.Count)
        .Take(5))
            {
                result[line.Color] = line.Count;
            }
            return result;
        }
        public Dictionary<string, int> getPiechartColorFull()
        {
            Dictionary<string, int> result = new Dictionary<string, int>();
            foreach (var line in fietsdiefstallen
              .GroupBy(fiets => new { fiets.kleur })
              .Select(group => new
              {
                  Color = group.Key.kleur,
                  Count = group.Count()
              })
              .OrderByDescending(x => x.Count))
              {
                result[line.Color] = line.Count;
            }
            return result;
        }
    }

  public class FietsDiefstal
  {
    public string Buurt { get; set; }
		public string Plaats { get; set; }
    public string merk { get; set; }
    public string kleur { get; set; }
    public DateTime Begindatum { get; set; }
    public string type { get; set; }
    public string typef { get; set; }
  }

  public class FietsTrommel
  {
    public string Straat { get; set; }
    public string ycoord { get; set; }
    public string xcoord { get; set; }
    public string Deelgem { get; set; }
    public DateTime Mutdatum { get; set; }
  }
}
