using System.Drawing;
using System.Windows.Forms;

namespace Poker.Users
{
    public class UserControls
    {
        public Point CardsLocation { get; set; }
        public AnchorStyles CardsAnchor { get; set; }

        public Panel Panel { get; } = new Panel();
        public Point PanelLocation { get; set; }
        public Size PanelSize { get; } = new Size((Settings.Width + 10) * 2, Settings.Height + 20);
        public int IndentationPanelXy { get; } = 10;

        public Label UsernameLabel { get; set; } = new Label();
        public Point UsernameLabelLocation { get; set; }
        public Size UsernameLabelSize { get; } = new Size(Settings.Width * 2, 20);

        public TextBox ChipsTextBox { get; set; } = new TextBox();
        public Label StatusLabel { get; set; } = new Label();

    }
}
