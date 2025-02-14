public static class GraphConverter {
  public static AdjacencyMatrixGraph ConvertAdjListToAdjMatrix(AdjacencyListGraph adjacencyListGraph){
    AdjacencyMatrixGraph adjacencyMatrixGraph = new AdjacencyMatrixGraph(adjacencyListGraph.Vertices, adjacencyListGraph.Directed);
    for (int i = 1; i <= adjacencyMatrixGraph.Vertices; i++){
      List<int> neighbors = adjacencyListGraph.GetAdjacentVertices(i);
      foreach (int neighbor in neighbors){
        adjacencyMatrixGraph.AddEdge(i, neighbor, 1);
      }
    }
    return adjacencyMatrixGraph;
  }

  public static AdjacencyListGraph ConvertAdjMatrixToAdjList(AdjacencyMatrixGraph adjacencyMatrixGraph){
    AdjacencyListGraph adjacencyListGraph = new AdjacencyListGraph(adjacencyMatrixGraph.Vertices, adjacencyMatrixGraph.Directed);
    for (int i = 1; i<= adjacencyListGraph.Vertices; i++){
      foreach (int neighbor in adjacencyMatrixGraph.GetAdjacentVertices(i)){
        adjacencyListGraph.AddEdge(i, neighbor, 0);
      }
    }
    return adjacencyListGraph;
  }
}
