using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using People.Models;
using SQLite;

namespace People
{
    public class PersonRepository
    {
        private SQLiteAsyncConnection conn;

        public string StatusMessage { get; set; }

        public PersonRepository(string dbPath)
        {
            // TODO: Initialize a new SQLiteConnection
            // TODO: Create the Person table
            conn = new SQLiteAsyncConnection(dbPath);

            // Note that we are using this blocking call to keep the exercise as simple
            // as possible. In general you should not mix asynchronous and synchronous 
            // code as there are scenarios where it can cause an application to deadlock.
            conn.CreateTableAsync<Person>().Wait();
        }

        public async Task AddNewPersonAsync(string name)
        {
            int result = 0;
            try
            {
                //basic validation to ensure a name was entered
                if (string.IsNullOrEmpty(name))
                    throw new Exception("Valid name required");

                // TODO: insert a new person into the Person table
                result = await conn.InsertAsync(new Person { Name = name, /* Id is Auto Increment */});

                StatusMessage = string.Format("{0} record(s) added [Name: {1})", result, name);
            }
            catch (Exception ex)
            {
                StatusMessage = string.Format("Failed to add {0}. Error: {1}", name, ex.Message);
            }
        }

        public async Task<List<Person>> GetAllPeopleAsync()
        {
            // TODO: return a list of people saved to the Person table in the database

            try
            {
                return await conn.Table<Person>().ToListAsync();
            }
            catch (Exception ex)
            {
                StatusMessage = $"Failed to retrieve data: {ex.Message}";
            }

            return new List<Person>();
        }
    }
}