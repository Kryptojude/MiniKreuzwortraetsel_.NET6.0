namespace KreuzworträtselGenerator
{
    abstract class QuestionOrBaseWordTile : Tile
    {
        protected string Text;
        protected int Direction;
        protected readonly List<LetterTile> LinkedLetterTiles;
        protected EmptyTile LinkedReservedTile;
        DeleteButton deleteButton;
        struct DeleteButton
        {
            public bool Visible { get; set; }
            public Pen Pen { get; }
            public Rectangle Bounds_tile_space { get; }

            public DeleteButton()
            {
                Pen = new Pen(Brushes.Red, 1.7f);
                Visible = false;
                int size = 10;
                Bounds_tile_space = new Rectangle(Form1.TS - size, 0, size, size);
            }
        }

        public QuestionOrBaseWordTile(Point position, int direction, Rectangle bounds_global) : base(position, bounds_global)
        {
            Direction = direction;
            LinkedLetterTiles = new List<LetterTile>();
            foregroundColor = Brushes.Red;
            font = new Font(FontFamily.GenericSerif, 12, FontStyle.Bold);

            deleteButton = new();
        }

        public string GetText()
        {
            return Text;
        }
        public void SetLinkedReservedTile(EmptyTile linkedReservedTile)
        {
            LinkedReservedTile = linkedReservedTile;
        }
        public int GetDirection()
        {
            return Direction;
        }

        public void AddLinkedLetterTile(LetterTile letterTile)
        {
            LinkedLetterTiles.Add(letterTile);
            letterTile.AddParentQuestionOrBaseWordTile(this);
        }
        public void MouseClick(MouseEventArgs e, Tile[,] grid, PictureBox pb)
        {
            // If the click was on the deleteButton
            if (IsMouseOverDeleteButton(e.Location))
            {
                // Then delete this question
                ToEmptyTile(grid);
                // Turn mouse normal
                pb.Cursor = Cursors.Default;
            }
        }
        bool IsMouseOverDeleteButton(Point mousePosition)
        {
            // Check if mouse is over deleteButton
            if (mousePosition.X >= Bounds_global.Left && mousePosition.Y <= Bounds_global.Bottom)
                return true;
            else
                return false;
        }
        public virtual void ToEmptyTile(Tile[,] grid)
        {
            // Turn the letter tiles associated with this questionTile into emptyTiles
            foreach (LetterTile letterTile in LinkedLetterTiles)
                letterTile.ToEmptyTile(grid, this);

            // Unreserve the reserved tile of the questionTile
            if (LinkedReservedTile != null)
                LinkedReservedTile.Reserved = false;

            // Insert a new EmptyTile instance into the grid at this tile's position, 
            Point position = GetPosition();
            grid[position.Y, position.X] = new EmptyTile(position, Bounds_global);
        }


        protected override void PaintOperations(Graphics g)
        {
            // Draw text // calculate in Text setter method?
            Size textSize = TextRenderer.MeasureText(Text, font);
            g.DrawString(Text, font, foregroundColor, Form1.TS / 2 - textSize.Width / 2, Form1.TS / 2 - textSize.Height / 2);
            g.DrawRectangle(Pens.Black, 0, 0, Bounds_local.Width - 1, Bounds_local.Height - 1);

            // Draw deleteButton
            if (deleteButton.Visible)
            {
                g.DrawRectangle(deleteButton.Pen, deleteButton.Bounds_tile_space);
                g.DrawLine(deleteButton.Pen, deleteButton.Bounds_tile_space.Left, deleteButton.Bounds_tile_space.Top, deleteButton.Bounds_tile_space.Right, deleteButton.Bounds_tile_space.Bottom);
                g.DrawLine(deleteButton.Pen, deleteButton.Bounds_tile_space.Left, deleteButton.Bounds_tile_space.Bottom, deleteButton.Bounds_tile_space.Right, deleteButton.Bounds_tile_space.Top);
            }
        }

        public override void MouseEnter(MouseEventArgs e, Point[] directions, Tile[,] grid)
        {
            // Set deleteButton to visible
            deleteButton.Visible = true;
            RepaintFlag = true;
        }
        public override void MouseLeave(PictureBox pb)
        {
            // deleteButton is not visible anymore
            deleteButton.Visible = false;
            pb.Cursor = Cursors.Default;

            RepaintFlag = true;
        }
        public override void IntraTileMouseMove(MouseEventArgs e, PictureBox pb, Point[] directions, Tile[,] grid)
        {
            // Is mouse hovering over deleteButton?
            if (IsMouseOverDeleteButton(e.Location))
                pb.Cursor = Cursors.Hand;
            else
                pb.Cursor = Cursors.Default;
        }

        
    }
}
