using Content.Client.UserInterface.Controls;
using Robust.Client.AutoGenerated;
using Robust.Client.UserInterface.Controls;
using Robust.Client.UserInterface.XAML;
using Robust.Shared.Utility;

namespace Content.Client._NF.UserInterface.Systems.Ghost.Controls
{
    [GenerateTypedNameReferences]
    public sealed partial class GhostRespawnRulesWindow : FancyWindow
    {
        public PanelContainer RulesContainer => TextContainer;
        public RichTextLabel RulesLabel = new() { Margin = new Thickness(5, 5, 5, 5) };
        public Button RespawnButton => ConfirmRespawnButton;

        public GhostRespawnRulesWindow()
        {
            RobustXamlLoader.Load(this);

            var message = new FormattedMessage();
            message.AddMarkup(Loc.GetString("ghost-respawn-rules-window-rules"));
            RulesLabel.SetMessage(message);
            RulesContainer.AddChild(RulesLabel);
            RulesLabel.SetPositionFirst();

            RespawnButton.OnPressed += _ => Close();
        }
    }
}
