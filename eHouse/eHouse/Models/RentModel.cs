

namespace eHouse.Models
{
    public class RentModel
    {
        public int id { get; set; }
        public string tittle { get; set; }
        public int price { get; set; }
        public string descrip { get; set; }

        public string areaUnit { get; set; }
        public int area { get; set; }
        public string province { get; set; }
        public string city { get; set; }
        public string stadress { get; set; }
        
        public string bathroom { get; set; }
        public string furnished { get; set; }
        public string p_type { get; set; }
        public string bedroom { get; set; }
        public string garage { get; set; }
        public int p_id { get; set; }
     
        public string? pic1 { get; set; }


        public IList<IFormFile> photos { get; set; }

        public string? pic2 { get; set; }

        


        public string? pic3 { get; set; }

       

        public string? pic4 { get; set; }

       

        public string? pic5 { get; set; }

        

        public string? pic6 { get; set; }

   

        public string? pic7 { get; set; }
        //public int CityCount { get; set; }
        public string? pic8 { get; set; }
        public string? pic9 { get; set; }
        public string? pic10 { get; set; }

        public int r_id {get; set;}
        public int favid { get; set; }

        public List<eHouse.Models.RentModel>? Data { get; set; }
        public List<string>? SearchList { get; set;}
        public inputModel? Input { get; set; }

    }
}
