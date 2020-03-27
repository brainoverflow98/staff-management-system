using PersonelTakip.Core.Models;
using System.Collections.Generic;

namespace PersonelTakip.Controllers.Resources
{
    public class HesaplamalarResource
    {
        public string uid { get; set; }

        public int tableNo { get; set; }

        public List<HesaplamalarHeader> headers { get; set; }

        public List<HesaplamalarRow> rows { get; set; }

        public HesaplamalarResource(int month, int year, int tableNo, ICollection<Hesaplama> hesaplamalar)
        {
            this.headers = new List<HesaplamalarHeader>();
            this.uid = month + "." + year + "-Summary";
            this.tableNo = tableNo;
            this.headers.Add(new HesaplamalarHeader(hesaplamalar));
            this.rows = new List<HesaplamalarRow>();

            var toplamRow = new HesaplamalarRow();

            toplamRow.uid = TableConstants.Toplam.Uid;

            toplamRow.columns.Add(new HesaplamalarRow.Column
            {
                uid = TableConstants.Toplam.Uid,
                value = TableConstants.Toplam.Text,
                type = "txt",
                header = true
            });

            foreach (var hesaplama in hesaplamalar)
            {
                if (hesaplama.OzetGoster)
                    toplamRow.columns.Add(new HesaplamalarRow.Column
                    {
                        uid = hesaplama.Id.ToString(),
                        value = "0",
                        type = "num"
                    });
            }
            

            this.rows.Add(toplamRow);
        }
    }
    public class HesaplamalarHeader
    {
        public string uid { get; set; }
        public string classes { get; set; }

        public List<Column> columns { get; set; }

        public class Column
        {
            public string uid { get; set; }
            public string type { get; set; }
            public string value { get; set; }
            public Column()
            {
            }
        }
        public HesaplamalarHeader(ICollection<Hesaplama> hesaplamalar)
        {
            this.classes = "thead-dark";
            this.columns = new List<Column>();


            // Hesaplama başlıkları
            columns.Add(new Column
            {
                uid = "unvan",
                value = "Unvan",
                type = "txt"
            });

            foreach (var hesaplama in hesaplamalar)
            {
                if(hesaplama.OzetGoster)
                columns.Add(new Column
                {
                    uid = hesaplama.Id.ToString(),
                    value = hesaplama.Baslik,
                    type = "txt"
                });
            }
            
        }
    }



    public class HesaplamalarRow
    {
        public string uid { get; set; }
        public List<Column> columns { get; set; }
        public HesaplamalarRow()
        {
            
            this.columns = new List<Column>();
            
        }
        public class Column
        {
            public string uid { get; set; }
            public string type { get; set; }
            public string value { get; set; }
            public bool header { get; set; }
            public string classes { get; set; }
            public int optionGroup { get; set; }

        }
    }




}
