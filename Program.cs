string inputFile = "input/Prim.INP";
EdgeListGraph edgeListGraph = EdgeListGraph.ReadEdgeList(inputFile, weighted:true);
edgeListGraph.Prim(1);
