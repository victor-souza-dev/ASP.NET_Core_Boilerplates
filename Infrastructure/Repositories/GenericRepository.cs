using Domain.Entities;
using Infrastructure.Helpers;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
namespace Infrastructure.Repositories;

// Template Method
public abstract class GenericRepository<T, TList> {
    private readonly QueryManipulator _queryManipulator;
    private readonly IMemoryCache _memoryCache;

    public GenericRepository() {
        _queryManipulator = new QueryManipulator();
        _memoryCache = new MemoryCache(new MemoryCacheOptions());
    }

    // Método que realiza paginação em cima do resultado da GetItemsQuery - GetAll
    public async Task<TList> GetWithPagination(GenericPagination pagination) {
        string query = pagination.Query;
        int page = pagination.Page;
        int pageSize = pagination.Size;

        var formattedQuery = _queryManipulator.FormatQuery(query);
        string ME_KEY = $"{page}_{pageSize}_{formattedQuery}";

        if (_memoryCache.TryGetValue(ME_KEY, out TList? me)) {
            return me ?? throw new Exception("Valor obtido do cache é nulo.");
        }

        var memoryCacheEntryOptions = new MemoryCacheEntryOptions {
            AbsoluteExpirationRelativeToNow = TimeSpan.FromSeconds(3600),
            SlidingExpiration = TimeSpan.FromSeconds(1200)
        };

        ValidateParameters(ref page, ref pageSize);

        var itemsQuery = GetItemsQuery(formattedQuery);
        int totalCount = await itemsQuery.CountAsync();
        int startIndex = (page - 1) * pageSize;

        var itemsOnPage = await Task.Run(() =>
            itemsQuery
                .Skip(startIndex)
                .Take(pageSize)
                .ToList());

        bool hasNext = startIndex + pageSize < totalCount;

        TList payload = CreateList(itemsOnPage, totalCount, hasNext);

        _memoryCache.Set(ME_KEY, payload, memoryCacheEntryOptions);

        return payload;
    }

    // Método para fazer a busca dos dados no banco
    protected abstract IQueryable<T> GetItemsQuery(string formattedQuery);

    // Método para formatar o retorno dos dados
    protected abstract TList CreateList(List<T> items, int totalCount, bool hasNext);

    private void ValidateParameters(ref int page, ref int pageSize) {
        if (page <= 0)
            page = 1;

        if (pageSize <= 0)
            pageSize = 10;
    }
}