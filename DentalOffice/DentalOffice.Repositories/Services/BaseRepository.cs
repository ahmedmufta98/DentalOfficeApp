using AutoMapper;
using DentalOffice.Entities.dbContext;
using DentalOffice.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DentalOffice.Repositories.Services
{
    public class BaseRepository<Tkey, Tmodel, Tsearch, Tdb> : IBaseRepository<Tkey, Tmodel, Tsearch, Tdb> where Tmodel : class where Tsearch : class where Tdb : class
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public BaseRepository(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public virtual async Task<Tmodel> Create(Tmodel model)
        {
            Tdb entity = _mapper.Map<Tdb>(model);
            await _context.Set<Tdb>().AddAsync(entity);
            await _context.SaveChangesAsync();

            return _mapper.Map<Tmodel>(entity);
        }

        public virtual async Task<Tmodel?> Delete(Tkey id)
        {
            Tdb entity = _context.Set<Tdb>().Find(id);

            if (entity is not null)
            {
                _context.Set<Tdb>().Remove(entity);
                await _context.SaveChangesAsync();

                return _mapper.Map<Tmodel>(entity);
            }

            return null;
        }

        public virtual async Task<List<Tmodel>> GetAll(Tsearch? searchRequest)
        {
            return _mapper.Map<List<Tmodel>>(await _context.Set<Tdb>().ToListAsync());
        }

        public virtual async Task<Tmodel?> GetById(Tkey id)
        {
            Tdb entity = await _context.Set<Tdb>().FindAsync(id);

            if (entity is not null)
                return _mapper.Map<Tmodel>(entity);

            return null;
        }

        public virtual async Task<Tmodel> Update(Tkey id, Tmodel model)
        {
            Tdb entity = _context.Set<Tdb>().Find(id);

            _mapper.Map(model, entity);
            _context.Set<Tdb>().Attach(entity);
            _context.Set<Tdb>().Update(entity);
            await _context.SaveChangesAsync();

            return _mapper.Map<Tmodel>(entity);
        }
    }
}
