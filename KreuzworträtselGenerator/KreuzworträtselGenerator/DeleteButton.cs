﻿namespace KreuzworträtselGenerator
{
    class DeleteButton
    {
        static readonly Pen pen;
        const float sizeFactor = 0.3f;
        static readonly int absoluteSize;
        public static readonly Rectangle bounds_tile_space;

        bool visible = false;
        bool hover = false;
        Rectangle bounds_global;

        static DeleteButton()
        {
            pen = new Pen(Brushes.Red, 1.7f);

            absoluteSize = (int)(sizeFactor * Form1.TS);
            bounds_tile_space = new Rectangle(Form1.TS - absoluteSize, 0, absoluteSize, absoluteSize);
        }

        public DeleteButton(Point parentTileLocation)
        {
            bounds_global = new Rectangle(bounds_tile_space.X + parentTileLocation.X, bounds_tile_space.Y + parentTileLocation.Y, absoluteSize, absoluteSize);
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
            Point mousePosition_tile_space = new Point(e.X - parentTile.GetGlobalBounds().X, e.Y - parentTile.GetGlobalBounds().Y);
            // Check if mouse is over deleteButton
            if (bounds_tile_space.X <= mousePosition_tile_space.X && bounds_tile_space.Height >= mousePosition_tile_space.Y)
                return true;
            else
                return false;
        }

        public void Paint(Graphics g)
        {
            if (IsVisible())
            {
                g.SetClip(bounds_global);
                Tile.TranslateTransformGraphics(g, bounds_global.Location);

                g.DrawRectangle(pen, 0, 0, absoluteSize - 1, absoluteSize - 1);
                g.DrawLine(pen, 0, 0, absoluteSize, absoluteSize - 1);
                g.DrawLine(pen, 0, absoluteSize - 1, absoluteSize, 0);

                Tile.TranslateTransformGraphics(g, new Point(-bounds_global.Location.X, -bounds_global.Location.Y));
                g.ResetClip();
            }
        }
    }
}
