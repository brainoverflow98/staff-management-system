using PersonelTakip.Core.Models;
using System;
using System.Collections.Generic;

namespace PersonelTakip.Controllers.Resources
{
    public class MonthlyTallyResource
    {
        //Tarih
        public string uid { get; set; }

        public int tableNo { get; set; }
        public int perPage { get; set; }
        public int pageNo { get; set; }
        public List<Dictionary<long,Option>> optionGroups { get; set; }

        public List<MonthlyTallyHeader> headers { get; set; }

        public List<MonthlyTallyRow> rows { get; set; }

        public MonthlyTallyResource(List<Hesaplama> hesaplamalar)
        {
            this.headers = new List<MonthlyTallyHeader>();
            this.headers.Add(new MonthlyTallyHeader(hesaplamalar));
            this.rows = new List<MonthlyTallyRow>();
            this.optionGroups = new List<Dictionary<long, Option>>();
        }
    }
    public class MonthlyTallyHeader
    {
        public string uid { get; set; }
        public string classes { get; set; }

        public List<Column> columns { get; set; }

        public class Column{
            public string uid { get; set; }
            public string type { get; set; }
            public string value { get; set; }
            public bool vertical { get; set; }
            public Column()
            {
                vertical = true;
            }
        }
        public MonthlyTallyHeader(List<Hesaplama> hesaplamalar)
        {
            this.classes = "thead-dark";
            this.columns = new List<Column>();

            foreach (var header in TableConstants.HeaderList)
            {
                columns.Add(new Column
                {
                    uid = header.Uid,
                    type = "txt",
                    value = header.Text,
                    vertical = true
                });
            }


            foreach (var hesaplama in hesaplamalar)
            {
                columns.Add(new Column
                {
                    uid = hesaplama.Id.ToString(),
                    value = hesaplama.Baslik,
                    vertical = true,
                    type = "txt"
                });
            }
            

        }
    }


    public class Option
    {
        public string text { get; set; }
        public string color { get; set; }
    }

    public class MonthlyTallyRow
    {
        public long uid { get; set; }
        public List<MonthlyTallyColumn> columns { get; set; }
        public MonthlyTallyRow()
        {
            this.columns = new List<MonthlyTallyColumn>();
        }
    }

    public class MonthlyTallyColumn
    {
        public string uid { get; set; }
        public string type { get; set; }
        public string value { get; set; }
        public bool th { get; set; }
        public string classes { get; set; }        
        public bool disabled { get; set; }
    }
  


}
