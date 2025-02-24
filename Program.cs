string inputFileName = "input/AdjList.INP";
if (!File.Exists(inputFileName))
  throw new Exception("No input file found!");

var graph = AdjacencyListGraph.ReadAdjacencyList(inputFileName, true);
var result = graph.BFS(6);
foreach (var neighbor in result){
  Console.Write(neighbor + " ");
}
