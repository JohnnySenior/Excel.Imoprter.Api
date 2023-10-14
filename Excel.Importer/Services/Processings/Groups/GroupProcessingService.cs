﻿//===========================
// Copyright (c) Tarteeb LLC
// Powering True Leadership
//===========================

using Excel.Importer.Brokers.DateTimes;
using Excel.Importer.Brokers.Loggings;
using Excel.Importer.Services.Foundations.Groups;
using System.Threading.Tasks;
using System;
using Excel.Importer.Models.Groups;
using System.Linq;

namespace Excel.Importer.Services.Processings.Groups
{
    public class GroupProcessingService : IGroupProcessingService
    {
        private readonly IDateTimeBroker dateTimeBroker;
        private readonly IGroupService groupService;
        private readonly ILoggingBroker loggingBroker;

        public GroupProcessingService(
            IGroupService groupService,
            IDateTimeBroker dateTimeBroker,
            ILoggingBroker loggingBroker)
        {
            this.groupService = groupService;
            this.dateTimeBroker = dateTimeBroker;
            this.loggingBroker = loggingBroker;
        }

        public async ValueTask<Group> EnsureGroupExistsByName(string groupName)
        {
            var maybeGroup = RetriveGroupByName(groupName);

            return maybeGroup is null
                ? await AddGroupAsync(groupName)
                : maybeGroup;
        }

        private Group RetriveGroupByName(string groupName)
        {
            var allGroups = groupService.RetrieveAllGroups();

            return allGroups.FirstOrDefault(storageGroup =>
                storageGroup.GroupName == groupName);
        }

        private async ValueTask<Group> AddGroupAsync(string groupName)
        {
            var group = new Group
            {
                GroupId = Guid.NewGuid(),
                GroupName = groupName
            };

            return await groupService.AddGroupAsync(group);
        }
    }
}
