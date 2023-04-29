using MyRestaurantDM.Models.Domain;

namespace MyRestaurantDM.Repositories
{
    public interface IimageRepo
    {
      Task<Image>  Upload(Image image);
       
    }
}
