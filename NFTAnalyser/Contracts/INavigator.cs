namespace NFTAnalyser.Contracts
{
    public interface INavigator
    {
        object CurrentContent { get; }

        void Display(object content);
    }
}
