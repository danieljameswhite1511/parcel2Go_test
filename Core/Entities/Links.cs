namespace Core.Entities
{
    public class Links : BaseEntity
    {
        //public string  Service { get; set; }

        public int ServiceId { get; set; }
        public string ImageSmall { get; set; }
        public string Imagelarge { get; set; }
        public string ImageSvg { get; set; }
        public string Courier { get; set; }
        

    }
}