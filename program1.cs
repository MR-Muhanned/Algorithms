 // Tree
 class Node
 {
     public Node left;
     public Node right;
     public int value;
     public Node(int value)
     {
         this.value = value;
     }
 }
 class BinaryTree
 {
     public Node root;
     public BinaryTree()
     {
         root = null;
     }
     public void insert(int value)
     {
         root = insertRecursive(value,root);
     }
     private Node insertRecursive(int value,Node currentNode) 
     {
         if (currentNode == null)
         {
             return new Node(value);
         }
         if (currentNode.value > value)
         {
             currentNode.left = insertRecursive(value,currentNode.left);
         }
         else if (currentNode.value < value)
         {
             currentNode.right = insertRecursive(value,currentNode.right);
         }
         return currentNode;
     }
     public void print()
     {
         printRecursive(root);
     }
     private void printRecursive(Node currentNode)
     {
         if(currentNode != null)
         {
             printRecursive(currentNode.left);
             Console.WriteLine(currentNode.value);
             printRecursive(currentNode.right);
         }
     }
     public bool search(int value)
     {
         return searchRecursive(value,root);
     }
     public int count;
     private bool searchRecursive(int value, Node currentNode)
     {
         count++;
         if (currentNode == null)
         {
             return false;
         }
         else if(currentNode.value == value) 
         { 
             return true;
         }
         else if (currentNode.value > value)
         {
             return searchRecursive(value, currentNode.left);
         }
         else
         {
             return searchRecursive(value, currentNode.right);
         }
     }
     private List<int> lst = new List<int>();
     public List<int> GetItem()
     {
         TreeToList(root);
         return lst;
     }
     private void TreeToList(Node currentNode)
     {
         if (currentNode != null)
         {
             printRecursive(currentNode.left);
             lst.Add(currentNode.value);
             printRecursive(currentNode.right);
         }
     }

 }

// Generic Tree
class Node<T>
    {
        public Node<T> left;
        public Node<T> right;
        public T value;
        public Node(T value)
        {
            this.value = value;
        }
    }
class Employee : IComparable<Employee>
    {
        public int Id { get; set; } 
        public string Name { get; set; }
        public int ManagerId { get; set; }
        public Employee(int id, string name)
        {
            this.Id = id;
            this.Name = name;
        }
        public Employee(int id, string name,int managerId)
        {
            this.Id = id;
            this.Name = name;
            this.ManagerId = managerId;
        }

        public int CompareTo(Employee? other)
        {
            if (other == null) 
            {
                throw new Exception();
            }
            if (ManagerId == other.Id)
            {
                return 0;
            }
            else if (Id > other.Id)
            {
                return -1;
            }
            else
            {
                return 1;
            }
        }
        public override string ToString()
        {
            return $"{Id} , {Name}";
        }
    }
class BinaryTree<T> where T : IComparable<T>
    {
        public Node<T> root;
        public BinaryTree()
        {
            root = null;
        }
        public void insert(T item)
        {
            //root = insertRecursive(item, root);
            root = insertRecursive2(item, root);
        }
        private Node<T> insertRecursive2(T item, Node<T> currentNode)
        {
            if (currentNode == null)
            {
                return new Node<T>(item);
            }
            if (item.CompareTo(currentNode.value) == 0)
            {
                    currentNode.left = insertRecursive(item, currentNode.left);
                    //currentNode.right = insertRecursive(item, currentNode.right);  
            }
            return currentNode;
        }
        private Node<T> insertRecursive(T item,Node<T> currentNode)
        {
            if (currentNode == null)
            {
                return new Node<T>(item);
            }
            if (item.CompareTo(currentNode.value) == 1)
            {
                currentNode.left = insertRecursive(item, currentNode.left);
            }
            else if (item.CompareTo(currentNode.value) == -1)
            {
                currentNode.right = insertRecursive(item, currentNode.right);
            }
            return currentNode;
        }
        public void print()
        {
            printRecursive(root);
        }
        private void printRecursive(Node<T> currentNode)
        {
            if (currentNode != null)
            {
                printRecursive(currentNode.left);
                Console.WriteLine(currentNode.value);
                printRecursive(currentNode.right);
            }
        }
        public bool search(T item)
        {
            return searchRecursive(item, root);
        }
        private bool searchRecursive(T item, Node<T> currentNode)
        {
            if (currentNode == null)
            {
                return false;
            }
            else if (currentNode.value.CompareTo(item) == 0)
            {
                return true;
            }
            else if (currentNode.value.CompareTo(item) == -1)
            {
                return searchRecursive(item, currentNode.left);
            }
            else
            {
                return searchRecursive(item, currentNode.right);
            }
        }
        public void PrintByLevel()
        {
            if (root == null)
            {
                Console.WriteLine("The tree is empty.");
                return;
            }

            Queue<Node<T>> queue = new Queue<Node<T>>();
            queue.Enqueue(root);

            while (queue.Count > 0)
            {
                Node<T> currentNode = queue.Dequeue();
                Console.Write(currentNode.value + " ");

                if (currentNode.left != null)
                {
                    queue.Enqueue(currentNode.left);
                }

                if (currentNode.right != null)
                {
                    queue.Enqueue(currentNode.right);
                }
            }
            Console.WriteLine();
        }
    }

