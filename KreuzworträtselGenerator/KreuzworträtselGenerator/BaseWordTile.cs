namespace KreuzworträtselGenerator
{
    class BaseWordTile : QuestionOrBaseWordTile
    {
        public BaseWordTile(Point position, int direction, Rectangle bounds_global) : base(position, direction, bounds_global)
        {
            Text = GetArrow(Direction);
        }
    }
}
