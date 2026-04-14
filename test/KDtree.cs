namespace test;
using System.Collections.Generic;
using System.Linq;

public class KDNode
{
    public int[] Point;
    public KDNode Left;
    public KDNode Right;

    public KDNode(int[] point)
    {
        Point = point;
    }
}

public class KDTree
{
    public KDNode Root;
    private int k = 2; 

    public KDNode Insert(KDNode node, int[] point, int depth)
    {
        if (node == null)
            return new KDNode(point);

        int axis = depth % k;

        if (point[axis] < node.Point[axis])
        {
            node.Left = Insert(node.Left, point, depth + 1);
        }
        else
        {
            node.Right = Insert(node.Right, point, depth + 1);
        }

        return node;
    }

    public KDNode BuildBalancedTree(List<int[]> points, int depth)
    {
        if (points == null || points.Count == 0)
            return null;

        int axis = depth % k;

        points.Sort((a, b) => a[axis].CompareTo(b[axis]));

        int medianIndex = points.Count / 2;

        KDNode node = new KDNode(points[medianIndex]);

        node.Left = BuildBalancedTree(points.GetRange(0, medianIndex), depth + 1);
        node.Right = BuildBalancedTree(points.GetRange(medianIndex + 1, points.Count - (medianIndex + 1)), depth + 1);

        return node;
    }

    public bool Search(KDNode node, int[] point, int depth)
    {
        if (node == null)
            return false;

        if (node.Point.SequenceEqual(point))
            return true;

        int axis = depth % k;

        if (point[axis] < node.Point[axis])
        {
            return Search(node.Left, point, depth + 1);
        }
        else
        {
            return Search(node.Right, point, depth + 1);
        }
    }
}