using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CookBook.Models;
public class CookingTimer
{
    public TimeSpan StartTime {  get; }
    public TimeSpan ElapsedTime { get; private set; }

    public bool IsRunning { get; set; }

    public CookingTimer(TimeSpan startTime)
    {
        StartTime = startTime;
        ElapsedTime = startTime;
    }

    public void OnTick()
    {
        if (IsRunning) ElapsedTime -= TimeSpan.FromSeconds(1);
    }

    public void Start()
    { 
        IsRunning = true; 
    }

    public void Pause()
    {
        IsRunning = false;
    }

    public void Reset()
    {
        ElapsedTime = StartTime;
    }
}

