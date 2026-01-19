using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathNode : MonoBehaviour
{
    [SerializeField] private PathNode left = null;
    [SerializeField] private PathNode right = null;
    [SerializeField] private PathNode up = null;
    [SerializeField] private PathNode down = null;

    public PathNode LeftNode { get { return left == null ? left : null; } }
    public PathNode RightNode { get { return right == null ? right : null; } }
    public PathNode UpNode { get { return up == null ? up : null; } }
    public PathNode DownNode { get { return down == null ? down : null; } }

    // Start is called before the first frame update
    void Start()
    {
        if (PathfindingSystem.Instance != null)
        {
            PathfindingSystem.Instance.AddNodeToPath(this);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public List<PathNode> GetAdjacentNodes()
    {
        List<PathNode> nodes = new List<PathNode>();
        if (left != null)
        {
            nodes.Add(left);
        }
        if (right != null)
        {
            nodes.Add(right);
        }
        if (up != null)
        {
            nodes.Add(up);
        }
        if (down != null)
        {
            nodes.Add(down);
        }
        return nodes;
    }
}
