//===========================
// Copyright (c) Tarteeb LLC
// Powering True Leadership
//===========================

using Excel.Importer.Models.Groups;
using System.Threading.Tasks;

namespace Excel.Importer.Services.Processings.Groups
{
    public interface IGroupProcessingService
    {
        ValueTask<Group> EnsureGroupExistsByName(string groupName);
    }
}
