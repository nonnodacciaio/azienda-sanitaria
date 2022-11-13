namespace Esercizio.Configuration;

public class AppSettings
{
    public bool NullAddressIfNameNotFound { get; set } = false;
    public string? DefaultAddress { get; set; }
    public string JsonPersonPath { get; set; }
    public string MySqlDbName { get; set; }
    public string MySqlHost { get; set; }
    public string MySqlUsername { get; set; }
    public string MySqlPassword { get; set; }

    public string DbConnectionString => "Server=" + this.MySqlHost + ";Database=" + this.MySqlDbName + ";Uid=" + this.MySqlUsername + ";Pwd=" + this.MySqlPassword + ";";
}