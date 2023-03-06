using Entities;
using Models;

namespace DataAcess.Repository
{
    public interface IFruitRepository
    {
        Task<IEnumerable<FruitDTO>> FindAll();
        Task<FruitDTO> FindById(long id);
        Task<FruitDTO> Save(FruitDTO fruitDTO);
        Task<FruitDTO> Update(long id, FruitDTO fruitDTO);
        Task Delete(long id);
    }

    public class FruitRepository : IFruitRepository
    {
        private FruitContext _dbContext { get; set; }
        private FruitTypeRepository FruitTypeRepository { get; set; }

        public FruitRepository(FruitContext dbContext)
        {
            _dbContext = dbContext;
            FruitTypeRepository = new FruitTypeRepository(dbContext);
        }

        public async Task Delete(long id)
        {
            Fruit fruit = _dbContext.Fruits.Where(x => x.Id == id).FirstOrDefault();

            _dbContext.Fruits.Remove(fruit);
            _dbContext.SaveChanges();
        }

        public async Task<IEnumerable<FruitDTO>> FindAll()
        {
            List<Fruit> result = _dbContext.Fruits.ToList();
            List<FruitDTO> response = new List<FruitDTO>();
            foreach (var fruit in result)
            {
                response.Add(new FruitDTO()
                {
                    Id = fruit.Id,
                    Name = fruit.Name,
                    Description = fruit.Description,
                    Type = await FruitTypeRepository.FindById(fruit.Type)
                });
            }
            return response;
        }

        public async Task<FruitDTO> FindById(long id)
        {
            Fruit result = _dbContext.Fruits.Where(x => x.Id == id).FirstOrDefault();
            FruitDTO response = new FruitDTO()
            {
                Id = result.Id,
                Description = result.Description,
                Name = result.Name,
                Type = await FruitTypeRepository.FindById(result.Type)
            };
            return response;
        }

        public async Task<FruitDTO> Save(FruitDTO fruitDTO)
        {
            await FruitTypeRepository.Save(fruitDTO.Type);

            Fruit fruit = new Fruit()
            {
                Type = fruitDTO.Type.Id,
                Name = fruitDTO.Name,
                Description = fruitDTO.Description,
            };
            var result = _dbContext.Fruits.Add(fruit);
            _dbContext.SaveChanges();
            fruitDTO.Id = result.Entity.Id;
            return fruitDTO;
        }

        public async Task<FruitDTO> Update(long id, FruitDTO fruitDTO)
        {
            Fruit fruit = _dbContext.Fruits.Where(x => x.Id == id).FirstOrDefault();


            fruit.Description = fruitDTO.Description;
            fruit.Name = fruitDTO.Name;
            fruit.Type = fruitDTO.Type.Id;

            var result = _dbContext.Update(fruit);
            _dbContext.SaveChanges();
            return fruitDTO;
        }
    }
}
