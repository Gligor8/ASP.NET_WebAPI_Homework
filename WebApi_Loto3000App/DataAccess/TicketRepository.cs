using DataModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess
{
    public class TicketRepository : IRepository<TicketDbo>
    {
        private readonly LottoAppDbContext _context;
        public TicketRepository(LottoAppDbContext context)
        {
            _context = context;
        }
        public void Add(TicketDbo entity)
        {
            _context.Tickets.Add(entity);
            _context.SaveChanges();
        }

        public void Delete(TicketDbo entity)
        {
            _context.Tickets.Remove(entity);
            _context.SaveChanges();
        }

        public IEnumerable<TicketDbo> GetAll()
        {
           return  _context.Tickets;
        }

        public void Update(TicketDbo entity)
        {
            _context.Tickets.Update(entity);
            _context.SaveChanges();
        }
    }
}
