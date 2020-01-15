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
    public class xcEquipEquipAttributesWrap
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			XUtils.BeginObjectRegister(typeof(xc.Equip.EquipAttributes), L, translator, 0, 5, 2, 0);
			
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "GetAttr", _m_GetAttr);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "Insert", _m_Insert);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "Add", _m_Add);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "AddValue", _m_AddValue);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "Clear", _m_Clear);
			
			
			XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "Score", _g_get_Score);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "Length", _g_get_Length);
            
			
			XUtils.EndObjectRegister(typeof(xc.Equip.EquipAttributes), L, translator, null, null,
			    null, null, null);

		    XUtils.BeginClassRegister(typeof(xc.Equip.EquipAttributes), L, __CreateInstance, 2, 0, 0);
			XUtils.RegisterFunc(L, XUtils.CLS_IDX, "ParseByPkgKvMins", _m_ParseByPkgKvMins_xlua_st_);
            
			
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "UnderlyingSystemType", typeof(xc.Equip.EquipAttributes));
			
			
			XUtils.EndClassRegister(typeof(xc.Equip.EquipAttributes), L, translator);
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CreateInstance(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			try {
				if(LuaAPI.lua_gettop(L) == 1)
				{
					
					xc.Equip.EquipAttributes __cl_gen_ret = new xc.Equip.EquipAttributes();
					translator.Push(L, __cl_gen_ret);
					return 1;
				}
				
			}
			catch(System.Exception __gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
			}
            return LuaAPI.luaL_error(L, "invalid arguments to xc.Equip.EquipAttributes constructor!");
            
        }
        
		
        
		
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetAttr(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.Equip.EquipAttributes __cl_gen_to_be_invoked = (xc.Equip.EquipAttributes)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    int idx = LuaAPI.xlua_tointeger(L, 2);
                    
                        xc.Equip.IEquipAttribute __cl_gen_ret = __cl_gen_to_be_invoked.GetAttr( idx );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Insert(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.Equip.EquipAttributes __cl_gen_to_be_invoked = (xc.Equip.EquipAttributes)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    int idx = LuaAPI.xlua_tointeger(L, 2);
                    uint id = LuaAPI.xlua_touint(L, 3);
                    System.Collections.Generic.List<uint> value = (System.Collections.Generic.List<uint>)translator.GetObject(L, 4, typeof(System.Collections.Generic.List<uint>));
                    
                    __cl_gen_to_be_invoked.Insert( idx, id, value );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Add(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.Equip.EquipAttributes __cl_gen_to_be_invoked = (xc.Equip.EquipAttributes)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    uint id = LuaAPI.xlua_touint(L, 2);
                    System.Collections.Generic.List<uint> value = (System.Collections.Generic.List<uint>)translator.GetObject(L, 3, typeof(System.Collections.Generic.List<uint>));
                    
                    __cl_gen_to_be_invoked.Add( id, value );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_AddValue(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.Equip.EquipAttributes __cl_gen_to_be_invoked = (xc.Equip.EquipAttributes)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    uint id = LuaAPI.xlua_touint(L, 2);
                    System.Collections.Generic.List<uint> value = (System.Collections.Generic.List<uint>)translator.GetObject(L, 3, typeof(System.Collections.Generic.List<uint>));
                    bool bMerge = LuaAPI.lua_toboolean(L, 4);
                    
                    __cl_gen_to_be_invoked.AddValue( id, value, bMerge );
                    
                    
                    
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
            
            
            xc.Equip.EquipAttributes __cl_gen_to_be_invoked = (xc.Equip.EquipAttributes)translator.FastGetCSObj(L, 1);
            
            
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
        static int _m_ParseByPkgKvMins_xlua_st_(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
            try {
                
                {
                    System.Collections.Generic.List<Net.PkgExotic> pkgExotics = (System.Collections.Generic.List<Net.PkgExotic>)translator.GetObject(L, 1, typeof(System.Collections.Generic.List<Net.PkgExotic>));
                    
                        xc.Equip.EquipAttributes __cl_gen_ret = xc.Equip.EquipAttributes.ParseByPkgKvMins( pkgExotics );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_Score(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.Equip.EquipAttributes __cl_gen_to_be_invoked = (xc.Equip.EquipAttributes)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushuint(L, __cl_gen_to_be_invoked.Score);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_Length(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.Equip.EquipAttributes __cl_gen_to_be_invoked = (xc.Equip.EquipAttributes)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushinteger(L, __cl_gen_to_be_invoked.Length);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        
        
		
		
		
		
    }
}