//MergeSort
public static void mergeSort(int[] arr, int start, int end)
        {
            if (start >= end) return;
            int m = start + (end - start)/2;
            mergeSort(arr, start, m);
            mergeSort(arr, m+1, end);
            merge(arr, start,m,end);


        }
public static void merge(int[] arr,int start,int m, int end)
        {
            int j = 0, i = 0, k = start;

            int leftLenght = m - start + 1;
            int rightLenght = end - m;

            int[] leftArray = new int[leftLenght];
            int[] rightArray = new int[rightLenght];

            for (int u = 0; u < leftLenght; u++)
            {
                leftArray[u] = arr[start + u];
            }

            for (int t = 0; t < rightLenght; t++)
            {
                rightArray[t] = arr[m + t + 1];
            }

            while (i < leftLenght && j < rightLenght)
            {
                if (leftArray[i] < rightArray[j])
                {
                    arr[k] = leftArray[i];
                    i++;
                }
                else
                {
                    arr[k] = rightArray[j];
                    j++;
                }
                k++;
            }

            while (i < leftLenght)
            {
                arr[k] = leftArray[i];
                i++;
                k++;
            }
            while (j < rightLenght)
            {
                arr[k] = rightArray[j];
                j++;
                k++;
            }

        }

//Generic MergeSort
public class MergeSortAlgorithm<T> where T : IComparable<T>
{
    public void MergeSort(T[] arr, int start, int end)
    {
        if (start >= end) return;
        int m = start + (end - start) / 2;
        MergeSort(arr, start, m);
        MergeSort(arr, m + 1, end);
        Merge(arr, start, m, end);
    }
    public void Merge(T[] arr, int start, int m, int end)
    {
        int j = 0, i = 0, k = start;

        int leftLength = m - start + 1;
        int rightLength = end - m;

        T[] leftArray = new T[leftLength];
        T[] rightArray = new T[rightLength];

        for (int u = 0; u < leftLength; u++)
        {
            leftArray[u] = arr[start + u];
        }

        for (int t = 0; t < rightLength; t++)
        {
            rightArray[t] = arr[m + t + 1];
        }

        while (i < leftLength && j < rightLength)
        {
            if (leftArray[i].CompareTo(rightArray[j]) == 1)
            {
                arr[k] = leftArray[i];
                i++;
            }
            else
            {
                arr[k] = rightArray[j];
                j++;
            }
            k++;
        }

        while (i < leftLength)
        {
            arr[k] = leftArray[i];
            i++;
            k++;
        }

        while (j < rightLength)
        {
            arr[k] = rightArray[j];
            j++;
            k++;
        }
    }

    public void printArray(T[] arr)
    {
        int n = arr.Length;
        foreach (T item in arr)
        {
            Console.WriteLine(item.ToString());
        }
    }
}     

//MaxValue
public static int FindMax(int[] arr, int left, int right)
{
    if (left == right)
        return arr[left];
    int mid = (left + right) / 2;
    // Recursively find the maximum element in the left and right halves
    int maxLeft = FindMax(arr, left, mid);
    int maxRight = FindMax(arr, mid + 1, right);
    // Compare the maximum elements from both halves and return the larger one
    return Math.Max(maxLeft, maxRight);
}

//SumValue
public static int SumValues(int[] arr, int left, int right)
{
    if (left == right)
        return arr[left];

    int mid = (left + right) / 2;

    int maxLeft = SumValues(arr, left, mid);
    int maxRight = SumValues(arr, mid + 1, right);

    return maxLeft + maxRight;
}   

