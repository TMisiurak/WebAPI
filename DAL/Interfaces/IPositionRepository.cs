using System.Collections.Generic;
using System.Threading.Tasks;
using ProjectCore.Models;

namespace DAL.Interfaces
{
    public interface IPositionRepository
    {
        Task<IList<Position>> GetAll();
        Task<Position>GetById(int id);
        Task<Position> Create(Position position);
        Task<Position> Update(Position position);
        Task<int> Delete(int id);
    }
}
