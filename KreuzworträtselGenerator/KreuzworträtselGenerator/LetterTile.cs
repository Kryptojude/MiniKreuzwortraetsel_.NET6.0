namespace KreuzworträtselGenerator
{
    class LetterTile : Tile
    {
        /// <summary>
        /// The question tile(s) that this letter belongs to
        /// </summary>
        /// Convert to array?
        readonly List<QuestionOrBaseWordTile> parent_QuestionOrBaseWordTiles = new List<QuestionOrBaseWordTile>();
        public string Text = "";

        public LetterTile(Point position, QuestionOrBaseWordTile questionOrBaseWordTile, string text, Rectangle bounds_global) : base(position, bounds_global)
        {
            questionOrBaseWordTile.AddLinkedLetterTile(this);
            Text = text;
        }

        public void ToEmptyTile(Tile[,] grid, QuestionOrBaseWordTile questionTileInterface)
        {
            // If the letterTile only belongs to one questionTile, then make into EmptyTile
            if (parent_QuestionOrBaseWordTiles.Count == 1)
            {
                grid[GetPosition().Y, GetPosition().X] = new EmptyTile(GetPosition(), Bounds_global);
            }
            // If the letterTile belongs to multiple QuestionTiles, just remove this QuestionTile from its question tile list
            else
                parent_QuestionOrBaseWordTiles.Remove(questionTileInterface);
        }
        protected override void PaintOperations(Graphics g)
        {
            // Draw text
            Size textSize = TextRenderer.MeasureText(Text, font);
            g.DrawString(Text, font, foregroundColor, Form1.TS / 2 - textSize.Width / 2, Form1.TS / 2 - textSize.Height / 2);
            g.DrawRectangle(Pens.Black, 0, 0, Bounds_local.Width - 1, Bounds_local.Height - 1);

            DrawExtendedHover(g);
        }

        public void AddParentQuestionOrBaseWordTile(QuestionOrBaseWordTile questionOrBaseWordTile)
        {
            parent_QuestionOrBaseWordTiles.Add(questionOrBaseWordTile);
        }

        public override void MouseEnter(MouseEventArgs e, Point[] directions, Tile[,] grid) { }
        public override void MouseLeave(PictureBox pb) { }
        public override void IntraTileMouseMove(MouseEventArgs e, PictureBox pb, Point[] directions, Tile[,] grid) { }
    }
}
