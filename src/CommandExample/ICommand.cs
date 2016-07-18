namespace CommandExample
{
    interface ICommand
    {
        void Execute();
        void Undo();
    }
}
