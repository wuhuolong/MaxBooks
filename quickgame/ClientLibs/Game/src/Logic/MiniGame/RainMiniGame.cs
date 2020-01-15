using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using xc.protocol;
using Net;

namespace xc
{
    public class RainMiniGame : IMiniGame
    {
        private const string ScoreKey = "RainMiniGameScore";
        private const string GameFinishKey = "RainMiniGameFinish";
        private const string GetRewardKey = "RainMiniGameGetReward";

        private Transform container;
        private RainGame game;

        public RainMiniGame(Transform gameObjContainer)
        {
            container = gameObjContainer;
        }

        public void StartGame()
        {
            string path = "MiniGame/RainGame";
            var prefab = Resources.Load<GameObject>(path);

            if (prefab == null)
            {
                Debug.Log("Load fail");
                return;
            }

            GameObject gameGO = GameObject.Instantiate(prefab) as GameObject;
            gameGO.SetActive(true);

            var rect = gameGO.GetComponent<RectTransform>();
            rect.SetParent(container);
            rect.localScale = Vector3.one;
            rect.localPosition = Vector3.zero;
            rect.sizeDelta = Vector2.zero;

            game = gameGO.GetComponent<RainGame>();
        }

        public void EndGame()
        {
            if (game != null)
            {
                int score = game.GetScore();
                UserPlayerPrefs.Instance.SetInt(ScoreKey, score);

                Debug.Log("MiniGameManager.EndGame " + score);

                SetGameFinish();
                game.EndGame();
                if (game.gameObject != null)
                {
                    game.gameObject.SetActive(false);
                }
            }
        }

        public void TryGetGameReward()
        {
            int score = UserPlayerPrefs.Instance.GetInt(ScoreKey, 0);
            bool canGetReward = UserPlayerPrefs.Instance.GetInt(GetRewardKey, 0) == 0;

            Debug.Log("MiniGameManager.TryGetGameReward " + score + "  " + canGetReward);

            if (canGetReward && score > 0)
            {
                UserPlayerPrefs.Instance.SetInt(ScoreKey, 0);

                C2SMiniMoneyRain msg = new C2SMiniMoneyRain();
                msg.num = (uint)score;
                NetClient.BaseClient.SendData<C2SMiniMoneyRain>(NetMsg.MSG_MINI_MONEY_RAIN, msg);

                Debug.Log("MiniGameManager.TryGetGameReward " + score);

                PlayerPrefs.SetInt(GetRewardKey, 1);
            }
        }

        public static bool IsFinish()
        {
            return UserPlayerPrefs.Instance.GetInt(GameFinishKey, 0) != 0;
        }

        public bool CheckFinish()
        {
            return UserPlayerPrefs.Instance.GetInt(GameFinishKey, 0) != 0;
        }

        private void SetGameFinish()
        {
            UserPlayerPrefs.Instance.SetInt(GameFinishKey, 1);
            UserPlayerPrefs.Instance.Save();
        }

        public bool IsReady()
        {
            if (game != null)
                return game.IsReady();
            return false;
        }

        public void Run()
        {
            if (game != null)
                game.Run();
        }
    }
}
