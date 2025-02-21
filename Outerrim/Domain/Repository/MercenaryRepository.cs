using Microsoft.EntityFrameworkCore;
using Model.Model;

namespace Domain.Repository;

public class MercenaryRepository : ARepositoryAsync<Mercenary>
{
    public MercenaryRepository(DbContext context) : base(context)
    {
    }
}