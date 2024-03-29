﻿using Furnivault.Core.Entities;

namespace Furnivault.Core.Interfaces
{
    public interface IGroupRepository
    {
        Group GetById(int id);

        IEnumerable<Group> GetAll();

        void Add(Group group);

        void Update(int id, string newName);

        void Delete(int id);
    }
}