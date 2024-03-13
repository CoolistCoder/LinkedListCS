// Written by Alec 3/11/2024
// in .net 8.0
using System;
using System.Drawing;

namespace LinkedListCS
{
    class LinkedList<T>
    {
        private class Node<T>
        {
            private T data;
            private Node<T> next = null;

            //getters/setters

            public T getData()
            {
                return this.data;
            }
            public void setData(T dat)
            {
                this.data = dat;
            }

            public Node<T> getNext()
            {
                return this.next;
            }
            public void setNext(Node<T> next)
            {
                this.next = next;
            }
        }

        private Node<T> head = null;

        //private methods
        public void swapNode(uint a, uint b)
        {
            //Check to see if a and b are within scope
            if (a < this.getSize() && b < this.getSize())
            {
                T temp = this.getAt(a);
                this.setAt(a, this.getAt(b));
                this.setAt(b, temp);
            }
            
        }

        //public methods
        public void add(T dat)
        {
            //Check to see if the head is empty
            if (head == null) //populate head if empty
            {
                this.head = new Node<T>();
                this.head.setData(dat);
                this.head.setNext(null);
            }
            else //hook data to end of list if not empty
            {
                //iterate through the list until we've found the end
                //use temporary pointer as iterator
                Node<T> temp = this.head;
                while (temp.getNext() != null)
                {
                    temp = temp.getNext();
                }
                //Init final entry with data
                temp.setNext(new Node<T>());
                temp.getNext().setData(dat);
                temp.getNext().setNext(null);
            }
        }
        public void printList()
        {
            if (this.head != null)
            {
                //Create temp node to iterate through list
                Node<T> temp = this.head;
                int iter = 0;
                while (temp != null)
                {
                    System.Console.WriteLine("Element at " + iter + ": " + temp.getData());
                    temp = temp.getNext();
                    iter++;
                }
            }
            else
            {
                System.Console.WriteLine("The list is empty");
            }
        }
        public int getSize()
        {
            if (this.head != null)
            {
                //Create temp node to iterate through list
                Node<T> temp = this.head;
                int iter = 0;
                while (temp != null)
                {
                    temp = temp.getNext();
                    iter++;
                }
                return iter;
            }
            return 0;
        }
        public T getAt(uint index)
        {
            //Prevent the get from going out of range
            if (this.head != null && index < this.getSize())
            {
                //Create temp node to iterate through list
                Node<T> temp = this.head;
                int iter = 0;
                while (temp != null && iter != index)
                {
                    temp = temp.getNext();
                    iter++;
                }
                return temp.getData();
            }
            else
            {
                System.Console.WriteLine("Out of range or empty");
            }
            return default(T);
        }
        public void setAt(uint index, T value)
        {
            //Similar to getAt but sets the value at the index instead
            //Prevent the get from going out of range
            if (this.head != null && index < this.getSize())
            {
                //Create temp node to iterate through list
                Node<T> temp = this.head;
                int iter = 0;
                while (temp != null && iter != index)
                {
                    temp = temp.getNext();
                    iter++;
                }
                temp.setData(value);
            }
            else
            {
                System.Console.WriteLine("Out of range");
            }
        }
        public void deleteAt(uint index)
        {
            //Prevent the delete from going out of range
            if (this.head != null && index < this.getSize())
            {
                //The theory is to get the temp to read the next node over
                //And delete the node between the last and next.next
                Node<T> temp = this.head;
                Node<T> previous = temp;
                int iter = 0;
                while (temp.getNext() != null && iter < index)
                {
                    previous = temp;
                    temp = temp.getNext();
                    iter++;
                }
                previous.setNext(temp.getNext());
                temp = null;
            }
            else if (this.head != null && this.head.getNext() == null)
            { //if the head is not null but has no additional nodes...
                this.head = null;
            }
        }
        
        public void clean()
        {
            //The Garbage Collector should catch this
            //If not, an implementation can be made to iterate
            //and delete all nodes
            this.head = null;
        }
       
    }

    class Program
    {
        //3/11/2024 current implementation works like an expanding array
        //Useful, and contains some tools arrays don't usually provide
        //Author's Note: A sort isn't really feasible with generics unless an extension is performed
        public static void Main(string[] args)
        {
            //This is the instance of the linked list in the main
            LinkedList<int> mylist = new LinkedList<int>();

            //Some clean user output
            System.Console.WriteLine("This is a program that demonstrates a custom linked list");
            System.Console.WriteLine("Press return to add some data to the linked list");
            System.Console.ReadLine();

            //Add a few elements (values are not random but don't have much value)
            mylist.add(25);
            mylist.add(33);
            mylist.add(45);
            mylist.add(688);
            mylist.add(1);
            mylist.add(9999);

            System.Console.WriteLine("Elements added");
            System.Console.WriteLine("Press return to print out each value");
            System.Console.ReadLine();
            mylist.printList();

            System.Console.WriteLine("Press return to retrieve elements from different positions");
            System.Console.ReadLine();

            System.Console.WriteLine("Element at 1: " + mylist.getAt(1));
            System.Console.WriteLine("Element at 5: " + mylist.getAt(5));
            System.Console.WriteLine("Element at 3: " + mylist.getAt(3));
            System.Console.WriteLine("Element at 99: " + mylist.getAt(99));

            //3/13/2024 test the deleteAt method to demonstrate how it works
            System.Console.WriteLine("I want to delete the element at 3");
            System.Console.WriteLine("Press return to continue");
            System.Console.ReadLine();

            mylist.deleteAt(3);
            System.Console.WriteLine("Printing all elements:");
            mylist.printList();

            //3/13/2024 test the swap
            System.Console.WriteLine("Performing a swap between 2 and 4");
            System.Console.WriteLine("Press return to continue");
            System.Console.ReadLine();

            mylist.swapNode(2, 4);
            System.Console.WriteLine("Printing each element in the list");
            mylist.printList();

            System.Console.WriteLine("End of program, have a nice day");
        }
    }
}
