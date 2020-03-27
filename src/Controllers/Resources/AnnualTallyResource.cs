using System.Collections.Generic;
using Microsoft.CodeAnalysis.Options;
using PersonelTakip.Controllers.Resources;
using PersonelTakip.Core.Models;

namespace PersonelTakip.Controllers.Resources
{
    public class AnnualTallyResource
    {
        //Tarih
        public string uid { get; set; }

        public int tableNo { get; set; }
        public int perPage { get; set; }
        public int pageNo { get; set; }
        public List<Dictionary<long, Option>> optionGroups { get; set; }

        public List<AnnualTallyHeader> headers { get; set; }

        public List<AnnualTallyRow> rows { get; set; }

        public AnnualTallyResource(string year, List<Hesaplama> hesaplamalar)
        {
            this.headers = new List<AnnualTallyHeader>();
            this.headers.Add(new AnnualTallyHeader(hesaplamalar));
            this.rows = new List<AnnualTallyRow>();
            this.optionGroups = new List<Dictionary<long, Option>>();
            this.tableNo = 3;
            this.perPage = 13;
            this.pageNo = 1;
            this.uid = year;
        }
    }
    public class AnnualTallyHeader
    {
        public string uid { get; set; }
        public string classes { get; set; }

        public List<Column> columns { get; set; }

        public class Column
        {
            public string uid { get; set; }
            public string type { get; set; }
            public string value { get; set; }
            public bool vertical { get; set; }
            public Column()
            {
                vertical = false;
            }
        }
        public AnnualTallyHeader(List<Hesaplama> hesaplamalar)
        {
            this.columns = new List<Column>();
            this.classes = "thead-dark";
            this.columns.Add(new Column
            {
                uid = null,
                type = "txt",
                value = ""
            });

            for (int i = 1; i <= 31; i++)
            {
                this.columns.Add(new Column
                {
                    uid = null,
                    type = "num",
                    value = i.ToString()
                });
            }

            foreach (var hesaplama in hesaplamalar)
            {
                this.columns.Add(new Column
                {
                    uid = hesaplama.Id.ToString(),
                    value = hesaplama.Baslik,
                    vertical = true,
                    type = "txt"
                });
            }

        }
    }

    public class AnnualTallyRow
    {
        public long uid { get; set; }
        public List<AnnualTallyColumn> columns { get; set; }
        public AnnualTallyRow()
        {
            this.columns = new List<AnnualTallyColumn>();
        }
    }

    public class AnnualTallyColumn
    {
        public string uid { get; set; }
        public string type { get; set; }
        public string value { get; set; }
        public bool th { get; set; }
        public string classes { get; set; }        
        public bool disabled { get; set; }

    }







}