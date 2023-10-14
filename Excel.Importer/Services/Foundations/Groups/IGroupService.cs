//===========================
// Copyright (c) Tarteeb LLC
// Powering True Leadership
//===========================

using Excel.Importer.Models.Groups;
using System.Linq;
using System.Threading.Tasks;

namespace Excel.Importer.Services.Foundations.Groups
{
    public interface IGroupService
    {
        ValueTask<Group> AddGroupAsync(Group group);
        IQueryable<Group> RetrieveAllGroups();
    }
}
