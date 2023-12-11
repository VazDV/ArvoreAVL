using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArvoreAVL
{
    public class AVLTree
    {
        private Node root;

        // Função para obter a altura de um nó
        private int GetHeight(Node node)
        {
            return (node == null) ? 0 : node.Height;
        }

        // Função para obter o fator de balanceamento de um nó
        private int GetBalance(Node node)
        {
            return (node == null) ? 0 : GetHeight(node.Left) - GetHeight(node.Right);
        }

        // Função para realizar uma rotação à direita
        private Node RotateRight(Node y)
        {
            Node x = y.Left;
            Node T2 = x.Right;

            x.Right = y;
            y.Left = T2;

            y.Height = Math.Max(GetHeight(y.Left), GetHeight(y.Right)) + 1;
            x.Height = Math.Max(GetHeight(x.Left), GetHeight(x.Right)) + 1;

            return x;
        }

        // Função para realizar uma rotação à esquerda
        private Node RotateLeft(Node x)
        {
            Node y = x.Right;
            Node T2 = y.Left;

            y.Left = x;
            x.Right = T2;

            x.Height = Math.Max(GetHeight(x.Left), GetHeight(x.Right)) + 1;
            y.Height = Math.Max(GetHeight(y.Left), GetHeight(y.Right)) + 1;

            return y;
        }

        // Função para inserir um nó na árvore AVL
        public Node Insert(Node node, int data)
        {
            if (node == null)
                return new Node(data);

            if (data < node.Data)
                node.Left = Insert(node.Left, data);
            else if (data > node.Data)
                node.Right = Insert(node.Right, data);
            else
                return node; // Ignora chaves duplicadas

            // Atualiza a altura do nó atual
            node.Height = 1 + Math.Max(GetHeight(node.Left), GetHeight(node.Right));

            // Obtém o fator de balanceamento deste nó para verificar se é necessário rebalancear
            int balance = GetBalance(node);

            // Casos de rotação
            if (balance > 1)
            {
                if (data < node.Left.Data)
                    return RotateRight(node);
                if (data > node.Left.Data)
                {
                    node.Left = RotateLeft(node.Left);
                    return RotateRight(node);
                }
            }

            if (balance < -1)
            {
                if (data > node.Right.Data)
                    return RotateLeft(node);
                if (data < node.Right.Data)
                {
                    node.Right = RotateRight(node.Right);
                    return RotateLeft(node);
                }
            }

            return node;
        }

        // Função para realizar uma travessia em ordem na árvore e imprimir os dados
        private void InOrderTraversal(Node root)
        {
            if (root != null)
            {
                InOrderTraversal(root.Left);
                Console.Write(root.Data + " ");
                InOrderTraversal(root.Right);
            }
        }

        // Função para imprimir os dados em ordem
        public void PrintInOrder()
        {
            InOrderTraversal(root);
            Console.WriteLine();
        }

        // Construtor
        public AVLTree()
        {
            root = null;
        }

        // Método para inserir dados de um arquivo .txt
        public void InsertDataFromFile(string filePath)
        {
            try
            {
                string content = File.ReadAllText(filePath);
                string[] numbersStr = content
                    .Trim('[', ']')
                    .Split(',')
                    .Select(s => s.Trim())
                    .ToArray();

                foreach (string numStr in numbersStr)
                {
                    int data = int.Parse(numStr);
                    root = Insert(root, data);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro ao ler o arquivo: " + ex.Message);
            }
        }
    }
}
