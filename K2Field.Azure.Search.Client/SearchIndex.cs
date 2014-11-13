using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace K2Field.Azure.Search.Client
{
    //01F678594E05572AE7143EA3F2989BF5
    //https://jonno.search.windows.net
    public class SearchIndex
    {

        static string SearchServiceName = "jonno";
        static string apikey = "E5B0C69B8548DFA2BB1344844B355D2C";

        static Uri _serviceUri;
        static HttpClient _httpClient;

        static SearchIndex()
        {
            _httpClient = new HttpClient();
            _serviceUri = new Uri("https://" + SearchServiceName + ".search.windows.net");
            _httpClient = new HttpClient();
            _httpClient.DefaultRequestHeaders.Add("api-key", apikey);
        }


        public static bool IndexExists(string name)
        {
            Uri uri = new Uri(_serviceUri, "/indexes/" + name);
            HttpResponseMessage response = AzureSearchHelper.SendSearchRequest(_httpClient, HttpMethod.Get, uri);
            if (response.StatusCode == HttpStatusCode.NotFound)
            {
                return false;
            }
            response.EnsureSuccessStatusCode();
            return true;
        }

        public static Index GetIndex(string name)
        {
            Uri uri = new Uri(_serviceUri, "/indexes/" + name);
            HttpResponseMessage response = AzureSearchHelper.SendSearchRequest(_httpClient, HttpMethod.Get, uri);
            if (response.StatusCode == HttpStatusCode.NotFound)
            {
                return null;
            }
            response.EnsureSuccessStatusCode();
            var index = AzureSearchHelper.DeserializeJson<Index>(response.Content.ReadAsStringAsync().Result);
            return index;
        }

        public static bool DeleteIndex(string name)
        {
            Uri uri = new Uri(_serviceUri, "/indexes/" + name);
            HttpResponseMessage response = AzureSearchHelper.SendSearchRequest(_httpClient, HttpMethod.Delete, uri);
            if (response.StatusCode == HttpStatusCode.NotFound)
            {
                return false;
            }
            response.EnsureSuccessStatusCode();
            return true;
        }

        public static void CreateIndex(string name, Field[] fields = null, string scoring = null)
        {
            //var definition = new 
            //{
            //    Name = name,
            //    Fields = new[] 
            //    { 
            //        new { Name = "productID",        Type = "Edm.String",         Key = true,  Searchable = false, Filterable = false, Sortable = false, Facetable = false, Retrievable = true,  Suggestions = false },
            //        new { Name = "name",             Type = "Edm.String",         Key = false, Searchable = true,  Filterable = false, Sortable = true,  Facetable = false, Retrievable = true,  Suggestions = true  },
            //        new { Name = "productNumber",    Type = "Edm.String",         Key = false, Searchable = true,  Filterable = false, Sortable = false, Facetable = false, Retrievable = true,  Suggestions = true  },
            //        new { Name = "color",            Type = "Edm.String",         Key = false, Searchable = true,  Filterable = true,  Sortable = true,  Facetable = true,  Retrievable = true,  Suggestions = false },
            //        new { Name = "standardCost",     Type = "Edm.Double",         Key = false, Searchable = false, Filterable = false, Sortable = false, Facetable = false, Retrievable = true,  Suggestions = false },
            //        new { Name = "listPrice",        Type = "Edm.Double",         Key = false, Searchable = false, Filterable = true,  Sortable = true,  Facetable = true,  Retrievable = true,  Suggestions = false },
            //        new { Name = "size",             Type = "Edm.String",         Key = false, Searchable = true,  Filterable = true,  Sortable = true,  Facetable = true,  Retrievable = true,  Suggestions = false },
            //        new { Name = "weight",           Type = "Edm.Double",         Key = false, Searchable = false, Filterable = true,  Sortable = false, Facetable = true,  Retrievable = true,  Suggestions = false },
            //        new { Name = "sellStartDate",    Type = "Edm.DateTimeOffset", Key = false, Searchable = false, Filterable = true,  Sortable = false, Facetable = false, Retrievable = false, Suggestions = false },
            //        new { Name = "sellEndDate",      Type = "Edm.DateTimeOffset", Key = false, Searchable = false, Filterable = true,  Sortable = false, Facetable = false, Retrievable = false, Suggestions = false },
            //        new { Name = "discontinuedDate", Type = "Edm.DateTimeOffset", Key = false, Searchable = false, Filterable = true,  Sortable = false, Facetable = false, Retrievable = true,  Suggestions = false },
            //        new { Name = "categoryName",     Type = "Edm.String",         Key = false, Searchable = true,  Filterable = true,  Sortable = false, Facetable = true,  Retrievable = true,  Suggestions = true  },
            //        new { Name = "modelName",        Type = "Edm.String",         Key = false, Searchable = true,  Filterable = true,  Sortable = false, Facetable = true,  Retrievable = true,  Suggestions = true  },
            //        new { Name = "description",      Type = "Edm.String",         Key = false, Searchable = true,  Filterable = true,  Sortable = false, Facetable = false, Retrievable = true,  Suggestions = false }
            //    }
            //};

            var definition = new Index();
            definition.name = name;

            if (fields != null && fields.Length > 0)
            {
                definition.fields = fields;
            }


            Uri uri = new Uri(_serviceUri, "/indexes");
            string json = AzureSearchHelper.SerializeJson(definition);
            HttpResponseMessage response = AzureSearchHelper.SendSearchRequest(_httpClient, HttpMethod.Post, uri, json);
            response.EnsureSuccessStatusCode();
        }

        public static void IndexBatch(string name, List<Dictionary<string, object>> changes)
        {
            var batch = new
            {
                value = changes
            };

            Uri uri = new Uri(_serviceUri, "/indexes/" + name + "/docs/index");
            string json = AzureSearchHelper.SerializeJson(batch);
            HttpResponseMessage response = AzureSearchHelper.SendSearchRequest(_httpClient, HttpMethod.Post, uri, json);
            response.EnsureSuccessStatusCode();
        }
    }

    public class Index
    {
        public string name { get; set; }
        public Field[] fields { get; set; }
        //public Field[] scoringProfile { get; set; }
        //public Field defaultScoringProfile { get; set; }
        public Field corsOptions { get; set; }
    }

    public class Field
    {
        public string name { get; set; }
        public string type { get; set; }
        public bool searchable { get; set; }
        public bool filterable { get; set; }
        public bool sortable { get; set; }
        public bool facetable { get; set; }
        public bool suggestions { get; set; }
        public bool key { get; set; }
        public bool retrievable { get; set; }
        public string analyzer { get; set; }
    }

    
public class SearchDocument
{
public Value[] value { get; set; }
}

public class Value
{
public string searchaction { get; set; }
public string hotelId { get; set; }
public float baseRate { get; set; }
public string description { get; set; }
public string description_fr { get; set; }
public string hotelName { get; set; }
public string category { get; set; }
public string[] tags { get; set; }
public bool parkingIncluded { get; set; }
public bool smokingAllowed { get; set; }
public DateTime? lastRenovationDate { get; set; }
public int rating { get; set; }
public Location location { get; set; }
}

public class Location
{
public string type { get; set; }
public float[] coordinates { get; set; }
}

}
