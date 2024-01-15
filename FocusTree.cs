using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;

public class FocusTree
{
    private List<Branch> branches;

    public FocusTree(List<Branch> branches)
    {
        this.branches = branches;
    }

    public void DisplayFocusTree()
    {
        Console.WriteLine("Focus Tree:");
        foreach (var branch in branches)
        {
            Console.WriteLine($"- {branch.Name}");
            foreach (var focus in branch.Focuses)
            {
                Console.WriteLine($"  - {focus.Name} ({focus.Requirements})");
            }
        }
    }

    public Focus SelectFocus()
    {
        DisplayFocusTree();
        Console.WriteLine("Select a focus:");

        // Get user input for branch and focus
        Console.Write("Enter branch name: ");
        string branchName = Console.ReadLine();
        Console.Write("Enter focus name: ");
        string focusName = Console.ReadLine();

        // Find the selected focus in the focus tree
        Branch selectedBranch = branches.Find(b => b.Name.Equals(branchName, StringComparison.OrdinalIgnoreCase));
        if (selectedBranch != null)
        {
            Focus selectedFocus = selectedBranch.Focuses.Find(f => f.Name.Equals(focusName, StringComparison.OrdinalIgnoreCase));
            if (selectedFocus != null && CheckRequirements(selectedFocus.Requirements))
            {
                return selectedFocus;
            }
        }

        Console.WriteLine("Invalid focus selection or requirements not met. Please try again.");
        return SelectFocus(); // Recursive call if the selection is invalid
    }

    private bool CheckRequirements(string requirements)
    {
        if (string.IsNullOrEmpty(requirements))
        {
            return true; // No requirements specified
        }

        // Split requirements into individual conditions
        string[] conditions = requirements.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);

        // Check each condition
        foreach (var condition in conditions)
        {
            if (!CheckCondition(condition.Trim()))
            {
                return false; // Player doesn't meet a requirement
            }
        }

        return true; // All requirements are met
    }

    private bool CheckCondition(string condition)
    {
        // Example: "Germany Exists"
        string[] parts = condition.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
        if (parts.Length == 2)
        {
            string target = parts[0];
            string comparison = parts[1];

            // Check if the player meets the condition
            // You may need to replace this with your specific game logic
            if (target.Equals("Germany", StringComparison.OrdinalIgnoreCase))
            {
                // Assume the player always meets the condition for "Germany Exists"
                return true;
            }
        }

        // Unknown or unsupported condition
        return false;
    }
}

public class Branch
{
    public string Name { get; set; }
    public List<Focus> Focuses { get; set; }
}

public class Focus
{
    public string Name { get; set; }
    public string Effect { get; set; }
    public string CompletionEvent { get; set; }
    public int TimeToComplete { get; set; }
    public string Requirements { get; set; }
}

// Player.cs
public class Player
{
    public void DoFocus(Focus selectedFocus)
    {
        Console.WriteLine($"Selected focus: {selectedFocus.Name}");
        Console.WriteLine($"Effect: {selectedFocus.Effect}");
        Console.WriteLine($"Time to complete: {selectedFocus.TimeToComplete} days");
        // Trigger any other actions related to completing the focus
    }
}

// Program.cs
class JsonReader
{
    static void InitReader()
    {
        // Load focus tree from JSON
        string jsonFilePath = "path/to/your/focustree.json"; // Replace with the actual path to your JSON file
        string jsonContent = ReadJsonFromFile(jsonFilePath);
        List<Branch> focusTreeData = JsonConvert.DeserializeObject<List<Branch>>(jsonContent);

        // Initialize FocusTree
        FocusTree focusTree = new FocusTree(focusTreeData);

        // Player selects a focus
        Focus selectedFocus = focusTree.SelectFocus();

        // Player performs the selected focus
        Player player = new Player();
        player.DoFocus(selectedFocus);
    }

    static string ReadJsonFromFile(string filePath)
    {
        try
        {
            // Read the entire file content
            string jsonContent = File.ReadAllText(filePath);
            return jsonContent;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error reading JSON file: {ex.Message}");
            return null;
        }
    }

    // Add ReadJsonFromFile method from the previous examples
}
