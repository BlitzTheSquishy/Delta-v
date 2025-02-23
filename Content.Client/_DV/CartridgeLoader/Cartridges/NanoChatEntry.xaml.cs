using Content.Shared._DV.CartridgeLoader.Cartridges;
using Content.Shared._DV.NanoChat;
using Content.Shared.Access.Components;
using Robust.Client.AutoGenerated;
using Robust.Client.UserInterface.Controls;
using Robust.Client.UserInterface.XAML;

namespace Content.Client._DV.CartridgeLoader.Cartridges;

[GenerateTypedNameReferences]
public sealed partial class NanoChatEntry : BoxContainer
{
    public event Action<uint>? OnPressed;
    private uint _number;
    private Action<EventArgs>? _pressHandler;

    public NanoChatEntry()
    {
        RobustXamlLoader.Load(this);
    }

    public void SetRecipient(NanoChatRecipient recipient, uint number, bool isSelected)
    {
        // Remove old handler if it exists
        if (_pressHandler != null)
            ChatButton.OnPressed -= _pressHandler;

        _number = number;

        // Create and store new handler
        _pressHandler = _ => OnPressed?.Invoke(_number);
        ChatButton.OnPressed += _pressHandler;

        NameLabel.Text = SharedNanoChatSystem.Truncate(recipient.Name, IdCardConsoleComponent.MaxFullNameLength);
        JobLabel.Text = SharedNanoChatSystem.Truncate(recipient.JobTitle ?? "", IdCardConsoleComponent.MaxJobTitleLength);
        JobLabel.Visible = !string.IsNullOrEmpty(recipient.JobTitle);
        UnreadIndicator.Visible = recipient.HasUnread;

        ChatButton.ModulateSelfOverride = isSelected ? NanoChatMessageBubble.OwnMessageColor : null;
    }
}
