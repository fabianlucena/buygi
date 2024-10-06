﻿using backend_buygi.Repo;
using backend_buygi.EntitiesLib;

namespace backend_buygi.ServicesLib
{
    public abstract class ServiceTimestampsIdUuid<Repo, Entity> : ServiceTimestampsId<Repo, Entity>
        where Repo : IRepo<Entity>
        where Entity : EntityTimestampsIdUuid
    {
        public ServiceTimestampsIdUuid(Repo repo)
            : base(repo) { }

        public override async Task<Entity> ValidateForCreation(Entity data)
        {
            data = await base.ValidateForCreation(data);

            if (data.Uuid == Guid.Empty)
            {
                data.Uuid = Guid.NewGuid();
            };

            return data;
        }
    }
}
