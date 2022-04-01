﻿namespace KreuzworträtselGenerator
{
    abstract class QuestionOrBaseWordTile : Tile
    {
        protected string Text;
        protected int Direction;
        protected readonly List<LetterTile> LinkedLetterTiles;
        protected EmptyTile LinkedReservedTile;
        protected DeleteButton deleteButton;

        public QuestionOrBaseWordTile(Point position, int direction, Rectangle bounds_global) : base(position, bounds_global)
        {
            Direction = direction;
            LinkedLetterTiles = new List<LetterTile>();
            Rectangle deleteButton_bounds_global 
            deleteButton = new DeleteButton(deleteButton_bounds_global);

            foregroundColor = Brushes.Red;
            font = new Font(FontFamily.GenericSerif, 12, FontStyle.Bold);
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
            if (deleteButton.IsMouseOverMe(e, this))
            {
                // Then delete this question
                ToEmptyTile(grid);
                // Turn mouse normal
                pb.Cursor = Cursors.Default;
            }
        }
        public virtual void ToEmptyTile(Tile[,] grid)
        {
            // Turn the letter tiles associated with this questionTile into emptyTiles
            foreach (LetterTile letterTile in LinkedLetterTiles)
                letterTile.ToEmptyTile(grid, this);

            // Unreserve the reserved tile of the questionTile
            LinkedReservedTile?.Unreserve();

            // Insert a new EmptyTile instance into the grid at this tile's position, 
            Point position = GetPosition();
            grid[position.Y, position.X] = new EmptyTile(position, Bounds_global);

            Destructor();
            deleteButton.Destructor();
        }

        public override void MouseLeave(MouseEventArgs e, PictureBox pb)
        {
            // deleteButton is not visible
            deleteButton.SetVisible(false);
            deleteButton.SetHover(false, pb);

            RepaintFlag = true;
        }

        protected override void PaintOperations(Graphics g)
        {
            // Draw text // calculate in Text setter method?
            Size textSize = TextRenderer.MeasureText(Text, font);
            g.DrawString(Text, font, foregroundColor, Form1.TS / 2 - textSize.Width / 2, Form1.TS / 2 - textSize.Height / 2);
            g.DrawRectangle(Pens.Black, 0, 0, Bounds_local.Width - 1, Bounds_local.Height - 1);

            // Draw X
            deleteButton.RepaintFlag = true;
        }

        public override void MouseMove(MouseEventArgs e, PictureBox pb, Point[] directions, Tile[,] grid)
        {
            // Set deleteButton to visible
            deleteButton.SetVisible(true);
            // Is mouse hovering over deleteButton?
            if (deleteButton.IsMouseOverMe(e, this))
                // Call delete button hover logic
                deleteButton.SetHover(true, pb);
            else
                // Mouse is not over deleteButton, 
                // so undo deleteButton hover
                deleteButton.SetHover(false, pb);

            RepaintFlag = true;
        }
    }
}
