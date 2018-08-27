using System.Collections.Generic;
using System.Threading.Tasks;
using DAL.EF;
using DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using ProjectCore.Models;

namespace DAL.Repositories
{
    public class PositionRepository : IPositionRepository
    {
        readonly ApplicationContext db;

        public PositionRepository(ApplicationContext applicationContext)
        {
            db = applicationContext;
        }
        public async Task<IList<Position>> GetAll()
        {
            var positions = await db.Positions.ToListAsync();

            return positions;
        }

        public async Task<Position> GetById(int id)
        {
            Position position = await db.Positions.FindAsync(id);
            return position;
        }

        public async Task<Position> Create(Position position)
        {
            await db.Set<Position>().AddAsync(position);
            await db.SaveChangesAsync();
            return position;
        }

        public async Task<Position> Update(Position position)
        {
            db.Entry(position).State = EntityState.Modified;
            await db.SaveChangesAsync();
            return position;
        }

        public async Task<int> Delete(int id)
        {
            Position position = await db.Positions.FindAsync(id);
            db.Remove(position);

            int result = await db.SaveChangesAsync();
            return result;
        }
    }
}
