//===========================
// Copyright (c) Tarteeb LLC
// Powering True Leadership
//===========================

using Excel.Importer.Models.Groups;
using System.Linq;
using System.Threading.Tasks;

namespace Excel.Importer.Brokers.Storages
{
    public partial interface IStorageBroker
    {
        ValueTask<Group> InsertGroupAsync(Group group);
        IQueryable<Group> SelectAllGroups();
    }
}
