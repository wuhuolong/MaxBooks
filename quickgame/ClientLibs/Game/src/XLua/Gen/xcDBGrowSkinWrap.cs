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
    public class xcDBGrowSkinWrap
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			XUtils.BeginObjectRegister(typeof(xc.DBGrowSkin), L, translator, 0, 6, 0, 0);
			
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "Load", _m_Load);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "Unload", _m_Unload);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "GetOneItem", _m_GetOneItem);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "GetSortItemArray", _m_GetSortItemArray);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "GetNextDegreeItem", _m_GetNextDegreeItem);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "GetOneSkinInfoByGoodsId", _m_GetOneSkinInfoByGoodsId);
			
			
			
			
			XUtils.EndObjectRegister(typeof(xc.DBGrowSkin), L, translator, null, null,
			    null, null, null);

		    XUtils.BeginClassRegister(typeof(xc.DBGrowSkin), L, __CreateInstance, 1, 0, 0);
			
			
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "UnderlyingSystemType", typeof(xc.DBGrowSkin));
			
			
			XUtils.EndClassRegister(typeof(xc.DBGrowSkin), L, translator);
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CreateInstance(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			try {
				if(LuaAPI.lua_gettop(L) == 3 && (LuaAPI.lua_isnil(L, 2) || LuaAPI.lua_type(L, 2) == LuaTypes.LUA_TSTRING) && (LuaAPI.lua_isnil(L, 3) || LuaAPI.lua_type(L, 3) == LuaTypes.LUA_TSTRING))
				{
					string strName = LuaAPI.lua_tostring(L, 2);
					string strPath = LuaAPI.lua_tostring(L, 3);
					
					xc.DBGrowSkin __cl_gen_ret = new xc.DBGrowSkin(strName, strPath);
					translator.Push(L, __cl_gen_ret);
					return 1;
				}
				
			}
			catch(System.Exception __gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
			}
            return LuaAPI.luaL_error(L, "invalid arguments to xc.DBGrowSkin constructor!");
            
        }
        
		
        
		
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Load(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.DBGrowSkin __cl_gen_to_be_invoked = (xc.DBGrowSkin)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    
                    __cl_gen_to_be_invoked.Load(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Unload(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.DBGrowSkin __cl_gen_to_be_invoked = (xc.DBGrowSkin)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    
                    __cl_gen_to_be_invoked.Unload(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetOneItem(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.DBGrowSkin __cl_gen_to_be_invoked = (xc.DBGrowSkin)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    uint grow_type = LuaAPI.xlua_touint(L, 2);
                    uint id = LuaAPI.xlua_touint(L, 3);
                    
                        xc.DBGrowSkin.DBGrowSkinItem __cl_gen_ret = __cl_gen_to_be_invoked.GetOneItem( grow_type, id );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetSortItemArray(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.DBGrowSkin __cl_gen_to_be_invoked = (xc.DBGrowSkin)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    uint grow_type = LuaAPI.xlua_touint(L, 2);
                    
                        System.Collections.Generic.List<xc.DBGrowSkin.DBGrowSkinItem> __cl_gen_ret = __cl_gen_to_be_invoked.GetSortItemArray( grow_type );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetNextDegreeItem(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.DBGrowSkin __cl_gen_to_be_invoked = (xc.DBGrowSkin)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    uint grow_type = LuaAPI.xlua_touint(L, 2);
                    uint cur_grow_level = LuaAPI.xlua_touint(L, 3);
                    
                        xc.DBGrowSkin.DBGrowSkinItem __cl_gen_ret = __cl_gen_to_be_invoked.GetNextDegreeItem( grow_type, cur_grow_level );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetOneSkinInfoByGoodsId(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.DBGrowSkin __cl_gen_to_be_invoked = (xc.DBGrowSkin)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    uint goods_id = LuaAPI.xlua_touint(L, 2);
                    
                        xc.DBGrowSkin.DBGrowSkinItem __cl_gen_ret = __cl_gen_to_be_invoked.GetOneSkinInfoByGoodsId( goods_id );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        
        
        
        
        
		
		
		
		
    }
}
