namespace Dijkstra_online_source
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Code source: Dr. Chen posted in Moodle
            // I updated the graph values to match a graph I wanted to use, some variable names, and formatting 

            int[,] graph =
           // col 0   1  2  3  4
            {  // A   B  C  D  E
                { 0, 10, 3, 0, 0},   // A  row 0
				{ 10, 0, 4, 2, 0},   // B  row 1
                { 3, 4, 0, 8, 2},    // C  row 2
                { 0, 2, 8, 0, 9},    // D  row 3
                { 0, 0, 2, 9, 0},    // E  row 4
            };

            int source = 0;

            int verticesCount = graph.GetLength(0);  // 0 is for the first dimension (rows) 

            Dijkstra(graph, source, verticesCount);
        }

        public static void Dijkstra(int[,] graph, int source, int verticesCount)
        {
            int[] distance = new int[verticesCount];
            bool[] shortestPathTreeSet = new bool[verticesCount];

            for (int i = 0; i < verticesCount; i++)
            {
                distance[i] = int.MaxValue;
                shortestPathTreeSet[i] = false;
            }

            distance[source] = 0;

            for (int count = 0; count < verticesCount - 1; count++)
            {
                int u = MinimumDistance(distance, shortestPathTreeSet, verticesCount);

                shortestPathTreeSet[u] = true;

                for (int v = 0; v < verticesCount; v++)
                    if (!shortestPathTreeSet[v] && Convert.ToBoolean(graph[u, v]) && distance[u] != int.MaxValue && distance[u] + graph[u, v] < distance[v])
                        distance[v] = distance[u] + graph[u, v];
            }

            Print(distance, verticesCount);
        }

        private static int MinimumDistance(int[] distance, bool[] shortestPathTreeSet, int verticesCount)
        {
            int min = int.MaxValue;
            int minIndex = 0;

            for (int v = 0; v < verticesCount; v++)
            {
                if (shortestPathTreeSet[v] == false && distance[v] <= min)
                {
                    min = distance[v];
                    minIndex = v;
                }
            }

            return minIndex;
        }

        private static void Print(int[] distance, int verticesCount)
        {
            Console.WriteLine("Vertex | Distance from source");
            for (int i = 0; i < verticesCount; ++i)
                Console.WriteLine("{0}\t  {1}", i, distance[i]);
        }
    }
}