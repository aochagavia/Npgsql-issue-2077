using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using NodaTime;
using Poc.WebApi;
using Xunit;

namespace Poc.Test
{
    public class UnitTest1 : IClassFixture<WebApplicationFactory<Startup>>
    {
        private readonly WebApplicationFactory<Startup> _factory;

        public UnitTest1(WebApplicationFactory<Startup> factory)
        {
            _factory = factory;
        }

        [Fact]
        public async Task Project_LocalDate_Succeeds()
        {
            using var scope = _factory.Services.CreateScope();
            var db = scope.ServiceProvider.GetRequiredService<Db>();

            db.Entities.Add(new() { LocalDateTime = LocalDateTime.FromDateTime(DateTime.Today) });
            await db.SaveChangesAsync();

            await db.Entities.Select(entity => entity.LocalDateTime.Date).ToArrayAsync();
        }
    }
}