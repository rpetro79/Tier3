using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SEP3.Model;
using SEP3.DbModel;
using SEP3.DbContexts;
using Microsoft.EntityFrameworkCore;

namespace SEP3.DbManagement
{
    public class TechnologiesDb
    {
        public static List<string> getTechnologiesOfProvider(string username, UserContext _context)
        {
            List<DbTechnologies> techs = new List<DbTechnologies>();
            techs = _context.technologies.Where(technology => technology.Username == username).ToList<DbTechnologies>();

            List<string> technologies = new List<string>();
            foreach (DbTechnologies t in techs)
            {
                technologies.Add(t.Technology);
            }

            return technologies;
        }

        public async static Task<bool> putTechnologies(List<DbTechnologies> techs, UserContext _context)
        {

            List<DbTechnologies> toDeleteTechs = _context.technologies.Where(tec => tec.Username == techs[1].Username).ToList<DbTechnologies>();
            foreach (DbTechnologies t in toDeleteTechs)
            {
                _context.technologies.Remove(t);
            }
            await _context.SaveChangesAsync();

            foreach (DbTechnologies t in techs)
            {
                _context.technologies.Add(t);
            }

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                return false;
            }

            return true;
        }

        public async static Task<bool> postTechnologies(List<DbTechnologies> techs, UserContext _context)
        {
            foreach (DbTechnologies tec in techs)
            {
                _context.technologies.Add(tec);
            }

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                return false;
            }

            return true;
        }

        public async static Task deleteTechnologiesOfProvider(string username, UserContext _context)
        {
            List<DbTechnologies> techs = _context.technologies.Where(tec => tec.Username == username).ToList<DbTechnologies>();
            foreach (DbTechnologies tec in techs)
            {
                _context.technologies.Remove(tec);
            }
            await _context.SaveChangesAsync();
        }
    }
}
