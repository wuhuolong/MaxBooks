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
    public class xcDungeonCollectionObjectBehaviourWrap
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			XUtils.BeginObjectRegister(typeof(xc.Dungeon.CollectionObjectBehaviour), L, translator, 0, 17, 4, 1);
			
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "Init", _m_Init);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "OnTouchEnter", _m_OnTouchEnter);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "OnTouchExit", _m_OnTouchExit);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "StartInteract", _m_StartInteract);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "InterruptCollect", _m_InterruptCollect);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "SendStartInteract", _m_SendStartInteract);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "SendInterruptCollect", _m_SendInterruptCollect);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "SendFinishCollect", _m_SendFinishCollect);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "OnClicked", _m_OnClicked);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "OnInteractButtonClickCallback", _m_OnInteractButtonClickCallback);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "OnLocalPlayerBeInterrupted", _m_OnLocalPlayerBeInterrupted);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "TryToStart", _m_TryToStart);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "HandleServerData", _m_HandleServerData);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "HandleBarDisappear", _m_HandleBarDisappear);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "OnResLoaded", _m_OnResLoaded);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "GuildBonfireCheckCanMeat", _m_GuildBonfireCheckCanMeat);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "CheckCanGetServerBossBox", _m_CheckCanGetServerBossBox);
			
			
			XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "IsTouching", _g_get_IsTouching);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "IsCollecting", _g_get_IsCollecting);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "SqrRadius", _g_get_SqrRadius);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "Class", _g_get_Class);
            
			XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "IsClickedTouch", _s_set_IsClickedTouch);
            
			XUtils.EndObjectRegister(typeof(xc.Dungeon.CollectionObjectBehaviour), L, translator, null, null,
			    null, null, null);

		    XUtils.BeginClassRegister(typeof(xc.Dungeon.CollectionObjectBehaviour), L, __CreateInstance, 1, 0, 0);
			
			
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "UnderlyingSystemType", typeof(xc.Dungeon.CollectionObjectBehaviour));
			
			
			XUtils.EndClassRegister(typeof(xc.Dungeon.CollectionObjectBehaviour), L, translator);
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CreateInstance(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			try {
				if(LuaAPI.lua_gettop(L) == 1)
				{
					
					xc.Dungeon.CollectionObjectBehaviour __cl_gen_ret = new xc.Dungeon.CollectionObjectBehaviour();
					translator.Push(L, __cl_gen_ret);
					return 1;
				}
				
			}
			catch(System.Exception __gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
			}
            return LuaAPI.luaL_error(L, "invalid arguments to xc.Dungeon.CollectionObjectBehaviour constructor!");
            
        }
        
		
        
		
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Init(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.Dungeon.CollectionObjectBehaviour __cl_gen_to_be_invoked = (xc.Dungeon.CollectionObjectBehaviour)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    uint id = LuaAPI.xlua_touint(L, 2);
                    uint excelId = LuaAPI.xlua_touint(L, 3);
                    
                    __cl_gen_to_be_invoked.Init( id, excelId );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_OnTouchEnter(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.Dungeon.CollectionObjectBehaviour __cl_gen_to_be_invoked = (xc.Dungeon.CollectionObjectBehaviour)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    
                    __cl_gen_to_be_invoked.OnTouchEnter(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_OnTouchExit(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.Dungeon.CollectionObjectBehaviour __cl_gen_to_be_invoked = (xc.Dungeon.CollectionObjectBehaviour)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    
                    __cl_gen_to_be_invoked.OnTouchExit(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_StartInteract(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.Dungeon.CollectionObjectBehaviour __cl_gen_to_be_invoked = (xc.Dungeon.CollectionObjectBehaviour)translator.FastGetCSObj(L, 1);
            
            
			int __gen_param_count = LuaAPI.lua_gettop(L);
            
            try {
                if(__gen_param_count == 2&& LuaTypes.LUA_TBOOLEAN == LuaAPI.lua_type(L, 2)) 
                {
                    bool isShowPauseAutoFightingTips = LuaAPI.lua_toboolean(L, 2);
                    
                    __cl_gen_to_be_invoked.StartInteract( isShowPauseAutoFightingTips );
                    
                    
                    
                    return 0;
                }
                if(__gen_param_count == 1) 
                {
                    
                    __cl_gen_to_be_invoked.StartInteract(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to xc.Dungeon.CollectionObjectBehaviour.StartInteract!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_InterruptCollect(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.Dungeon.CollectionObjectBehaviour __cl_gen_to_be_invoked = (xc.Dungeon.CollectionObjectBehaviour)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    bool executeCallback = LuaAPI.lua_toboolean(L, 2);
                    
                    __cl_gen_to_be_invoked.InterruptCollect( executeCallback );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SendStartInteract(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.Dungeon.CollectionObjectBehaviour __cl_gen_to_be_invoked = (xc.Dungeon.CollectionObjectBehaviour)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    
                    __cl_gen_to_be_invoked.SendStartInteract(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SendInterruptCollect(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.Dungeon.CollectionObjectBehaviour __cl_gen_to_be_invoked = (xc.Dungeon.CollectionObjectBehaviour)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    
                    __cl_gen_to_be_invoked.SendInterruptCollect(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SendFinishCollect(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.Dungeon.CollectionObjectBehaviour __cl_gen_to_be_invoked = (xc.Dungeon.CollectionObjectBehaviour)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    
                    __cl_gen_to_be_invoked.SendFinishCollect(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_OnClicked(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.Dungeon.CollectionObjectBehaviour __cl_gen_to_be_invoked = (xc.Dungeon.CollectionObjectBehaviour)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    CEventBaseArgs args = (CEventBaseArgs)translator.GetObject(L, 2, typeof(CEventBaseArgs));
                    
                    __cl_gen_to_be_invoked.OnClicked( args );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_OnInteractButtonClickCallback(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.Dungeon.CollectionObjectBehaviour __cl_gen_to_be_invoked = (xc.Dungeon.CollectionObjectBehaviour)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    CEventBaseArgs args = (CEventBaseArgs)translator.GetObject(L, 2, typeof(CEventBaseArgs));
                    
                    __cl_gen_to_be_invoked.OnInteractButtonClickCallback( args );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_OnLocalPlayerBeInterrupted(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.Dungeon.CollectionObjectBehaviour __cl_gen_to_be_invoked = (xc.Dungeon.CollectionObjectBehaviour)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    CEventBaseArgs evt = (CEventBaseArgs)translator.GetObject(L, 2, typeof(CEventBaseArgs));
                    
                    __cl_gen_to_be_invoked.OnLocalPlayerBeInterrupted( evt );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_TryToStart(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.Dungeon.CollectionObjectBehaviour __cl_gen_to_be_invoked = (xc.Dungeon.CollectionObjectBehaviour)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    
                        bool __cl_gen_ret = __cl_gen_to_be_invoked.TryToStart(  );
                        LuaAPI.lua_pushboolean(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_HandleServerData(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.Dungeon.CollectionObjectBehaviour __cl_gen_to_be_invoked = (xc.Dungeon.CollectionObjectBehaviour)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    ushort protocol = (ushort)LuaAPI.xlua_tointeger(L, 2);
                    byte[] data = LuaAPI.lua_tobytes(L, 3);
                    
                    __cl_gen_to_be_invoked.HandleServerData( protocol, data );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_HandleBarDisappear(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.Dungeon.CollectionObjectBehaviour __cl_gen_to_be_invoked = (xc.Dungeon.CollectionObjectBehaviour)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    uint barId = LuaAPI.xlua_touint(L, 2);
                    
                    __cl_gen_to_be_invoked.HandleBarDisappear( barId );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_OnResLoaded(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.Dungeon.CollectionObjectBehaviour __cl_gen_to_be_invoked = (xc.Dungeon.CollectionObjectBehaviour)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    
                    __cl_gen_to_be_invoked.OnResLoaded(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GuildBonfireCheckCanMeat(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.Dungeon.CollectionObjectBehaviour __cl_gen_to_be_invoked = (xc.Dungeon.CollectionObjectBehaviour)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    bool showTips = LuaAPI.lua_toboolean(L, 2);
                    
                        bool __cl_gen_ret = __cl_gen_to_be_invoked.GuildBonfireCheckCanMeat( showTips );
                        LuaAPI.lua_pushboolean(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_CheckCanGetServerBossBox(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.Dungeon.CollectionObjectBehaviour __cl_gen_to_be_invoked = (xc.Dungeon.CollectionObjectBehaviour)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    bool showTips = LuaAPI.lua_toboolean(L, 2);
                    
                        bool __cl_gen_ret = __cl_gen_to_be_invoked.CheckCanGetServerBossBox( showTips );
                        LuaAPI.lua_pushboolean(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_IsTouching(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.Dungeon.CollectionObjectBehaviour __cl_gen_to_be_invoked = (xc.Dungeon.CollectionObjectBehaviour)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, __cl_gen_to_be_invoked.IsTouching);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_IsCollecting(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.Dungeon.CollectionObjectBehaviour __cl_gen_to_be_invoked = (xc.Dungeon.CollectionObjectBehaviour)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, __cl_gen_to_be_invoked.IsCollecting);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_SqrRadius(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.Dungeon.CollectionObjectBehaviour __cl_gen_to_be_invoked = (xc.Dungeon.CollectionObjectBehaviour)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushnumber(L, __cl_gen_to_be_invoked.SqrRadius);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_Class(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.Dungeon.CollectionObjectBehaviour __cl_gen_to_be_invoked = (xc.Dungeon.CollectionObjectBehaviour)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushstring(L, __cl_gen_to_be_invoked.Class);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_IsClickedTouch(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.Dungeon.CollectionObjectBehaviour __cl_gen_to_be_invoked = (xc.Dungeon.CollectionObjectBehaviour)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.IsClickedTouch = LuaAPI.lua_toboolean(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
		
		
		
		
    }
}
