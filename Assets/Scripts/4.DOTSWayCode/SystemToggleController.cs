using Unity.Entities;
using UnityEngine;
using UnityEngine.UI;

public class SystemToggleController : MonoBehaviour
{
    private World world;
   
    void Start()
    {
        world = World.DefaultGameObjectInjectionWorld;
        UpdateSystemState(false);
    }

    public void ToggleSystem(Toggle isEnableJobSystemCode)
    {
        UpdateSystemState(isEnableJobSystemCode.isOn);
    }

    void UpdateSystemState(bool isEnableJobSystemCode)
    {
        var systemWithoutJob = world.GetOrCreateSystem<SystemRotateObject>();
        SystemHandle systemWithJob = world.GetOrCreateSystem<SystemRotateObjectWithJobs>();
        if (isEnableJobSystemCode)
        {
            ref SystemState state = ref world.Unmanaged.ResolveSystemStateRef(systemWithoutJob);
            state.Enabled = false;

            ref SystemState state2= ref world.Unmanaged.ResolveSystemStateRef(systemWithJob);
            state2.Enabled = true;
            //systemWithoutJob.
        }
        else
        {
           
                ref SystemState state = ref world.Unmanaged.ResolveSystemStateRef(systemWithoutJob);
                state.Enabled = true;

                ref SystemState state2 = ref world.Unmanaged.ResolveSystemStateRef(systemWithJob);
                state2.Enabled = false;
                //systemWithoutJob.
           
        }
    }
}
