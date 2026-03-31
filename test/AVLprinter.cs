namespace test;

public static class AVLPrinter
{
    public static void Print(Node root)
    {
        if (root == null)
        {
            Console.WriteLine("Дерево порожнє.");
            return;
        }
        
        PrintNode(root, "", true);
    }

    private static void PrintNode(Node node, string indent, bool isLast)
    {
        if (node != null)
        {
            Console.Write(indent);

            if (isLast)
            {
                Console.Write("└── ");
                indent += "    ";
            }
            else
            {
                Console.Write("├── ");
                indent += "│   ";
            }

            Console.WriteLine($"{node.Value} (H:{node.Height})");

            PrintNode(node.Left, indent, false);
            PrintNode(node.Right, indent, true);
        }
    }
}