string inputFileName = "input/AdjList.INP";
if (!File.Exists(inputFileName))
  throw new Exception("No input file found!");

AdjacencyListGraph adjacencyListGraph = AdjacencyListGraph.ReadAdjacencyList(inputFileName);
AdjacencyMatrixGraph adjacencyMatrixGraph = GraphConverter.ConvertAdjListToAdjMatrix(adjacencyListGraph);

var result = adjacencyMatrixGraph.GetVertexOutDegree(3);
Console.WriteLine(result);
Console.WriteLine("Finished");
