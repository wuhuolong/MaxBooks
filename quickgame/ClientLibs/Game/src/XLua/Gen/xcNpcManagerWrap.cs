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
    public class xcNpcManagerWrap
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			XUtils.BeginObjectRegister(typeof(xc.NpcManager), L, translator, 0, 11, 3, 2);
			
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "AddNpc", _m_AddNpc);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "RemoveNpc", _m_RemoveNpc);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "DestroyNpc", _m_DestroyNpc);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "NpcCanGuide", _m_NpcCanGuide);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "RemoveNpcInDoNotGuideList", _m_RemoveNpcInDoNotGuideList);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "Reset", _m_Reset);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "CreateAllNpcs", _m_CreateAllNpcs);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "CreateNPC", _m_CreateNPC);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "GetNpcByNpcId", _m_GetNpcByNpcId);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "GetNpcByNpcExcelId", _m_GetNpcByNpcExcelId);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "GetClosestNpc", _m_GetClosestNpc);
			
			
			XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "NavigatingNpcId", _g_get_NavigatingNpcId);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "AllNpc", _g_get_AllNpc);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "TravelBootsJumpNpcId", _g_get_TravelBootsJumpNpcId);
            
			XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "NavigatingNpcId", _s_set_NavigatingNpcId);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "TravelBootsJumpNpcId", _s_set_TravelBootsJumpNpcId);
            
			XUtils.EndObjectRegister(typeof(xc.NpcManager), L, translator, null, null,
			    null, null, null);

		    XUtils.BeginClassRegister(typeof(xc.NpcManager), L, __CreateInstance, 2, 0, 0);
			XUtils.RegisterFunc(L, XUtils.CLS_IDX, "GetNpcPos", _m_GetNpcPos_xlua_st_);
            
			
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "UnderlyingSystemType", typeof(xc.NpcManager));
			
			
			XUtils.EndClassRegister(typeof(xc.NpcManager), L, translator);
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CreateInstance(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			try {
				if(LuaAPI.lua_gettop(L) == 1)
				{
					
					xc.NpcManager __cl_gen_ret = new xc.NpcManager();
					translator.Push(L, __cl_gen_ret);
					return 1;
				}
				
			}
			catch(System.Exception __gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
			}
            return LuaAPI.luaL_error(L, "invalid arguments to xc.NpcManager constructor!");
            
        }
        
		
        
		
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_AddNpc(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.NpcManager __cl_gen_to_be_invoked = (xc.NpcManager)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    NpcPlayer npc = (NpcPlayer)translator.GetObject(L, 2, typeof(NpcPlayer));
                    
                    __cl_gen_to_be_invoked.AddNpc( npc );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_RemoveNpc(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.NpcManager __cl_gen_to_be_invoked = (xc.NpcManager)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    NpcPlayer npc = (NpcPlayer)translator.GetObject(L, 2, typeof(NpcPlayer));
                    
                    __cl_gen_to_be_invoked.RemoveNpc( npc );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_DestroyNpc(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.NpcManager __cl_gen_to_be_invoked = (xc.NpcManager)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    NpcPlayer npc = (NpcPlayer)translator.GetObject(L, 2, typeof(NpcPlayer));
                    
                    __cl_gen_to_be_invoked.DestroyNpc( npc );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_NpcCanGuide(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.NpcManager __cl_gen_to_be_invoked = (xc.NpcManager)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    int npcId = LuaAPI.xlua_tointeger(L, 2);
                    
                        bool __cl_gen_ret = __cl_gen_to_be_invoked.NpcCanGuide( npcId );
                        LuaAPI.lua_pushboolean(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_RemoveNpcInDoNotGuideList(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.NpcManager __cl_gen_to_be_invoked = (xc.NpcManager)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    int npcId = LuaAPI.xlua_tointeger(L, 2);
                    
                    __cl_gen_to_be_invoked.RemoveNpcInDoNotGuideList( npcId );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Reset(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.NpcManager __cl_gen_to_be_invoked = (xc.NpcManager)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    
                    __cl_gen_to_be_invoked.Reset(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_CreateAllNpcs(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.NpcManager __cl_gen_to_be_invoked = (xc.NpcManager)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    
                    __cl_gen_to_be_invoked.CreateAllNpcs(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_CreateNPC(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.NpcManager __cl_gen_to_be_invoked = (xc.NpcManager)translator.FastGetCSObj(L, 1);
            
            
			int __gen_param_count = LuaAPI.lua_gettop(L);
            
            try {
                if(__gen_param_count == 3&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 2)&& translator.Assignable<Actor>(L, 3)) 
                {
                    int npcId = LuaAPI.xlua_tointeger(L, 2);
                    Actor parent = (Actor)translator.GetObject(L, 3, typeof(Actor));
                    
                        xc.UnitID __cl_gen_ret = __cl_gen_to_be_invoked.CreateNPC( npcId, parent );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                if(__gen_param_count == 2&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 2)) 
                {
                    int npcId = LuaAPI.xlua_tointeger(L, 2);
                    
                        xc.UnitID __cl_gen_ret = __cl_gen_to_be_invoked.CreateNPC( npcId );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                if(__gen_param_count == 3&& translator.Assignable<Neptune.NPC>(L, 2)&& translator.Assignable<Actor>(L, 3)) 
                {
                    Neptune.NPC npcInfo = (Neptune.NPC)translator.GetObject(L, 2, typeof(Neptune.NPC));
                    Actor parent = (Actor)translator.GetObject(L, 3, typeof(Actor));
                    
                        xc.UnitID __cl_gen_ret = __cl_gen_to_be_invoked.CreateNPC( npcInfo, parent );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                if(__gen_param_count == 2&& translator.Assignable<Neptune.NPC>(L, 2)) 
                {
                    Neptune.NPC npcInfo = (Neptune.NPC)translator.GetObject(L, 2, typeof(Neptune.NPC));
                    
                        xc.UnitID __cl_gen_ret = __cl_gen_to_be_invoked.CreateNPC( npcInfo );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to xc.NpcManager.CreateNPC!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetNpcByNpcId(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.NpcManager __cl_gen_to_be_invoked = (xc.NpcManager)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    uint npcId = LuaAPI.xlua_touint(L, 2);
                    
                        NpcPlayer __cl_gen_ret = __cl_gen_to_be_invoked.GetNpcByNpcId( npcId );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetNpcByNpcExcelId(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.NpcManager __cl_gen_to_be_invoked = (xc.NpcManager)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    uint npcExcelId = LuaAPI.xlua_touint(L, 2);
                    
                        NpcPlayer __cl_gen_ret = __cl_gen_to_be_invoked.GetNpcByNpcExcelId( npcExcelId );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetNpcPos_xlua_st_(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
            try {
                
                {
                    uint npcId = LuaAPI.xlua_touint(L, 1);
                    UnityEngine.Vector3 result;translator.Get(L, 2, out result);
                    
                        bool __cl_gen_ret = xc.NpcManager.GetNpcPos( npcId, ref result );
                        LuaAPI.lua_pushboolean(L, __cl_gen_ret);
                    translator.PushUnityEngineVector3(L, result);
                        translator.UpdateUnityEngineVector3(L, 2, result);
                        
                    
                    
                    
                    return 2;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetClosestNpc(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.NpcManager __cl_gen_to_be_invoked = (xc.NpcManager)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    Neptune.Relationship npcType;translator.Get(L, 2, out npcType);
                    
                        NpcPlayer __cl_gen_ret = __cl_gen_to_be_invoked.GetClosestNpc( npcType );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_NavigatingNpcId(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.NpcManager __cl_gen_to_be_invoked = (xc.NpcManager)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushuint(L, __cl_gen_to_be_invoked.NavigatingNpcId);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_AllNpc(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.NpcManager __cl_gen_to_be_invoked = (xc.NpcManager)translator.FastGetCSObj(L, 1);
                translator.Push(L, __cl_gen_to_be_invoked.AllNpc);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_TravelBootsJumpNpcId(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.NpcManager __cl_gen_to_be_invoked = (xc.NpcManager)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushuint(L, __cl_gen_to_be_invoked.TravelBootsJumpNpcId);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_NavigatingNpcId(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.NpcManager __cl_gen_to_be_invoked = (xc.NpcManager)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.NavigatingNpcId = LuaAPI.xlua_touint(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_TravelBootsJumpNpcId(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.NpcManager __cl_gen_to_be_invoked = (xc.NpcManager)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.TravelBootsJumpNpcId = LuaAPI.xlua_touint(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
		
		
		
		
    }
}
