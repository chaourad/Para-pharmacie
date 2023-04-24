using Microsoft.EntityFrameworkCore;
using paraMvc.Data.Base;
using paraMvc.Models;

namespace paraMvc.Data.Services
{
    public class FournisseurService :EntityBaseReposotory <Fournisseur>,IFournisseurService
    {
        private readonly AppDbContext _context;
        public FournisseurService(AppDbContext context) :base(context)
        {

           
        }


        
    }
}
