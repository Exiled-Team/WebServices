namespace ExiledWebServices.Components.Interfaces;

/// <summary>
/// Defines an object identified by a name.
/// </summary>
public interface INamedObject
{
    /// <summary>
    /// Gets the name of the object.
    /// </summary>
    string Name { get; }
}