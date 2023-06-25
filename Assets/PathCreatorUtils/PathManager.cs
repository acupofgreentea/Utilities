using System.Collections.Generic;
using PathCreation;
using UnityEditor;
using UnityEngine;
using Extensions;

public class PathManager : MonoBehaviour
{
    [SerializeField] private PathCreator pathCreator;

    [SerializeField] private Transform pathPointsParent;

    [field: SerializeField] List<Transform> PathPoints = new List<Transform>();

    private void Awake()
    {
        pathCreator = GetComponent<PathCreator>();
    }
    
    [ContextMenu("GeneratePath")]
    public void GeneratePath()
    {
        if(!pathCreator)
            pathCreator = GetComponent<PathCreator>();

        if (PathPoints.Count <= 0)
        {
            Debug.LogError("Assign Path Points");

            return;
        }

        BezierPath bezierPath = new BezierPath(PathPoints, false, PathSpace.xyz);
        pathCreator.bezierPath = bezierPath;
        pathCreator.bezierPath.GlobalNormalsAngle = 90f;

#if UNITY_EDITOR
        EditorUtility.SetDirty(this.gameObject);
#endif
    }

    [ContextMenu("Fill List")]
    public void FillList()
    {
        if (pathPointsParent == null)
        {
            Debug.LogError("Assign Parent");

            return;
        }
        
        /*
        PathPoints.Clear();
        
        foreach (Transform child in pathPointsParent)
        {
            if(child == pathPointsParent) continue;
            
            PathPoints.Add(child);
        }*/
        
        PathPoints.FillListByParent(pathPointsParent);
    }
    
    

    public Vector3 GetPointAtTime(float timeProgress, EndOfPathInstruction endOfPathInstruction = EndOfPathInstruction.Stop) =>
        pathCreator.path.GetPointAtTime(timeProgress, endOfPathInstruction);

    public Vector3 GetDirection(float timeProgress, EndOfPathInstruction endOfPathInstruction = EndOfPathInstruction.Stop) =>
        pathCreator.path.GetDirection(timeProgress, endOfPathInstruction);

    public Quaternion GetRotationAtTime(float timeProgress, EndOfPathInstruction endOfPathInstruction = EndOfPathInstruction.Stop) =>
        pathCreator.path.GetRotation(timeProgress, endOfPathInstruction);

    public float GetClosestTimeOnPath(Vector3 point) => pathCreator.path.GetClosestTimeOnPath(point);
    public Vector3 GetClosestPointOnPath(Vector3 point) => pathCreator.path.GetClosestPointOnPath(point);
    public float GetClosestDistanceAlongPath(Vector3 point) => pathCreator.path.GetClosestDistanceAlongPath(point);
    public Vector3 GetPathRight(float timeProgress) => Vector3.Cross(GetDirection(timeProgress), Vector3.up);
    public float GetLength => pathCreator.path.length;
}
