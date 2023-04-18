using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Numerics;
using static System.Net.Mime.MediaTypeNames;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryForApliedMathService
{
    public class Graph
    {
        private int VerticesCount;
        private int EdgesCount;
        private Edge[] edge;
        public struct Edge
        {
            public int Source;
            public int Destination;
            public int Weight;
        }

        public Graph(int verticesCount, int edgesCount)
        {
            VerticesCount = verticesCount;
            EdgesCount = edgesCount;
            edge = new Edge[EdgesCount];
        }

        public int getVerticesCount()
        {
            return VerticesCount;
        }

        public int getEdgesCount()
        {
            return EdgesCount;
        }

        public void setEdge(int i, int Source, int Destination, int Weight)
        {
            edge[i].Source = Source;
            edge[i].Destination = Destination;
            edge[i].Weight = Weight;
        }

        public Edge getEdge(int i)
        {
            return edge[i];
        }

    }

    public class GraphAlgoritm
    {
        public static async void BellmanFord()
        {
            String fileInfo = "";
            try
            {
                fileInfo = File.ReadAllText("C:\\Users\\Nikita\\source\\repos\\AppliedMathematicService\\AppliedMathematicService\\Graph.txt");
            } catch(FileNotFoundException e)
            {
                Console.WriteLine(e.FileName);
            }
            String[] fileParse = fileInfo.Split(' ');
            int[] fileParseInSplit = new int[fileParse.Length];

            for (int i = 0; i < fileParse.Length; i++)
            {
                fileParseInSplit[i] = int.Parse(fileParse[i]);
            }

            Graph graph = new Graph(fileParseInSplit[0], fileParseInSplit[1]);
            int source = fileParseInSplit[2];


            for (int i = 0; i < graph.getEdgesCount(); i++)
            {
                //формула 3i+(3,4,5) перебирает все элементы после того, как из файла были выкочены элементы, связанные с основными данными графа
                graph.setEdge(i, fileParseInSplit[3 * i + 3], fileParseInSplit[3 * i + 4], fileParseInSplit[3 * i + 5]);

            }
            int verticesCount = graph.getVerticesCount();
            int edgesCount = graph.getEdgesCount();
            int[] distance = new int[verticesCount];

            for (int i = 0; i < verticesCount; i++)
                distance[i] = int.MaxValue;

            distance[source] = 0;

            for (int i = 1; i <= verticesCount - 1; ++i)
            {
                for (int j = 0; j < edgesCount; ++j)
                {
                    int u = graph.getEdge(j).Source;
                    int v = graph.getEdge(j).Destination;
                    int weight = graph.getEdge(j).Weight;

                    if (distance[u] != int.MaxValue && distance[u] + weight < distance[v])
                        distance[v] = distance[u] + weight;
                }
            }
            string res = string.Join(" ", distance);
            File.WriteAllText("C:\\Users\\Nikita\\source\\repos\\AppliedMathematicService\\AppliedMathematicService\\result.txt", res);

        }
    }
}