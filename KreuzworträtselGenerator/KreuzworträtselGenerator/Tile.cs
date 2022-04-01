namespace KreuzworträtselGenerator
{
    abstract class Tile : PaintObject
    {
        //
        //  <--- static --->
        //
        // Shorten tuple lines with var?
        static public (string Question, string Answer) TupleToBeFilled;
        static protected List<Tile> tiles_with_extended_hover_list = new List<Tile>();
        public enum ExtendedHover
        {
            Off = -1,
            Two_Outlines_Horizontal = 0,
            Three_Outlines_Horizontal = 1,
            Two_Outlines_Vertical = 2,
            Three_Outlines_Vertical = 3,
        }
        static protected void RemoveAllExtendedHover()
        {
            for (int i = 0; i < tiles_with_extended_hover_list.Count; i++)
                tiles_with_extended_hover_list[i].SetExtendedHover(ExtendedHover.Off);
            tiles_with_extended_hover_list.Clear();
        }

        static readonly Dictionary<string, string> Arrows = new Dictionary<string, string>() {
                                                                    { "horizontal", "►" },
                                                                    { "vertical", "▼" } };
        static public string GetArrow(string direction)
        {
            return Arrows[direction];
        }
        static public string GetArrow(int direction)
        {
            return Arrows.ElementAt(direction).Value;
        }

        //
        //  <--- instance --->
        //
        Point Position;
        // All fields private with accessor methods?
        protected Font font = new Font("Verdana", 9.75f, FontStyle.Bold);
        protected Brush foregroundColor = Brushes.Blue;
        /// <summary>
        /// Determines if this tile should have red outline based on question tile hover pointing to it, 
        /// -1 = off, 0 = 2 outlines horizontal, 1 = 3 outlines horizontal, 2 = 2 outlines vertical, 3 = 3 outlines vertical
        /// </summary>
        ExtendedHover extendedHover = ExtendedHover.Off;
        protected Pen extendedHoverPen = new Pen(Brushes.Red, 6);

        public Tile(Point position, Rectangle bounds_global) : base(bounds_global)
        {
            Position = position;
        }
        public ExtendedHover GetExtendedHover()
        {
            return extendedHover;
        }
        public void SetExtendedHover(ExtendedHover _extendedHover)
        {
            extendedHover = _extendedHover;
            RepaintFlag = true;
        }
        /// <summary>
        /// Refers to the position in grid[,] array
        /// </summary>
        public Point GetPosition()
        {
            return Position;
        }
        /// <summary>
        /// This will be called when the mouse has moved, 
        /// the called method belongs to the tile instance that the mouse is on after the movement
        /// </summary>
        public abstract void IntraTileMouseMove(MouseEventArgs e, PictureBox pb, Point[] directions, Tile[,] grid);
        /// <summary>
        /// This will be called when the mouse has moved from one tile to another,
        /// the called method belongs to the tile instance that the mouse was on before the movement
        /// </summary>
        public abstract void MouseEnter(MouseEventArgs e, PictureBox pb);
        public abstract void MouseLeave(MouseEventArgs e, PictureBox pb);
        /// <summary>
        /// Moves the origin of the grid
        /// </summary>
        static public void TranslateTransformGraphics(Graphics g, Point location)
        {
            g.TranslateTransform(location.X, location.Y);
        }
        protected void DrawExtendedHover(Graphics g)
        {
            int stroke_length = Form1.TS;
            // Draw extendedHover
            switch (GetExtendedHover())
            {
                case ExtendedHover.Two_Outlines_Horizontal:
                    g.DrawLine(extendedHoverPen, 0, 0, stroke_length, 0);
                    g.DrawLine(extendedHoverPen, 0, stroke_length, stroke_length, stroke_length);
                    break;
                case ExtendedHover.Three_Outlines_Horizontal:
                    g.DrawLine(extendedHoverPen, 0, 0, stroke_length, 0);
                    g.DrawLine(extendedHoverPen, stroke_length, 0, stroke_length, stroke_length);
                    g.DrawLine(extendedHoverPen, 0, stroke_length, stroke_length, stroke_length);
                    break;
                case ExtendedHover.Two_Outlines_Vertical:
                    g.DrawLine(extendedHoverPen, 0, 0, 0, stroke_length);
                    g.DrawLine(extendedHoverPen, stroke_length, 0, stroke_length, stroke_length);
                    break;
                case ExtendedHover.Three_Outlines_Vertical:
                    g.DrawLine(extendedHoverPen, 0, 0, 0, stroke_length);
                    g.DrawLine(extendedHoverPen, stroke_length, 0, stroke_length, stroke_length);
                    g.DrawLine(extendedHoverPen, 0, stroke_length, stroke_length, stroke_length);
                    break;
            }
        }
    }
}
