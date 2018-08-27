using System.Collections.Generic;
using System.Threading.Tasks;
using ProjectCore;
using ProjectCore.DTO;

namespace BLL.Interfaces
{
    public interface IPositionService
    {
        Task<IList<PositionDTO>> GetAll();
        Task<PositionDTO> GetById(int id);
        Task<PositionDTO> Create(PositionDTO employee);
        Task<PositionDTO> Update(PositionDTO employee);
        Task<int> Delete(int id);
    }
}
