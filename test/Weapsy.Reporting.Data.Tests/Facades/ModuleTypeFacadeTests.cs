﻿using System;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using Weapsy.Data;
using Weapsy.Domain.ModuleTypes;
using Weapsy.Tests.Shared;
using ModuleType = Weapsy.Data.Entities.ModuleType;

namespace Weapsy.Reporting.Data.Tests.Facades
{
    [TestFixture]
    public class ModuleTypeFacadeTests
    {
        private DbContextOptions<WeapsyDbContext> _contextOptions;
        private Guid _moduleTypeId;

        [SetUp]
        public void Setup()
        {
            _contextOptions = DbContextShared.CreateContextOptions();

            using (var context = new WeapsyDbContext(_contextOptions))
            {
                _moduleTypeId = Guid.NewGuid();

                context.ModuleTypes.AddRange(
                    new ModuleType
                    {
                        Id = _moduleTypeId,
                        Name = "ModuleType 1",
                        Status = ModuleTypeStatus.Active
                    }
                );

                context.SaveChanges();
            }
        }
    }
}
