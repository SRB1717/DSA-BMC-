using System;
using MySql.Data.MySqlClient;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace TodoApp
{
    internal class Program
    {
        private static string connString = "Server=localhost;Database=todo;User=root;Password=suman;";

        private static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("We are creating a todo app");
                Console.WriteLine("Add task");
                Console.WriteLine("View task");
                Console.WriteLine("Remove task");

                string userChoice = Console.ReadLine();

                if (userChoice.Equals("add task", StringComparison.OrdinalIgnoreCase))
                {
                    // Add Task
                    Console.WriteLine("Write the task that you want to add: ");
                    string taskToAdd = Console.ReadLine();
                    AddTaskToDatabase(taskToAdd);
                }
                else if (userChoice.Equals("view task", StringComparison.OrdinalIgnoreCase))
                {
                    // View Tasks
                    ViewTasksFromDatabase();
                }
                else if (userChoice.Equals("remove task", StringComparison.OrdinalIgnoreCase))
                {
                    // Remove Task
                    Console.WriteLine("Which task do you want to remove? You have the following tasks:");
                    ViewTasksFromDatabase();
                    Console.WriteLine("Enter the task name to remove: ");
                    string taskToRemove = Console.ReadLine();
                    RemoveTaskFromDatabase(taskToRemove);
                }
                else
                {
                    Console.WriteLine("Invalid command. Please try again.");
                }
            }
        }

        private static void AddTaskToDatabase(string taskName)
        {
            using (MySqlConnection connection = new MySqlConnection(connString))
            {
                try
                {
                    connection.Open();

                    string insertQuery = "INSERT INTO Tasks (TaskName) VALUES (@TaskName)";
                    using (MySqlCommand cmd = new MySqlCommand(insertQuery, connection))
                    {
                        cmd.Parameters.AddWithValue("@TaskName", taskName);
                        cmd.ExecuteNonQuery();
                        Console.WriteLine("Task added successfully!");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                }
            }
        }

        private static void ViewTasksFromDatabase()
        {
            using (MySqlConnection connection = new MySqlConnection(connString))
            {
                try
                {
                    connection.Open();

                    string selectQuery = "SELECT * FROM Tasks";
                    using (MySqlCommand cmd = new MySqlCommand(selectQuery, connection))
                    {
                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (!reader.HasRows)
                            {
                                Console.WriteLine("No tasks available.");
                            }
                            else
                            {
                                while (reader.Read())
                                {
                                    Console.WriteLine($"TaskID: {reader["TaskID"]}, Task: {reader["TaskName"]}, Completed: {reader["IsCompleted"]}");
                                }
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                }
            }
        }

        private static void RemoveTaskFromDatabase(string taskName)
        {
            using (MySqlConnection connection = new MySqlConnection(connString))
            {
                try
                {
                    connection.Open();

                    string deleteQuery = "DELETE FROM Tasks WHERE TaskName = @TaskName";
                    using (MySqlCommand cmd = new MySqlCommand(deleteQuery, connection))
                    {
                        cmd.Parameters.AddWithValue("@TaskName", taskName);
                        int rowsAffected = cmd.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            Console.WriteLine($"Task '{taskName}' removed successfully!");
                        }
                        else
                        {
                            Console.WriteLine($"Task '{taskName}' not found.");
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                }
            }
        }
    }
}
