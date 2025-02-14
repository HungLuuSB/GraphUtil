public class AdjacencyMatrixGraph : Graph {
  int[,] matrix;
  public AdjacencyMatrixGraph(int vertices, bool directed = false)
  :base(vertices, directed)
  {
    this.matrix = new int[vertices + 1, vertices + 1];
    GenerateEmptyMatrix(vertices);
  }

  private void GenerateEmptyMatrix(int vertices){
    for (int rows = 1; rows <= vertices; rows++){
      for (int cols = 1; cols <= vertices; cols++){
        this.matrix[rows, cols] = 0;
      }
    }
  }

  public override void AddEdge(int v1, int v2, int w)
  {
    this.matrix[v1, v2] = w;
    if (!this.directed)
      this.matrix[v2, v1] = w;
  }

  public override void DeleteEdge(int v1, int v2){
    this.matrix[v1, v2] = 0;
    if (this.directed)
      this.matrix[v2, v1] = 0;
  }

  public static AdjacencyMatrixGraph ReadAdjacencyMatrixGraph(string path, bool directed = false){
    StreamReader sr = new StreamReader(path);
    string line = sr.ReadLine();
    int n = int.Parse(line);

    AdjacencyMatrixGraph adjacencyMatrixGraph = new AdjacencyMatrixGraph(n, directed);
    for (int rows = 1; rows <= n; rows++){
      line = sr.ReadLine();
      string[] values = line.Split(' ');
      for (int cols = 1; cols <= n; cols++){
        adjacencyMatrixGraph.AddEdge(rows, cols, int.Parse(values[cols - 1]));
      }
    }
    sr.Close();
    return adjacencyMatrixGraph;
  }

  public override int GetEdgeWeight(int v1, int v2){
    return this.matrix[v1, v2];
  }

  public override List<int> GetAdjacentVertices(int v){
    List<int> result = new List<int>();
    for (int i = 1; i <= this.vertices; i++){
      if (this.matrix[v, i] != 0)
        result.Add(i);
    }
    return result;
  }

  public override bool CheckAdjacentVertices(int v1, int v2){
    return this.matrix[v1, v2] != 0;
  }

  public override int GetVertexOutDegree(int v){
    int level = 0;
    for (int i = 1; i <= this.vertices; i++){
      if (this.matrix[v, i] != 0)
        level+=1;
    }
    return level;
  }

  public override int GetVertexInDegree(int v){
    int level = 0;
    for (int i = 1; i <= this.vertices; i++){
      if (this.matrix[i, v] != 0)
        level+=1;
    }
    return level;
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
      foreach (int neighbor in GetAdjacentVertices(current)){
        if (!visited[neighbor]){
          queue.Enqueue(neighbor);
          visited[neighbor] = true;
        }
      }
    }
    result.RemoveAt(0);
    return result;
  }
}
