namespace WebApp.Components.Interfaces;

/// <summary>
/// Defines an object capable of redirecting to a href.
/// </summary>
public interface IRefObject
{
    /// <summary>
    /// Gets the object's href.
    /// </summary>
    string Href { get; }
}