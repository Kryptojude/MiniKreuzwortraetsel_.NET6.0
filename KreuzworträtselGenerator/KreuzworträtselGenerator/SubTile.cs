namespace KreuzworträtselGenerator
{
    // Is this class even necessary?
    class SubTile : PaintObject
    {
        //
        //  <--- static --->
        //
        static List<Tile> Tiles_with_extended_hover_list = new();
        static void RemoveAllExtendedHover()
        {
            for (int i = 0; i < Tiles_with_extended_hover_list.Count; i++)
                Tiles_with_extended_hover_list[i].SetExtendedHover(Tile.ExtendedHover.Off);
            Tiles_with_extended_hover_list.Clear();
        }

        static public Font Hover_arrow_font { get; } = new Font(FontFamily.GenericSerif, 12, FontStyle.Bold);
        static Point[][] SubTilePolygons { get; } = new Point[][] {
            new Point[3] { new Point(0, 0), new Point(Form1.TS, 0),  new Point(Form1.TS, Form1.TS) },
            new Point[3] { new Point(0, 0), new Point(Form1.TS, Form1.TS), new Point(0, Form1.TS) }
        };

        static Point[] ArrowPositions { get; } = new Point[] { new Point(Form1.TS / 3, 0), new Point(-3, 2 * (Form1.TS / 5)) };
        static public Color MinColor { get; } = Color.FromArgb(0x9be8a1);
        static public Color MaxColor { get; } = Color.FromArgb(0x00ff14);
        
        //
        //  <--- instance --->
        //
        public bool Hover_effect_flag { get; set; }
        public bool Mouse_Hover_flag { get; set; }
        public Brush Highlight_color { get; private set; }
        public bool Highlight_flag { get; private set; }
        public int Direction { get; }
        public EmptyTile ParentTile { get; }

        public SubTile(int direction, EmptyTile parentTile, Rectangle bounds_global) : base(bounds_global)
        {
            Hover_effect_flag = false;
            Mouse_Hover_flag = false;
            Highlight_flag = false;
            Direction = direction;
            ParentTile = parentTile;
        }
        public void RemoveHighlight()
        {
            Highlight_color = null;
            Highlight_flag = false;
            ParentTile.RepaintFlag = true;
        }
        public void SetHighlight(float colorLevel)
        {
            Highlight_color = new SolidBrush(Color.FromArgb((int)(MinColor.R + (MaxColor.R - MinColor.R) * colorLevel), (int)(MinColor.G + (MaxColor.G - MinColor.G) * colorLevel), (int)(MinColor.B + (MaxColor.B - MinColor.B) * colorLevel)));
            Highlight_flag = true;
            ParentTile.RepaintFlag = true;
        }
        protected override void PaintOperations (Graphics g)
        {
            if (ParentTile.GetPosition().X == 0 && ParentTile.GetPosition().Y == 0)
            { }
            if (ParentTile.GetPosition().X == 0 && ParentTile.GetPosition().Y == 1 && Direction == 1)
            { }

            // Draw Rectangle
            if (Highlight_flag)
                g.DrawRectangle(Pens.Black, 0, 0, Bounds_local.Width - 1, Bounds_local.Height - 1);

            // Hover effect flag set to true?
            if (Hover_effect_flag)
            {
                // Draw hover effect
                g.FillPolygon(Brushes.Blue, SubTilePolygons[Direction]);
                g.DrawString(Tile.GetArrow(Direction), Hover_arrow_font, Brushes.Red, ArrowPositions[Direction]);
            }
            // If no hover effect, check highlight flag
            else if (Highlight_flag)
                g.FillPolygon(Highlight_color, SubTilePolygons[Direction]);
        }
        public void MouseEnter(Point[] directions, (string Question, string Answer) tuple, Tile[,] grid)
        {
            RepaintFlag = true;
            Mouse_Hover_flag = true;
            if (Highlight_flag)
            {
                Hover_effect_flag = true;
                // Activate extendedHover outline for adjacent tiles
                Point directionPoint = directions[Direction];
                for (int i = 0; i < tuple.Answer.Length; i++)
                {
                    int letterX = ParentTile.GetPosition().X + directionPoint.X * (1 + i);
                    int letterY = ParentTile.GetPosition().Y + directionPoint.Y * (1 + i);
                    // Out of bounds check
                    if (letterX <= grid.GetUpperBound(1) && letterY <= grid.GetUpperBound(0))
                    {
                        Tile tile = grid[letterY, letterX];
                        // End or middle outline
                        if (i < tuple.Answer.Length - 1)
                            tile.SetExtendedHover(Tile.ExtendedHover.Two_Outlines_Horizontal);
                        else
                            tile.SetExtendedHover(Tile.ExtendedHover.Three_Outlines_Horizontal);

                        // Vertical mode
                        if (directionPoint.Y == 1)
                            tile.SetExtendedHover(tile.GetExtendedHover() + 2);

                        // Add this tile to list
                        Tiles_with_extended_hover_list.Add(tile);
                    }
                }
            }
        }
        public void MouseLeave()
        {
            RepaintFlag = true;
            Mouse_Hover_flag = false;
            Hover_effect_flag = false;

            // Remove extendedHover outline for adjacent tiles
            RemoveAllExtendedHover();

        }
        public bool MouseClick()
        {
            bool call_fill_answer = false;

            if (Highlight_flag)
            {
                RemoveAllExtendedHover();
                EmptyTile.RemoveAllHighlights();
                Hover_effect_flag = false;
                RepaintFlag = true;

                call_fill_answer = true;
            }

            return call_fill_answer;
        }
    }
}
