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
    public class xcGoodsWeddingRingWrap
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			XUtils.BeginObjectRegister(typeof(xc.GoodsWeddingRing), L, translator, 0, 1, 9, 2);
			
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "Clone", _m_Clone);
			
			
			XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "IdInfo", _g_get_IdInfo);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "MateInfo", _g_get_MateInfo);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "step", _g_get_step);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "lv", _g_get_lv);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "need_exp", _g_get_need_exp);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "skill", _g_get_skill);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "gid", _g_get_gid);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "normal_attrs", _g_get_normal_attrs);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "couple_attrs", _g_get_couple_attrs);
            
			XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "IdInfo", _s_set_IdInfo);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "MateInfo", _s_set_MateInfo);
            
			XUtils.EndObjectRegister(typeof(xc.GoodsWeddingRing), L, translator, null, null,
			    null, null, null);

		    XUtils.BeginClassRegister(typeof(xc.GoodsWeddingRing), L, __CreateInstance, 1, 0, 0);
			
			
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "UnderlyingSystemType", typeof(xc.GoodsWeddingRing));
			
			
			XUtils.EndClassRegister(typeof(xc.GoodsWeddingRing), L, translator);
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CreateInstance(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			try {
				if(LuaAPI.lua_gettop(L) == 3 && LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 2) && (LuaAPI.lua_isnil(L, 3) || LuaAPI.lua_type(L, 3) == LuaTypes.LUA_TTABLE))
				{
					uint idInfo = LuaAPI.xlua_touint(L, 2);
					XLua.LuaTable mateInfo = (XLua.LuaTable)translator.GetObject(L, 3, typeof(XLua.LuaTable));
					
					xc.GoodsWeddingRing __cl_gen_ret = new xc.GoodsWeddingRing(idInfo, mateInfo);
					translator.Push(L, __cl_gen_ret);
					return 1;
				}
				
			}
			catch(System.Exception __gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
			}
            return LuaAPI.luaL_error(L, "invalid arguments to xc.GoodsWeddingRing constructor!");
            
        }
        
		
        
		
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Clone(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.GoodsWeddingRing __cl_gen_to_be_invoked = (xc.GoodsWeddingRing)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    
                        xc.GoodsWeddingRing __cl_gen_ret = __cl_gen_to_be_invoked.Clone(  );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_IdInfo(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.GoodsWeddingRing __cl_gen_to_be_invoked = (xc.GoodsWeddingRing)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushuint(L, __cl_gen_to_be_invoked.IdInfo);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_MateInfo(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.GoodsWeddingRing __cl_gen_to_be_invoked = (xc.GoodsWeddingRing)translator.FastGetCSObj(L, 1);
                translator.Push(L, __cl_gen_to_be_invoked.MateInfo);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_step(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.GoodsWeddingRing __cl_gen_to_be_invoked = (xc.GoodsWeddingRing)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushuint(L, __cl_gen_to_be_invoked.step);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_lv(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.GoodsWeddingRing __cl_gen_to_be_invoked = (xc.GoodsWeddingRing)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushuint(L, __cl_gen_to_be_invoked.lv);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_need_exp(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.GoodsWeddingRing __cl_gen_to_be_invoked = (xc.GoodsWeddingRing)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushuint(L, __cl_gen_to_be_invoked.need_exp);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_skill(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.GoodsWeddingRing __cl_gen_to_be_invoked = (xc.GoodsWeddingRing)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushuint(L, __cl_gen_to_be_invoked.skill);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_gid(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.GoodsWeddingRing __cl_gen_to_be_invoked = (xc.GoodsWeddingRing)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushuint(L, __cl_gen_to_be_invoked.gid);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_normal_attrs(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.GoodsWeddingRing __cl_gen_to_be_invoked = (xc.GoodsWeddingRing)translator.FastGetCSObj(L, 1);
                translator.Push(L, __cl_gen_to_be_invoked.normal_attrs);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_couple_attrs(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.GoodsWeddingRing __cl_gen_to_be_invoked = (xc.GoodsWeddingRing)translator.FastGetCSObj(L, 1);
                translator.Push(L, __cl_gen_to_be_invoked.couple_attrs);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_IdInfo(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.GoodsWeddingRing __cl_gen_to_be_invoked = (xc.GoodsWeddingRing)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.IdInfo = LuaAPI.xlua_touint(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_MateInfo(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.GoodsWeddingRing __cl_gen_to_be_invoked = (xc.GoodsWeddingRing)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.MateInfo = (XLua.LuaTable)translator.GetObject(L, 2, typeof(XLua.LuaTable));
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
		
		
		
		
    }
}
