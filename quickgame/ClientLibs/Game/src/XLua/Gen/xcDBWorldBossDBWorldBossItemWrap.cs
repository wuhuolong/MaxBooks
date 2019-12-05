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
    public class xcDBWorldBossDBWorldBossItemWrap
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			XUtils.BeginObjectRegister(typeof(xc.DBWorldBoss.DBWorldBossItem), L, translator, 0, 0, 12, 12);
			
			
			
			XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "Id", _g_get_Id);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "Rank", _g_get_Rank);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "Tag", _g_get_Tag);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "ShowAward", _g_get_ShowAward);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "ModelCameraOffset", _g_get_ModelCameraOffset);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "DeathModelCenter", _g_get_DeathModelCenter);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "ModelCameraRotate", _g_get_ModelCameraRotate);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "ModelDefaultAngle", _g_get_ModelDefaultAngle);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "DeathModelRadius", _g_get_DeathModelRadius);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "ColorType", _g_get_ColorType);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "Order", _g_get_Order);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "MustDropAwardArray", _g_get_MustDropAwardArray);
            
			XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "Id", _s_set_Id);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "Rank", _s_set_Rank);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "Tag", _s_set_Tag);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "ShowAward", _s_set_ShowAward);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "ModelCameraOffset", _s_set_ModelCameraOffset);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "DeathModelCenter", _s_set_DeathModelCenter);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "ModelCameraRotate", _s_set_ModelCameraRotate);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "ModelDefaultAngle", _s_set_ModelDefaultAngle);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "DeathModelRadius", _s_set_DeathModelRadius);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "ColorType", _s_set_ColorType);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "Order", _s_set_Order);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "MustDropAwardArray", _s_set_MustDropAwardArray);
            
			XUtils.EndObjectRegister(typeof(xc.DBWorldBoss.DBWorldBossItem), L, translator, null, null,
			    null, null, null);

		    XUtils.BeginClassRegister(typeof(xc.DBWorldBoss.DBWorldBossItem), L, __CreateInstance, 1, 0, 0);
			
			
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "UnderlyingSystemType", typeof(xc.DBWorldBoss.DBWorldBossItem));
			
			
			XUtils.EndClassRegister(typeof(xc.DBWorldBoss.DBWorldBossItem), L, translator);
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CreateInstance(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			try {
				if(LuaAPI.lua_gettop(L) == 1)
				{
					
					xc.DBWorldBoss.DBWorldBossItem __cl_gen_ret = new xc.DBWorldBoss.DBWorldBossItem();
					translator.Push(L, __cl_gen_ret);
					return 1;
				}
				
			}
			catch(System.Exception __gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
			}
            return LuaAPI.luaL_error(L, "invalid arguments to xc.DBWorldBoss.DBWorldBossItem constructor!");
            
        }
        
		
        
		
        
        
        
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_Id(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBWorldBoss.DBWorldBossItem __cl_gen_to_be_invoked = (xc.DBWorldBoss.DBWorldBossItem)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushuint(L, __cl_gen_to_be_invoked.Id);
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
			
                xc.DBWorldBoss.DBWorldBossItem __cl_gen_to_be_invoked = (xc.DBWorldBoss.DBWorldBossItem)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushuint(L, __cl_gen_to_be_invoked.Rank);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_Tag(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBWorldBoss.DBWorldBossItem __cl_gen_to_be_invoked = (xc.DBWorldBoss.DBWorldBossItem)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushuint(L, __cl_gen_to_be_invoked.Tag);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_ShowAward(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBWorldBoss.DBWorldBossItem __cl_gen_to_be_invoked = (xc.DBWorldBoss.DBWorldBossItem)translator.FastGetCSObj(L, 1);
                translator.Push(L, __cl_gen_to_be_invoked.ShowAward);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_ModelCameraOffset(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBWorldBoss.DBWorldBossItem __cl_gen_to_be_invoked = (xc.DBWorldBoss.DBWorldBossItem)translator.FastGetCSObj(L, 1);
                translator.PushUnityEngineVector3(L, __cl_gen_to_be_invoked.ModelCameraOffset);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_DeathModelCenter(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBWorldBoss.DBWorldBossItem __cl_gen_to_be_invoked = (xc.DBWorldBoss.DBWorldBossItem)translator.FastGetCSObj(L, 1);
                translator.PushUnityEngineVector3(L, __cl_gen_to_be_invoked.DeathModelCenter);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_ModelCameraRotate(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBWorldBoss.DBWorldBossItem __cl_gen_to_be_invoked = (xc.DBWorldBoss.DBWorldBossItem)translator.FastGetCSObj(L, 1);
                translator.PushUnityEngineVector3(L, __cl_gen_to_be_invoked.ModelCameraRotate);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_ModelDefaultAngle(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBWorldBoss.DBWorldBossItem __cl_gen_to_be_invoked = (xc.DBWorldBoss.DBWorldBossItem)translator.FastGetCSObj(L, 1);
                translator.PushUnityEngineVector3(L, __cl_gen_to_be_invoked.ModelDefaultAngle);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_DeathModelRadius(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBWorldBoss.DBWorldBossItem __cl_gen_to_be_invoked = (xc.DBWorldBoss.DBWorldBossItem)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushnumber(L, __cl_gen_to_be_invoked.DeathModelRadius);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_ColorType(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBWorldBoss.DBWorldBossItem __cl_gen_to_be_invoked = (xc.DBWorldBoss.DBWorldBossItem)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushuint(L, __cl_gen_to_be_invoked.ColorType);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_Order(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBWorldBoss.DBWorldBossItem __cl_gen_to_be_invoked = (xc.DBWorldBoss.DBWorldBossItem)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushuint(L, __cl_gen_to_be_invoked.Order);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_MustDropAwardArray(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBWorldBoss.DBWorldBossItem __cl_gen_to_be_invoked = (xc.DBWorldBoss.DBWorldBossItem)translator.FastGetCSObj(L, 1);
                translator.Push(L, __cl_gen_to_be_invoked.MustDropAwardArray);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_Id(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBWorldBoss.DBWorldBossItem __cl_gen_to_be_invoked = (xc.DBWorldBoss.DBWorldBossItem)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.Id = LuaAPI.xlua_touint(L, 2);
            
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
			
                xc.DBWorldBoss.DBWorldBossItem __cl_gen_to_be_invoked = (xc.DBWorldBoss.DBWorldBossItem)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.Rank = LuaAPI.xlua_touint(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_Tag(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBWorldBoss.DBWorldBossItem __cl_gen_to_be_invoked = (xc.DBWorldBoss.DBWorldBossItem)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.Tag = LuaAPI.xlua_touint(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_ShowAward(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBWorldBoss.DBWorldBossItem __cl_gen_to_be_invoked = (xc.DBWorldBoss.DBWorldBossItem)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.ShowAward = (System.Collections.Generic.List<xc.DBWorldBoss.DBWorldBossRewardItem>)translator.GetObject(L, 2, typeof(System.Collections.Generic.List<xc.DBWorldBoss.DBWorldBossRewardItem>));
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_ModelCameraOffset(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBWorldBoss.DBWorldBossItem __cl_gen_to_be_invoked = (xc.DBWorldBoss.DBWorldBossItem)translator.FastGetCSObj(L, 1);
                UnityEngine.Vector3 __cl_gen_value;translator.Get(L, 2, out __cl_gen_value);
				__cl_gen_to_be_invoked.ModelCameraOffset = __cl_gen_value;
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_DeathModelCenter(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBWorldBoss.DBWorldBossItem __cl_gen_to_be_invoked = (xc.DBWorldBoss.DBWorldBossItem)translator.FastGetCSObj(L, 1);
                UnityEngine.Vector3 __cl_gen_value;translator.Get(L, 2, out __cl_gen_value);
				__cl_gen_to_be_invoked.DeathModelCenter = __cl_gen_value;
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_ModelCameraRotate(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBWorldBoss.DBWorldBossItem __cl_gen_to_be_invoked = (xc.DBWorldBoss.DBWorldBossItem)translator.FastGetCSObj(L, 1);
                UnityEngine.Vector3 __cl_gen_value;translator.Get(L, 2, out __cl_gen_value);
				__cl_gen_to_be_invoked.ModelCameraRotate = __cl_gen_value;
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_ModelDefaultAngle(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBWorldBoss.DBWorldBossItem __cl_gen_to_be_invoked = (xc.DBWorldBoss.DBWorldBossItem)translator.FastGetCSObj(L, 1);
                UnityEngine.Vector3 __cl_gen_value;translator.Get(L, 2, out __cl_gen_value);
				__cl_gen_to_be_invoked.ModelDefaultAngle = __cl_gen_value;
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_DeathModelRadius(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBWorldBoss.DBWorldBossItem __cl_gen_to_be_invoked = (xc.DBWorldBoss.DBWorldBossItem)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.DeathModelRadius = (float)LuaAPI.lua_tonumber(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_ColorType(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBWorldBoss.DBWorldBossItem __cl_gen_to_be_invoked = (xc.DBWorldBoss.DBWorldBossItem)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.ColorType = LuaAPI.xlua_touint(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_Order(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBWorldBoss.DBWorldBossItem __cl_gen_to_be_invoked = (xc.DBWorldBoss.DBWorldBossItem)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.Order = LuaAPI.xlua_touint(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_MustDropAwardArray(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBWorldBoss.DBWorldBossItem __cl_gen_to_be_invoked = (xc.DBWorldBoss.DBWorldBossItem)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.MustDropAwardArray = (System.Collections.Generic.List<xc.DBWorldBoss.DBWorldBossRewardItem>)translator.GetObject(L, 2, typeof(System.Collections.Generic.List<xc.DBWorldBoss.DBWorldBossRewardItem>));
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
		
		
		
		
    }
}
