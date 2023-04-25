using System;

namespace FinalExam.Models
{
    public class EFEntertainersRepository : IEntertainersRepository
    {
        private EntertainmentDbContext _context { get; set; }

        public EFEntertainersRepository (EntertainmentDbContext temp)
        {
            _context = temp;
        }

        public IQueryable<Entertainer> Entertainers => _context.Entertainers;
    }
}

