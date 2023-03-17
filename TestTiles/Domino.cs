//using System;
//using System.Collections.Generic;
//using System.Linq;

//class DominoTile
//{
//    public int SideA { get; }
//    public int SideB { get; }

//    public DominoTile(int sideA, int sideB)
//    {
//        SideA = sideA;
//        SideB = sideB;
//    }

//    public override string ToString() => $"[{SideA}|{SideB}]";
//}

//class DominoChain
//{
//    private readonly List<DominoTile> _tiles;

//    public DominoChain(IEnumerable<DominoTile> tiles)
//    {
//        _tiles = tiles.ToList();
//    }

//    public DominoChain(IEnumerable<int> sides)
//    {
//        if (sides.Count() % 2 != 0)
//            throw new ArgumentException("El número de lados no es par.");

//        _tiles = new List<DominoTile>();

//        for (int i = 0; i < sides.Count(); i += 2)
//        {
//            _tiles.Add(new DominoTile(sides.ElementAt(i), sides.ElementAt(i + 1)));
//        }
//    }

//    public bool IsValid()
//    {
//        if (_tiles.Count == 0)
//            return true;

//        if (_tiles.First().SideA != _tiles.Last().SideB)
//            return false;

//        for (int i = 1; i < _tiles.Count; i++)
//        {
//            if (_tiles[i - 1].SideB != _tiles[i].SideA)
//                return false;
//        }

//        return true;
//    }

//    public void Sort()
//    {
//        if (IsValid())
//            return;

//        List<List<DominoTile>> permutations = GetPermutations(_tiles);

//        foreach (List<DominoTile> permutation in permutations)
//        {
//            DominoChain chain = new DominoChain(permutation);

//            if (chain.IsValid())
//            {
//                _tiles.Clear();
//                _tiles.AddRange(permutation);
//                return;
//            }
//        }
//    }

//    private List<List<DominoTile>> GetPermutations(List<DominoTile> tiles)
//    {
//        if (tiles.Count == 1)
//            return new List<List<DominoTile>> { tiles };

//        List<List<DominoTile>> permutations = new List<List<DominoTile>>();

//        for (int i = 0; i < tiles.Count; i++)
//        {
//            DominoTile tile = tiles[i];

//            List<DominoTile> remainingTiles = new List<DominoTile>(tiles);
//            remainingTiles.RemoveAt(i);

//            List<List<DominoTile>> subPermutations = GetPermutations(remainingTiles);

//            foreach (List<DominoTile> subPermutation in subPermutations)
//            {
//                subPermutation.Insert(0, tile);
//                permutations.Add(subPermutation);
//            }
//        }

//        return permutations;
//    }

//    public override string ToString() => string.Join(" ", _tiles);
//}

////class Program
////{
////    static void Main(string[] args)
////    {
////        List<DominoTile> tiles1 = new List<DominoTile>
////        {
////            new DominoTile(2, 1),
////            new DominoTile(2, 3),
////            new DominoTile(1, 3)
////        };

////        DominoChain chain1 = new DominoChain(tiles1);
////        chain1.Sort();
////        Console.WriteLine(chain1);

////        List<int> sides2 = new List<int> { 1, 2, 4, 1, 2, 3 };

////        DominoChain chain2 = new DominoChain(sides2);
////        chain2.Sort();
////        Console.WriteLine(chain2);
////    }
////}
