namespace KreuzworträtselGenerator
{
    class EmptyTile : Tile
    {
        //
        //  <--- static --->
        //
        static public readonly List<EmptyTile> EmptyTileList = new List<EmptyTile>();

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
        public override void Destructor()
        {
            base.Destructor();
            SubTiles[0].Destructor();
            SubTiles[1].Destructor();
        }
        public LetterTile ToLetterTile(Tile[,] grid, QuestionOrBaseWordTile questionOrBaseWordTile, string text)
        {
            EmptyTileList.Remove(this);
            grid[GetPosition().Y, GetPosition().X] = new LetterTile(GetPosition(), questionOrBaseWordTile, text, Bounds_global);
            Destructor();
            return grid[GetPosition().Y, GetPosition().X] as LetterTile;
        }
        public QuestionTile ToQuestionTile(Tile[,] grid, string question, int direction)
        {
            EmptyTileList.Remove(this);
            grid[GetPosition().Y, GetPosition().X] = new QuestionTile(GetPosition(), question, direction, Bounds_global);
            Destructor();
            return grid[GetPosition().Y, GetPosition().X] as QuestionTile;
        }

        public BaseWordTile ToBaseWordTile(Tile[,] grid, int direction)
        {
            EmptyTileList.Remove(this);
            grid[GetPosition().Y, GetPosition().X] = new BaseWordTile(GetPosition(), direction, Bounds_global);
            Destructor();
            return grid[GetPosition().Y, GetPosition().X] as BaseWordTile;
        }
        protected override void PaintOperations(Graphics g)
        {
            // Mark subtiles to be repainted
            SubTiles[0].RepaintFlag = true;
            SubTiles[1].RepaintFlag = true;

            // Draw Rectangle
            // Condition: At least one subtile is highlighted
            if (SubTiles[0].IsHighlighted() || SubTiles[1].IsHighlighted())
                g.DrawRectangle(Pens.Black, 0, 0, Bounds_local.Width - 1, Bounds_local.Height - 1);

            DrawExtendedHover(g);
        }

        private void RemoveHoverFlagFromBothSubtiles()
        {
            SubTiles[0].HoverFlag = false;
            SubTiles[1].HoverFlag = false;
        }
        private void Reset()
        {
            RemoveHoverFlagFromBothSubtiles();
            RepaintFlag = true;
            RemoveAllExtendedHover();
        }
        public override void MouseEnter(MouseEventArgs e, PictureBox pb)
        {
            // Entering an EmptyTile and moving within one don't differ in behaviour
            IntraTileMouseMove();
        }
        public override void MouseLeave(MouseEventArgs e, PictureBox pb)
        { 
            Reset();
        }
        public override void IntraTileMouseMove(MouseEventArgs e, PictureBox pb, Point[] directions, Tile[,] grid)
        {
            //Reset();
            // Which subtile is mouse hovering over?
            int mouseSubtile = (e.X - Bounds_global.X < e.Y - Bounds_global.Y) ? 1 : 0;
            SubTile hover_subTile = SubTiles[mouseSubtile];
            // Did mouse move from one subTile to the other?
            if (!hover_subTile.Hover_flag)
            {
                // If the current hovering subTile has its hover flag set to false, then the mouse has moved to the subtile from the other subtile,
                // so only in this case is there any change

                // Doesnt work because Hover_flag refers to the hover effect (blue background) and not just mouse hovering over a subtile

                // Check if that subtile has a highlight
                if (hover_subTile.IsHighlighted())
                {
                    // If so, then set hover_flag to true
                    hover_subTile.HoverFlag = true;

                    // And Activate extendedHover outline for adjacent tiles
                    Point directionPoint = directions[hover_subTile.Direction];
                    for (int i = 0; i < TupleToBeFilled.Answer.Length; i++)
                    {
                        int letterX = GetPosition().X + directionPoint.X * (1 + i);
                        int letterY = GetPosition().Y + directionPoint.Y * (1 + i);
                        // Out of bounds check
                        if (letterX <= grid.GetUpperBound(1) && letterY <= grid.GetUpperBound(0))
                        {
                            Tile tile = grid[letterY, letterX];
                            // End or middle outline
                            if (i < TupleToBeFilled.Answer.Length - 1)
                                tile.SetExtendedHover(ExtendedHover.Two_Outlines_Horizontal);
                            else
                                tile.SetExtendedHover(ExtendedHover.Three_Outlines_Horizontal);

                            // Vertical mode
                            if (directionPoint.Y == 1)
                                tile.SetExtendedHover(tile.GetExtendedHover() + 2);

                            // Save tile with extended hover in list
                            tiles_with_extended_hover_list.Add(tile);
                        }
                    }

                }
            }
        }
        /// <returns>Returns whether FillAnswer() method should be called</returns>
        public bool MouseClick(MouseEventArgs e, out int direction) 
        {
            bool callFillAnswer = false;
            // Which subTile was clicked?
            int subTileIdx = (e.X - Bounds_global.Location.X > e.Y - Bounds_global.Location.Y) ? 0:1;
            direction = subTileIdx;
            SubTile clickedSubTile = SubTiles[subTileIdx];
            // Is clicked subTile highlighted?
            if (clickedSubTile.IsHighlighted())
            {
                Reset();
                callFillAnswer = true;
            }

            return callFillAnswer;
        }
    }
}
