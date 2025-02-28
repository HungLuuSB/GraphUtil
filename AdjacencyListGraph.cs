public class AdjacencyListGraph : Graph {
  List<int>[] adjList;

  public AdjacencyListGraph(int vertices, bool directed = false)
  :base(vertices, directed){
    this.adjList = new List<int>[vertices + 1];
    GenerateEmptyAdjList();
  }

  private void GenerateEmptyAdjList(){
    for (int i = 1; i <= this.vertices; i++){
      this.adjList[i] = new List<int>();
    }
  }

  public override void AddEdge(int v1, int v2, int w){
    this.adjList[v1].Add(v2);
    //if (!this.directed)
     // this.adjList[v2].Add(v1);
  }

  public override void DeleteEdge(int v1, int v2){
    this.adjList[v1].Remove(v2);
    //if (!this.directed)
    //  this.adjList[v2].Remove(v1);
  }

  public static AdjacencyListGraph ReadAdjacencyList(string path, bool directed = false){
    if (!File.Exists(path))
      throw new Exception("File not found!");
    StreamReader sr = new StreamReader(path);
    string line = sr.ReadLine();
    int n = int.Parse(line);

    AdjacencyListGraph adjacencyListGraph = new AdjacencyListGraph(n, directed);

    for (int i = 1; i <= n; i++){
      line = sr.ReadLine();
      if (string.IsNullOrEmpty(line))
        continue;
      string[] neighbors = line.Split(' ');
      foreach (string neighbor in neighbors){
        adjacencyListGraph.AddEdge(i, int.Parse(neighbor), 1);
      }
    }
    return adjacencyListGraph;
  }

  public override int GetEdgeWeight(int v1, int v2){
    return 1;
  }

  public override List<int> GetAdjacentVertices(int v){
    return this.adjList[v];
  }

  public override bool CheckAdjacentVertices(int v1, int v2){
    foreach (int neighbor in GetAdjacentVertices(v1)){
      if (neighbor == v2)
        return true;
    }
    return false;
  }

  public override int GetVertexInDegree(int v){
    int level = 0;
    for (int i = 1; i <= this.vertices; i++){
      foreach (int vertex in this.adjList[i]){
        if (vertex == v){
          level++;
        }
      }
    }
    return level;
  }

  public override int GetVertexOutDegree(int v){
    return this.adjList[v].Count;
  }

  public override List<int> GetVertexInOutDegree(int v){
    int inLevel = GetVertexInDegree(v), outLevel = GetVertexOutDegree(v);
    List<int> result = new List<int>();
    result.Add(inLevel);
    result.Add(outLevel);
    return result;
  }

  public override bool IsConnectedGraph(){
    List<int> _checkVertices = BFS(1);
    return _checkVertices.Count == this.vertices - 1;
  }

  public override List<int> BFS(int v){
    List<int> result = new List<int>();
    Queue<int> queue = new Queue<int>();
    bool[] visited = new bool[this.vertices + 1];
    queue.Enqueue(v);
    visited[v] = true;
    while (queue.Count > 0){
      int current = queue.Dequeue();
      result.Add(current);
      foreach (int neighbor in this.adjList[current]){
        if (!visited[neighbor]){
          queue.Enqueue(neighbor);
          visited[neighbor] = true;
        }
      }
    }
    result.RemoveAt(0);
    return result;
  }

  public List<int> FindPath(int s, int e){
    List<int> result = new List<int>();
    Queue<int> queue = new Queue<int>();
    bool[] visited = new bool[vertices + 1];
    int[] pre = new int[vertices + 1];
    Array.Fill(pre, -1);
    visited[s] = true;
    queue.Enqueue(s);
    while (queue.Count > 0){
      int curr = queue.Dequeue();
      if (curr == e)
        break;
      foreach (int neighbor in this.adjList[curr]){
        if (!visited[neighbor]){
          visited[neighbor] = true;
          queue.Enqueue(neighbor);
          pre[neighbor] = curr;
        }
      }
    }
    int node = e;
    while (pre[node] != -1){
      result.Add(node);
      node = pre[node];
    }
    return result;
  }
  
  public List<int> DFS(int s){
    List<int> result = new List<int>();
    Stack<int> stack = new Stack<int>();
    bool[] visited = new bool[vertices + 1];
    visited[s] = true;
    stack.Push(s);
    while (stack.Count > 0){
      int curr = stack.Pop();
      result.Add(curr);
      foreach (int neighbor in this.adjList[curr]){
        if (!visited[neighbor]){
          visited[neighbor] = true;
          stack.Push(neighbor);
        }
      }
    }
    result.RemoveAt(0);
    return result;
  }

  // Only available by using Weight-support Graph
  public void Dijkstra(int s){
    int[] dist = new int[vertices + 1];
    Array.Fill(dist, int.MaxValue);
    int[] pre = new int[vertices + 1];
    Array.Fill(pre, -1);
    bool[] visited = new bool[vertices + 1];
    
  }


}
