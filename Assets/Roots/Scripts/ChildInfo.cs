namespace Roots
{
    public class ChildInfo
    {
        public UndergroundRootView Connection;
        public LetterBehaviour Children;
        public bool CanGrow => Connection.IsUpgradable;
    }
}