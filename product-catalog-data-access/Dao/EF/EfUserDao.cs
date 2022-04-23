using System.Data.Entity;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using product_catalog_data_access.EfModels;
using product_catalog_data_access.Interfaces;
using product_catalog_data_model.Exceptions;
using User = product_catalog_data_model.Model.Security.User;

namespace product_catalog_data_access.Dao.EF;

/// <inheritdoc />
public class EfUserDao : IUserDao
{
    private readonly ProductCatalogDbContext _context;

    private readonly IMapper _mapper;

    /// <summary>
    /// ctor
    /// </summary>
    /// <param name="mapper"></param>
    /// <param name="context"></param>
    public EfUserDao(IMapper mapper, ProductCatalogDbContext context)
    {
        _mapper = mapper;
        _context = context;
    }

    /// <inheritdoc />
    public async Task<IEnumerable<User>> GetAll()
    {
        var data = await EntityFrameworkQueryableExtensions.ToListAsync(_context.Users);
        return _mapper.Map<IEnumerable<EfModels.User>, IEnumerable<User>>(data);
    }

    /// <inheritdoc />
    public async Task<IEnumerable<User>> GetAllPaged(int page, int count)
    {
        var usersCount = await EntityFrameworkQueryableExtensions.CountAsync(_context.Users);
        var skip = Utility.SkipForPage(page, count);
        if (skip > usersCount)
        {
            throw new PageNotValidException($"Zadaná stránka {page} není validní.");
        }

        var data = await EntityFrameworkQueryableExtensions.ToListAsync(_context.Users.Skip(skip).Take(count));
        return _mapper.Map<IEnumerable<EfModels.User>, IEnumerable<User>>(data);
    }

    /// <inheritdoc />
    public async Task<User> GetById(long id)
    {
        var user = await GetByIdInternal(id);

        return _mapper.Map<User>(user);
    }

    /// <inheritdoc />
    public async Task<long> Create(User item)
    {
        var user = _mapper.Map<EfModels.User>(item);

        _context.Add(user);

        await _context.SaveChangesAsync();

        return user.Id;
    }

    /// <inheritdoc />
    public async Task Update(long id, User item)
    {
        var user = await GetByIdInternal(id);

        user.Password = item.Password;

        _context.Update(user);

        await _context.SaveChangesAsync();
    }

    /// <inheritdoc />
    public async Task Delete(long id)
    {
        var user = await GetByIdInternal(id);

        _context.Remove(user);

        await _context.SaveChangesAsync();
    }

    /// <inheritdoc />
    public async Task<User> GetByLogin(string login)
    {
        var user = _context.Users.FirstOrDefault(x => x.Login == login);

        if (user == null)
        {
            throw new ItemNotFoundException($"Uživatel nebyl nalezen.");
        }

        var item = _mapper.Map<User>(user);

        return await Task.FromResult(item);
    }

    private async Task<EfModels.User> GetByIdInternal(long id)
    {
        var item = await _context.Users.FindAsync(id);

        if (item == null)
        {
            throw new ItemNotFoundException($"Uživatel se zadaným id {id} nebyl nalezen.");
        }

        return item;
    }
}
