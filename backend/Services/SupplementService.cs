namespace Furny.Services
{
    //public class SupplementService
    //{
    //    private readonly IMongoCollection<Supplement> _supplement;

    //    public SupplementService(IConfiguration config)
    //    {
    //        var client = new MongoClient(config.GetConnectionString("FurnyDb"));
    //        var database = client.GetDatabase("FurnyDb"); 
    //         _supplement = database.GetCollection<Supplement>("Supplements");
    //    }

    //    public async Task<List<Supplement>> Get()
    //    {
    //        return await _supplement.Find(s => true).ToListAsync();
    //    }

    //    public async Task<Supplement> Get(string id)
    //    {
    //        return await _supplement.Find(s => s.Id == id).FirstOrDefaultAsync();
    //    }

    //    public async Task<Supplement> Create(Supplement s)
    //    {
    //        await _supplement.InsertOneAsync(s);
    //        return s;
    //    }

    //    public async Task<Supplement> Update(string id, Supplement s)
    //    {
    //        await _supplement.ReplaceOneAsync(su => su.Id == id, s);
    //        return s;
    //    }

    //    public async Task Remove(string id)
    //    {
    //        await _supplement.DeleteOneAsync(su => su.Id == id);
    //    }

    //}
}
