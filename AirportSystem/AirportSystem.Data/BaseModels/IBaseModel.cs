namespace AirportSystem.Data.BaseModels
{
    public interface IBaseModel
    {
         public int Id { get; set; }

         public DateTimeOffset CreatedAt { get; set; }

         public DateTimeOffset? UpdatedAt { get; set; }

         public DateTimeOffset? DeletedAt { get; set; }
    }
}