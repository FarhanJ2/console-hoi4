using System.Collections.Generic;
using System;
using System.ComponentModel;

public class Notifications 
{
  public List<Notification> NotificationList { get; set; }

  public Notifications()
  {
    NotificationList = new List<Notification>();
  }

  public void AddNotification(Notification notification)
  {
    NotificationList.Add(notification);
  }

  public void RemoveNotification(Notification notification) 
  {
    NotificationList.Remove(notification);
  }

  public async Task DisplayNotifications()
  {
    await Task.Run(() =>
    {
      Console.ForegroundColor = ConsoleColor.Yellow;
    
      foreach (Notification n in NotificationList)
      {
        Console.WriteLine($"{n.Title}: {n.Message}");
      }
      
      Console.ResetColor();
    });
  }

  public void OpenNotificationsLog()
  {
    Console.WriteLine("Notification Log:");
    
    foreach (Notification n in NotificationList)
    {
      switch (n.Type)
      {
        case NotificationType.Event:
          Console.ForegroundColor = ConsoleColor.Red;
          break;
        case NotificationType.Warning:
          Console.ForegroundColor = ConsoleColor.Yellow;
          break;
        case NotificationType.Error:
          Console.ForegroundColor = ConsoleColor.DarkBlue;
          break;
      }

      // if (NotificationList.Count > 5)
      // {
      //   NotificationList.Remove(n);
      // }

      Console.WriteLine($"{n.Timestamp} - {n.Title}: {n.Message}"); 
    }
    
    Console.ResetColor();
    Console.ReadLine();
  }
}

public class Notification
{
  public string Title { get; set; }
  public string Message { get; set; }
  public NotificationType Type { get; set; } 
  public DateTime Timestamp { get; set; }
}

public enum NotificationType
{
  Event,
  Warning,
  Error
}
