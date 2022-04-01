﻿namespace KreuzworträtselGenerator
{
    // Is this class even necessary?
    class SubTile : PaintObject
    {
        static public readonly Font HOVER_ARROW_FONT = new Font(FontFamily.GenericSerif, 12, FontStyle.Bold);
        static readonly Point[][] subTilePolygons = new Point[][] {
            new Point[3] { new Point(0, 0), new Point(Form1.TS, 0),  new Point(Form1.TS, Form1.TS) },
            new Point[3] { new Point(0, 0), new Point(Form1.TS, Form1.TS), new Point(0, Form1.TS) }
        };

        static readonly Point[] arrowPositions = new Point[] { new Point(Form1.TS / 3, 0), new Point(-3, 2 * (Form1.TS / 5)) };

        static public readonly Color MinColor = Color.FromArgb(0x9be8a1);
        static public readonly Color MaxColor = Color.FromArgb(0x00ff14);

        bool hover_flag;
        Brush highlight_color;
        bool highlight_flag;
        public int Direction { get; }
        public EmptyTile ParentTile { get; }

        public SubTile(int direction, EmptyTile parentTile, Rectangle bounds_global) : base(bounds_global)
        {
            Direction = direction;
            ParentTile = parentTile;
        }
        public void RemoveHighlight()
        {
            highlight_color = null;
            highlight_flag = false;
            ParentTile.RepaintFlag = true;
        }
        public void SetHighlight(float colorLevel)
        {
            highlight_color = new SolidBrush(Color.FromArgb((int)(MinColor.R + (MaxColor.R - MinColor.R) * colorLevel), (int)(MinColor.G + (MaxColor.G - MinColor.G) * colorLevel), (int)(MinColor.B + (MaxColor.B - MinColor.B) * colorLevel)));
            highlight_flag = true;
        }
        public bool IsHighlighted()
        {
            return highlight_flag;
        }
        public void SetHoverFlag(bool flag)
        {
            hover_flag = flag;
        }
        public bool GetHoverFlag()
        {
            return hover_flag;
        }
        public Brush GetColor()
        {
            return highlight_color;
        }

        protected override void PaintOperations (Graphics g)
        {
            // Hover flag set to true?
            if (hover_flag)
            {
                // Draw hover effect
                g.FillPolygon(Brushes.Blue, subTilePolygons[Direction]);
                g.DrawString(Tile.GetArrow(Direction), HOVER_ARROW_FONT, Brushes.Red, arrowPositions[Direction]);
            }
            // If no hover effect, check highlight flag
            else if (highlight_flag)
                g.FillPolygon(GetColor(), subTilePolygons[Direction]);
        }
    }
}
