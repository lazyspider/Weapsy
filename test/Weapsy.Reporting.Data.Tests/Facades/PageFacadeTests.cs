﻿using System;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using Weapsy.Data;
using Weapsy.Domain.Pages;
using Weapsy.Tests.Shared;
using Page = Weapsy.Data.Entities.Page;

namespace Weapsy.Reporting.Data.Tests.Facades
{
    [TestFixture]
    public class PageFacadeTests
    {
        private DbContextOptions<WeapsyDbContext> _contextOptions;
        private Guid _pageId;

        [SetUp]
        public void Setup()
        {
            _contextOptions = DbContextShared.CreateContextOptions();

            using (var context = new WeapsyDbContext(_contextOptions))
            {
                _pageId = Guid.NewGuid();

                context.Pages.AddRange(
                    new Page
                    {
                        Id = _pageId,
                        Name = "Page 1",
                        Status = PageStatus.Active
                    }
                );

                context.SaveChanges();
            }
        }
    }
}
