using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathfindingSystem : MonoBehaviour
{
    public static PathfindingSystem Instance { get; private set; }
    private List<PathNode> pathNodes;

    private void Awake()
    {
        Instance = this;
        pathNodes = new List<PathNode>();
    }
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddNodeToPath(PathNode node)
    {
        if (pathNodes == null)
        {
            pathNodes = new List<PathNode>();
        }

        pathNodes.Add(node);
    }

    public List<Vector3> GetShortestPathAsVectors(Vector3 source, Vector3 target)
    {
        List<PathNode> nodePath = GetShortestPathAsNodes(source, target);
        List<Vector3> vectorPath = new List<Vector3>();

        foreach (PathNode node in nodePath)
        {
            vectorPath.Add(node.transform.position);
        }

        return vectorPath;
    }

    public List<PathNode> GetShortestPathAsNodes(Vector3 source, Vector3 target)
    {
        PathNode sourceNode = GetClosestNodeToPosition(source);
        PathNode targetNode = GetClosestNodeToPosition(target);
        DijkstrasAlgorithm dA = new DijkstrasAlgorithm();
        return dA.GetShortestPath(sourceNode, targetNode);
    }

    public PathNode GetClosestNodeToPosition(Vector3 position)
    {
        float minDistance = float.MaxValue;
        PathNode minNode = null;
        foreach (PathNode node in pathNodes)
        {
            float dist = Vector3.Distance(position, node.transform.position);
            if (dist < minDistance)
            {
                minDistance = dist;
                minNode = node;
            }
        }
        return minNode;
    }
}


public class DijkstrasAlgorithm
{
    private List<PathNode> currShortestPath;
    
    public List<PathNode> GetShortestPath(PathNode sourceNode, PathNode targetNode)
    {
        List<PathNode> temp = GetPath(null, sourceNode, targetNode);
        if (currShortestPath != null)
        {
            return currShortestPath;
        }
        else
        {
            return temp;
        }
    }
    
    public List<PathNode> GetPath(List<PathNode> previousNodes, PathNode sourceNode, PathNode targetNode)
    {
        previousNodes ??= new List<PathNode>();
        if (!previousNodes.Contains(sourceNode))
        {
            previousNodes.Add(sourceNode);
        }
        else
        {
            return null;
        }
        if (sourceNode == targetNode)
        {
            if (currShortestPath == null || currShortestPath.Count == 0 || (currShortestPath.Count > previousNodes.Count))
            {
                currShortestPath = previousNodes;
            }
            return previousNodes;
        }
        List<PathNode> minPath = new List<PathNode>();
        List<PathNode> snAdjacentNodes = sourceNode.GetAdjacentNodes();
        int minCount = int.MaxValue;
        if (snAdjacentNodes.Count == 0 || snAdjacentNodes == null)
        {
            return null;
        }
        foreach (PathNode adjacentNode in snAdjacentNodes)
        {
            List<PathNode> path = GetPath(new List<PathNode>(previousNodes), adjacentNode, targetNode);
            if (path != null)
            {
                if (path.Count < minCount)
                {
                    minCount = path.Count;
                    minPath = path;
                }
            }
        }
        if (minCount != int.MaxValue)
        {
            return minPath;
        }
        else
        {
            return null;
        }
        
    }
}
