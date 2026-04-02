using test;

var avl = new AVLTree();
var root = new Node(50);

avl.Insert(root, 40);
avl.Insert(root, 60);
avl.Insert(root, 39);
avl.Insert(root, 53);
avl.Insert(root, 55);
avl.Insert(root, 79);
avl.Insert(root, 45);
avl.Insert(root, 57);
avl.Insert(root, 90);

AVLPrinter.Print(root);