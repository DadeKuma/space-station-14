using Robust.Client.GameObjects;
using Content.Shared.Atmos.Visuals;
using Content.Client.Power;

namespace Content.Client.Atmos.Visualizers
{
    /// <summary>
    /// Controls client-side visuals for portable pumps.
    /// </summary>
    public sealed class PortablePumpVisualsSystem : VisualizerSystem<PortablePumpVisualsComponent>
    {
        protected override void OnAppearanceChange(EntityUid uid, PortablePumpVisualsComponent component, ref AppearanceChangeEvent args)
        {
            if (args.Sprite == null)
                return;

            if (AppearanceSystem.TryGetData<bool>(uid, PortablePumpVisuals.IsFull, out var isFull, args.Component)
                && AppearanceSystem.TryGetData<bool>(uid, PortablePumpVisuals.IsRunning, out var isRunning, args.Component))
            {
                var runningState = isRunning ? component.RunningState : component.IdleState;
                args.Sprite.LayerSetState(PortablePumpVisualLayers.IsRunning, runningState);

                var fullState = isFull ? component.FullState : component.ReadyState;
                args.Sprite.LayerSetState(PowerDeviceVisualLayers.Powered, fullState);
            }

            if (AppearanceSystem.TryGetData<bool>(uid, PortablePumpVisuals.IsDraining, out var isDraining, args.Component))
            {
                args.Sprite.LayerSetVisible(PortablePumpVisualLayers.IsDraining, isDraining);
            }
        }
    }
}
public enum PortablePumpVisualLayers : byte
{
    IsRunning,

    IsDraining
}
