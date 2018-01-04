public class UserData
{
    public string FirstName { get; set; }
    public double UserID { get; set; }

    public UserData()
    {
        FirstName = "Unknown";
        UserID = -1;
    }
}