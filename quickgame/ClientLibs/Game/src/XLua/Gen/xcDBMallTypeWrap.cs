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
    public class xcDBMallTypeWrap
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			XUtils.BeginObjectRegister(typeof(xc.DBMallType), L, translator, 0, 2, 0, 0);
			
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "Unload", _m_Unload);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "GetOneItem", _m_GetOneItem);
			
			
			
			
			XUtils.EndObjectRegister(typeof(xc.DBMallType), L, translator, null, null,
			    null, null, null);

		    XUtils.BeginClassRegister(typeof(xc.DBMallType), L, __CreateInstance, 14, 0, 0);
			
			
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "MallType_WeekLimit", xc.DBMallType.MallType_WeekLimit);
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "GrowUp", xc.DBMallType.GrowUp);
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "Common", xc.DBMallType.Common);
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "BindGoldShop", xc.DBMallType.BindGoldShop);
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "Score", xc.DBMallType.Score);
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "BagShop", xc.DBMallType.BagShop);
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "InvisibilityShop", xc.DBMallType.InvisibilityShop);
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "TitleTaskMoneyShop", xc.DBMallType.TitleTaskMoneyShop);
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "EquipExchange", xc.DBMallType.EquipExchange);
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "SoulExchange", xc.DBMallType.SoulExchange);
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "Equip", xc.DBMallType.Equip);
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "Marry", xc.DBMallType.Marry);
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "Active", xc.DBMallType.Active);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "UnderlyingSystemType", typeof(xc.DBMallType));
			
			
			XUtils.EndClassRegister(typeof(xc.DBMallType), L, translator);
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
					
					xc.DBMallType __cl_gen_ret = new xc.DBMallType(strName, strPath);
					translator.Push(L, __cl_gen_ret);
					return 1;
				}
				
			}
			catch(System.Exception __gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
			}
            return LuaAPI.luaL_error(L, "invalid arguments to xc.DBMallType constructor!");
            
        }
        
		
        
		
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Unload(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.DBMallType __cl_gen_to_be_invoked = (xc.DBMallType)translator.FastGetCSObj(L, 1);
            
            
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
            
            
            xc.DBMallType __cl_gen_to_be_invoked = (xc.DBMallType)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    uint mall_type = LuaAPI.xlua_touint(L, 2);
                    
                        xc.DBMallType.DBMallTypeItem __cl_gen_ret = __cl_gen_to_be_invoked.GetOneItem( mall_type );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        
        
        
        
        
		
		
		
		
    }
}
