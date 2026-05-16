using MongoDB.Driver;
using Vyracare.Api.Proceedings.Models;

namespace Vyracare.Api.Proceedings.Services;

public class ProceedingsService
{
    private readonly IMongoCollection<ProceedingsModel> _collection;

    public ProceedingsService(IMongoDatabase db)
    {
        _collection = db.GetCollection<ProceedingsModel>("proceedings");
    }

    public async Task<List<ProceedingsModel>> GetAllAsync()
    {
        return await _collection.Find(Builders<ProceedingsModel>.Filter.Empty).ToListAsync();
    }

    public async Task<ProceedingsModel?> GetByIdAsync(string id)
    {
        return await _collection.Find(item => item.Id == id).FirstOrDefaultAsync();
    }

    public async Task CreateAsync(ProceedingsModel item)
    {
        item.CreatedAt = DateTime.UtcNow;
        item.UpdatedAt = item.CreatedAt;
        await _collection.InsertOneAsync(item);
    }
}
