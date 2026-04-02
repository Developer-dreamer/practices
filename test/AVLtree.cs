namespace test;

public class Node
{
    public int Value;
    public Node Left;
    public Node Right;
    public int Height;

    public Node(int value)
    {
        // 1. Присвоїти Value значення value.
        Value = value;
        // 2. Встановити Height = 1.
        Height = 1;
    }
}

public class AVLTree
{
    private int GetHeight(Node node)
    {
        // 1. Якщо node дорівнює null, повернути 0.
        if (node == null)
        {
            return 0;
        }
        // 2. Інакше повернути node.Height.
        return node.Height;
    }

    private int GetBalanceFactor(Node node)
    {
        // 1. Якщо node дорівнює null, повернути 0.
        if (node == null)
        {
            return 0;
        }
        // 2. Повернути різницю: GetHeight(node.Left) - GetHeight(node.Right).
        return GetHeight(node.Left) - GetHeight(node.Right);
    }

    private void UpdateHeight(Node node)
    {
        // 1. Знайти максимальне значення між GetHeight(node.Left) та GetHeight(node.Right).
        var maxHeight = Math.Max(GetHeight(node.Left), GetHeight(node.Right));
        
        // 2. Додати 1 до знайденого максимуму.
        maxHeight += 1;
        
        // 3. Зберегти результат у node.Height.
        node.Height = maxHeight;
    }

    private Node RotateRight(Node y)
    {
        // 1. Зберегти лівого нащадка Y у змінну x: x = y.Left.
        var x = y.Left;
        
        // 2. Зберегти правого нащадка X у змінну T2: T2 = x.Right.
        var T2 = x.Right;
        
        // 3. Виконати поворот: присвоїти x.Right = y.
        x.Right = y;
        
        // 4. Присвоїти y.Left = T2.
        y.Left = T2;
        
        // 5. Оновити висоту y викликом UpdateHeight(y).
        UpdateHeight(y);
        
        // 6. Оновити висоту x викликом UpdateHeight(x).
        UpdateHeight(x);
        
        // 7. Повернути x як новий корінь піддерева.
        return x;
    }

    private Node RotateLeft(Node x)
    {
        // 1. Зберегти правого нащадка x у змінну y: y = x.Right.
        var y = x.Right;
        
        // 2. Зберегти лівого нащадка y у змінну T2: T2 = y.Left.
        var T2 = y.Left;
        
        // 3. Виконати поворот: присвоїти y.Left = x.
        y.Left = x;
        
        // 4. Присвоїти x.Right = T2.
        x.Right = T2;
        
        // 5. Оновити висоту x викликом UpdateHeight(x).
        UpdateHeight(x);
        
        // 6. Оновити висоту y викликом UpdateHeight(y).
        UpdateHeight(y);
        
        // 7. Повернути y як новий корінь піддерева.
        return y;
    }

    private Node Balance(Node node)
    {
        // 1. Оновити висоту поточного вузла node викликом UpdateHeight(node).
        UpdateHeight(node);
        
        // 2. Отримати фактор балансу: balance = GetBalanceFactor(node).
        var balance = GetBalanceFactor(node);

        // 3. Обробка лівого перекосу (balance > 1):
        if (balance > 1)
        {
            //    a. Якщо GetBalanceFactor(node.Left) < 0 (випадок Left-Right):
            if (GetBalanceFactor(node.Left) < 0)
            {
                //       - Виконати node.Left = RotateLeft(node.Left).
                node.Left = RotateLeft(node.Left);
            }
            //    b. Повернути RotateRight(node).
            return RotateRight(node);
        }
        
        // 4. Обробка правого перекосу (balance < -1):
        if (balance < -1)
        {
            //    a. Якщо GetBalanceFactor(node.Right) > 0 (випадок Right-Left):
            if (GetBalanceFactor(node.Right) > 0)
            {
                //       - Виконати node.Right = RotateRight(node.Right).
                node.Right = RotateRight(node.Right);
            }
            
            //    b. Повернути RotateLeft(node).
            return RotateLeft(node);
        }

        

        // 5. Якщо баланс у межах [-1; 1], повернути node без змін.
        return node;
    }

    public Node Insert(Node node, int value)
    {
        // 1. Якщо node дорівнює null, повернути новий об'єкт Node(value).
        if (node == null)
        {
            return new Node(value);
        }
        
        // 2. Якщо value < node.Value, викликати Insert для node.Left і зберегти результат у node.Left.
        if (value < node.Value)
        {
            node.Left = Insert(node.Left, value);
        }
        
        // 3. Якщо value > node.Value, викликати Insert для node.Right і зберегти результат у node.Right.
        if (value > node.Value)
        {
            node.Right = Insert(node.Right, value);
        }

        // 4. Якщо value дорівнює node.Value, повернути node (дублікати не допускаються).
        if (value == node.Value)
        {
            return node;
        }

        // 5. Викликати і повернути результат Balance(node).
        return Balance(node);
    }
}