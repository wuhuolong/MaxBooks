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
    public class xcActorAttributeDataWrap
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			XUtils.BeginObjectRegister(typeof(xc.ActorAttributeData), L, translator, 0, 3, 30, 29);
			
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "InitAttributeData", _m_InitAttributeData);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "Copy", _m_Copy);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "Clear", _m_Clear);
			
			
			XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "HP", _g_get_HP);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "MP", _g_get_MP);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "HPMax", _g_get_HPMax);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "MPMax", _g_get_MPMax);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "AttackSpeed", _g_get_AttackSpeed);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "AttackSpeedComb", _g_get_AttackSpeedComb);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "MoveSpeedScale", _g_get_MoveSpeedScale);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "MoveSpeedAdd", _g_get_MoveSpeedAdd);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "BattlePower", _g_get_BattlePower);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "UnitId", _g_get_UnitId);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "Name", _g_get_Name);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "Level", _g_get_Level);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "TeamId", _g_get_TeamId);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "GuildId", _g_get_GuildId);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "GuildName", _g_get_GuildName);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "Camp", _g_get_Camp);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "State", _g_get_State);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "Honor", _g_get_Honor);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "Title", _g_get_Title);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "EscortId", _g_get_EscortId);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "TransferLv", _g_get_TransferLv);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "Vocation", _g_get_Vocation);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "BehaviourTree", _g_get_BehaviourTree);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "SummonBehaviourTree", _g_get_SummonBehaviourTree);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "DefaultMotionRadius", _g_get_DefaultMotionRadius);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "WarTag", _g_get_WarTag);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "AttackRotaion", _g_get_AttackRotaion);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "Quality", _g_get_Quality);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "Gravity", _g_get_Gravity);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "Attribute", _g_get_Attribute);
            
			XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "HP", _s_set_HP);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "MP", _s_set_MP);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "HPMax", _s_set_HPMax);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "MPMax", _s_set_MPMax);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "AttackSpeed", _s_set_AttackSpeed);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "MoveSpeedScale", _s_set_MoveSpeedScale);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "MoveSpeedAdd", _s_set_MoveSpeedAdd);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "BattlePower", _s_set_BattlePower);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "UnitId", _s_set_UnitId);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "Name", _s_set_Name);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "Level", _s_set_Level);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "TeamId", _s_set_TeamId);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "GuildId", _s_set_GuildId);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "GuildName", _s_set_GuildName);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "Camp", _s_set_Camp);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "State", _s_set_State);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "Honor", _s_set_Honor);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "Title", _s_set_Title);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "EscortId", _s_set_EscortId);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "TransferLv", _s_set_TransferLv);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "Vocation", _s_set_Vocation);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "BehaviourTree", _s_set_BehaviourTree);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "SummonBehaviourTree", _s_set_SummonBehaviourTree);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "DefaultMotionRadius", _s_set_DefaultMotionRadius);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "WarTag", _s_set_WarTag);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "AttackRotaion", _s_set_AttackRotaion);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "Quality", _s_set_Quality);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "Gravity", _s_set_Gravity);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "Attribute", _s_set_Attribute);
            
			XUtils.EndObjectRegister(typeof(xc.ActorAttributeData), L, translator, null, null,
			    null, null, null);

		    XUtils.BeginClassRegister(typeof(xc.ActorAttributeData), L, __CreateInstance, 1, 0, 0);
			
			
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "UnderlyingSystemType", typeof(xc.ActorAttributeData));
			
			
			XUtils.EndClassRegister(typeof(xc.ActorAttributeData), L, translator);
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CreateInstance(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			try {
				if(LuaAPI.lua_gettop(L) == 1)
				{
					
					xc.ActorAttributeData __cl_gen_ret = new xc.ActorAttributeData();
					translator.Push(L, __cl_gen_ret);
					return 1;
				}
				
			}
			catch(System.Exception __gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
			}
            return LuaAPI.luaL_error(L, "invalid arguments to xc.ActorAttributeData constructor!");
            
        }
        
		
        
		
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_InitAttributeData(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.ActorAttributeData __cl_gen_to_be_invoked = (xc.ActorAttributeData)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    uint type_id = LuaAPI.xlua_touint(L, 2);
                    
                    __cl_gen_to_be_invoked.InitAttributeData( type_id );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Copy(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.ActorAttributeData __cl_gen_to_be_invoked = (xc.ActorAttributeData)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    xc.ActorAttributeData at = (xc.ActorAttributeData)translator.GetObject(L, 2, typeof(xc.ActorAttributeData));
                    
                    __cl_gen_to_be_invoked.Copy( at );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Clear(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.ActorAttributeData __cl_gen_to_be_invoked = (xc.ActorAttributeData)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    
                    __cl_gen_to_be_invoked.Clear(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_HP(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.ActorAttributeData __cl_gen_to_be_invoked = (xc.ActorAttributeData)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushint64(L, __cl_gen_to_be_invoked.HP);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_MP(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.ActorAttributeData __cl_gen_to_be_invoked = (xc.ActorAttributeData)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushint64(L, __cl_gen_to_be_invoked.MP);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_HPMax(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.ActorAttributeData __cl_gen_to_be_invoked = (xc.ActorAttributeData)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushint64(L, __cl_gen_to_be_invoked.HPMax);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_MPMax(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.ActorAttributeData __cl_gen_to_be_invoked = (xc.ActorAttributeData)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushint64(L, __cl_gen_to_be_invoked.MPMax);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_AttackSpeed(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.ActorAttributeData __cl_gen_to_be_invoked = (xc.ActorAttributeData)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushinteger(L, __cl_gen_to_be_invoked.AttackSpeed);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_AttackSpeedComb(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.ActorAttributeData __cl_gen_to_be_invoked = (xc.ActorAttributeData)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushnumber(L, __cl_gen_to_be_invoked.AttackSpeedComb);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_MoveSpeedScale(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.ActorAttributeData __cl_gen_to_be_invoked = (xc.ActorAttributeData)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushinteger(L, __cl_gen_to_be_invoked.MoveSpeedScale);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_MoveSpeedAdd(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.ActorAttributeData __cl_gen_to_be_invoked = (xc.ActorAttributeData)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushinteger(L, __cl_gen_to_be_invoked.MoveSpeedAdd);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_BattlePower(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.ActorAttributeData __cl_gen_to_be_invoked = (xc.ActorAttributeData)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushint64(L, __cl_gen_to_be_invoked.BattlePower);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_UnitId(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.ActorAttributeData __cl_gen_to_be_invoked = (xc.ActorAttributeData)translator.FastGetCSObj(L, 1);
                translator.Push(L, __cl_gen_to_be_invoked.UnitId);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_Name(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.ActorAttributeData __cl_gen_to_be_invoked = (xc.ActorAttributeData)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushstring(L, __cl_gen_to_be_invoked.Name);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_Level(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.ActorAttributeData __cl_gen_to_be_invoked = (xc.ActorAttributeData)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushuint(L, __cl_gen_to_be_invoked.Level);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_TeamId(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.ActorAttributeData __cl_gen_to_be_invoked = (xc.ActorAttributeData)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushuint(L, __cl_gen_to_be_invoked.TeamId);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_GuildId(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.ActorAttributeData __cl_gen_to_be_invoked = (xc.ActorAttributeData)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushuint(L, __cl_gen_to_be_invoked.GuildId);
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
			
                xc.ActorAttributeData __cl_gen_to_be_invoked = (xc.ActorAttributeData)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushstring(L, __cl_gen_to_be_invoked.GuildName);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_Camp(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.ActorAttributeData __cl_gen_to_be_invoked = (xc.ActorAttributeData)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushuint(L, __cl_gen_to_be_invoked.Camp);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_State(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.ActorAttributeData __cl_gen_to_be_invoked = (xc.ActorAttributeData)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushuint(L, __cl_gen_to_be_invoked.State);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_Honor(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.ActorAttributeData __cl_gen_to_be_invoked = (xc.ActorAttributeData)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushuint(L, __cl_gen_to_be_invoked.Honor);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_Title(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.ActorAttributeData __cl_gen_to_be_invoked = (xc.ActorAttributeData)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushuint(L, __cl_gen_to_be_invoked.Title);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_EscortId(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.ActorAttributeData __cl_gen_to_be_invoked = (xc.ActorAttributeData)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushuint(L, __cl_gen_to_be_invoked.EscortId);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_TransferLv(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.ActorAttributeData __cl_gen_to_be_invoked = (xc.ActorAttributeData)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushuint(L, __cl_gen_to_be_invoked.TransferLv);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_Vocation(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.ActorAttributeData __cl_gen_to_be_invoked = (xc.ActorAttributeData)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushuint(L, __cl_gen_to_be_invoked.Vocation);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_BehaviourTree(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.ActorAttributeData __cl_gen_to_be_invoked = (xc.ActorAttributeData)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushstring(L, __cl_gen_to_be_invoked.BehaviourTree);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_SummonBehaviourTree(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.ActorAttributeData __cl_gen_to_be_invoked = (xc.ActorAttributeData)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushstring(L, __cl_gen_to_be_invoked.SummonBehaviourTree);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_DefaultMotionRadius(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.ActorAttributeData __cl_gen_to_be_invoked = (xc.ActorAttributeData)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushinteger(L, __cl_gen_to_be_invoked.DefaultMotionRadius);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_WarTag(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.ActorAttributeData __cl_gen_to_be_invoked = (xc.ActorAttributeData)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushinteger(L, __cl_gen_to_be_invoked.WarTag);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_AttackRotaion(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.ActorAttributeData __cl_gen_to_be_invoked = (xc.ActorAttributeData)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushuint(L, __cl_gen_to_be_invoked.AttackRotaion);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_Quality(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.ActorAttributeData __cl_gen_to_be_invoked = (xc.ActorAttributeData)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushuint(L, __cl_gen_to_be_invoked.Quality);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_Gravity(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.ActorAttributeData __cl_gen_to_be_invoked = (xc.ActorAttributeData)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushinteger(L, __cl_gen_to_be_invoked.Gravity);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_Attribute(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.ActorAttributeData __cl_gen_to_be_invoked = (xc.ActorAttributeData)translator.FastGetCSObj(L, 1);
                translator.Push(L, __cl_gen_to_be_invoked.Attribute);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_HP(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.ActorAttributeData __cl_gen_to_be_invoked = (xc.ActorAttributeData)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.HP = LuaAPI.lua_toint64(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_MP(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.ActorAttributeData __cl_gen_to_be_invoked = (xc.ActorAttributeData)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.MP = LuaAPI.lua_toint64(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_HPMax(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.ActorAttributeData __cl_gen_to_be_invoked = (xc.ActorAttributeData)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.HPMax = LuaAPI.lua_toint64(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_MPMax(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.ActorAttributeData __cl_gen_to_be_invoked = (xc.ActorAttributeData)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.MPMax = LuaAPI.lua_toint64(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_AttackSpeed(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.ActorAttributeData __cl_gen_to_be_invoked = (xc.ActorAttributeData)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.AttackSpeed = LuaAPI.xlua_tointeger(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_MoveSpeedScale(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.ActorAttributeData __cl_gen_to_be_invoked = (xc.ActorAttributeData)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.MoveSpeedScale = LuaAPI.xlua_tointeger(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_MoveSpeedAdd(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.ActorAttributeData __cl_gen_to_be_invoked = (xc.ActorAttributeData)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.MoveSpeedAdd = LuaAPI.xlua_tointeger(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_BattlePower(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.ActorAttributeData __cl_gen_to_be_invoked = (xc.ActorAttributeData)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.BattlePower = LuaAPI.lua_toint64(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_UnitId(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.ActorAttributeData __cl_gen_to_be_invoked = (xc.ActorAttributeData)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.UnitId = (xc.UnitID)translator.GetObject(L, 2, typeof(xc.UnitID));
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_Name(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.ActorAttributeData __cl_gen_to_be_invoked = (xc.ActorAttributeData)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.Name = LuaAPI.lua_tostring(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_Level(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.ActorAttributeData __cl_gen_to_be_invoked = (xc.ActorAttributeData)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.Level = LuaAPI.xlua_touint(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_TeamId(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.ActorAttributeData __cl_gen_to_be_invoked = (xc.ActorAttributeData)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.TeamId = LuaAPI.xlua_touint(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_GuildId(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.ActorAttributeData __cl_gen_to_be_invoked = (xc.ActorAttributeData)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.GuildId = LuaAPI.xlua_touint(L, 2);
            
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
			
                xc.ActorAttributeData __cl_gen_to_be_invoked = (xc.ActorAttributeData)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.GuildName = LuaAPI.lua_tostring(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_Camp(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.ActorAttributeData __cl_gen_to_be_invoked = (xc.ActorAttributeData)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.Camp = LuaAPI.xlua_touint(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_State(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.ActorAttributeData __cl_gen_to_be_invoked = (xc.ActorAttributeData)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.State = LuaAPI.xlua_touint(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_Honor(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.ActorAttributeData __cl_gen_to_be_invoked = (xc.ActorAttributeData)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.Honor = LuaAPI.xlua_touint(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_Title(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.ActorAttributeData __cl_gen_to_be_invoked = (xc.ActorAttributeData)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.Title = LuaAPI.xlua_touint(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_EscortId(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.ActorAttributeData __cl_gen_to_be_invoked = (xc.ActorAttributeData)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.EscortId = LuaAPI.xlua_touint(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_TransferLv(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.ActorAttributeData __cl_gen_to_be_invoked = (xc.ActorAttributeData)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.TransferLv = LuaAPI.xlua_touint(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_Vocation(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.ActorAttributeData __cl_gen_to_be_invoked = (xc.ActorAttributeData)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.Vocation = LuaAPI.xlua_touint(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_BehaviourTree(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.ActorAttributeData __cl_gen_to_be_invoked = (xc.ActorAttributeData)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.BehaviourTree = LuaAPI.lua_tostring(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_SummonBehaviourTree(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.ActorAttributeData __cl_gen_to_be_invoked = (xc.ActorAttributeData)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.SummonBehaviourTree = LuaAPI.lua_tostring(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_DefaultMotionRadius(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.ActorAttributeData __cl_gen_to_be_invoked = (xc.ActorAttributeData)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.DefaultMotionRadius = LuaAPI.xlua_tointeger(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_WarTag(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.ActorAttributeData __cl_gen_to_be_invoked = (xc.ActorAttributeData)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.WarTag = (byte)LuaAPI.lua_tonumber(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_AttackRotaion(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.ActorAttributeData __cl_gen_to_be_invoked = (xc.ActorAttributeData)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.AttackRotaion = LuaAPI.xlua_touint(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_Quality(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.ActorAttributeData __cl_gen_to_be_invoked = (xc.ActorAttributeData)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.Quality = LuaAPI.xlua_touint(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_Gravity(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.ActorAttributeData __cl_gen_to_be_invoked = (xc.ActorAttributeData)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.Gravity = (ushort)LuaAPI.xlua_tointeger(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_Attribute(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.ActorAttributeData __cl_gen_to_be_invoked = (xc.ActorAttributeData)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.Attribute = (xc.ActorAttribute)translator.GetObject(L, 2, typeof(xc.ActorAttribute));
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
		
		
		
		
    }
}
