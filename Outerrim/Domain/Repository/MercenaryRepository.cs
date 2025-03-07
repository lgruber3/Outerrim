using Microsoft.EntityFrameworkCore;
using Model;
using Model.Model;

namespace Domain.Repository;

public class MercenaryRepository : ARepositoryAsync<Mercenary>
{
    public MercenaryRepository(OuterrimContext context) : base(context)
    {
    }
}