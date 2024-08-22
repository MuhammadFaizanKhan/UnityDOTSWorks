using System.Collections.Generic;
using Unity.Collections;
using Unity.Jobs;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Jobs;

/// <summary>
/// Using Job only (No ECS) Rotate all the objects
/// </summary>
public class RotateObjectAllWithJobOnly : MonoBehaviour
{
    public float speed = 3;
    public List<Transform> rotateObjectTransformList = new List<Transform>();

    private TransformAccessArray transforms;
    private NativeArray<float3> rotations;

    void Reset()
    {
        // Find all objects with MeshRenderer components
        MeshRenderer[] rotateObjectList = FindObjectsOfType<MeshRenderer>();

        // Clear the existing list to avoid duplications
        rotateObjectTransformList.Clear();

        // Iterate over each MeshRenderer and add its Transform to the list
        foreach (MeshRenderer meshRenderer in rotateObjectList)
        {
            rotateObjectTransformList.Add(meshRenderer.transform);
        }
    }

    private void Start()
    {
        transforms = new TransformAccessArray(rotateObjectTransformList.ToArray());
        rotations = new NativeArray<float3>(rotateObjectTransformList.Count, Allocator.Persistent);
        for (int i = 0; i < rotations.Length; i++)
        {
            rotations[i] = float3.zero;
        }
    }

    void Update()
    {
        var job = new RotateJob
        {
            deltaTime = Time.deltaTime,
            rotationList = rotations,
            rotationSpeed = speed,
        };

        JobHandle jobHandle = job.Schedule(transforms);//TODO: Check Other Methods to schedule jobs
        jobHandle.Complete();
    }

    void OnDestroy()
    {
        // Dispose of the NativeArray and TransformAccessArray
        if (rotations.IsCreated) rotations.Dispose();
        if (transforms.isCreated) transforms.Dispose();
    }

    struct RotateJob : IJobParallelForTransform
    {
        public float deltaTime;
        public float rotationSpeed;
        [ReadOnly] public NativeArray<float3> rotationList;

        public void Execute(int index, TransformAccess transformItem)
        {
            //Debug.Log(index);
            //float3 rotation = rotationList[index] * deltaTime * rotationSpeed;
            //transformItem.rotation *= math.mul(transformItem.rotation, Quaternion.Euler(rotation));
            float rotationAmount = rotationSpeed * deltaTime;
            transformItem.rotation *= Quaternion.Euler(0, rotationAmount, 0);
        }
    }
}
