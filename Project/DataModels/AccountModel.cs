using System.Text.Json.Serialization;


public class AccountModel
{
    [JsonPropertyName("id")]
    public int Id { get; set; }

    [JsonPropertyName("emailAddress")]
    public string EmailAddress { get; set; }

    [JsonPropertyName("password")]
    public string Password { get; set; }

    [JsonPropertyName("date_of_birth")]
    public DateTime Date_Of_Birth { get; set; }

    [JsonPropertyName("fullName")]
    public string FullName { get; set; }

    [JsonPropertyName("V.I.P.")]
    public bool Vip { get; set; }

    public AccountModel(int id, string emailAddress, string password, DateTime date_of_birth, string fullName, bool vip)
    {
        Id = id;
        EmailAddress = emailAddress;
        Password = password;
        Date_Of_Birth = date_of_birth;
        FullName = fullName;
        Vip = vip;
    }
    public override string ToString()
    {
        return $"ID: {Id}, email: {EmailAddress}, password: {Password}, Date of birth: {Date_Of_Birth}, Fullname: {FullName}, V.I.P: {Vip}";
    }

    public static int GetNextId()
    {
        return AccountsAccess.LoadAll().Select(a => a.Id).Max() + 1;
    }

}




