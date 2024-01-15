using Newtonsoft.Json;
using System;
using System.Collections.Generic;

public class NewsPopup
{
    public string? Headline { get; set; }
    public string? Content { get; set; }
    public DateTime Date { get; set; }
}

public class EventSystem
{
    public static event Action<string>? FocusCompleted;


    public static void OnFocusCompleted(string focusName)
    {
        FocusCompleted?.Invoke(focusName);
    }
}
