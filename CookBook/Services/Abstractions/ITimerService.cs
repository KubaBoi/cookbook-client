using CookBook.Models;
using System;
using System.Collections.Generic;

namespace CookBook.Services.Abstractions;
public interface ITimerService
{
    /// <summary>
    /// Return active timers (paused or running)
    /// </summary>
    /// <returns></returns>
    List<CookingTimer> GetTimers();

    /// <summary>
    /// Other services could add some method which would be called 
    /// every second like timers.
    /// </summary>
    /// <param name="action"></param>
    void AddEvent(Action action);

    /// <summary>
    /// Remove the event for dispozable services.
    /// </summary>
    /// <param name="action"></param>
    void RemoveEvent(Action action);

    /// <summary>
    /// Create new timer and start it
    /// </summary>
    /// <param name="time"></param>
    /// <returns></returns>
    CookingTimer AddTimer(TimeSpan time);
    
    /// <summary>
    /// Create new timer and start it
    /// </summary>
    /// <param name="timer"></param>
    /// <returns></returns>
    CookingTimer AddTimer(CookingTimer timer);
    
    /// <summary>
    /// Remove timer
    /// </summary>
    /// <param name="timer"></param>
    void RemoveTimer(CookingTimer timer);
}

