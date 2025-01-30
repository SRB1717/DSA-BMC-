using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    internal class CircularQueue
    {
        private int[] queu;

        private int front;
        private int rear;
        private int size;
        private int capacity;


        public  CircularQueue(int capacity)

        {
            this.capacity = capacity;
            queu = new int[capacity];
            rear = -1;
            front = -1;
            size = 0;

        }
        public bool isEmpty()
        {
            return size == 0;
        }
        public bool isFuLL(int capacity)
        {
            return size == capacity;
        }
        public void enque(int x)
        {
            if (isFuLL(capacity))
            {
                Console.WriteLine("the queue is full ");
                return;
            }
            rear = (rear + 1) % capacity;
            queu[rear] = x;
            Console.WriteLine(" the element is add" + queu[rear]);
            size++;
        }
        public void deque()
        {
            if (isEmpty())
            {
                Console.WriteLine("THE QUEUE IS IN UNDERFLOW");
                
            }
            front = (front + 1) % capacity;
            Console.WriteLine("the element is deleted " + queu[front]);

            size--;
            if (size == 0)
            {
                rear = -1;
                front = -1;
            }
            
        }







        static void Main(string[] args)
        {
            const int VAT = 13;
            Console.WriteLine(VAT);

            Console.WriteLine(" this is me suman hellow world ");
            CircularQueue circularQueue = new CircularQueue(5);

            circularQueue.enque(10);
            circularQueue.enque(10);
            circularQueue.enque(10);
            circularQueue.enque(10);
            circularQueue.enque(10);
            circularQueue.enque(20);
            circularQueue.deque();
                circularQueue.deque();
            circularQueue.deque();

            circularQueue.deque();
            circularQueue.deque();
            circularQueue.deque();
            circularQueue.deque();
            circularQueue.deque();
            circularQueue.deque();
            circularQueue.deque();
            circularQueue.deque();

            circularQueue.enque(20);

            circularQueue.enque(30);

            circularQueue.enque(40);
            circularQueue.enque(50);
            circularQueue.enque(60);




        }
    }
}
