using Application.Services.Repositories;
using Core.Persistence.Repositories;
using Core.Security.Entities;
using Microsoft.EntityFrameworkCore;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class RefreshTokenRepository : EfRepositoryBase<RefreshToken, int, BaseDbContext>, IRefreshTokenRepository
{
    public RefreshTokenRepository(BaseDbContext context) : base(context)
    {
    }

    public async Task<List<RefreshToken>> GetOldRefreshTokenAsync(int userId, int refreshTokenTTL)
    {
        List<RefreshToken> tokens = await Query()
            .AsNoTracking()
            .Where(rt =>
                rt.UserId == userId && rt.Revoked == null && rt.Expires >= DateTime.UtcNow &&
                rt.CreatedDate.AddDays(refreshTokenTTL) <= DateTime.UtcNow).ToListAsync();
        return tokens;
    }
}