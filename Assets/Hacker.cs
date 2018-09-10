using UnityEngine;
using System;

public class Hacker : MonoBehaviour {

    //Game configuration data
    string[] level1Passwords = {"books", "aisle", "shelf", "password", "font", "borrow" };
    string[] level2Passwords = { "prisoner", "handcuffs", "holster", "uniform", "arrest" };
    string[] level3Paddwords = { "starfield", "telescope", "environment", "exploration", "astronauts" };
    // Game state
    int level;
    enum Screen { MainMenu, Password, Win };
    Screen currentScreen;
    string password;

	// Use this for initialization
    void Start () 
    {
        ShowMainMenu();
	}

    void ShowMainMenu() 
    {
        currentScreen = Screen.MainMenu;
        Terminal.ClearScreen();
        Terminal.WriteLine("What would you like to hack into?");
        Terminal.WriteLine("Press 1 for the local library.");
        Terminal.WriteLine("Press 2 for the police station.");
        Terminal.WriteLine("Enter your selection: ");
    }

    void OnUserInput(string input) 
    {
        if (input == "menu") // We can always go direct to main menu
        {
            ShowMainMenu();
        }
        else if (currentScreen == Screen.MainMenu)
        {
            RunMainMenu(input);
        } 
        else if (currentScreen == Screen.Password)
        {
            CheckPassword(input);
        }
    }

    void RunMainMenu(string input)
    {
        bool isValidLevelNumber = (input == "1" || input == "2");
        if (isValidLevelNumber)
        {
            level = int.Parse(input);
            StartGame(level);
        }
        else if (input == "007")
        {
            Terminal.WriteLine("Please select a level Mr Bond.");
        }
        else
        {
            Terminal.WriteLine("Please choose a valid level.");
        }
    }

    void CheckPassword(string input)
    {
        if (input == password)
        {
            DisplayWinScreen();
        }
        else 
        {
            Terminal.WriteLine("Sorry, wrong password my G.");
        }
    }

    void DisplayWinScreen()
    {
        currentScreen = Screen.Win;
        Terminal.ClearScreen();
        ShowLevelReward();
        Terminal.WriteLine("Press menu to start again!");
    }

    void ShowLevelReward()
    {
        switch(level)
        {
            case 1:
                Terminal.WriteLine("You've beaten level 1 - have a book.");
                Terminal.WriteLine(@"
    _______
   /      /,
  /      //
 /______//
(______(/
           
"        
                );
                break;
            case 2:
                Terminal.WriteLine("You've beaten level 2 - have a badge!");
                Terminal.WriteLine(@"
   ,   /\   ,
  / '-'  '-' \
  |  POLICE  |
  |   .--.   |
  |  ( 19 )  |
  \   '--'   /
   '--.  .--'
       \/             
" );
                break;
            default:
                print("Something went wrong");
                break;
        }
    }

    void StartGame(int level)
    {
        currentScreen = Screen.Password;
        Terminal.ClearScreen();
        SetRandomPassword(level);
        Terminal.WriteLine("You have chosen " + level);
        Terminal.WriteLine("Enter your password: " + password.Anagram());
    }

    void SetRandomPassword(int level)
    {
        switch (level)
        {
            case 1:
                int index1 = Random.Range(0, level1Passwords.Length);
                password = level1Passwords[index1];
                break;
            case 2:
                int index2 = Random.Range(0, level2Passwords.Length);
                password = level2Passwords[index2];
                break;
            default:
                Debug.LogError("Invalid level number");
                break;
        }
    }
}
