using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace xc
{
    public class MiniGameManager : xc.Singleton<MiniGameManager>
    {
        private bool playing = false;
        private IMiniGame game;

        public bool StartGame(Transform container)
        {
            Debug.Log("MiniGameManager.StartGame");

            if (playing)
                return false;

            if (container == null)
                return false;

            while (container.childCount > 0)
            {
                Transform child = container.GetChild(0);
                child.parent = null;
                GameObject.Destroy(child.gameObject);
            }

            game = CreateGame(container);
            if(game == null || game.CheckFinish())
            {
                return false;
            }
            game.StartGame();
            playing = true;
            return true;
        }

        public void EndGame()
        {
            Debug.Log("MiniGameManager.EndGame");

            if (!playing)
                return;

            if (game != null)
            {
                game.EndGame();
            }
            playing = false;

        }

        private void TryGetGameReward()
        {
            if (game != null)
            {
                game.TryGetGameReward();
                game = null;
            }
            else
            {
                var miniGame = CreateGame(null);
                if (miniGame != null)
                {
                    miniGame.TryGetGameReward();
                }
            }
        }

        public void RegisterAllMessages()
        {
            ClientEventMgr.GetInstance().SubscribeClientEvent((int)ClientEvent.CE_FIRST_ENTER_SCENE, OnFirstEnterScene);

        }

        void OnFirstEnterScene(CEventBaseArgs args)
        {
            Debug.Log("MiniGameManager.OnFirstEnterScene");
            TryGetGameReward();
        }


        //留接口：后续可做工厂
        IMiniGame CreateGame(Transform container)
        {
            if (Const.Region == RegionType.KOREA)
            {
                return new RainMiniGame(container);
            }
            return null;
        }

        public bool IsReady()
        {
            if (game != null)
            {
                return game.IsReady();
            }
            return false;
        }

        public void Run()
        {
            if (game != null)
                game.Run();
        }
    }
}
