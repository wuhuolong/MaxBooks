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
    public class xcWorshipModelWrap
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			XUtils.BeginObjectRegister(typeof(xc.WorshipModel), L, translator, 0, 4, 3, 3);
			
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "AfterCreate", _m_AfterCreate);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "InitBehaviors", _m_InitBehaviors);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "OnResLoaded", _m_OnResLoaded);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "Update", _m_Update);
			
			
			XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "RawUID", _g_get_RawUID);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "Rank", _g_get_Rank);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "GuildName", _g_get_GuildName);
            
			XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "RawUID", _s_set_RawUID);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "Rank", _s_set_Rank);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "GuildName", _s_set_GuildName);
            
			XUtils.EndObjectRegister(typeof(xc.WorshipModel), L, translator, null, null,
			    null, null, null);

		    XUtils.BeginClassRegister(typeof(xc.WorshipModel), L, __CreateInstance, 3, 0, 0);
			XUtils.RegisterFunc(L, XUtils.CLS_IDX, "ResetUUId", _m_ResetUUId_xlua_st_);
            XUtils.RegisterFunc(L, XUtils.CLS_IDX, "CreateWorshipModelForLua", _m_CreateWorshipModelForLua_xlua_st_);
            
			
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "UnderlyingSystemType", typeof(xc.WorshipModel));
			
			
			XUtils.EndClassRegister(typeof(xc.WorshipModel), L, translator);
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CreateInstance(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			try {
				if(LuaAPI.lua_gettop(L) == 1)
				{
					
					xc.WorshipModel __cl_gen_ret = new xc.WorshipModel();
					translator.Push(L, __cl_gen_ret);
					return 1;
				}
				
			}
			catch(System.Exception __gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
			}
            return LuaAPI.luaL_error(L, "invalid arguments to xc.WorshipModel constructor!");
            
        }
        
		
        
		
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_AfterCreate(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.WorshipModel __cl_gen_to_be_invoked = (xc.WorshipModel)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    
                    __cl_gen_to_be_invoked.AfterCreate(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_InitBehaviors(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.WorshipModel __cl_gen_to_be_invoked = (xc.WorshipModel)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    
                    __cl_gen_to_be_invoked.InitBehaviors(  );
                    
                    
                    
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
            
            
            xc.WorshipModel __cl_gen_to_be_invoked = (xc.WorshipModel)translator.FastGetCSObj(L, 1);
            
            
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
        static int _m_Update(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.WorshipModel __cl_gen_to_be_invoked = (xc.WorshipModel)translator.FastGetCSObj(L, 1);
            
            
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
        static int _m_ResetUUId_xlua_st_(RealStatePtr L)
        {
            
            
            
            try {
                
                {
                    
                    xc.WorshipModel.ResetUUId(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_CreateWorshipModelForLua_xlua_st_(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
			int __gen_param_count = LuaAPI.lua_gettop(L);
            
            try {
                if(__gen_param_count == 11&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 1)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 2)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 3)&& (LuaAPI.lua_isnil(L, 4) || LuaAPI.lua_type(L, 4) == LuaTypes.LUA_TSTRING)&& (LuaAPI.lua_isnil(L, 5) || LuaAPI.lua_type(L, 5) == LuaTypes.LUA_TSTRING)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 6)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 7)&& (LuaAPI.lua_isnil(L, 8) || LuaAPI.lua_type(L, 8) == LuaTypes.LUA_TTABLE)&& (LuaAPI.lua_isnil(L, 9) || LuaAPI.lua_type(L, 9) == LuaTypes.LUA_TTABLE)&& (LuaAPI.lua_isnil(L, 10) || LuaAPI.lua_type(L, 10) == LuaTypes.LUA_TTABLE)&& translator.Assignable<System.Action<Actor>>(L, 11)) 
                {
                    uint type_id = LuaAPI.xlua_touint(L, 1);
                    uint uid = LuaAPI.xlua_touint(L, 2);
                    uint rank = LuaAPI.xlua_touint(L, 3);
                    string name = LuaAPI.lua_tostring(L, 4);
                    string guildName = LuaAPI.lua_tostring(L, 5);
                    uint honor = LuaAPI.xlua_touint(L, 6);
                    uint title = LuaAPI.xlua_touint(L, 7);
                    XLua.LuaTable modIdLst = (XLua.LuaTable)translator.GetObject(L, 8, typeof(XLua.LuaTable));
                    XLua.LuaTable fashions = (XLua.LuaTable)translator.GetObject(L, 9, typeof(XLua.LuaTable));
                    XLua.LuaTable suit_effects = (XLua.LuaTable)translator.GetObject(L, 10, typeof(XLua.LuaTable));
                    System.Action<Actor> cbResLoad = translator.GetDelegate<System.Action<Actor>>(L, 11);
                    
                        xc.UnitID __cl_gen_ret = xc.WorshipModel.CreateWorshipModelForLua( type_id, uid, rank, name, guildName, honor, title, modIdLst, fashions, suit_effects, cbResLoad );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                if(__gen_param_count == 10&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 1)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 2)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 3)&& (LuaAPI.lua_isnil(L, 4) || LuaAPI.lua_type(L, 4) == LuaTypes.LUA_TSTRING)&& (LuaAPI.lua_isnil(L, 5) || LuaAPI.lua_type(L, 5) == LuaTypes.LUA_TSTRING)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 6)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 7)&& (LuaAPI.lua_isnil(L, 8) || LuaAPI.lua_type(L, 8) == LuaTypes.LUA_TTABLE)&& (LuaAPI.lua_isnil(L, 9) || LuaAPI.lua_type(L, 9) == LuaTypes.LUA_TTABLE)&& (LuaAPI.lua_isnil(L, 10) || LuaAPI.lua_type(L, 10) == LuaTypes.LUA_TTABLE)) 
                {
                    uint type_id = LuaAPI.xlua_touint(L, 1);
                    uint uid = LuaAPI.xlua_touint(L, 2);
                    uint rank = LuaAPI.xlua_touint(L, 3);
                    string name = LuaAPI.lua_tostring(L, 4);
                    string guildName = LuaAPI.lua_tostring(L, 5);
                    uint honor = LuaAPI.xlua_touint(L, 6);
                    uint title = LuaAPI.xlua_touint(L, 7);
                    XLua.LuaTable modIdLst = (XLua.LuaTable)translator.GetObject(L, 8, typeof(XLua.LuaTable));
                    XLua.LuaTable fashions = (XLua.LuaTable)translator.GetObject(L, 9, typeof(XLua.LuaTable));
                    XLua.LuaTable suit_effects = (XLua.LuaTable)translator.GetObject(L, 10, typeof(XLua.LuaTable));
                    
                        xc.UnitID __cl_gen_ret = xc.WorshipModel.CreateWorshipModelForLua( type_id, uid, rank, name, guildName, honor, title, modIdLst, fashions, suit_effects );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to xc.WorshipModel.CreateWorshipModelForLua!");
            
        }
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_RawUID(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.WorshipModel __cl_gen_to_be_invoked = (xc.WorshipModel)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushuint(L, __cl_gen_to_be_invoked.RawUID);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_Rank(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.WorshipModel __cl_gen_to_be_invoked = (xc.WorshipModel)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushuint(L, __cl_gen_to_be_invoked.Rank);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_GuildName(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.WorshipModel __cl_gen_to_be_invoked = (xc.WorshipModel)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushstring(L, __cl_gen_to_be_invoked.GuildName);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_RawUID(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.WorshipModel __cl_gen_to_be_invoked = (xc.WorshipModel)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.RawUID = LuaAPI.xlua_touint(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_Rank(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.WorshipModel __cl_gen_to_be_invoked = (xc.WorshipModel)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.Rank = LuaAPI.xlua_touint(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_GuildName(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.WorshipModel __cl_gen_to_be_invoked = (xc.WorshipModel)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.GuildName = LuaAPI.lua_tostring(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
		
		
		
		
    }
}
