// Use unique namespaces for your apps if you going to share with others to avoid
// conflicting names
namespace HassModel;

/// <summary>
///     Showcase using the new HassModel API and turn on light on movement
/// </summary>
//[NetDaemonApp]
public class LightOnMovement
{
    public LightOnMovement(IHaContext ha)
    {
        ha.Entity("binary_sensor.0x001788010bcfb16f_occupancy")
            .StateChanges().Where(e => e.New?.State == "on")
            .Subscribe(_ => ha.Entity("light.kitchen_light_2").CallService("turn_on"));
    }
}
