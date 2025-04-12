using System;

public interface IGameText
{
    public void SetText(string text);
    public void SubscribeToTextUpdate(Action onTextUpdated);
    public void UnSubscribeFromTextUpdate(Action onTextUpdated);
}
