#if USE_UNI_LUA
using LuaAPI = UniLua.Lua;
using RealStatePtr = UniLua.ILuaState;
using LuaCSFunction = UniLua.CSharpFunctionDelegate;
#else
using LuaAPI = XLua.LuaDLL.Lua;
using RealStatePtr = System.IntPtr;
using LuaCSFunction = XLua.LuaDLL.lua_CSFunction;
#endif

using XLua;
using System.Collections.Generic;


namespace XLua.CSObjectWrap
{
    using XUtils = XLua.XUtils;
    public class xcCommonInstanceStateWrap
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			XUtils.BeginObjectRegister(typeof(xc.CommonInstanceState), L, translator, 0, 25, 3, 0);
			
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "AddComponent", _m_AddComponent);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "GetComponent", _m_GetComponent);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "LocalPlayerSocietyName", _m_LocalPlayerSocietyName);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "LocalPlayerName", _m_LocalPlayerName);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "LocalPlayerWholeName", _m_LocalPlayerWholeName);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "PlayerSvrName", _m_PlayerSvrName);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "PlayerName", _m_PlayerName);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "PlayerWholeName", _m_PlayerWholeName);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "NpcWholeName", _m_NpcWholeName);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "MonsterWholeName", _m_MonsterWholeName);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "ActorNameText", _m_ActorNameText);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "IsMonsterFriend", _m_IsMonsterFriend);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "IsRemotePlayerFriend", _m_IsRemotePlayerFriend);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "IsFriend", _m_IsFriend);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "CreateState", _m_CreateState);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "GetState", _m_GetState);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "Update", _m_Update);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "Enter", _m_Enter);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "Exit", _m_Exit);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "StateEnter_InPlay", _m_StateEnter_InPlay);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "ReactInstanceEvent", _m_ReactInstanceEvent);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "CompleteInstance", _m_CompleteInstance);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "PauseInstance", _m_PauseInstance);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "ResumeInstance", _m_ResumeInstance);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "IsInState", _m_IsInState);
			
			
			XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "Flag", _g_get_Flag);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "NameFlag", _g_get_NameFlag);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "LocalPlayerInitPos", _g_get_LocalPlayerInitPos);
            
			
			XUtils.EndObjectRegister(typeof(xc.CommonInstanceState), L, translator, null, null,
			    null, null, null);

		    XUtils.BeginClassRegister(typeof(xc.CommonInstanceState), L, __CreateInstance, 1, 0, 0);
			
			
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "UnderlyingSystemType", typeof(xc.CommonInstanceState));
			
			
			XUtils.EndClassRegister(typeof(xc.CommonInstanceState), L, translator);
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CreateInstance(RealStatePtr L)
        {
            return LuaAPI.luaL_error(L, "xc.CommonInstanceState does not have a constructor!");
        }
        
		
        
		
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_AddComponent(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.CommonInstanceState __cl_gen_to_be_invoked = (xc.CommonInstanceState)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    string component_name = LuaAPI.lua_tostring(L, 2);
                    
                        xc.instance_behaviour.Behaviour __cl_gen_ret = __cl_gen_to_be_invoked.AddComponent( component_name );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetComponent(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.CommonInstanceState __cl_gen_to_be_invoked = (xc.CommonInstanceState)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    string name = LuaAPI.lua_tostring(L, 2);
                    
                        xc.instance_behaviour.Behaviour __cl_gen_ret = __cl_gen_to_be_invoked.GetComponent( name );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_LocalPlayerSocietyName(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.CommonInstanceState __cl_gen_to_be_invoked = (xc.CommonInstanceState)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    LocalPlayer actor = (LocalPlayer)translator.GetObject(L, 2, typeof(LocalPlayer));
                    
                        string __cl_gen_ret = __cl_gen_to_be_invoked.LocalPlayerSocietyName( actor );
                        LuaAPI.lua_pushstring(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_LocalPlayerName(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.CommonInstanceState __cl_gen_to_be_invoked = (xc.CommonInstanceState)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    LocalPlayer actor = (LocalPlayer)translator.GetObject(L, 2, typeof(LocalPlayer));
                    
                        string __cl_gen_ret = __cl_gen_to_be_invoked.LocalPlayerName( actor );
                        LuaAPI.lua_pushstring(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_LocalPlayerWholeName(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.CommonInstanceState __cl_gen_to_be_invoked = (xc.CommonInstanceState)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    LocalPlayer actor = (LocalPlayer)translator.GetObject(L, 2, typeof(LocalPlayer));
                    
                        string __cl_gen_ret = __cl_gen_to_be_invoked.LocalPlayerWholeName( actor );
                        LuaAPI.lua_pushstring(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_PlayerSvrName(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.CommonInstanceState __cl_gen_to_be_invoked = (xc.CommonInstanceState)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    Actor actor = (Actor)translator.GetObject(L, 2, typeof(Actor));
                    
                        string __cl_gen_ret = __cl_gen_to_be_invoked.PlayerSvrName( actor );
                        LuaAPI.lua_pushstring(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_PlayerName(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.CommonInstanceState __cl_gen_to_be_invoked = (xc.CommonInstanceState)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    Actor actor = (Actor)translator.GetObject(L, 2, typeof(Actor));
                    
                        string __cl_gen_ret = __cl_gen_to_be_invoked.PlayerName( actor );
                        LuaAPI.lua_pushstring(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_PlayerWholeName(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.CommonInstanceState __cl_gen_to_be_invoked = (xc.CommonInstanceState)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    Actor actor = (Actor)translator.GetObject(L, 2, typeof(Actor));
                    
                        string __cl_gen_ret = __cl_gen_to_be_invoked.PlayerWholeName( actor );
                        LuaAPI.lua_pushstring(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_NpcWholeName(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.CommonInstanceState __cl_gen_to_be_invoked = (xc.CommonInstanceState)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    NpcPlayer actor = (NpcPlayer)translator.GetObject(L, 2, typeof(NpcPlayer));
                    
                        string __cl_gen_ret = __cl_gen_to_be_invoked.NpcWholeName( actor );
                        LuaAPI.lua_pushstring(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_MonsterWholeName(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.CommonInstanceState __cl_gen_to_be_invoked = (xc.CommonInstanceState)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    Monster actor = (Monster)translator.GetObject(L, 2, typeof(Monster));
                    
                        string __cl_gen_ret = __cl_gen_to_be_invoked.MonsterWholeName( actor );
                        LuaAPI.lua_pushstring(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_ActorNameText(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.CommonInstanceState __cl_gen_to_be_invoked = (xc.CommonInstanceState)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    Actor actor = (Actor)translator.GetObject(L, 2, typeof(Actor));
                    
                        string __cl_gen_ret = __cl_gen_to_be_invoked.ActorNameText( actor );
                        LuaAPI.lua_pushstring(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_IsMonsterFriend(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.CommonInstanceState __cl_gen_to_be_invoked = (xc.CommonInstanceState)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    LocalPlayer local = (LocalPlayer)translator.GetObject(L, 2, typeof(LocalPlayer));
                    Monster actor = (Monster)translator.GetObject(L, 3, typeof(Monster));
                    
                        bool __cl_gen_ret = __cl_gen_to_be_invoked.IsMonsterFriend( local, actor );
                        LuaAPI.lua_pushboolean(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_IsRemotePlayerFriend(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.CommonInstanceState __cl_gen_to_be_invoked = (xc.CommonInstanceState)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    LocalPlayer local = (LocalPlayer)translator.GetObject(L, 2, typeof(LocalPlayer));
                    RemotePlayer actor = (RemotePlayer)translator.GetObject(L, 3, typeof(RemotePlayer));
                    
                        bool __cl_gen_ret = __cl_gen_to_be_invoked.IsRemotePlayerFriend( local, actor );
                        LuaAPI.lua_pushboolean(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_IsFriend(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.CommonInstanceState __cl_gen_to_be_invoked = (xc.CommonInstanceState)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    Actor actor = (Actor)translator.GetObject(L, 2, typeof(Actor));
                    
                        bool __cl_gen_ret = __cl_gen_to_be_invoked.IsFriend( actor );
                        LuaAPI.lua_pushboolean(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_CreateState(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.CommonInstanceState __cl_gen_to_be_invoked = (xc.CommonInstanceState)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    uint id = LuaAPI.xlua_touint(L, 2);
                    
                        xc.Machine.State __cl_gen_ret = __cl_gen_to_be_invoked.CreateState( id );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetState(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.CommonInstanceState __cl_gen_to_be_invoked = (xc.CommonInstanceState)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    uint id = LuaAPI.xlua_touint(L, 2);
                    
                        xc.Machine.State __cl_gen_ret = __cl_gen_to_be_invoked.GetState( id );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Update(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.CommonInstanceState __cl_gen_to_be_invoked = (xc.CommonInstanceState)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    
                    __cl_gen_to_be_invoked.Update(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Enter(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.CommonInstanceState __cl_gen_to_be_invoked = (xc.CommonInstanceState)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    object[] param = translator.GetParams<object>(L, 2);
                    
                    __cl_gen_to_be_invoked.Enter( param );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Exit(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.CommonInstanceState __cl_gen_to_be_invoked = (xc.CommonInstanceState)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    
                    __cl_gen_to_be_invoked.Exit(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_StateEnter_InPlay(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.CommonInstanceState __cl_gen_to_be_invoked = (xc.CommonInstanceState)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    xc.Machine.State s = (xc.Machine.State)translator.GetObject(L, 2, typeof(xc.Machine.State));
                    
                    __cl_gen_to_be_invoked.StateEnter_InPlay( s );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_ReactInstanceEvent(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.CommonInstanceState __cl_gen_to_be_invoked = (xc.CommonInstanceState)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    uint game_event = LuaAPI.xlua_touint(L, 2);
                    
                    __cl_gen_to_be_invoked.ReactInstanceEvent( game_event );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_CompleteInstance(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.CommonInstanceState __cl_gen_to_be_invoked = (xc.CommonInstanceState)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    
                    __cl_gen_to_be_invoked.CompleteInstance(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_PauseInstance(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.CommonInstanceState __cl_gen_to_be_invoked = (xc.CommonInstanceState)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    
                    __cl_gen_to_be_invoked.PauseInstance(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_ResumeInstance(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.CommonInstanceState __cl_gen_to_be_invoked = (xc.CommonInstanceState)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    
                    __cl_gen_to_be_invoked.ResumeInstance(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_IsInState(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.CommonInstanceState __cl_gen_to_be_invoked = (xc.CommonInstanceState)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    uint state = LuaAPI.xlua_touint(L, 2);
                    
                        bool __cl_gen_ret = __cl_gen_to_be_invoked.IsInState( state );
                        LuaAPI.lua_pushboolean(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_Flag(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.CommonInstanceState __cl_gen_to_be_invoked = (xc.CommonInstanceState)translator.FastGetCSObj(L, 1);
                translator.Push(L, __cl_gen_to_be_invoked.Flag);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_NameFlag(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.CommonInstanceState __cl_gen_to_be_invoked = (xc.CommonInstanceState)translator.FastGetCSObj(L, 1);
                translator.Push(L, __cl_gen_to_be_invoked.NameFlag);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_LocalPlayerInitPos(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.CommonInstanceState __cl_gen_to_be_invoked = (xc.CommonInstanceState)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushuint(L, __cl_gen_to_be_invoked.LocalPlayerInitPos);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        
        
		
		
		
		
    }
}
