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
                emptyTile.subTiles[0].RemoveHighlight();
                emptyTile.subTiles[1].RemoveHighlight();
            }
        }

        //
        //  <--- instance --->
        //
        bool reserved;
        public SubTile[] subTiles { get; set; }

        public EmptyTile(Point position, Rectangle bounds_global) : base(position, bounds_global)
        {
            reserved = false;
            subTiles = new SubTile[] {
                new SubTile(direction: 0, parentTile: this, Bounds_global),
                new SubTile(direction: 1, parentTile: this, Bounds_global)
            };
            EmptyTileList.Add(this); 
        }
        public override void Destructor()
        {
            base.Destructor();
            subTiles[0].Destructor();
            subTiles[1].Destructor();
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
            subTiles[0].RepaintFlag = true;
            subTiles[1].RepaintFlag = true;

            // Draw Rectangle
            // Condition: At least one subtile is highlighted
            if (subTiles[0].IsHighlighted() || subTiles[1].IsHighlighted())
                g.DrawRectangle(Pens.Black, 0, 0, Bounds_local.Width - 1, Bounds_local.Height - 1);

            DrawExtendedHover(g);
        }

        public void Reserve()
        {
            reserved = true;
        }

        public void Unreserve()
        {
            reserved = false;
        }

        public bool IsReservedForQuestionTile()
        {
            return reserved;
        }
        private void RemoveHoverFlagFromBothSubtiles()
        {
            subTiles[0].SetHoverFlag(false);
            subTiles[1].SetHoverFlag(false);
        }
        public override void MouseMove(MouseEventArgs e, PictureBox pb, Point[] directions, Tile[,] grid)
        {
            RemoveHoverFlagFromBothSubtiles();
            RemoveAllExtendedHover();
            // Which subtile is mouse over?
            int mouseSubtile = (e.X - Bounds_global.X < e.Y - Bounds_global.Y) ? 1 : 0;
            SubTile hoverSubTile = subTiles[mouseSubtile];
            // Check if that subtile has a highlight
            if (hoverSubTile.IsHighlighted())
            {
                // If so, then set hover_flag to true
                hoverSubTile.SetHoverFlag(true);

                // And Activate extendedHover outline for adjacent tiles
                Point directionPoint = directions[hoverSubTile.Direction];
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

            RepaintFlag = true;
        }
        /// <returns>Returns whether FillAnswer() method should be called</returns>
        public bool MouseClick(MouseEventArgs e, out int direction) 
        {
            bool callFillAnswer = false;
            // Which subTile was clicked?
            int subTileIdx = (e.X - Bounds_global.Location.X > e.Y - Bounds_global.Location.Y) ? 0:1;
            direction = subTileIdx;
            SubTile clickedSubTile = subTiles[subTileIdx];
            // Is clicked subTile highlighted?
            if (clickedSubTile.IsHighlighted())
            {
                RemoveAllHighlights();
                RemoveAllExtendedHover();
                callFillAnswer = true;
            }

            return callFillAnswer;
        }
        public override void MouseLeave(MouseEventArgs e, PictureBox pb)
        {
            RemoveHoverFlagFromBothSubtiles();
            RepaintFlag = true;
            RemoveAllExtendedHover();
        }
    }
}
