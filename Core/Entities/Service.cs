namespace Core.Entities
{
  public class Service : BaseEntity
    {
        public string CourierName { get; set; }
        public string CourierSlug { get; set; }
        public string Slug { get; set; }
        public string Name { get; set; }
        public string CollectionType { get; set; }
        public string DeliveryType { get; set; }
        public string ShortDescriptions { get; set; }
        public string Overview { get; set; }
        public string Features { get; set; }
        public string ImageSmall { get; set; }
        public string Imagelarge { get; set; }
        public string ImageSvg { get; set; }
        public string Courier { get; set; }

        public Links Links { get; set; }=null;
    }
}
