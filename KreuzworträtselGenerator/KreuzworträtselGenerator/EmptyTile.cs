namespace KreuzworträtselGenerator
{
    class EmptyTile : Tile
    {
        //
        //  <--- static --->
        //
        static readonly List<EmptyTile> EmptyTileList = new();

        public static void RemoveAllHighlights()
        {
            for (int i = 0; i < EmptyTileList.Count; i++)
            {
                EmptyTile emptyTile = EmptyTileList[i];
                // Reset the Subtiles so highlights disappear
                emptyTile.SubTiles[0].RemoveHighlight();
                emptyTile.SubTiles[1].RemoveHighlight();
            }
        }

        //
        //  <--- instance --->
        //
        public bool Reserved { get; set; }
        public SubTile[] SubTiles { get; set; }

        public EmptyTile(Point position, Rectangle bounds_global) : base(position, bounds_global)
        {
            Reserved = false;
            SubTiles = new SubTile[] {
                new SubTile(direction: 0, parentTile: this, Bounds_global),
                new SubTile(direction: 1, parentTile: this, Bounds_global)
            };
            EmptyTileList.Add(this); 
        }
        public LetterTile ToLetterTile(Tile[,] grid, QuestionOrBaseWordTile questionOrBaseWordTile, string text)
        {
            EmptyTileList.Remove(this);
            grid[GetPosition().Y, GetPosition().X] = new LetterTile(GetPosition(), questionOrBaseWordTile, text, Bounds_global);
            return grid[GetPosition().Y, GetPosition().X] as LetterTile;
        }
        public QuestionTile ToQuestionTile(Tile[,] grid, string question, int direction)
        {
            EmptyTileList.Remove(this);
            grid[GetPosition().Y, GetPosition().X] = new QuestionTile(GetPosition(), question, direction, Bounds_global);
            return grid[GetPosition().Y, GetPosition().X] as QuestionTile;
        }

        public BaseWordTile ToBaseWordTile(Tile[,] grid, int direction)
        {
            EmptyTileList.Remove(this);
            grid[GetPosition().Y, GetPosition().X] = new BaseWordTile(GetPosition(), direction, Bounds_global);
            return grid[GetPosition().Y, GetPosition().X] as BaseWordTile;
        }
        protected override void PaintOperations(Graphics g)
        {
            if (GetPosition().X == 0 && GetPosition().Y == 0) 
            { }
            if (GetPosition().X == 0 && GetPosition().Y == 1) 
            { }

            DrawExtendedHover(g);
        }
        private int DetermineSubTile(Point mouse_position)
        {
            return (mouse_position.X - Bounds_global.X < mouse_position.Y - Bounds_global.Y) ? 1 : 0;
        }
        public override void MouseEnter(MouseEventArgs e, Point[] directions, Tile[,] grid)
        {
            // Hand down
            SubTiles[DetermineSubTile(e.Location)].MouseEnter(directions, TupleToBeFilled, grid);
        }
        public override void MouseLeave(PictureBox pb)
        {
            
        }
        public override void IntraTileMouseMove(MouseEventArgs e, PictureBox pb, Point[] directions, Tile[,] grid)
        {
            // Which subtile is mouse hovering over?
            SubTile hover_subTile = SubTiles[DetermineSubTile(e.Location)];
            // Is the Mouse_Hover_flag of this subTile false?
            if (!hover_subTile.Mouse_Hover_flag)
            {
                // Then the mouse has moved from the other subTile to this one
                hover_subTile.MouseEnter(directions, TupleToBeFilled, grid);
                // Get the other subTile
                if (hover_subTile.Direction == 0)
                    SubTiles[1].MouseLeave();
                else
                    SubTiles[0].MouseLeave();
            }
        }
        /// <returns>Returns whether FillAnswer() method should be called</returns>
        public bool MouseClick(MouseEventArgs e, out int direction)
        { 
            SubTile clickedSubTile = SubTiles[DetermineSubTile(e.Location)];
            direction = clickedSubTile.Direction;
            return clickedSubTile.MouseClick();
        }
    }
}
