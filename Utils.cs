public static class Utils{
  public static bool IsOutOfBound(int[,] matrix ,(int, int) position){
    if (position.Item1 == 1 || position.Item1 == matrix.GetLongLength(1) - 1){
      return true;
    }else if (position.Item2 == 1 || position.Item2 == matrix.GetLongLength(0) - 1){
      return true;
    }
    return false;
  }

  public static int GetMinDirection(int[,] matrix, ref (int, int) position){
    List<(int, int)> directions = new List<(int, int)>();
    directions.Add((-1, 0));
    directions.Add((0, 1));
    directions.Add((1, 0));
    directions.Add((-1, 0));
    if (IsOutOfBound(matrix, position)){
      return -1;
    }else{
      int min = int.MaxValue;
      (int, int) tmpPos = position;
      foreach (var direction in directions){
        int tmp = matrix[position.Item1, position.Item2];
        (int, int) new_pos = new (position.Item1 + direction.Item1, position.Item2 + direction.Item2);
        int tmp_sum = tmp + matrix[new_pos.Item1, new_pos.Item2];
        if (tmp_sum < min){
          min = tmp_sum;
          tmpPos = new_pos;
          Console.WriteLine($"{tmpPos.Item1}, {tmpPos.Item2}");
        }
      }
      position = tmpPos;
      return min;
    }
  }

  public static int MinOutbound(int[,] matrix, (int, int) position){
    int sum = 0;
    while (true){
      int result = GetMinDirection(matrix,ref position);
      if (result != -1){
        sum += result;
      }else{
        break;
      }
    }
    return sum;
  }
}

