using paraMvc.Data.Base;
using paraMvc.Data.ViewModels;
using paraMvc.Models;

namespace paraMvc.Data.Services
{
    public interface IProductService : IEntityBaseReposotory<Product>
    {
       
      
        Task AddNewProductAsync(NewProductVm data);
        Task UpdateProductAsync( NewProductVm data);
    }
}
