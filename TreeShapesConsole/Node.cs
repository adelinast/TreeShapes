﻿namespace Tree
{
    public class Node<T>
    {
        public Node(T data)
        {
            Data = data;
        }

        public Node<T> Left { get; set; }

        public Node<T> Right { get; set; }

        public T Data
        {
            get; set;            
        }
    }
}