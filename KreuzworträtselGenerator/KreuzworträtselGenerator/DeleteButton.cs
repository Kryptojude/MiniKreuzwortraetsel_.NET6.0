namespace KreuzworträtselGenerator
{
    class DeleteButton : PaintObject
    {
        //
        //  <--- static --->
        //
        static readonly Pen pen;
        const float sizeFactor = 0.3f;
        static int absoluteSize { get; }

        static DeleteButton()
        {
            pen = new Pen(Brushes.Red, 1.7f);
            absoluteSize = (int)(sizeFactor * Form1.TS);
        }

        //
        //  <--- instance --->
        //
        bool visible = false;
        bool hover = false;

        public DeleteButton(Rectangle bounds_global) : base(bounds_global)
        {

        }

        public bool IsVisible()
        {
            return visible;
        }

        public void SetVisible(bool visible)
        {
            this.visible = visible;
        }

        public void SetHover(bool hover, PictureBox pb)
        {
            this.hover = hover;
            if (hover)
                pb.Cursor = Cursors.Hand;
            else
                pb.Cursor = Cursors.Default;
        }

        public bool IsMouseOverMe(MouseEventArgs e, QuestionOrBaseWordTile parentTile)
        {
            // Calculate mouse position in tile space
            Point mousePosition_tile_space = new Point(e.X - parentTile.Bounds_global.X, e.Y - parentTile.Bounds_global.Y);
            // Check if mouse is over deleteButton
            if (Bounds_local.X <= mousePosition_tile_space.X && Bounds_local.Height >= mousePosition_tile_space.Y)
                return true;
            else
                return false;
        }

        protected override void PaintOperations(Graphics g)
        {
            if (IsVisible())
            {
                g.SetClip(Bounds_global);
                Tile.TranslateTransformGraphics(g, Bounds_global.Location);

                g.DrawRectangle(pen, 0, 0, absoluteSize - 1, absoluteSize - 1);
                g.DrawLine(pen, 0, 0, absoluteSize, absoluteSize - 1);
                g.DrawLine(pen, 0, absoluteSize - 1, absoluteSize, 0);
            }
        }
    }
}
