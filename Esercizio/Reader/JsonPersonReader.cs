using Esercizio.Configuration;

namespace Esercizio.Reader
{
    internal class JsonPersonReader : IPersonReader
    {
        List<PersonRead> personsRead;

        public JsonPersonReader()
        {
            string json = File.ReadAllText(Config.Settings.JsonPersonPath);
            personsRead = JsonSerializer.Deserialize<List<PersonRead>>(json);
        }

        public List<PersonRead> Read()
        {
            return personsRead;
        }

        public PersonRead Add(string name, int age)
        {
            // TODO: scrivere anche le persone su JSON, ma non è necessario perché vengono lette dal DB
            return new PersonRead() { Name = name, Age = age };
        }
    }
