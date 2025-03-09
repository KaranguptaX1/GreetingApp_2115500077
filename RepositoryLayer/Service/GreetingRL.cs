using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModelLayer.Model;
using RepositoryLayer.Context;
using RepositoryLayer.Interface;
namespace RepositoryLayer.Service
{
    public class GreetingRL : IGreetingRL
    {
        public readonly HelloGreetingContext _context;
        public GreetingRL(HelloGreetingContext context)
        {
            _context = context;
        }
        public bool Add(GreetingModel greeting)
        {
            _context.Greetings.Add(greeting);
            try
            {
                _context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
