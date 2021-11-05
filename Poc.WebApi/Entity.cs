using System;
using NodaTime;

namespace Poc.WebApi
{
    public class Entity
    {
        public Guid Id { get; set; }
        public LocalDateTime LocalDateTime { get; set; }
    }
}