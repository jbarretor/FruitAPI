using DataAccess.Models;
using Entities;

namespace DataAcess.Repository
{
    public interface IFruitTypeRepository
    {
        Task<FruitTypeDTO> FindById(long id);
        Task<FruitTypeDTO> Save(FruitTypeDTO fruitDTO);
    }

    public class FruitTypeRepository : IFruitTypeRepository
    {
        public FruitContext _dbContext { get; set; }

        public FruitTypeRepository(FruitContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<FruitTypeDTO> FindById(long id)
        {
            FruitType result = _dbContext.FruitTypes.Where(x => x.Id == id).FirstOrDefault();
            FruitTypeDTO response = new FruitTypeDTO()
            {
                Id = result.Id,
                Description = result.Description,
                Name = result.Name
            };
            return response;
        }

        public async Task<FruitTypeDTO> Save(FruitTypeDTO fruitTypeDTO)
        {
            FruitType fruitType = _dbContext.FruitTypes.Where(x => x.Name == fruitTypeDTO.Name && x.Description == fruitTypeDTO.Description).FirstOrDefault();

            if (fruitType != null)
            {
                return new FruitTypeDTO() { Id = fruitType.Id, Description = fruitType.Description, Name = fruitType.Name };
            }

            FruitType fruit = new FruitType()
            {
                Name = fruitTypeDTO.Name,
                Description = fruitTypeDTO.Description,
            };
            var result = _dbContext.FruitTypes.Add(fruit);
            _dbContext.SaveChanges();
            fruitTypeDTO.Id = result.Entity.Id;
            return fruitTypeDTO;
        }
    }
}
