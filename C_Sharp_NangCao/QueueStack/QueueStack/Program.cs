namespace QueueStack
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Queue<string> cachoso = new Queue<string>();// vào trước ra trước FIFO
            cachoso.Enqueue("hs A"); // Hồ sơ xếp thứ nhất trong hàng đợi
            cachoso.Enqueue("hs B"); // Hồ sơ xếp thứ hai
            cachoso.Enqueue("hs C");

            cachoso.ToList().ForEach(hs => Console.Write(hs + "  " ));
            var hoso =cachoso.Dequeue();// Lấy phaafnt ử đầu ra khỏi hàng đợi
            Console.WriteLine(hoso);

            Stack<string> hanghoa = new Stack<string>();  //Vào sau ra trước LIFO
            hanghoa.Push("hang 1");
            hanghoa.Push("hang 2");

            var lay= hanghoa.Pop();// Bỏ cái 2

            //LinkedList 
            LinkedList<string> list = new LinkedList<string>();
            var node1= list.AddFirst("node 1");
            list.AddLast("node end");
           

            LinkedListNode<string> newnode = list.AddAfter(node1, "node 2");
            var nodex = newnode;
            nodex = nodex.Next;
            Console.WriteLine("node 1 la :" + newnode.Value);

            list.ToList().ForEach(l=>Console.WriteLine(l));


            //hashset các phần tử k dc trùng nhau
            //có phép giao , phép hợp
        }
    }
}