//NQueen
public class NQueens
{
    public static int N;
    public static int numberOfSolution = 0;
    public static bool SloveNQueens(int[,] board, int row)
    {
        if (row == N)
        {
            numberOfSolution++;
            PrintSolution(board);
            Console.WriteLine("*****************");
            return true;
        }
        bool result = false;
        for (int col = 0; col < N; col++)
        {
            if (IsSafe(board,row,col))
            {
                board[row, col] = 1;

                result = SloveNQueens(board,row + 1) || result;

                board[row, col] = 0;
            }
        }
        return result;
    }

    public static bool IsSafe(int[,] board, int row, int col)
    {
        for (int i = 0; i < row; i++)
        {
            if (board[i, col] == 1)
                return false;
        }
        for (int i = row, j = col; i >= 0 && j >= 0; i--, j--)
        {
            if (board[i, j] == 1)
                return false;
        }

        for (int i = row, j = col; i >= 0 && j < N; i--, j++)
        {
            if (board[i, j] == 1)
                return false;
        }
        return true;
    }

    public static void PrintSolution(int[,] board)
    {
        for(int i = 0;i < N; i++)
        {
            for (int j = 0; j < N; j++)
            {
                Console.Write(board[i,j]+" ");
            }
            Console.WriteLine();
        }
    }
}
internal class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Enter The Value Of N");
        NQueens.N = int.Parse(Console.ReadLine());
        int N = NQueens.N;
        int[,] board = new int[N, N];

        if(! NQueens.SloveNQueens(board,0))
        {
            Console.WriteLine("No Solution Exists");
        }
        else
        {
            Console.WriteLine("Number Of Solutions");
            Console.WriteLine(NQueens.numberOfSolution);
        }
    }
}

//nightToor
public class KnightTour
{
    public static int size = 8;
    public static int[][] board;
    public static int[] dx = { 2, 1, -1, -2, -2, -1, 1, 2 };
    public static int[] dy = { 1, 2, 2, 1, -1, -2, -2, -1 };
    //public static int[] dx = { 2, -2, -2, 2 };
    //public static int[] dy = { 2, 2, -2, -2};

    //public static int[] dx = { 3, 1, -1, -3, -3, -1, 1, 3 };
    //public static int[] dy = { 1, 3, 3, 1, -1, -3, -3, -1 };
    public static bool SolveKnightTour(int x, int y, int moveCount)
    {
        if (moveCount == size * size)
            return true;
        for (int i = 0; i < 8; i++)
        {
            int nextX = x + dx[i];
            int nextY = y + dy[i];
            if (IsValid(nextX,nextY))
            {
                board[nextX][nextY] = moveCount;
                if (SolveKnightTour(nextX,nextY,moveCount +1))
                    return true;
                board[nextX][nextY] = -1;
            }
        }
        return false;
    }
    public static bool IsValid(int x, int y)
    {
        return (x >= 0 && x < size && y >= 0 && y < size && board[x][y] == -1);
    }
    public static void printSolution()
    {
        for (int i = 0;i < size; i++)
        {
            for(int j = 0; j < size; j++)
            {
                Console.Write(board[i][j].ToString().PadLeft(3) + " ");
            }
            Console.WriteLine();
        }
    }
}
internal class Program
{
    static void Main(string[] args)
    {
        KnightTour.board = new int[KnightTour.size][];
        for (int i = 0; i < KnightTour.size; i++)
        {
            KnightTour.board[i] = new int[KnightTour.size];
            for (int j = 0; j < KnightTour.size; j++)
            {
                KnightTour.board[i][j] = -1; 
            }
        }
        int startX = 0, startY = 0;
        KnightTour.board[startX][startX] = 0;
        if (KnightTour.SolveKnightTour(startX,startY,1))
        {
            Console.WriteLine("Solution Exist");
            KnightTour.printSolution();
        }
        else
        {
            Console.WriteLine("No Solution Exist");
        }
    }
}

