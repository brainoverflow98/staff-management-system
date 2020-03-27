using System;
using System.Collections.Generic;

namespace PersonelTakip.Controllers.Resources
{
    public class PersonelListResource
    {
        public string uid { get; set; }
        public int tableNo { get; set; }
        public int pageNo { get; set; }
        public int perPage { get; set; }
        public List<Header> headers { get; set; }
        public List<PersonelListResourceRow> rows { get; set; }
        public PersonelListResource()
        {
            headers = new List<Header>();
            headers.Add(new Header());
            rows = new List<PersonelListResourceRow>();
        }

    }
    public class Header
    {
        public string uid { get; set; }
        public string classes { get; set; }
        public List<Column> columns { get; set; }
        public Header()
        {
            this.classes = "thead-dark";
            this.columns = new List<Column>();
            foreach (var header in TableConstants.PersonelListHeader)
            {
                columns.Add(new Column
                {
                    uid = header.Uid,
                    type = "txt",
                    value = header.Text,
                });
            }            
           
        }

    }





    public class PersonelListResourceRow
    {
        public long uid { get; set; }
        public string href { get; set; }
        public List<Column> columns { get; set; }
        public PersonelListResourceRow()
        {
            this.columns = new List<Column>();
        }
    }
    public class Column
    {
        public string uid { get; set; }
        public string type { get; set; }
        public string value { get; set; }
    }


}
