namespace DataStructures
{
    public class DoublyNode<T>
    {
        public DoublyNode<T> Prev { get; set; }

        public T Value { get; set; }

        public DoublyNode<T> Next { get; set; }
    }
}