//FindSubsetSum
internal class Program
{
    static void Main(string[] args)
    {
        int[] numbers = { 2, 4, 7, 9, 10};
        int targetSum = 20;
        List<int> currentSubset = new List<int>();
        List<int> resultSubset = new List<int>();

        bool foundedSubset = FindSubsetSum(numbers, targetSum, targetSum, 0, currentSubset, ref resultSubset);
        if (foundedSubset)
        {
            Console.WriteLine("Subset that sums to "+targetSum+": "+"["+string.Join(",", resultSubset)+"]");
        }
        else
        {
            Console.WriteLine("No Subset found that sums to "+targetSum);
        }


    }
    private static bool FindSubsetSum(int[] numbers, int targetSum1,int targetSum,int currentIndex, List<int> currentSubset, ref List<int> resultSubset)
    {
        if (targetSum == 0)
        {
            resultSubset = new List<int>(currentSubset);
            return true;
        }
        if (currentIndex >= numbers.Length || targetSum < 0)
        {
            return false;
        }

        bool includeResult = false;
        if (numbers[currentIndex] + currentSubset.Sum() <= targetSum1)
        {
            currentSubset.Add(numbers[currentIndex]);
            includeResult = FindSubsetSum(numbers, targetSum1, targetSum - numbers[currentIndex], currentIndex + 1, currentSubset, ref resultSubset);
            currentSubset.RemoveAt(currentSubset.Count - 1);
        }

        bool excludeResult = FindSubsetSum(numbers, targetSum1, targetSum, currentIndex + 1, currentSubset, ref resultSubset);
        return includeResult || excludeResult;
    }
}

//FindLongestIncreingSequens
internal class Program
{
    static void Main(string[] args)
    {
        int[] arr = {1,1,5,6,2,2,2,1};
        List<int> currentSequence = new List<int>();
        List<int> longestSequence = new List<int>();

        Algorithm(arr, 0, currentSequence, ref longestSequence);
        Console.WriteLine("Longest Increasing Sequence: "+string.Join(",", longestSequence));
    }

    private static void Algorithm(int[] arr, int currentIndex, List<int> currentSequence, ref List<int> longestSequence)
    {
        if (currentIndex == arr.Length)
        {
            if (currentSequence.Count > longestSequence.Count)
            {
                longestSequence = new List<int>(currentSequence);
            }
            return;
        }

        //if (currentSequence.Count == 0 || arr[currentIndex] == currentSequence.Last())
        if (currentSequence.Count == 0 || arr[currentIndex] > currentSequence.Last())
        {
            currentSequence.Add(arr[currentIndex]);
            Algorithm(arr,currentIndex+1,currentSequence,ref longestSequence);
            currentSequence.RemoveAt(currentSequence.Count-1);
        }
        Algorithm(arr, currentIndex + 1, currentSequence, ref longestSequence);
    }
}

//FindBestFileCom
internal class Program
{
    static void Main(string[] args)
    {
        int[] fileSizes = { 1, 3, 7, 8, 4, 2,10,2 };
        int storageSize = 20;
        List<int> bestSolution = new List<int>();
        List<int> currentSolution = new List<int>();

        FindBestFileCombination(fileSizes, storageSize, 0, currentSolution, ref bestSolution);
        if (bestSolution.Sum() < storageSize )
        {
            Console.WriteLine("NO Solution");
        }
        else
        {
            Console.WriteLine("Best File Combination: " + string.Join(",", bestSolution));
        }

    }

    public static void FindBestFileCombination(int[] fileSizes, int storageSize, int currentIndex, List<int> currentSolution, ref List<int> bestSolution)
    {
        if (currentSolution.Sum() == storageSize)
        {
            DisplaySolution(currentSolution);
            UpdateBestSolution(currentSolution, bestSolution);
            return;
        }

        if (currentIndex == fileSizes.Length)
        {
            UpdateBestSolution(currentSolution, bestSolution);
            return;
        }

        if (currentSolution.Sum() + fileSizes[currentIndex] <= storageSize)
        {
            currentSolution.Add(fileSizes[currentIndex]);
            FindBestFileCombination(fileSizes, storageSize, currentIndex + 1, currentSolution, ref bestSolution);
            currentSolution.RemoveAt(currentSolution.Count - 1);
        }

        FindBestFileCombination(fileSizes, storageSize, currentIndex + 1, currentSolution, ref bestSolution);
    }

    public static void DisplaySolution(List<int> solution)
    {
        Console.WriteLine("File Combination: " + string.Join(",", solution));
        //Console.WriteLine("Sum: " + solution.Sum());
        Console.WriteLine("---------------------------------");
    }

    public static void UpdateBestSolution(List<int> currentSolution, List<int> bestSolution)
    {
        if (currentSolution.Sum() > bestSolution.Sum())
        {
            bestSolution.Clear();
            bestSolution.AddRange(currentSolution);
        }
    }
}