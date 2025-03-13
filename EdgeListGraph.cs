public class EdgeData {
  public int Vertex { get; set; }
  public int AdjVertex { get; set; }
  public int Weight { get; set; }
  public EdgeData(int v, int adjV, int w = 0){
    Vertex = v;
    AdjVertex = adjV;
    Weight = w;
  }
}

public class EdgeListGraph : Graph {
  List<EdgeData> edgeList;
  public EdgeListGraph(int vertices, int edges, bool directed = false, bool weighted = false)
  :base(vertices, edges, directed, weighted){
    edgeList = new List<EdgeData>();
  }

  public static EdgeListGraph ReadEdgeList(string filePath, bool directed = false, bool weighted = false){
    StreamReader sr = new StreamReader(filePath);
    string line = sr.ReadLine();
    string[] param = line.Split(" ");
    int n = int.Parse(param[0]);
    int e = int.Parse(param[1]);
    EdgeListGraph graph = new EdgeListGraph(n, e, directed, weighted);
    for (int i = 1; i <= e; i++){
      line = sr.ReadLine();
      string[] values = line.Split(" ");
      int v = int.Parse(values[0]);
      int adjV = int.Parse(values[1]);
      int w = 0;
      if (weighted && values.Length == 3){
        w = int.Parse(values[2]);
      }
      graph.AddEdge(v, adjV, w);
    }
    return graph;
  }
  
  private EdgeData GetEdgeDataFromVertex(int v1, int v2){
    foreach (var data in edgeList){
      if (data.Vertex == v1 && data.AdjVertex == v2){
        return data;
      }
    }
    return null;
  }

  private List<EdgeData> GetEdgeDatasFromVertex(int v){
    List<EdgeData> result = new List<EdgeData>();
    foreach (var data in edgeList){
      if (data.Vertex == v)
        result.Add(data);
    }
    return result;
  }

  public override void AddEdge(int v1, int v2, int w){
    EdgeData data_0 = new EdgeData(v1, v2, w);
    edgeList.Add(data_0);
    if (!directed){ 
      EdgeData data_1 = new EdgeData(v2, v1, w);
      edgeList.Add(data_1);
    }
  }

  public override void DeleteEdge(int v1, int v2){
    EdgeData edge_1 = GetEdgeDataFromVertex(v1, v2);
    edgeList.Remove(edge_1);
    if (!directed){
      EdgeData edge_2 = GetEdgeDataFromVertex(v2, v1);
      edgeList.Remove(edge_2);
    }
  }

  public override int GetEdgeWeight(int v1, int v2){
    EdgeData edge = GetEdgeDataFromVertex(v1, v2);
    if (edge != null)
      return edge.Weight;
    return -1;
  }

  public override int GetVertexOutDegree(int v){
    List<EdgeData> result = GetEdgeDatasFromVertex(v);
    return result.Count;
  }

  public override int GetVertexInDegree(int v){
    int inDegree = 0;
    foreach (var data in edgeList){
      if (data.AdjVertex == v){
        inDegree++;
      }
    }
    return inDegree;
  }

  public override List<int> GetVertexInOutDegree(int v){
    int inDegree = GetVertexInDegree(v), outDegree = GetVertexOutDegree(v);
    List<int> result = new List<int>();
    result.Add(inDegree);
    result.Add(outDegree);
    return result;
  }

  public override bool CheckAdjacentVertices(int v1, int v2){
    if (GetEdgeDataFromVertex(v1, v2) != null)
      return true;
    return false;
  }

  public override List<int> GetAdjacentVertices(int v){
    List<EdgeData> edges = GetEdgeDatasFromVertex(v);
    List<int> result = new List<int>();
    foreach (var edge in edges){
      result.Add(edge.AdjVertex);
    }
    return result;
  }

  public override List<int> BFS(int s){
    throw new NotImplementedException();
  }

  public override bool IsConnectedGraph(){
    throw new NotImplementedException();
  }

  public List<int> Dijkstra(int s, int e){
    throw new NotImplementedException();
  }

  public void SortByWeight(){
    edgeList.Sort((a, b) => {
        return a.Weight.CompareTo(b.Weight);
        });
  }

  public bool MakeConnectedGraph(int u, int v, int[] labels){
    throw new NotImplementedException();
  }

  public void Kruskal(){
    int[] labels = new int[vertices + 1];
    for (int i = 1; i <= vertices; i++){
      labels[i] = i;
    }
    SortByWeight();
    List<EdgeData> mst = new List<EdgeData>();
    int count = 0;
    foreach (var edge in edgeList){
      if (count >= edges - 1)
        break;
      if (labels[edge.Vertex] != labels[edge.AdjVertex]){
        mst.Add(edge);
        count++;
        for (int i = 1; i <= vertices; i++){
          if (labels[i] == edge.AdjVertex){
            labels[i] = labels[edge.Vertex];
          }
        }
      }
    }
    foreach (var edge in mst){
      Console.WriteLine($"{edge.Vertex} {edge.AdjVertex} {edge.Weight}");
    }
  }

  private int GetMinWeightedVertex(bool[] inMST, int[] weight){
    int minValue = int.MaxValue;
    int minVertex = -1;
    for(int i = 1; i <= vertices; i++){
      if (!inMST[i] && weight[i] < minValue){
        minValue = weight[i];
        minVertex = i;
      }
    }
    return minVertex;
  }

  public void Prim(int s){
    List<EdgeData> mst = new List<EdgeData>();
    int[] pre = new int[vertices + 1];
    bool[] inMST = new bool[vertices + 1];
    int[] weight = new int[vertices + 1];

    Array.Fill(pre, -1);
    Array.Fill(weight, int.MaxValue);

    weight[s] = 0;
    for (int i = 0; i < vertices; i++){
      int curr = GetMinWeightedVertex(inMST, weight);
      Console.WriteLine(curr);
      inMST[curr] = true;
      if (pre[curr] != -1){
        mst.Add(new EdgeData(pre[curr], curr, weight[curr]));
      }
      foreach (var neighbor in GetAdjacentVertices(curr)){
        Console.WriteLine(neighbor);
        if (!inMST[neighbor]){
          if (weight[neighbor] > GetEdgeWeight(curr, neighbor)){
            weight[neighbor] = GetEdgeWeight(curr, neighbor);
            pre[neighbor] = curr;
          }
        }
      }
    }
    foreach (var edge in mst){
      Console.WriteLine($"{edge.Vertex} {edge.AdjVertex} {edge.Weight}");
    }
  }
}
