﻿using Core.Entities;

namespace Core.Interfaces.IRepositories;

public interface ISharedCalendarRepository : IRepository<SharedCalendar>
{
    public Task<List<SharedCalendar>> GetAllSharedCalendars();

    public Task<SharedCalendar?> GetSharedCalendarById(int sharedCalendarId);
}
