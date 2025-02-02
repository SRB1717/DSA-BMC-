using System;
using MySql.Data.MySqlClient;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics.Eventing.Reader;
using System.Management;
using System.Diagnostics;
using MySqlX.XDevAPI.Common;
using System.Net.NetworkInformation;

namespace TodoApp
{
    internal class Program
    {
        private static string connString = "Server=localhost;Database=todo;User=root;Password=suman;";
        //private static object cmd;

        private static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("We are creating a todo app");
                Console.WriteLine("Add task");
                Console.WriteLine("View task");
                Console.WriteLine("Remove task");
                Console.WriteLine("Modify Completion");

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
                    Console.WriteLine("Enter the taskId That you want to remove : ");
                    int taskToRemove = Convert.ToInt32(Console.ReadLine());
                    RemoveTaskFromDatabas(taskToRemove);
                }
                else if(userChoice.Equals("MODIFY completion",StringComparison.OrdinalIgnoreCase))

                {
                    ViewTasksFromDatabase();
                    Console.WriteLine("write the taskId whose status you want to view ");
                    int modifyId = Convert.ToInt32(Console.ReadLine());
                    if(modifyStatus(modifyId))
                    {
                        
                        Console.WriteLine($"the {modifyId} is changed ");
                        
                    }
                    else
                    {
                        Console.WriteLine($"sorry {modifyId} cannot be changed ");
                    }

                    




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
            using (MySqlConnection conn = new MySqlConnection(connString))
            {
                conn.Open();
                string selectQuery = "select *  from TaskS";
                using (MySqlCommand cmd = new MySqlCommand(selectQuery, conn))

                {
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (!reader.HasRows)
                        {
                            Console.WriteLine("no task available ");
                        }
                        else
                        {
                            while (reader.Read())
                            {
                                Console.WriteLine($"taskId:{reader["taskId"]}, taskName:{reader["taskName"]},Completed: {reader["IsCompleted"]}");
                            }


                        }
                    }
                }
            }
        }


        public static  bool  modifyStatus(int modifyID)
        {
            using (MySqlConnection mySqlConnection = new MySqlConnection(connString))
            {
                mySqlConnection.Open();
                string modifyQuery = "select  IsCompleted from Tasks where taskID=@modifyID";
                using (MySqlCommand cmd = new MySqlCommand(modifyQuery, mySqlConnection))
                {
                    cmd.Parameters.AddWithValue("@modifyID", modifyID);
                    object readStatus = cmd.ExecuteScalar();

                    bool readBStatus;
                    if (readStatus is bool)
                    {
                        readBStatus = (bool)readStatus;
                    }
                    else
                    {
                        Console.WriteLine("Unexpected type for readStatus. Expected boolean ");
                        return false;
                    }



                    Console.WriteLine("do you want to change the current status write in yes or no ");
                    string doModify = Console.ReadLine();
                    if (doModify.Equals("yes", StringComparison.OrdinalIgnoreCase))
                    {
                        if (readBStatus == true)
                        {
                            readBStatus = false;
                            Console.WriteLine("about to calling pushto db");
                            pushChange(readBStatus, modifyID);
                            return true;

                        }
                        else
                        {
                            readBStatus = true;
                            Console.WriteLine("about to calling push db");
                            pushChange(readBStatus, modifyID);
                            return true;
                        }
                    }
                    
                    else return false;
                
                  





                }
                       
                }
               
            }




        public static void  pushChange(bool changedStatus, int modifID)
        {
            Console.WriteLine("insid the push change ");
            using (MySqlConnection conn = new MySqlConnection(connString))
            {
                conn.Open();

                using (MySqlCommand cmd = new MySqlCommand())
                {
                    string pushChange = "update Tasks SET IsCompleted = @readBStatus WHERE TaskID=@modifyID";
                    using (MySqlCommand cmdc = new MySqlCommand(pushChange, conn))
                    {
                        cmdc.Parameters.AddWithValue("@readBStatus", changedStatus);
                        cmdc.Parameters.AddWithValue("@modifyID", modifID);
                        int rowsAffected = cmdc.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            Console.WriteLine($"the value isCompleted o taskid :{modifID} is changed to {changedStatus}");
                            return;
                           

                        }
                        else
                        {
                            Console.WriteLine("inside to push change about to hit break ");
                            return;
                        }


                    }
                }


            }
        }
        private static void RemoveTaskFromDatabas(int taskToRemove)
        {
            using (MySqlConnection connection = new MySqlConnection(connString))
            {
                connection.Open();
                string deleteQuery = "DELETE FROM Tasks WHERE TaskId=@TaskToRemove";

                using (MySqlCommand cmd = new MySqlCommand(deleteQuery, connection))
                {
                    cmd.Parameters.AddWithValue("@TaskToRemove", taskToRemove);
                    int rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        Console.WriteLine($"Task{taskToRemove} removed successfully");
                    }
                    else
                    {
                        Console.WriteLine("NO DATA TO DELETE");

                    }

                }


            }
        }
    }
}
