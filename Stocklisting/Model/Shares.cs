

using System.ComponentModel.DataAnnotations;

namespace Stocklisting.Model
{
  public class Shares
  {
        //add the following attributes to the class shares i.e. symbol, name, currency, country, exchange, type, mic_code

        [Key]
        public string symbol { get; set; }
        public string name { get; set; }
        public string currency { get; set; }
        public string country { get; set; }
        public string exchange { get; set; }
        public string type { get; set; }
        public string mic_code { get; set; }
        public string mic_name { get; set;}
    
  }
}
