using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using CyberSecurityPart2.Models;

namespace CyberSecurityPart2.DATA
{
    internal class TaskRepository
    {
        // Gets every task from the database and returns them as a list
        public List<TaskItems> GetAllTasks()
        {
            List<TaskItems> tasks = new List<TaskItems>();

            using (SqlConnection conn = new SqlConnection(DbConfig.ConnectionString))
            {
                conn.Open();
                string sql = "SELECT id, title, description, reminder_date, is_completed FROM tasks ORDER BY id";
                SqlCommand cmd = new SqlCommand(sql, conn);
                SqlDataReader reader = cmd.ExecuteReader();

                // Read one row at a time and turn it into a TaskItems object
                while (reader.Read())
                {
                    TaskItems task = new TaskItems();
                    task.Id = reader.GetInt32(0);
                    task.Title = reader.GetString(1);
                    task.Description = reader.GetString(2);

                    // The reminder column can be empty (NULL)
                    if (reader.IsDBNull(3))
                    {
                        task.ReminderDate = null;
                    }
                    else
                    {
                        task.ReminderDate = reader.GetDateTime(3);
                    }

                    task.IsCompleted = reader.GetBoolean(4);
                    tasks.Add(task);
                }
                reader.Close();
            }
            return tasks;
        }

        // Adds a new task and gives back the id the database gave it
        public int AddTask(string title, string description, DateTime? reminder)
        {
            using (SqlConnection conn = new SqlConnection(DbConfig.ConnectionString))
            {
                conn.Open();
                string sql = "INSERT INTO tasks (title, description, reminder_date) " +
                             "OUTPUT INSERTED.id VALUES (@title, @description, @reminder)";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@title", title);
                cmd.Parameters.AddWithValue("@description", description);

                // If there is no reminder, save NULL in the database
                if (reminder == null)
                {
                    cmd.Parameters.AddWithValue("@reminder", DBNull.Value);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@reminder", reminder.Value);
                }

                return (int)cmd.ExecuteScalar();
            }
        }

        // Sets the reminder date of a task
        public void SetReminder(int id, DateTime reminder)
        {
            using (SqlConnection conn = new SqlConnection(DbConfig.ConnectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("UPDATE tasks SET reminder_date = @reminder WHERE id = @id", conn);
                cmd.Parameters.AddWithValue("@reminder", reminder);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();
            }
        }

        // Marks a task as completed
        public void MarkComplete(int id)
        {
            using (SqlConnection conn = new SqlConnection(DbConfig.ConnectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("UPDATE tasks SET is_completed = 1 WHERE id = @id", conn);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();
            }
        }

        // Deletes a task from the database
        public void DeleteTask(int id)
        {
            using (SqlConnection conn = new SqlConnection(DbConfig.ConnectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("DELETE FROM tasks WHERE id = @id", conn);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();
            }
        }
    }
}
