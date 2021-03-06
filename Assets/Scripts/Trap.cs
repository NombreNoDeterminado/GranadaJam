using UnityEngine;

public interface ITrap
{
    // Returns the damage of the trap
    int Damage();

    // Trap duration
    float Duration();

    int Size();

    /// True if is horizontal, false if vertical
    bool Orientation();

    Sprite Sprite();

    string Name();
}