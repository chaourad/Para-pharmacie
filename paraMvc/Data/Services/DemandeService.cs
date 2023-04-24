using paraMvc.Data.Base;
using paraMvc.Data.ViewModels;
using paraMvc.Models;
using System.Data.Entity;

namespace paraMvc.Data.Services
{
    public class DemandeService : EntityBaseReposotory<Demmande>, IDemandeService
    {
        private readonly AppDbContext _context;
        public DemandeService(AppDbContext context) : base(context)
        {


        }

    }
}
