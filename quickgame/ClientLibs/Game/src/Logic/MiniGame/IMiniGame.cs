namespace xc
{
    public interface IMiniGame
    {
        void StartGame();
        void EndGame();
        void TryGetGameReward();
        bool CheckFinish();
        bool IsReady();
        void Run();
    }
}
