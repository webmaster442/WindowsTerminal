using System.Drawing;
using System.Runtime.Versioning;

namespace Webmaster442.WindowsTerminal.Sixel.Drawing;

//https://raw.githubusercontent.com/bacowan/cSharpColourQuantization/refs/heads/master/ColourQuantization/Octree.cs
[SupportedOSPlatform("windows")]
internal static class Octree
{
    public static Bitmap Quantize(Bitmap bitmap, int colourCount)
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
        var ret = new Bitmap(bitmap.Width, bitmap.Height);
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

        public void AddColour(System.Drawing.Color colour)
        {
            _root.AddColour(colour, 0);
        }

        public void AddLevelNode(Node node, int level)
        {
            _levelNodes[level].Add(node);
        }

        public System.Drawing.Color GetQuantizedColour(System.Drawing.Color colour)
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
        private System.Drawing.Color Colour { get; set; }
        private int Count { get; set; }

        public int ChildrenCount => _children.Count(c => c != null);

        public Node(PaletteQuantizer parent)
        {
            this._parent = parent;
        }

        public void AddColour(System.Drawing.Color colour, int level)
        {
            if (level < 8)
            {
                var index = Node.GetIndex(colour, level);
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

        public System.Drawing.Color GetColour(System.Drawing.Color colour, int level)
        {
            if (ChildrenCount == 0)
            {
                return Colour;
            }
            else
            {
                var index = Node.GetIndex(colour, level);
                return _children[index].GetColour(colour, level + 1);
            }
        }

        private static byte GetIndex(System.Drawing.Color colour, int level)
        {
            byte ret = 0;
            var mask = Convert.ToByte(0b10000000 >> level);
            if ((colour.R & mask) != 0)
            {
                ret |= 0b100;
            }
            if ((colour.G & mask) != 0)
            {
                ret |= 0b010;
            }
            if ((colour.B & mask) != 0)
            {
                ret |= 0b001;
            }
            return ret;
        }

        public void Merge()
        {
            Colour = Average(_children.Where(c => c != null).Select(c => new Tuple<System.Drawing.Color, int>(c.Colour, c.Count)));
            Count = _children.Sum(c => c?.Count ?? 0);
            _children = new Node[8];
        }

        private static System.Drawing.Color Average(IEnumerable<Tuple<System.Drawing.Color, int>> colours)
        {
            var totals = colours.Sum(c => c.Item2);
            return System.Drawing.Color.FromArgb(
                alpha: 255,
                red: colours.Sum(c => c.Item1.R * c.Item2) / totals,
                green: colours.Sum(c => c.Item1.G * c.Item2) / totals,
                blue: colours.Sum(c => c.Item1.B * c.Item2) / totals);
        }
    }
}