using System.Collections.Generic;
using UnityEngine;

public class RotateObjectAll : MonoBehaviour
{
    public float speed = 3;
    public List<Transform> rotateObjectTransformList = new List<Transform>();

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

    void Update()
    {
        for (int i = 0; i < rotateObjectTransformList.Count; i++)
        {
            rotateObjectTransformList[i].Rotate(Vector3.up * speed * Time.deltaTime);
        }
    }
}
