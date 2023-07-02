using Robust.Shared.Serialization;

namespace Content.Shared.Atmos.Visuals;

/// <summary>
/// Used for the visualizer
/// </summary>
[Serializable, NetSerializable]
public enum PortablePumpVisuals : byte
{
    IsFull,
    IsRunning,
    IsDraining,
}
