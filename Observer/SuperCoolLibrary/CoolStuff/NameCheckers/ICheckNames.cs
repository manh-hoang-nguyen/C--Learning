namespace SuperCoolLibrary.CoolStuff.NameCheckers
{
    public interface ICheckNames
    {
        bool CheckName(string name);
        string FriendlyName { get; }
    }
}
