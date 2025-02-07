using CookBook.Models;
using System;
using System.Collections.Generic;

namespace CookBook.Services.Abstractions;
public interface ITimerService
{
    List<CookingTimer> GetTimers();

    void AddEvent(Action action);
    void RemoveEvent(Action action);

    CookingTimer AddTimer(TimeSpan time);
    CookingTimer AddTimer(CookingTimer timer);
    void RemoveTimer(CookingTimer timer);
}

