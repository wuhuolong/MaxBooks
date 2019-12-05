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
    public class xcClientModelWrap
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			XUtils.BeginObjectRegister(typeof(xc.ClientModel), L, translator, 0, 2, 3, 3);
			
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "AfterCreate", _m_AfterCreate);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "IsClientModel", _m_IsClientModel);
			
			
			XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "IsRidePlayer", _g_get_IsRidePlayer);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "RawUID", _g_get_RawUID);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "UpdateWithRawActor", _g_get_UpdateWithRawActor);
            
			XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "IsRidePlayer", _s_set_IsRidePlayer);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "RawUID", _s_set_RawUID);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "UpdateWithRawActor", _s_set_UpdateWithRawActor);
            
			XUtils.EndObjectRegister(typeof(xc.ClientModel), L, translator, null, null,
			    null, null, null);

		    XUtils.BeginClassRegister(typeof(xc.ClientModel), L, __CreateInstance, 8, 0, 0);
			XUtils.RegisterFunc(L, XUtils.CLS_IDX, "CreateClientModel", _m_CreateClientModel_xlua_st_);
            XUtils.RegisterFunc(L, XUtils.CLS_IDX, "CreateClientModelByClone", _m_CreateClientModelByClone_xlua_st_);
            XUtils.RegisterFunc(L, XUtils.CLS_IDX, "CreateClientModelByCloneForLua", _m_CreateClientModelByCloneForLua_xlua_st_);
            XUtils.RegisterFunc(L, XUtils.CLS_IDX, "CheckResourceActorId", _m_CheckResourceActorId_xlua_st_);
            XUtils.RegisterFunc(L, XUtils.CLS_IDX, "HasExistResourceActorId", _m_HasExistResourceActorId_xlua_st_);
            XUtils.RegisterFunc(L, XUtils.CLS_IDX, "CreateClientModelByActorIdForLua", _m_CreateClientModelByActorIdForLua_xlua_st_);
            XUtils.RegisterFunc(L, XUtils.CLS_IDX, "CreateClientModelForLua", _m_CreateClientModelForLua_xlua_st_);
            
			
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "UnderlyingSystemType", typeof(xc.ClientModel));
			
			
			XUtils.EndClassRegister(typeof(xc.ClientModel), L, translator);
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CreateInstance(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			try {
				if(LuaAPI.lua_gettop(L) == 1)
				{
					
					xc.ClientModel __cl_gen_ret = new xc.ClientModel();
					translator.Push(L, __cl_gen_ret);
					return 1;
				}
				
			}
			catch(System.Exception __gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
			}
            return LuaAPI.luaL_error(L, "invalid arguments to xc.ClientModel constructor!");
            
        }
        
		
        
		
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_AfterCreate(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.ClientModel __cl_gen_to_be_invoked = (xc.ClientModel)translator.FastGetCSObj(L, 1);
            
            
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
        static int _m_IsClientModel(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.ClientModel __cl_gen_to_be_invoked = (xc.ClientModel)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    
                        bool __cl_gen_ret = __cl_gen_to_be_invoked.IsClientModel(  );
                        LuaAPI.lua_pushboolean(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_CreateClientModel_xlua_st_(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
			int __gen_param_count = LuaAPI.lua_gettop(L);
            
            try {
                if(__gen_param_count == 8&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 1)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 2)&& translator.Assignable<System.Collections.Generic.List<uint>>(L, 3)&& translator.Assignable<System.Collections.Generic.List<uint>>(L, 4)&& translator.Assignable<System.Collections.Generic.List<uint>>(L, 5)&& translator.Assignable<System.Action<Actor>>(L, 6)&& LuaTypes.LUA_TBOOLEAN == LuaAPI.lua_type(L, 7)&& LuaTypes.LUA_TBOOLEAN == LuaAPI.lua_type(L, 8)) 
                {
                    uint type_id = LuaAPI.xlua_touint(L, 1);
                    uint uid = LuaAPI.xlua_touint(L, 2);
                    System.Collections.Generic.List<uint> modleIdLst = (System.Collections.Generic.List<uint>)translator.GetObject(L, 3, typeof(System.Collections.Generic.List<uint>));
                    System.Collections.Generic.List<uint> fashions = (System.Collections.Generic.List<uint>)translator.GetObject(L, 4, typeof(System.Collections.Generic.List<uint>));
                    System.Collections.Generic.List<uint> suit_effects = (System.Collections.Generic.List<uint>)translator.GetObject(L, 5, typeof(System.Collections.Generic.List<uint>));
                    System.Action<Actor> cbResLoad = translator.GetDelegate<System.Action<Actor>>(L, 6);
                    bool updateWithRawActor = LuaAPI.lua_toboolean(L, 7);
                    bool isUIModel = LuaAPI.lua_toboolean(L, 8);
                    
                        xc.ClientModel __cl_gen_ret = xc.ClientModel.CreateClientModel( type_id, uid, modleIdLst, fashions, suit_effects, cbResLoad, updateWithRawActor, isUIModel );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                if(__gen_param_count == 7&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 1)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 2)&& translator.Assignable<System.Collections.Generic.List<uint>>(L, 3)&& translator.Assignable<System.Collections.Generic.List<uint>>(L, 4)&& translator.Assignable<System.Collections.Generic.List<uint>>(L, 5)&& translator.Assignable<System.Action<Actor>>(L, 6)&& LuaTypes.LUA_TBOOLEAN == LuaAPI.lua_type(L, 7)) 
                {
                    uint type_id = LuaAPI.xlua_touint(L, 1);
                    uint uid = LuaAPI.xlua_touint(L, 2);
                    System.Collections.Generic.List<uint> modleIdLst = (System.Collections.Generic.List<uint>)translator.GetObject(L, 3, typeof(System.Collections.Generic.List<uint>));
                    System.Collections.Generic.List<uint> fashions = (System.Collections.Generic.List<uint>)translator.GetObject(L, 4, typeof(System.Collections.Generic.List<uint>));
                    System.Collections.Generic.List<uint> suit_effects = (System.Collections.Generic.List<uint>)translator.GetObject(L, 5, typeof(System.Collections.Generic.List<uint>));
                    System.Action<Actor> cbResLoad = translator.GetDelegate<System.Action<Actor>>(L, 6);
                    bool updateWithRawActor = LuaAPI.lua_toboolean(L, 7);
                    
                        xc.ClientModel __cl_gen_ret = xc.ClientModel.CreateClientModel( type_id, uid, modleIdLst, fashions, suit_effects, cbResLoad, updateWithRawActor );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                if(__gen_param_count == 6&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 1)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 2)&& translator.Assignable<System.Collections.Generic.List<uint>>(L, 3)&& translator.Assignable<System.Collections.Generic.List<uint>>(L, 4)&& translator.Assignable<System.Collections.Generic.List<uint>>(L, 5)&& translator.Assignable<System.Action<Actor>>(L, 6)) 
                {
                    uint type_id = LuaAPI.xlua_touint(L, 1);
                    uint uid = LuaAPI.xlua_touint(L, 2);
                    System.Collections.Generic.List<uint> modleIdLst = (System.Collections.Generic.List<uint>)translator.GetObject(L, 3, typeof(System.Collections.Generic.List<uint>));
                    System.Collections.Generic.List<uint> fashions = (System.Collections.Generic.List<uint>)translator.GetObject(L, 4, typeof(System.Collections.Generic.List<uint>));
                    System.Collections.Generic.List<uint> suit_effects = (System.Collections.Generic.List<uint>)translator.GetObject(L, 5, typeof(System.Collections.Generic.List<uint>));
                    System.Action<Actor> cbResLoad = translator.GetDelegate<System.Action<Actor>>(L, 6);
                    
                        xc.ClientModel __cl_gen_ret = xc.ClientModel.CreateClientModel( type_id, uid, modleIdLst, fashions, suit_effects, cbResLoad );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                if(__gen_param_count == 5&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 1)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 2)&& translator.Assignable<System.Collections.Generic.List<uint>>(L, 3)&& translator.Assignable<System.Collections.Generic.List<uint>>(L, 4)&& translator.Assignable<System.Collections.Generic.List<uint>>(L, 5)) 
                {
                    uint type_id = LuaAPI.xlua_touint(L, 1);
                    uint uid = LuaAPI.xlua_touint(L, 2);
                    System.Collections.Generic.List<uint> modleIdLst = (System.Collections.Generic.List<uint>)translator.GetObject(L, 3, typeof(System.Collections.Generic.List<uint>));
                    System.Collections.Generic.List<uint> fashions = (System.Collections.Generic.List<uint>)translator.GetObject(L, 4, typeof(System.Collections.Generic.List<uint>));
                    System.Collections.Generic.List<uint> suit_effects = (System.Collections.Generic.List<uint>)translator.GetObject(L, 5, typeof(System.Collections.Generic.List<uint>));
                    
                        xc.ClientModel __cl_gen_ret = xc.ClientModel.CreateClientModel( type_id, uid, modleIdLst, fashions, suit_effects );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to xc.ClientModel.CreateClientModel!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_CreateClientModelByClone_xlua_st_(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
            try {
                
                {
                    Actor actor = (Actor)translator.GetObject(L, 1, typeof(Actor));
                    System.Action<Actor> actionAfterLoad = translator.GetDelegate<System.Action<Actor>>(L, 2);
                    
                        xc.ClientModel __cl_gen_ret = xc.ClientModel.CreateClientModelByClone( actor, actionAfterLoad );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_CreateClientModelByCloneForLua_xlua_st_(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
			int __gen_param_count = LuaAPI.lua_gettop(L);
            
            try {
                if(__gen_param_count == 4&& translator.Assignable<Actor>(L, 1)&& translator.Assignable<System.Action<Actor>>(L, 2)&& LuaTypes.LUA_TBOOLEAN == LuaAPI.lua_type(L, 3)&& LuaTypes.LUA_TBOOLEAN == LuaAPI.lua_type(L, 4)) 
                {
                    Actor actor = (Actor)translator.GetObject(L, 1, typeof(Actor));
                    System.Action<Actor> actionAfterLoad = translator.GetDelegate<System.Action<Actor>>(L, 2);
                    bool updateWithRawActor = LuaAPI.lua_toboolean(L, 3);
                    bool isUIModel = LuaAPI.lua_toboolean(L, 4);
                    
                        xc.UnitID __cl_gen_ret = xc.ClientModel.CreateClientModelByCloneForLua( actor, actionAfterLoad, updateWithRawActor, isUIModel );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                if(__gen_param_count == 3&& translator.Assignable<Actor>(L, 1)&& translator.Assignable<System.Action<Actor>>(L, 2)&& LuaTypes.LUA_TBOOLEAN == LuaAPI.lua_type(L, 3)) 
                {
                    Actor actor = (Actor)translator.GetObject(L, 1, typeof(Actor));
                    System.Action<Actor> actionAfterLoad = translator.GetDelegate<System.Action<Actor>>(L, 2);
                    bool updateWithRawActor = LuaAPI.lua_toboolean(L, 3);
                    
                        xc.UnitID __cl_gen_ret = xc.ClientModel.CreateClientModelByCloneForLua( actor, actionAfterLoad, updateWithRawActor );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                if(__gen_param_count == 2&& translator.Assignable<Actor>(L, 1)&& translator.Assignable<System.Action<Actor>>(L, 2)) 
                {
                    Actor actor = (Actor)translator.GetObject(L, 1, typeof(Actor));
                    System.Action<Actor> actionAfterLoad = translator.GetDelegate<System.Action<Actor>>(L, 2);
                    
                        xc.UnitID __cl_gen_ret = xc.ClientModel.CreateClientModelByCloneForLua( actor, actionAfterLoad );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to xc.ClientModel.CreateClientModelByCloneForLua!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_CheckResourceActorId_xlua_st_(RealStatePtr L)
        {
            
            
            
            try {
                
                {
                    uint actorId = LuaAPI.xlua_touint(L, 1);
                    
                        uint __cl_gen_ret = xc.ClientModel.CheckResourceActorId( actorId );
                        LuaAPI.xlua_pushuint(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_HasExistResourceActorId_xlua_st_(RealStatePtr L)
        {
            
            
            
            try {
                
                {
                    uint actorId = LuaAPI.xlua_touint(L, 1);
                    
                        bool __cl_gen_ret = xc.ClientModel.HasExistResourceActorId( actorId );
                        LuaAPI.lua_pushboolean(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_CreateClientModelByActorIdForLua_xlua_st_(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
			int __gen_param_count = LuaAPI.lua_gettop(L);
            
            try {
                if(__gen_param_count == 3&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 1)&& translator.Assignable<System.Action<Actor>>(L, 2)&& LuaTypes.LUA_TBOOLEAN == LuaAPI.lua_type(L, 3)) 
                {
                    uint actorId = LuaAPI.xlua_touint(L, 1);
                    System.Action<Actor> actionAfterLoad = translator.GetDelegate<System.Action<Actor>>(L, 2);
                    bool is_ui_model = LuaAPI.lua_toboolean(L, 3);
                    
                        xc.UnitID __cl_gen_ret = xc.ClientModel.CreateClientModelByActorIdForLua( actorId, actionAfterLoad, is_ui_model );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                if(__gen_param_count == 2&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 1)&& translator.Assignable<System.Action<Actor>>(L, 2)) 
                {
                    uint actorId = LuaAPI.xlua_touint(L, 1);
                    System.Action<Actor> actionAfterLoad = translator.GetDelegate<System.Action<Actor>>(L, 2);
                    
                        xc.UnitID __cl_gen_ret = xc.ClientModel.CreateClientModelByActorIdForLua( actorId, actionAfterLoad );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to xc.ClientModel.CreateClientModelByActorIdForLua!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_CreateClientModelForLua_xlua_st_(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
			int __gen_param_count = LuaAPI.lua_gettop(L);
            
            try {
                if(__gen_param_count == 9&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 1)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 2)&& (LuaAPI.lua_isnil(L, 3) || LuaAPI.lua_type(L, 3) == LuaTypes.LUA_TTABLE)&& (LuaAPI.lua_isnil(L, 4) || LuaAPI.lua_type(L, 4) == LuaTypes.LUA_TTABLE)&& (LuaAPI.lua_isnil(L, 5) || LuaAPI.lua_type(L, 5) == LuaTypes.LUA_TTABLE)&& translator.Assignable<System.Action<Actor>>(L, 6)&& (LuaAPI.lua_isnil(L, 7) || LuaAPI.lua_type(L, 7) == LuaTypes.LUA_TTABLE)&& LuaTypes.LUA_TBOOLEAN == LuaAPI.lua_type(L, 8)&& LuaTypes.LUA_TBOOLEAN == LuaAPI.lua_type(L, 9)) 
                {
                    uint type_id = LuaAPI.xlua_touint(L, 1);
                    uint uid = LuaAPI.xlua_touint(L, 2);
                    XLua.LuaTable modIdLst = (XLua.LuaTable)translator.GetObject(L, 3, typeof(XLua.LuaTable));
                    XLua.LuaTable fashions = (XLua.LuaTable)translator.GetObject(L, 4, typeof(XLua.LuaTable));
                    XLua.LuaTable suit_effects = (XLua.LuaTable)translator.GetObject(L, 5, typeof(XLua.LuaTable));
                    System.Action<Actor> cbResLoad = translator.GetDelegate<System.Action<Actor>>(L, 6);
                    XLua.LuaTable no_show_parts = (XLua.LuaTable)translator.GetObject(L, 7, typeof(XLua.LuaTable));
                    bool is_ui_model = LuaAPI.lua_toboolean(L, 8);
                    bool updateWithRawActor = LuaAPI.lua_toboolean(L, 9);
                    
                        xc.UnitID __cl_gen_ret = xc.ClientModel.CreateClientModelForLua( type_id, uid, modIdLst, fashions, suit_effects, cbResLoad, no_show_parts, is_ui_model, updateWithRawActor );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                if(__gen_param_count == 8&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 1)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 2)&& (LuaAPI.lua_isnil(L, 3) || LuaAPI.lua_type(L, 3) == LuaTypes.LUA_TTABLE)&& (LuaAPI.lua_isnil(L, 4) || LuaAPI.lua_type(L, 4) == LuaTypes.LUA_TTABLE)&& (LuaAPI.lua_isnil(L, 5) || LuaAPI.lua_type(L, 5) == LuaTypes.LUA_TTABLE)&& translator.Assignable<System.Action<Actor>>(L, 6)&& (LuaAPI.lua_isnil(L, 7) || LuaAPI.lua_type(L, 7) == LuaTypes.LUA_TTABLE)&& LuaTypes.LUA_TBOOLEAN == LuaAPI.lua_type(L, 8)) 
                {
                    uint type_id = LuaAPI.xlua_touint(L, 1);
                    uint uid = LuaAPI.xlua_touint(L, 2);
                    XLua.LuaTable modIdLst = (XLua.LuaTable)translator.GetObject(L, 3, typeof(XLua.LuaTable));
                    XLua.LuaTable fashions = (XLua.LuaTable)translator.GetObject(L, 4, typeof(XLua.LuaTable));
                    XLua.LuaTable suit_effects = (XLua.LuaTable)translator.GetObject(L, 5, typeof(XLua.LuaTable));
                    System.Action<Actor> cbResLoad = translator.GetDelegate<System.Action<Actor>>(L, 6);
                    XLua.LuaTable no_show_parts = (XLua.LuaTable)translator.GetObject(L, 7, typeof(XLua.LuaTable));
                    bool is_ui_model = LuaAPI.lua_toboolean(L, 8);
                    
                        xc.UnitID __cl_gen_ret = xc.ClientModel.CreateClientModelForLua( type_id, uid, modIdLst, fashions, suit_effects, cbResLoad, no_show_parts, is_ui_model );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                if(__gen_param_count == 7&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 1)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 2)&& (LuaAPI.lua_isnil(L, 3) || LuaAPI.lua_type(L, 3) == LuaTypes.LUA_TTABLE)&& (LuaAPI.lua_isnil(L, 4) || LuaAPI.lua_type(L, 4) == LuaTypes.LUA_TTABLE)&& (LuaAPI.lua_isnil(L, 5) || LuaAPI.lua_type(L, 5) == LuaTypes.LUA_TTABLE)&& translator.Assignable<System.Action<Actor>>(L, 6)&& (LuaAPI.lua_isnil(L, 7) || LuaAPI.lua_type(L, 7) == LuaTypes.LUA_TTABLE)) 
                {
                    uint type_id = LuaAPI.xlua_touint(L, 1);
                    uint uid = LuaAPI.xlua_touint(L, 2);
                    XLua.LuaTable modIdLst = (XLua.LuaTable)translator.GetObject(L, 3, typeof(XLua.LuaTable));
                    XLua.LuaTable fashions = (XLua.LuaTable)translator.GetObject(L, 4, typeof(XLua.LuaTable));
                    XLua.LuaTable suit_effects = (XLua.LuaTable)translator.GetObject(L, 5, typeof(XLua.LuaTable));
                    System.Action<Actor> cbResLoad = translator.GetDelegate<System.Action<Actor>>(L, 6);
                    XLua.LuaTable no_show_parts = (XLua.LuaTable)translator.GetObject(L, 7, typeof(XLua.LuaTable));
                    
                        xc.UnitID __cl_gen_ret = xc.ClientModel.CreateClientModelForLua( type_id, uid, modIdLst, fashions, suit_effects, cbResLoad, no_show_parts );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                if(__gen_param_count == 6&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 1)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 2)&& (LuaAPI.lua_isnil(L, 3) || LuaAPI.lua_type(L, 3) == LuaTypes.LUA_TTABLE)&& (LuaAPI.lua_isnil(L, 4) || LuaAPI.lua_type(L, 4) == LuaTypes.LUA_TTABLE)&& (LuaAPI.lua_isnil(L, 5) || LuaAPI.lua_type(L, 5) == LuaTypes.LUA_TTABLE)&& translator.Assignable<System.Action<Actor>>(L, 6)) 
                {
                    uint type_id = LuaAPI.xlua_touint(L, 1);
                    uint uid = LuaAPI.xlua_touint(L, 2);
                    XLua.LuaTable modIdLst = (XLua.LuaTable)translator.GetObject(L, 3, typeof(XLua.LuaTable));
                    XLua.LuaTable fashions = (XLua.LuaTable)translator.GetObject(L, 4, typeof(XLua.LuaTable));
                    XLua.LuaTable suit_effects = (XLua.LuaTable)translator.GetObject(L, 5, typeof(XLua.LuaTable));
                    System.Action<Actor> cbResLoad = translator.GetDelegate<System.Action<Actor>>(L, 6);
                    
                        xc.UnitID __cl_gen_ret = xc.ClientModel.CreateClientModelForLua( type_id, uid, modIdLst, fashions, suit_effects, cbResLoad );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                if(__gen_param_count == 5&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 1)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 2)&& (LuaAPI.lua_isnil(L, 3) || LuaAPI.lua_type(L, 3) == LuaTypes.LUA_TTABLE)&& (LuaAPI.lua_isnil(L, 4) || LuaAPI.lua_type(L, 4) == LuaTypes.LUA_TTABLE)&& (LuaAPI.lua_isnil(L, 5) || LuaAPI.lua_type(L, 5) == LuaTypes.LUA_TTABLE)) 
                {
                    uint type_id = LuaAPI.xlua_touint(L, 1);
                    uint uid = LuaAPI.xlua_touint(L, 2);
                    XLua.LuaTable modIdLst = (XLua.LuaTable)translator.GetObject(L, 3, typeof(XLua.LuaTable));
                    XLua.LuaTable fashions = (XLua.LuaTable)translator.GetObject(L, 4, typeof(XLua.LuaTable));
                    XLua.LuaTable suit_effects = (XLua.LuaTable)translator.GetObject(L, 5, typeof(XLua.LuaTable));
                    
                        xc.UnitID __cl_gen_ret = xc.ClientModel.CreateClientModelForLua( type_id, uid, modIdLst, fashions, suit_effects );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                if(__gen_param_count == 9&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 1)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 2)&& translator.Assignable<System.Collections.Generic.List<uint>>(L, 3)&& translator.Assignable<System.Collections.Generic.List<uint>>(L, 4)&& translator.Assignable<System.Collections.Generic.List<uint>>(L, 5)&& translator.Assignable<System.Action<Actor>>(L, 6)&& translator.Assignable<System.Collections.Generic.List<xc.DBAvatarPart.BODY_PART>>(L, 7)&& LuaTypes.LUA_TBOOLEAN == LuaAPI.lua_type(L, 8)&& LuaTypes.LUA_TBOOLEAN == LuaAPI.lua_type(L, 9)) 
                {
                    uint type_id = LuaAPI.xlua_touint(L, 1);
                    uint uid = LuaAPI.xlua_touint(L, 2);
                    System.Collections.Generic.List<uint> modIdLst = (System.Collections.Generic.List<uint>)translator.GetObject(L, 3, typeof(System.Collections.Generic.List<uint>));
                    System.Collections.Generic.List<uint> fashions = (System.Collections.Generic.List<uint>)translator.GetObject(L, 4, typeof(System.Collections.Generic.List<uint>));
                    System.Collections.Generic.List<uint> suit_effects = (System.Collections.Generic.List<uint>)translator.GetObject(L, 5, typeof(System.Collections.Generic.List<uint>));
                    System.Action<Actor> cbResLoad = translator.GetDelegate<System.Action<Actor>>(L, 6);
                    System.Collections.Generic.List<xc.DBAvatarPart.BODY_PART> no_show_parts = (System.Collections.Generic.List<xc.DBAvatarPart.BODY_PART>)translator.GetObject(L, 7, typeof(System.Collections.Generic.List<xc.DBAvatarPart.BODY_PART>));
                    bool is_ui_model = LuaAPI.lua_toboolean(L, 8);
                    bool updateWithRawActor = LuaAPI.lua_toboolean(L, 9);
                    
                        xc.UnitID __cl_gen_ret = xc.ClientModel.CreateClientModelForLua( type_id, uid, modIdLst, fashions, suit_effects, cbResLoad, no_show_parts, is_ui_model, updateWithRawActor );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                if(__gen_param_count == 8&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 1)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 2)&& translator.Assignable<System.Collections.Generic.List<uint>>(L, 3)&& translator.Assignable<System.Collections.Generic.List<uint>>(L, 4)&& translator.Assignable<System.Collections.Generic.List<uint>>(L, 5)&& translator.Assignable<System.Action<Actor>>(L, 6)&& translator.Assignable<System.Collections.Generic.List<xc.DBAvatarPart.BODY_PART>>(L, 7)&& LuaTypes.LUA_TBOOLEAN == LuaAPI.lua_type(L, 8)) 
                {
                    uint type_id = LuaAPI.xlua_touint(L, 1);
                    uint uid = LuaAPI.xlua_touint(L, 2);
                    System.Collections.Generic.List<uint> modIdLst = (System.Collections.Generic.List<uint>)translator.GetObject(L, 3, typeof(System.Collections.Generic.List<uint>));
                    System.Collections.Generic.List<uint> fashions = (System.Collections.Generic.List<uint>)translator.GetObject(L, 4, typeof(System.Collections.Generic.List<uint>));
                    System.Collections.Generic.List<uint> suit_effects = (System.Collections.Generic.List<uint>)translator.GetObject(L, 5, typeof(System.Collections.Generic.List<uint>));
                    System.Action<Actor> cbResLoad = translator.GetDelegate<System.Action<Actor>>(L, 6);
                    System.Collections.Generic.List<xc.DBAvatarPart.BODY_PART> no_show_parts = (System.Collections.Generic.List<xc.DBAvatarPart.BODY_PART>)translator.GetObject(L, 7, typeof(System.Collections.Generic.List<xc.DBAvatarPart.BODY_PART>));
                    bool is_ui_model = LuaAPI.lua_toboolean(L, 8);
                    
                        xc.UnitID __cl_gen_ret = xc.ClientModel.CreateClientModelForLua( type_id, uid, modIdLst, fashions, suit_effects, cbResLoad, no_show_parts, is_ui_model );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                if(__gen_param_count == 7&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 1)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 2)&& translator.Assignable<System.Collections.Generic.List<uint>>(L, 3)&& translator.Assignable<System.Collections.Generic.List<uint>>(L, 4)&& translator.Assignable<System.Collections.Generic.List<uint>>(L, 5)&& translator.Assignable<System.Action<Actor>>(L, 6)&& translator.Assignable<System.Collections.Generic.List<xc.DBAvatarPart.BODY_PART>>(L, 7)) 
                {
                    uint type_id = LuaAPI.xlua_touint(L, 1);
                    uint uid = LuaAPI.xlua_touint(L, 2);
                    System.Collections.Generic.List<uint> modIdLst = (System.Collections.Generic.List<uint>)translator.GetObject(L, 3, typeof(System.Collections.Generic.List<uint>));
                    System.Collections.Generic.List<uint> fashions = (System.Collections.Generic.List<uint>)translator.GetObject(L, 4, typeof(System.Collections.Generic.List<uint>));
                    System.Collections.Generic.List<uint> suit_effects = (System.Collections.Generic.List<uint>)translator.GetObject(L, 5, typeof(System.Collections.Generic.List<uint>));
                    System.Action<Actor> cbResLoad = translator.GetDelegate<System.Action<Actor>>(L, 6);
                    System.Collections.Generic.List<xc.DBAvatarPart.BODY_PART> no_show_parts = (System.Collections.Generic.List<xc.DBAvatarPart.BODY_PART>)translator.GetObject(L, 7, typeof(System.Collections.Generic.List<xc.DBAvatarPart.BODY_PART>));
                    
                        xc.UnitID __cl_gen_ret = xc.ClientModel.CreateClientModelForLua( type_id, uid, modIdLst, fashions, suit_effects, cbResLoad, no_show_parts );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                if(__gen_param_count == 6&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 1)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 2)&& translator.Assignable<System.Collections.Generic.List<uint>>(L, 3)&& translator.Assignable<System.Collections.Generic.List<uint>>(L, 4)&& translator.Assignable<System.Collections.Generic.List<uint>>(L, 5)&& translator.Assignable<System.Action<Actor>>(L, 6)) 
                {
                    uint type_id = LuaAPI.xlua_touint(L, 1);
                    uint uid = LuaAPI.xlua_touint(L, 2);
                    System.Collections.Generic.List<uint> modIdLst = (System.Collections.Generic.List<uint>)translator.GetObject(L, 3, typeof(System.Collections.Generic.List<uint>));
                    System.Collections.Generic.List<uint> fashions = (System.Collections.Generic.List<uint>)translator.GetObject(L, 4, typeof(System.Collections.Generic.List<uint>));
                    System.Collections.Generic.List<uint> suit_effects = (System.Collections.Generic.List<uint>)translator.GetObject(L, 5, typeof(System.Collections.Generic.List<uint>));
                    System.Action<Actor> cbResLoad = translator.GetDelegate<System.Action<Actor>>(L, 6);
                    
                        xc.UnitID __cl_gen_ret = xc.ClientModel.CreateClientModelForLua( type_id, uid, modIdLst, fashions, suit_effects, cbResLoad );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                if(__gen_param_count == 5&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 1)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 2)&& translator.Assignable<System.Collections.Generic.List<uint>>(L, 3)&& translator.Assignable<System.Collections.Generic.List<uint>>(L, 4)&& translator.Assignable<System.Collections.Generic.List<uint>>(L, 5)) 
                {
                    uint type_id = LuaAPI.xlua_touint(L, 1);
                    uint uid = LuaAPI.xlua_touint(L, 2);
                    System.Collections.Generic.List<uint> modIdLst = (System.Collections.Generic.List<uint>)translator.GetObject(L, 3, typeof(System.Collections.Generic.List<uint>));
                    System.Collections.Generic.List<uint> fashions = (System.Collections.Generic.List<uint>)translator.GetObject(L, 4, typeof(System.Collections.Generic.List<uint>));
                    System.Collections.Generic.List<uint> suit_effects = (System.Collections.Generic.List<uint>)translator.GetObject(L, 5, typeof(System.Collections.Generic.List<uint>));
                    
                        xc.UnitID __cl_gen_ret = xc.ClientModel.CreateClientModelForLua( type_id, uid, modIdLst, fashions, suit_effects );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to xc.ClientModel.CreateClientModelForLua!");
            
        }
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_IsRidePlayer(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.ClientModel __cl_gen_to_be_invoked = (xc.ClientModel)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, __cl_gen_to_be_invoked.IsRidePlayer);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_RawUID(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.ClientModel __cl_gen_to_be_invoked = (xc.ClientModel)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushuint(L, __cl_gen_to_be_invoked.RawUID);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_UpdateWithRawActor(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.ClientModel __cl_gen_to_be_invoked = (xc.ClientModel)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, __cl_gen_to_be_invoked.UpdateWithRawActor);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_IsRidePlayer(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.ClientModel __cl_gen_to_be_invoked = (xc.ClientModel)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.IsRidePlayer = LuaAPI.lua_toboolean(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_RawUID(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.ClientModel __cl_gen_to_be_invoked = (xc.ClientModel)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.RawUID = LuaAPI.xlua_touint(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_UpdateWithRawActor(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.ClientModel __cl_gen_to_be_invoked = (xc.ClientModel)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.UpdateWithRawActor = LuaAPI.lua_toboolean(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
		
		
		
		
    }
}
