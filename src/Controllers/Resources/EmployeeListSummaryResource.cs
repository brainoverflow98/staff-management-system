using PersonelTakip.Core.Models;
using System.Collections.Generic;


namespace PersonelTakip.Controllers.Resources
{
    public class EmployeeListSummaryResource
    {

        public string uid { get; set; }

        public int tableNo { get; set; }

        public List<Header> headers { get; set; }

        public List<Row> rows { get; set; }

        public EmployeeListSummaryResource(string uid, int tableNo, ICollection<Unvan> unvanlar)
        {
            this.uid = uid;
            this.tableNo = tableNo;
            this.headers = new List<Header>();
            this.headers.Add(new Header(unvanlar));
            this.rows = new List<Row>();

        }
        public class Header
        {
            public string uid { get; set; }
            public string classes { get; set; }

            public List<Column> columns { get; set; }
            public Header(ICollection<Unvan> unvanlar)
            {
                this.uid = "gorev";
                this.classes = "thead-dark";
                
                this.columns = new List<Column>();
                foreach (var unvan in unvanlar)
                {
                    this.columns.Add(new Column
                    {
                        uid = unvan.Id.ToString(),
                        value = unvan.UnvanAdi,
                        type = "txt"
                    });
                }
                this.columns.Add(new Column
                {
                    uid = TableConstants.Toplam.Uid,
                    value = TableConstants.Toplam.Text,
                    type = "txt"
                });
            }

            public class Column
            {
                public string uid { get; set; }
                public string type { get; set; }
                public string value { get; set; }
                public Column()
                {
                }
            }

        }






        public class Row
        {
            public string uid { get; set; }
            public List<Column> columns { get; set; }
            public Row(string uid)
            {
                this.uid = uid;
                this.columns = new List<Column>();

            }
            public class Column
            {
                public string uid { get; set; }
                public string type { get; set; }
                public int value { get; set; }
            }
        }
    }





}
