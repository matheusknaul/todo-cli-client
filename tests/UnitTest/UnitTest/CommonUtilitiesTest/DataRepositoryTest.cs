using Domain.Entities;
using Domain.Interfaces;
using System.Text.Json;

namespace UnitTest.CommonUtilitiesTest
{
    public class SessionRepositoryTest : ITodoRepository
    {
        public void CreateSessionJson(Session session)
        {
            string jsonString = JsonSerializer.Serialize(session, new JsonSerializerOptions { WriteIndented = true });

            File.WriteAllText("sessionTest.json", jsonString);
        }

        public void DeleteSessionJson() 
        {
            
        }

        public async Task<Session> LoadAsync()
        {
            string jsonString = File.ReadAllText("sessionTest.json");
            Session session = JsonSerializer.Deserialize<Session>(jsonString);

            return session;
        }

        public async Task SaveAsync(Session session)
        {
            CreateSessionJson(session);
        }
    }
}
