using System;

namespace BinarySearchTree
{
	class BinaryTree
	{
		public Node Root { get; set; }

		/// <summary>
		/// Add Number to Binary Tree
		/// </summary>
		/// <param name="num">
		/// </param>
		public bool Add(int num)
		{
			Node before = null, after = this.Root;

			while (after != null)
			{
				before = after;
				if (num < after.Data)
				{
					after = after.LeftNode;
				}
				else if (num > after.Data)
				{
					after = after.RightNode;
				}
				else
				{
					return false;
				}
			}

			Node newNode = new Node();
			newNode.Data = num;

			if (this.Root == null)
			{
				this.Root = newNode;
			}
			else
			{
				if (num < before.Data)
					before.LeftNode = newNode;
				else
					before.RightNode = newNode;
			}

			return true;
		}

		/// <summary>
		/// Find Number in Binary Tree  
		/// </summary>
		/// <param name="num">
		/// </param>
		/// <returns>
		/// </returns>
		public Node Find(int num)
		{
			return this.Find(num, this.Root);
		}

		/// <summary>
		/// Remove Number in Binary Tree  
		/// </summary>
		/// <param name="num">
		/// </param>
		public void Remove(int num)
		{
			Remove(this.Root, num);
		}

		/// <summary>
		/// Remove Number in Binary Tree
		/// </summary>
		/// <param name="parent">
		/// </param>
		/// <param name="key">
		/// </param>
		private Node Remove(Node parent, int key)
		{
			if (parent == null)
			{ 
				return parent; 
			}

			if (key < parent.Data)
			{
				parent.LeftNode = Remove(parent.LeftNode, key);
			}
			else if (key > parent.Data)
            {
				parent.RightNode = Remove(parent.RightNode, key);
			}
			else
			{
				if (parent.LeftNode == null)
					return parent.RightNode;
				else if (parent.RightNode == null)
					return parent.LeftNode;

				parent.Data = MinNum(parent.RightNode);

				parent.RightNode = Remove(parent.RightNode, parent.Data);
			}

			return parent;
		}

		/// <summary>
		/// Get Min Number in Binary Tree
		/// </summary>
		/// <param name="node">
		/// </param>
		/// <returns></returns>
		private int MinNum(Node node)
		{
			int minNum = node.Data;

			while (node.LeftNode != null)
			{
				minNum = node.LeftNode.Data;
				node = node.LeftNode;
			}

			return minNum;
		}

		/// <summary>
		/// Find Number in Binary Tree
		/// </summary>
		/// <param name="num">
		/// </param>
		/// <param name="parent">
		/// </param>
		/// <returns></returns>
		private Node Find(int num, Node parent)
		{
			if (parent != null)
			{
				if (num == parent.Data)
				{
					return parent;
				}
				if (num < parent.Data)
				{
					return Find(num, parent.LeftNode);
				}
				else
				{
					return Find(num, parent.RightNode);
				}
			}

			return null;
		}

		/// <summary>
		/// Get Depth of Binary Tree
		/// </summary>
		/// <param name="parent">
		/// </param>
		/// <returns></returns>
		private int GetDepth(Node parent)
		{
			return parent == null ? 0 : Math.Max(GetDepth(parent.LeftNode), GetDepth(parent.RightNode)) + 1;
		}

		/// <summary>
		/// Recursively Print Binary Tree via Pre Order Traversal
		/// </summary>
		/// <param name="parent">
		/// </param>
		public void PrintPreOrder(Node parent)
		{
			if (parent != null)
			{
				Console.Write(parent.Data + " ");
				PrintPreOrder(parent.LeftNode);
				PrintPreOrder(parent.RightNode);
			}
		}

		/// <summary>
		/// Recursively Print Binary Tree via In Order Traversal
		/// </summary>
		/// <param name="parent">
		/// </param>
		public void PrintInOrder(Node parent)
		{
			if (parent != null)
			{
				PrintInOrder(parent.LeftNode);
				Console.Write(parent.Data + " ");
				PrintInOrder(parent.RightNode);
			}
		}

		/// <summary>
		/// Recursively Print Binary Tree via Post Traversal
		/// </summary>
		/// <param name="parent">
		/// </param>
		public void PrintPostOrder(Node parent)
		{
			if (parent != null)
			{
				PrintPostOrder(parent.LeftNode);
				PrintPostOrder(parent.RightNode);
				Console.Write(parent.Data + " ");
			}
		}

		/// <summary>
		/// Recursively Print Binary Tree via Depth First Search
		/// </summary>
		/// <param name="node">
		/// </param>
		public void PrintDFS(Node node)
		{
			if (node == null)
			{
				return;
			}

			if (node.LeftNode != null)
			{
				PrintDFS(node.LeftNode);
			}

			Console.Write(node.Data + " ");

			if (node.RightNode != null)
			{
				PrintDFS(node.RightNode);
			}
		}

		/// <summary>
		/// Recursively Print Binary Tree via Breadth First Search  
		/// </summary>
		/// <param name="node">
		/// </param>
		public void PrintBFS(Node node)
		{
			int maxLevel = GetMaxDepth(node, 0, 0);
			int count = 1;

			if (node != null)
			{
				Console.Write(node.Data + " ");
			}
			else
			{
				return;
			}

			while (count <= maxLevel)
			{
				if (node.LeftNode != null)
				{
					PrintLevelValues(node.LeftNode, 1, count);
				}

				if (node.RightNode != null)
				{
					PrintLevelValues(node.RightNode, 1, count);
				}

				count++;
			}
		}

		/// <summary>
		/// Get Max Depth of Binary Tree
		/// </summary>
		/// <returns></returns>
		public int GetMaxDepth()
		{
			return GetMaxDepth(this.Root, 0, 0);
		}

		/// <summary>
		/// Get Max Depth of Binary Tree
		/// </summary>
		/// <param name="node">
		/// </param>
		/// <param name="maxBranchLevel">
		/// </param>
		/// <param name="currentLevel">
		/// </param>
		/// <returns></returns>
		private int GetMaxDepth(Node node, int maxBranchLevel, int currentLevel)
		{
			if (node.LeftNode != null)
			{
				if ((currentLevel + 1) > maxBranchLevel)
				{
					maxBranchLevel++;
				}

				maxBranchLevel = GetMaxDepth(node.LeftNode, maxBranchLevel, currentLevel + 1);
			}

			if (node.RightNode != null)
			{
				if ((currentLevel + 1) > maxBranchLevel)
				{
					maxBranchLevel++;
				}

				maxBranchLevel = GetMaxDepth(node.RightNode, maxBranchLevel, currentLevel + 1);
			}

			return maxBranchLevel;
		}

		/// <summary>
		/// Prints Level Values
		/// </summary>
		/// <param name="node">
		/// </param>
		/// <param name="currentLevel">
		/// </param>
		/// <param name="stopLevel">
		/// </param>
		private void PrintLevelValues(Node node, int currentLevel, int stopLevel)
		{
			if (node == null)
			{
				return;
			}

			if (currentLevel == stopLevel)
			{
				Console.Write(node.Data + " ");
				return;
			}

			if (node.LeftNode != null)
			{
				PrintLevelValues(node.LeftNode, (currentLevel + 1), stopLevel);
			}

			if (node.RightNode != null)
			{
				PrintLevelValues(node.RightNode, (currentLevel + 1), stopLevel);
			}
		}
	}
}
