namespace ArvoreAVL
{
    public class Node
    {
        public int Data;
        public int Height;
        public Node Left, Right;

        public Node(int data)
        {
            Data = data;
            Height = 1;
            Left = null;
            Right = null;
        }
    }
}
