string inputFileName = "input/EdgeList.INP";
if (!File.Exists(inputFileName))
  throw new Exception("No input file found!");

EdgeListGraph graph = EdgeListGraph.ReadEdgeList(inputFileName);

var result = graph.GetVertexOutDegree(2);
Console.WriteLine(result);
Console.WriteLine("Finished");
