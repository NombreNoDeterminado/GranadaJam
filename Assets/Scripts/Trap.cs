using UnityEngine;

public interface ITrap
{
    // Returns the damage of the trap
    int Damage();

    // Trap duration
    float Duration();

    float ItemDuration();

    int Size();

    /// True if is horizontal, false if vertical
    bool Orientation();

    Sprite Sprite();

    string Name();

    Material Trapped();

    ParticleSystem Particles();

    GameObject Item();
}