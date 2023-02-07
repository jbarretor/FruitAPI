using DataAcess;
using DataAcess.Repository;
using Entities;

namespace BusinessLogic
{
    public interface IBLFruit
    {
        Task<FruitDTO> Create(FruitDTO input);
        Task<FruitDTO> FindById(long id);
        Task<IEnumerable<FruitDTO>> FindAll();
        Task<FruitDTO> Update(long id, FruitDTO fruitDTO);
        Task Delete(long id);
    }

    public class BLFruit : IBLFruit
    {
        private IFruitRepository _repo;

        public BLFruit(IFruitRepository repo)
        {
            _repo = repo;
        }

        public async Task<FruitDTO> Create(FruitDTO input)
        {
            FruitDTO fruit = await _repo.Save(input);
            return fruit;
        }

        public async Task<FruitDTO> FindById(long id)
        {
            return await _repo.FindById(id);
        }

        public async Task<IEnumerable<FruitDTO>> FindAll()
        {
            return await _repo.FindAll();
        }

        public async Task<FruitDTO> Update(long id, FruitDTO fruitDTO)
        {
            return await _repo.Update(id, fruitDTO);
        }

        public async Task Delete(long id)
        {
            await _repo.Delete(id);
        }
    }
}