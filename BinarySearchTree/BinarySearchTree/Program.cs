using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinarySearchTree
{
    class Program
    {
        static void Main(string[] args)
        {
            
        }
    }

    public class BST
    {
        public int value;
        public BST left;
        public BST right;

        public BST(int value)
        {
            this.value = value;
        }

        public BST Insert(int value)
        {
            Stack<BST> stack = new Stack<BST>();
            stack.Push(this);

            while (stack.Count > 0)
            {
                BST node = stack.Pop();

                if (value < node.value)
                {
                    if (node.left != null)
                    {
                        stack.Push(node.left);
                    }
                    else
                    {
                        node.left = new BST(value);
                    }
                }
                else
                {
                    if (node.right != null)
                    {
                        stack.Push(node.right);
                    }
                    else
                    {
                        node.right = new BST(value);
                    }
                }
            }

            return this;
        }

        public bool Contains(int value)
        {
            Stack<BST> stack = new Stack<BST>();
            stack.Push(this);

            while (stack.Count > 0)
            {
                BST node = stack.Pop();

                if (node.value == value)
                {
                    return true;
                }

                if (value < node.value)
                {
                    if (node.left != null)
                    {
                        stack.Push(node.left);
                    }
                }
                else
                {
                    if (node.right != null)
                    {
                        stack.Push(node.right);
                    }
                }
            }

            return false;
        }
        
        // Recursive implementation is much simpler 
        public BST Remove(int value)
        {
            Remove(value, null);
            return this;
        }

        public void Remove(int value, BST parent)
        {
            if (value < this.value)
            {
                // look left
                if (left != null)
                {
                    left.Remove(value, this);
                }
            }
            else if (value > this.value)
            {
                // look right
                if (right != null)
                {
                    right.Remove(value, this);
                }
            }
            else
            {
                // remove case
                if (left != null && right != null)
                {
                    // full subtree
                    this.value = right.getMinValue();
                    right.Remove(this.value, this);
                }
                else if (parent == null)
                {
                    // partial subtree case 
                    if (left != null)
                    {
                        this.value = left.value;
                        right = left.right;
                        left = left.left;
                    }
                    else if (right != null)
                    {
                        this.value = right.value;
                        left = right.left;
                        right = right.right;
                    }
                    else
                    {
                        // single node tree here
                    }
                }
                else if (parent.left == this)
                {
                    parent.left = left != null ? left : right;
                }
                else if (parent.right == this)
                {
                    parent.right = left != null ? left : right;
                }
            }
        }


        public int getMinValue()
        {
            if (left == null)
            {
                return this.value;
            }
            else
            {
                return left.getMinValue();
            }
        }

    }
}

