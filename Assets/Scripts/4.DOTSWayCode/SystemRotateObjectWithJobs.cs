using Unity.Burst;
using Unity.Entities;
using Unity.Jobs;
using Unity.Transforms;
using UnityEngine.Profiling;

public partial struct SystemRotateObjectWithJobs : ISystem
{
    [BurstCompile]
    public void OnUpdate(ref SystemState state)//OnUpdate is called every frame
    {
        Profiler.BeginSample("Job System Only");
        JobForRotation rotationJob = new JobForRotation
        {
            deltaTime = SystemAPI.Time.DeltaTime
        };
       // UnityEngine.Debug.Log("onupdate in rotation object system with job");
        //rotationJob.Schedule();

        rotationJob.ScheduleParallel();
        //handle.Complete();//complete it in same frame
        Profiler.EndSample();
    }

}

[BurstCompile]//The [BurstCompile] attribute is used, which is good for performance. Ensure that the Burst compiler is enabled and properly configured in your project.
public partial struct JobForRotation : IJobEntity
{
    public float deltaTime;
    void Execute(ref LocalTransform localTransform, in CompRotateSpeed rotateSpeed)
    {
        localTransform = localTransform.RotateY(rotateSpeed.speed * deltaTime);
    }
}
