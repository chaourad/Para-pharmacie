using paraMvc.Data.Base;
using paraMvc.Data.Enums;
using paraMvc.Data.ViewModels;
using paraMvc.Models;
using System.Data.Entity;
using Microsoft.EntityFrameworkCore;

namespace paraMvc.Data.Services
{
    public class ProductService : EntityBaseReposotory<Product>, IProductService
    {
        private readonly AppDbContext _context;
        public ProductService(AppDbContext context) : base(context)
        {
            _context = context;
        }
       

        public async  Task AddNewProductAsync(NewProductVm data)
        {
            var newProduct = new Product()
            {
                Name = data.Name,
                Description = data.Description,
                Price = data.Price,
                ImageURL = data.ImageURL,
                ProductCategory = data.ProductCategory,

            };
            await _context.Product.AddAsync(newProduct);
            await _context.SaveChangesAsync();


            await _context.SaveChangesAsync();
        }

       

        public async  Task UpdateProductAsync(NewProductVm data)
        {
            var dbMovie = await _context.Product.FirstOrDefaultAsync(n => n.Id == data.Id);

            if (dbMovie != null)
            {
                dbMovie.Name = data.Name;
                dbMovie.Description = data.Description;
                dbMovie.Price = data.Price;
                dbMovie.ImageURL = data.ImageURL;
                dbMovie.ProductCategory = data.ProductCategory;
                await _context.SaveChangesAsync();
            }

            await _context.SaveChangesAsync();
        }
    }
    }

