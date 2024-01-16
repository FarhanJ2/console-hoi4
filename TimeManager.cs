using System;
using System.Threading;

public class TimeManager
{
    public event Action<string> OnDateTimeChanged;

    private int currentDay = 0; // Start from January 1st
    private int currentMonth = 0; // Start from January
    private int currentHour = 0; // Start from midnight
    private bool isRunning = true;

    public void Start()
    {
        // Start the time loop in a separate thread
        Thread timeThread = new Thread(TimeLoop);
        timeThread.Start();
    }

    public void Stop()
    {
        isRunning = false;
    }

    private void TimeLoop()
    {
        while (isRunning)
        {
            // Increment the day (adjust as needed for your game's time scale)
            currentDay = (currentDay + 1) % 31; // Assuming 31 days in a month

            // Check if a new month has started
            if (currentDay == 0)
            {
                currentMonth = (currentMonth + 1) % 12; // Assuming 12 months in a year
            }

            // Increment the hour
            currentHour = (currentHour + 1) % 24; // 24 hours in a day

            // Trigger events when specific dates or times are reached
            HandleDateTimeChange();

            // Wait for a short time before the next iteration
            Thread.Sleep(1000); // 1 second (adjust as needed for your game speed)
        }
    }

    private void HandleDateTimeChange()
    {
        // You can customize this to trigger different events based on the current date and time
        string dateTimeString = $"{currentMonth + 1}/{currentDay + 1} - {currentHour:00}:00"; // Adding 1 to start from 1
        Console.WriteLine($"Current Date and Time: {dateTimeString}");

        OnDateTimeChanged?.Invoke(dateTimeString);
    }
}

public class Game
{
    private TimeManager timeManager;

    public Game()
    {
        timeManager = new TimeManager();
        timeManager.OnDateTimeChanged += HandleDateTimeChanged;
    }

    public void Start()
    {
        Console.WriteLine("Game started!");

        // Start the time manager
        timeManager.Start();

        // Your game logic can go here

        // To stop the game, you can call Stop on the time manager
        // timeManager.Stop();
    }

    private void HandleDateTimeChanged(string message)
    {
        // Handle events triggered by date and time changes
        Console.WriteLine(message);
    }
}