using System.Collections.Generic;
using System.Threading.Tasks;
using BLL.Interfaces;
using ProjectCore;
using AutoMapper;
using DAL.UnitOfWork;
using ProjectCore.Models;
using ProjectCore.DTO;

namespace BLL.Services
{
    public class PositionService : IPositionService
    {
        readonly IUnitOfWork _unitOfWork;
        readonly IMapper _mapper;

        public PositionService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IList<PositionDTO>> GetAll()
        {
            IList<Position> positions = await _unitOfWork.Positions.GetAll();
            var result = _mapper.Map<IList<PositionDTO>>(positions);
            return result;
        }

        public async Task<PositionDTO> GetById(int id)
        {
            Position position = await _unitOfWork.Positions.GetById(id);
            PositionDTO result = _mapper.Map<PositionDTO>(position);
            return result;
        }

        public async Task<PositionDTO> Create(PositionDTO position)
        {
            await _unitOfWork.Positions.Create(_mapper.Map<Position>(position));
            PositionDTO result = _mapper.Map<PositionDTO>(position);
            return result;
        }

        public async Task<PositionDTO> Update(PositionDTO position)
        {
            await _unitOfWork.Positions.Update(_mapper.Map<Position>(position));
            return position;
        }

        public async Task<int> Delete(int id)
        {
            int result = await _unitOfWork.Positions.Delete(id);
            return result;
        }
    }
}
