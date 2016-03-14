namespace Poker.Users
{
    public class UsersProperties : UserControls
    {
        public enum CUser
        {
            Player,
            Bot1,
            Bot2,
            Bot3,
            Bot4,
            Bot5
        }

        public int RightCard { get; set; }
        public string Name { get; set; }
        public int? Chips { get; set; }
        public int Type { get; set; }
        public bool Turn { get; set; }
        public bool FoldTurn { get; set; }
        public int PreviousCall { get; set; }
        public int LeftCard { get; set; }
        public double Power { get; set; }
        public int EnumCasted { get; set; }
    }
}
