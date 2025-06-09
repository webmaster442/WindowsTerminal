
using SkiaSharp;

namespace Webmaster442.WindowsTerminal.SkiaSharp;

//https://raw.githubusercontent.com/bacowan/cSharpColourQuantization/refs/heads/master/ColourQuantization/Octree.cs
internal static class Octree
{
    public static SKBitmap Quantize(SKBitmap bitmap, int colourCount)
    {
        var quantizer = new PaletteQuantizer();
        for (int x = 0; x < bitmap.Width; x++)
        {
            for (int y = 0; y < bitmap.Height; y++)
            {
                var colour = bitmap.GetPixel(x, y);
                quantizer.AddColour(colour);
            }
        }
        quantizer.Quantize(colourCount);
        var ret = new SKBitmap(bitmap.Width, bitmap.Height);
        for (int x = 0; x < bitmap.Width; x++)
        {
            for (int y = 0; y < bitmap.Height; y++)
            {
                var colour = quantizer.GetQuantizedColour(bitmap.GetPixel(x, y));
                ret.SetPixel(x, y, colour);
            }
        }
        return ret;
    }

    private class PaletteQuantizer
    {
        private readonly Node _root;
        private readonly Dictionary<int, List<Node>> _levelNodes;

        public PaletteQuantizer()
        {
            _root = new Node(this);
            _levelNodes = new Dictionary<int, List<Node>>();
            for (int i = 0; i < 8; i++)
            {
                _levelNodes[i] = new List<Node>();
            }
        }

        public void AddColour(SKColor colour)
        {
            _root.AddColour(colour, 0);
        }

        public void AddLevelNode(Node node, int level)
        {
            _levelNodes[level].Add(node);
        }

        public SKColor GetQuantizedColour(SKColor colour)
        {
            return _root.GetColour(colour, 0);
        }

        public void Quantize(int colourCount)
        {
            var nodesToRemove = _levelNodes[7].Count - colourCount;
            int level = 6;
            var toBreak = false;
            while (level >= 0 && nodesToRemove > 0)
            {
                var leaves = _levelNodes[level]
                    .Where(n => n.ChildrenCount - 1 <= nodesToRemove)
                    .OrderBy(n => n.ChildrenCount);
                foreach (var leaf in leaves)
                {
                    if (leaf.ChildrenCount > nodesToRemove)
                    {
                        toBreak = true;
                        continue;
                    }
                    nodesToRemove -= (leaf.ChildrenCount - 1);
                    leaf.Merge();
                    if (nodesToRemove <= 0)
                    {
                        break;
                    }
                }
                _levelNodes.Remove(level + 1);
                level--;
                if (toBreak)
                {
                    break;
                }
            }
        }
    }

    private class Node
    {
        private readonly PaletteQuantizer _parent;
        private Node[] _children = new Node[8];
        private SKColor Colour { get; set; }
        private int Count { get; set; }

        public int ChildrenCount => _children.Count(c => c != null);

        public Node(PaletteQuantizer parent)
        {
            this._parent = parent;
        }

        public void AddColour(SKColor colour, int level)
        {
            if (level < 8)
            {
                var index = GetIndex(colour, level);
                if (_children[index] == null)
                {
                    var newNode = new Node(_parent);
                    _children[index] = newNode;
                    _parent.AddLevelNode(newNode, level);
                }
                _children[index].AddColour(colour, level + 1);
            }
            else
            {
                Colour = colour;
                Count++;
            }
        }

        public SKColor GetColour(SKColor colour, int level)
        {
            if (ChildrenCount == 0)
            {
                return Colour;
            }
            else
            {
                var index = GetIndex(colour, level);
                return _children[index].GetColour(colour, level + 1);
            }
        }

        private byte GetIndex(SKColor colour, int level)
        {
            byte ret = 0;
            var mask = Convert.ToByte(0b10000000 >> level);
            if ((colour.Red & mask) != 0)
            {
                ret |= 0b100;
            }
            if ((colour.Green & mask) != 0)
            {
                ret |= 0b010;
            }
            if ((colour.Blue & mask) != 0)
            {
                ret |= 0b001;
            }
            return ret;
        }

        public void Merge()
        {
            Colour = Average(_children.Where(c => c != null).Select(c => new Tuple<SKColor, int>(c.Colour, c.Count)));
            Count = _children.Sum(c => c?.Count ?? 0);
            _children = new Node[8];
        }

        private static SKColor Average(IEnumerable<Tuple<SKColor, int>> colours)
        {
            var totals = colours.Sum(c => c.Item2);
            return new SKColor(red: (byte)(colours.Sum(c => c.Item1.Red * c.Item2) / totals),
                               green: (byte)(colours.Sum(c => c.Item1.Green * c.Item2) / totals),
                               blue: (byte)(colours.Sum(c => c.Item1.Blue * c.Item2) / totals),
                               alpha: 255);
        }
    }
}
