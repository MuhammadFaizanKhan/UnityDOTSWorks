using System.Diagnostics;
using Unity.Burst;
using Unity.Entities;
using Unity.Transforms;

public partial struct SystemRotateObject : ISystem 
    //ISyestem for unmanage type, while SystemBase is for managed type e.g, gameobject, transform.
    //Remember ISystem or SysteBase is not by default multithread. Need to make a job to make it multitread.

{
    [BurstCompile]
    public void OnUpdate(ref SystemState state)
    {

        //foreach(RefRO<CompRotateSpeed> rotateSpeed //get all entties who have Rotate Speed Component
        //in SystemAPI.Query<RefRO<CompRotateSpeed>>()) //RefRW for read and write the data, RefRO only for read. By Default it Read only but you should explictly mentioned. YOu have to mention explcity that you want to read only data or you want write as well.
        //{

        //}
        //UnityEngine.Debug.Log("onupdate in rotation object sysem");
        //get all entites who have Rotate Speed Component and LocalTransfrom
        foreach ((RefRO<CompRotateSpeed> rotateSpeed, RefRW<LocalTransform> localTransform)
            in SystemAPI.Query<RefRO<CompRotateSpeed>, RefRW<LocalTransform>>()) //RefRW for read and write the data, RefRO only for read. By Default it Read only but you should explictly mentioned.
        {
            localTransform.ValueRW = 
                localTransform.ValueRO.RotateY(rotateSpeed.ValueRO.speed * SystemAPI.Time.DeltaTime);
        }

        //simple representation, of below loop
        //get all entites who have Rotate Speed Component and LocalTransfrom, 
        //foreach ((var rotateSpeed, var transform)
        //    in SystemAPI.Query<RefRO<CompRotateSpeed>, RefRW<LocalTransform>>()) //RefRW for read and write the data, RefRO only for read. By Default it Read only but you should explictly mentioned.
        //{

        //}
    }
}

