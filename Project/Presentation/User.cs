﻿public class User
{
    static public void CurrentUser()
    {
        AccountModel current_user = Factory.accountsLogic.Return_Current_User();
        if (current_user == null)
        {
            Console.WriteLine("\n\nYou are currently not logged in \n\n");
        }
        else
        {
            Console.ForegroundColor= ConsoleColor.DarkGreen;
            Console.WriteLine($"\n\nYou are logged in as {current_user.FullName}\n\n ");
            Console.ResetColor();
        }
    }
}