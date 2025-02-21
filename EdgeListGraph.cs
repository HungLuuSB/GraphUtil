public class EgdeData {
  public int Vertex { get; set; }
  public int AdjVertex { get; set; }
  public int Weight { get; set; }
  public EgdeData(int v, int adjV, int w){
    Vertex = v;
    AdjVertex = adjV;
    Weight = w;
  }
}

public class EdgeListGraph : Graph {
  List<EgdeData> edgeList;
  public EdgeListGraph(int vertices, int edges, bool directed = false)
  :base(vertices, edges, directed){
    edgeList = new List<EgdeData>();
  }
  
  private void GenerateEmptyList(){
    
  }
  
  private EgdeData GetEgdeDataFromVertex(int v1, int v2){
    foreach (var data in edgeList){
      if (data.Vertex == v1 && data.AdjVertex == v2){
        return data;
      }
    }
    return null;
  }

  private List<EgdeData> GetEgdeDatasFromVertex(int v){
    List<EgdeData> result = new List<EgdeData>();
    foreach (var data in edgeList){
      if (data.Vertex == v)
        result.Add(data);
    }
    return result;
  }

  public override void AddEdge(int v1, int v2, int w){
    EgdeData data_0 = new EgdeData(v1, v2, w);
    edgeList.Add(data_0);
    if (directed){ 
      EgdeData data_1 = new EgdeData(v2, v1, w);
      edgeList.Add(data_1);
    }
  }

  public override int GetEdgeWeight(int v1, int v2){
    EgdeData edge = GetEgdeDataFromVertex(v1, v2);
    if (edge != null)
      return edge.Weight;
    return -1;
  }

  public override int GetVertexOutDegree(int v){
    List<EgdeData> result = GetEgdeDatasFromVertex(v);
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
}
