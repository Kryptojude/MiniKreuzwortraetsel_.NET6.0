namespace KreuzworträtselGenerator
{
    class BaseWordTile : QuestionOrBaseWordTile
    {
        public BaseWordTile(Point position, int direction) : base(position, direction)
        {
            Text = GetArrow(Direction);
        }
    }
}
