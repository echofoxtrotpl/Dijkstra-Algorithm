using System;
using System.IO;
using System.Collections.Generic;

namespace DijkstraAlgorithm
{
    static class Solution
    {
        public static void Print(double[] distance, char[] predecessor, char source, char target)
        {
            string v = " V ";
            string dV = "dV ";
            string pV = "pV ";
            for (int i = (int)source - 'a'; i <= (int)target - 'a'; i++)
            {
                v += $"{Convert.ToChar(i + (int)'a')} ";
                dV += $"{distance[i]} ";
                pV += $"{predecessor[i]} ";
            }
            Console.WriteLine("-------------------------------");
            Console.WriteLine(v);
            Console.WriteLine(dV);
            Console.WriteLine(pV);
            double totalCost = distance[(int)target - 'a'];
            if (totalCost != double.PositiveInfinity)
            {
                Console.Write($"Optimal path form \"{source}\" to \"{target}\" is: ");
                string path = $"{target}";
                int j = (int)target - 'a';
                while (predecessor[j] != '-')
                {
                    path = $"{predecessor[j]}->{path}";
                    j = (int)predecessor[j] - 'a';
                }
                Console.Write(path);
                Console.WriteLine($" with total cost of {totalCost}.");
            }
            else Console.WriteLine($"There is no path from \"{source}\" to \"{target}\".");
            Console.WriteLine("-------------------------------");
        }
    }
    static class FileWithData
    {
        public static List<Edge> GetData(ref StreamReader file)
        {
            string line;
            List<Edge> edges = new();
            while ((line = file.ReadLine()) != null)
            {
                edges.Add(new Edge(ref line));
            }
            file.Close();
            return edges;
        }
    }
    static class Dijkstra
    {
        public static int vQuantity = 5;
        public static int MinimalDistance(double[] distance, bool[] visited)
        {
            double minDist = double.MaxValue;
            int minVIndex = 0;
            for (int vIndex = 0; vIndex < vQuantity; ++vIndex)
            {
                if (!visited[vIndex] && distance[vIndex] < minDist)
                {
                    minDist = distance[vIndex];
                    minVIndex = vIndex;
                }
            }
            return minVIndex;
        }

        public static void Algorithm(List<Edge> edges, char source, char target)
        {
            double[] distance = new double[vQuantity];
            bool[] visited = new bool[vQuantity];
            char[] predecessors = new char[vQuantity];
            for (int vIndex = 0; vIndex < vQuantity; vIndex++)
            {
                distance[vIndex] = double.PositiveInfinity;
                visited[vIndex] = false;
                predecessors[vIndex] = '-';
            }
            int src = (int)source - 'a';
            distance[src] = 0;
            for (int i = 0; i < vQuantity - 1; i++)
            {
                int idx = MinimalDistance(distance, visited);
                visited[idx] = true;
                foreach (Edge edge in edges)
                {
                    int fromVertex = (int)edge.fromVertex - 'a';
                    int toVertex = (int)edge.toVertex - 'a';
                    if (fromVertex == idx && distance[idx] != double.PositiveInfinity && distance[idx] + edge.weight < distance[toVertex])
                    {
                        distance[toVertex] = edge.weight + distance[idx];
                        predecessors[toVertex] = Convert.ToChar(fromVertex + 'a');
                    }
                }
            }
            Solution.Print(distance, predecessors, source, target);
        }
    }
    class Edge
    {
        public Edge(ref string l)
        {
            FillEdge(ref l);
        }
        public char fromVertex;
        public char toVertex;
        public double weight;

        public void FillEdge(ref string line)
        {
            line = line.Trim(new Char[] { '[', ']' });
            string[] data = line.Split(",");
            fromVertex = Char.Parse(data[0]);
            toVertex = Char.Parse(data[1]);
            weight = Double.Parse(data[2]);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter name of file containing graph's data (in current folder): ");
            string path = Console.ReadLine();
            Console.WriteLine("Enter info about path (lowercase letters [a-z])");
            Console.Write("Starting vertex: ");
            char start = Console.ReadLine()[0];
            Console.Write("Target vertex: ");
            char target = Console.ReadLine()[0];
            try
            { 
                StreamReader file = new(path);
                List<Edge> edges = FileWithData.GetData(ref file);
                Dijkstra.Algorithm(edges, start, target);
            }
            catch (FileNotFoundException) 
            {
                Console.WriteLine("File not found! Make sure it is in the same folder as executable");
            }
        }
    }
}