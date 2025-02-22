public enum SearchMethod {
  BSF,
  DFS
}

public abstract class Graph {
  protected readonly int vertices;
  protected readonly bool directed;
  ///<summary>
  /// May only be used by EdgeLishGraph
  ///</summary>
  protected readonly int edges;
  protected readonly bool weighted;

  public Graph(int vertices, bool directed = false, bool weighted = false){
    this.vertices = vertices;
    this.directed = directed;
    this.weighted = weighted;
  }

  public Graph(int vertices, int edges, bool directed = false){
    this.vertices = vertices;
    this.directed = directed;
    this.edges = edges;
  }

  public Graph(int vertices, int edges, bool directed = false, bool weighted = false){
    this.vertices = vertices;
    this.directed = directed;
    this.edges = edges;
    this.weighted = weighted;
  }


  public abstract void AddEdge(int v1, int v2, int w);
  public abstract void DeleteEdge(int v1, int v2);
  public abstract List<int> GetAdjacentVertices(int v);
  public abstract bool CheckAdjacentVertices(int v1, int v2);
  public abstract int GetVertexOutDegree(int v);
  public abstract int GetVertexInDegree(int v);
  public abstract List<int> GetVertexInOutDegree(int v);
  public abstract int GetEdgeWeight(int v1, int v2);
  public abstract bool IsConnectedGraph();
  public abstract List<int> BFS(int v);
  public int Vertices { get {return this.vertices; } }
  public bool Directed { get {return this.directed; } }
}
