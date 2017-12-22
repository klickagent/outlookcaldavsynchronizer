﻿// This file is Part of CalDavSynchronizer (http://outlookcaldavsynchronizer.sourceforge.net/)
// Copyright (c) 2015 Gerhard Zehetbauer
// Copyright (c) 2015 Alexander Nimmervoll
// 
// This program is free software: you can redistribute it and/or modify
// it under the terms of the GNU Affero General Public License as
// published by the Free Software Foundation, either version 3 of the
// License, or (at your option) any later version.
// 
// This program is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU Affero General Public License for more details.
// 
// You should have received a copy of the GNU Affero General Public License
// along with this program.  If not, see <http://www.gnu.org/licenses/>.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using CalDavSynchronizer.Contracts;
using CalDavSynchronizer.Implementation.ComWrappers;
using CalDavSynchronizer.Utilities;
using GenSync.Logging;
using log4net;
using Microsoft.Office.Interop.Outlook;

namespace CalDavSynchronizer.Implementation.Events
{
  public class EventSynchronizationContext : IEventSynchronizationContext
  {
    private readonly IColorCategoryMapper _colorCategoryMapper;
    private static readonly ILog s_logger = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

    public EventSynchronizationContext(IDuplicateEventCleaner duplicateEventCleaner, IColorCategoryMapper colorCategoryMapper)
    {
      _colorCategoryMapper = colorCategoryMapper ?? throw new ArgumentNullException(nameof(colorCategoryMapper));
      DuplicateEventCleaner = duplicateEventCleaner ?? throw new ArgumentNullException(nameof(duplicateEventCleaner));
    }

    public IDuplicateEventCleaner DuplicateEventCleaner { get; }

    public string MapHtmlColorToCategoryOrNull(string htmlColor, IEntityMappingLogger logger)
    {
      return _colorCategoryMapper.MapHtmlColorToCategoryOrNull(htmlColor, logger);
    }

    public string MapCategoryToHtmlColorOrNull(string categoryName)
    {
      return _colorCategoryMapper.MapCategoryToHtmlColorOrNull(categoryName);
    }
  }
}