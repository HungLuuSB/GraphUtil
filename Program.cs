string inputFileName = "input/Dijkstra.INP";
if (!File.Exists(inputFileName))
  throw new Exception("No input file found!");

var graph = AdjacencyMatrixGraph.ReadAdjacencyMatrixGraph(inputFileName);
var result = graph.Dijkstra(1, 7);
foreach (var neighbor in result){
  Console.Write(neighbor + " ");
}
