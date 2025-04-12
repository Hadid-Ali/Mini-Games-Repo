public interface IHighlighterComponent
{
    public bool IsHighlighted { get; }
    public void Highlight();
    public void UnHighlight();
}
