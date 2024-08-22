using Unity.Entities;

/// <summary>
/// This is the baker which will bake the Data component (CompRotateSpeed) to the Entity.
/// This class works automatically.
/// </summary>
public class BakerRotateSpeed : Baker<AuthRotateSpeed>
{
    public override void Bake(AuthRotateSpeed authoring)
    {
        Entity entity = GetEntity(TransformUsageFlags.Dynamic);
        AddComponent(entity, new CompRotateSpeed
        {
            speed = authoring.speed,
        });
    }
}
