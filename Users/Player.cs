using System.Drawing;
using System.Windows.Forms;

namespace Poker.Users
{
    public class Player : UsersProperties
    {
        public Player(int? chips, Point cardsLocation)
        {
            LeftCard = 1;
            RightCard = 0;
            Name = "Player";
            Chips = chips;
            Type = -1;
            Power = 0;
            Turn = true;
            FoldTurn = false;
            CardsAnchor = AnchorStyles.Bottom;
            PreviousCall = 0;
            EnumCasted = (int)CUser.Player;
            CardsLocation = cardsLocation;
            UsernameLabelLocation = new Point(CardsLocation.X, CardsLocation.Y + Settings.Height);
            PanelLocation = new Point(CardsLocation.X - IndentationPanelXy, CardsLocation.Y - IndentationPanelXy);
        }
        public Player(int? chips, bool turn, bool foldTurn, AnchorStyles style, Point cardsLocation)
        {
            LeftCard = 1;
            RightCard = 0;
            Name = "Player";
            Chips = chips;
            Type = -1;
            Power = 0;
            Turn = turn;
            FoldTurn = foldTurn;
            CardsAnchor = style;
            PreviousCall = 0;
            EnumCasted = (int)CUser.Player;
            CardsLocation = cardsLocation;
            UsernameLabelLocation = new Point(CardsLocation.X, CardsLocation.Y + Settings.Height);
            PanelLocation = new Point(CardsLocation.X - IndentationPanelXy, CardsLocation.Y - IndentationPanelXy);
        }
    }
}