using UnityEngine;

using System.Reflection;
using System.Collections;
using System.Collections.Generic;

using Utils;
using Net;
using xc.protocol;

namespace xc
{
    class DebugServer : xc.Singleton<DebugServer>
    {
        public void RegisterAllMessage()
        {
            Game.Instance.SubscribeNetNotify(NetMsg.MSG_MWAR_DEBUG_BULLET, HandleServerData);
            Game.Instance.SubscribeNetNotify(NetMsg.MSG_MWAR_DEBUG_WORD, HandleServerData);
            Game.Instance.SubscribeNetNotify(NetMsg.MSG_MWAR_DEBUG_POS, HandleServerData);
            Game.Instance.SubscribeNetNotify(NetMsg.MSG_MWAR_DEBUG_LINE, HandleServerData);
            Game.Instance.SubscribeNetNotify(NetMsg.MSG_MWAR_DEBUG_CIRCLE, HandleServerData);
        }

        public static Color GetColor(uint color_type)
        {
            Color col = Color.black;
            if (color_type == 1)
            {
                col.r = 1;
            }
            else if (color_type == 2)
            {
                col.g = 1;
            }
            else if (color_type == 3)
            {
                col.b = 1;
            }
            else if (color_type == 4)
            {
                col.r = 1;
                col.g = 1;
            }
            else if (color_type == 5)
            {
                col.r = 1;
                col.b = 1;
            }
            else if (color_type == 6)
            {
                col.g = 1;
                col.b = 1;
            }
            else if (color_type == 7)
            {
                col.r = 1;
                col.g = 1;
                col.b = 1;
            }
            col.a = 0.5f;

            return col;
        }

        void HandleServerData(ushort pro, byte[] data)
        {
            switch (pro)
            {
                case NetMsg.MSG_MWAR_DEBUG_BULLET: // 响应服务端的子弹位置调试的消息
                    {
                        if (TestUnit.DisplayDebugDraw == false)
                            return;
                    }
                    break;
                case NetMsg.MSG_MWAR_DEBUG_WORD: // 绘制服务端发来的文字
                    {
                        if (TestUnit.DisplayDebugDraw == false)
                            return;

                        S2CMwarDebugWord debugWord = S2CPackBase.DeserializePack<S2CMwarDebugWord>(data);

                        Vector3 pos = PhysicsHelp.GetPosition(debugWord.px / 100.0f, debugWord.py / 100.0f);
                        Object prefab = Resources.Load("core/prefabs/AttackSphere");
                        GameObject testGo = GameObject.Instantiate(prefab, pos, Quaternion.identity) as GameObject;
                        testGo.transform.localScale = Vector3.one * (1.0f) / 100.0f * 2;
                        testGo.transform.parent = MainGame.CoreObject.transform;

                        Color col = GetColor(debugWord.color);
                        testGo.GetComponent<Renderer>().material.SetColor("_Color", col);

                        testGo.AddComponent<DelayDestroyComponent>().DelayTime = debugWord.time;

                        UI3DText ui3dText = testGo.AddComponent<UI3DText>();
                        ui3dText.Text = System.Text.Encoding.UTF8.GetString(debugWord.word);
                        ui3dText.TextColor = col;
                        ui3dText.FontSize = (int)debugWord.size;
                        ui3dText.UpdatePosition(pos, Vector3.zero, Vector3.zero);
                        //ui3dText.SetOwnerTrans(null);

                        break;
                    }
                case NetMsg.MSG_MWAR_DEBUG_POS: // 绘制服务端发送过来的位置
                    {
                        if (TestUnit.DisplayDebugDraw == false)
                            return;

                        var debugPos = S2CPackBase.DeserializePack<S2CMwarDebugPos>(data);

                        Vector3 pos = PhysicsHelp.GetPosition(debugPos.px / 100.0f, debugPos.py / 100.0f);
                        Object prefab = Resources.Load("core/prefabs/AttackSphere");
                        GameObject testGo = GameObject.Instantiate(prefab, pos, Quaternion.identity) as GameObject;
                        testGo.transform.localScale = Vector3.one * debugPos.radius / 100.0f * 2;
                        testGo.transform.parent = MainGame.CoreObject.transform;

                        Color col = GetColor(debugPos.color);
                        testGo.GetComponent<Renderer>().material.SetColor("_Color", col);

                        testGo.AddComponent<DelayDestroyComponent>().DelayTime = 0.5f;
                    }
                    break;
                case NetMsg.MSG_MWAR_DEBUG_LINE: // 绘制服务端发送过来的线段
                    {
                        if (TestUnit.DisplayDebugDraw == false)
                            return;

                        S2CMwarDebugLine debugLine = S2CPackBase.DeserializePack<S2CMwarDebugLine>(data);

                        float height = PhysicsHelp.GetHeight(debugLine.px1 / 100.0f, debugLine.py1 / 100.0f);
                        Vector3 pos1 = new Vector3(debugLine.px1 / 100.0f, height, debugLine.py1 / 100.0f);
                        Vector3 pos2 = new Vector3(debugLine.px2 / 100.0f, height, debugLine.py2 / 100.0f);
                        Vector3 dir = (pos2 - pos1);
                        Vector3 dirNormal = dir.normalized;
                        if (dirNormal == Vector3.zero)
                            return;

                        Vector3 middlePos = (pos1 + pos2) / 2.0f;

                        Object prefab = Resources.Load("core/prefabs/AttackCube");
                        GameObject testGo = GameObject.Instantiate(prefab, middlePos, Quaternion.identity) as GameObject;

                        testGo.transform.localScale = new Vector3(debugLine.radius * 2.0f / 100.0f, debugLine.radius * 2.0f / 100.0f, (pos2 - pos1).magnitude);
                        testGo.transform.rotation = Quaternion.LookRotation(dirNormal, Vector3.up);
                        testGo.transform.parent = MainGame.CoreObject.transform;

                        Color col = GetColor(debugLine.color);
                        testGo.GetComponent<Renderer>().material.SetColor("_Color", col);

                        testGo.AddComponent<DelayDestroyComponent>().DelayTime = debugLine.time;
                    }
                    break;
                case NetMsg.MSG_MWAR_DEBUG_CIRCLE:// 绘制服务端发送过来的圆环
                    {
                        if (TestUnit.DisplayDebugDraw == false)
                            return;

                        var debugCircle = S2CPackBase.DeserializePack<S2CMwarDebugCircle>(data);
                        float height = PhysicsHelp.GetHeight(debugCircle.px / 100.0f, debugCircle.py / 100.0f);
                        Vector3 pos = new Vector3(debugCircle.px / 100.0f, height, debugCircle.py / 100.0f);

                        Object prefab = Resources.Load("Core/Prefabs/AttackCircle");
                        GameObject testGo = GameObject.Instantiate(prefab, pos, Quaternion.identity) as GameObject;

                        testGo.transform.localScale = new Vector3(debugCircle.size/ 100.0f, 1.0f, debugCircle.size / 100.0f);
                        testGo.transform.rotation = Quaternion.identity;
                        testGo.transform.parent = MainGame.CoreObject.transform;

                        Color col = GetColor(debugCircle.color);
                        testGo.GetComponentInChildren<Renderer>().material.SetColor("Tint Color", col);
                        testGo.AddComponent<DelayDestroyComponent>().DelayTime = debugCircle.time * GlobalConst.MilliToSecond;
                    } break;
            }
        }
    }
}
