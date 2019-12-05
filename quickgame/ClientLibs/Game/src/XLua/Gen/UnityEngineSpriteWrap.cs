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
    public class UnityEngineSpriteWrap
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			XUtils.BeginObjectRegister(typeof(UnityEngine.Sprite), L, translator, 0, 5, 15, 0);
			
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "OverrideGeometry", _m_OverrideGeometry);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "GetPhysicsShapeCount", _m_GetPhysicsShapeCount);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "GetPhysicsShapePointCount", _m_GetPhysicsShapePointCount);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "GetPhysicsShape", _m_GetPhysicsShape);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "OverridePhysicsShape", _m_OverridePhysicsShape);
			
			
			XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "bounds", _g_get_bounds);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "rect", _g_get_rect);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "texture", _g_get_texture);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "associatedAlphaSplitTexture", _g_get_associatedAlphaSplitTexture);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "textureRect", _g_get_textureRect);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "textureRectOffset", _g_get_textureRectOffset);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "packed", _g_get_packed);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "packingMode", _g_get_packingMode);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "packingRotation", _g_get_packingRotation);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "pivot", _g_get_pivot);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "border", _g_get_border);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "vertices", _g_get_vertices);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "triangles", _g_get_triangles);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "uv", _g_get_uv);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "pixelsPerUnit", _g_get_pixelsPerUnit);
            
			
			XUtils.EndObjectRegister(typeof(UnityEngine.Sprite), L, translator, null, null,
			    null, null, null);

		    XUtils.BeginClassRegister(typeof(UnityEngine.Sprite), L, __CreateInstance, 2, 0, 0);
			XUtils.RegisterFunc(L, XUtils.CLS_IDX, "Create", _m_Create_xlua_st_);
            
			
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "UnderlyingSystemType", typeof(UnityEngine.Sprite));
			
			
			XUtils.EndClassRegister(typeof(UnityEngine.Sprite), L, translator);
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CreateInstance(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			try {
				if(LuaAPI.lua_gettop(L) == 1)
				{
					
					UnityEngine.Sprite __cl_gen_ret = new UnityEngine.Sprite();
					translator.Push(L, __cl_gen_ret);
					return 1;
				}
				
			}
			catch(System.Exception __gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
			}
            return LuaAPI.luaL_error(L, "invalid arguments to UnityEngine.Sprite constructor!");
            
        }
        
		
        
		
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Create_xlua_st_(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
			int __gen_param_count = LuaAPI.lua_gettop(L);
            
            try {
                if(__gen_param_count == 3&& translator.Assignable<UnityEngine.Texture2D>(L, 1)&& translator.Assignable<UnityEngine.Rect>(L, 2)&& translator.Assignable<UnityEngine.Vector2>(L, 3)) 
                {
                    UnityEngine.Texture2D texture = (UnityEngine.Texture2D)translator.GetObject(L, 1, typeof(UnityEngine.Texture2D));
                    UnityEngine.Rect rect;translator.Get(L, 2, out rect);
                    UnityEngine.Vector2 pivot;translator.Get(L, 3, out pivot);
                    
                        UnityEngine.Sprite __cl_gen_ret = UnityEngine.Sprite.Create( texture, rect, pivot );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                if(__gen_param_count == 4&& translator.Assignable<UnityEngine.Texture2D>(L, 1)&& translator.Assignable<UnityEngine.Rect>(L, 2)&& translator.Assignable<UnityEngine.Vector2>(L, 3)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 4)) 
                {
                    UnityEngine.Texture2D texture = (UnityEngine.Texture2D)translator.GetObject(L, 1, typeof(UnityEngine.Texture2D));
                    UnityEngine.Rect rect;translator.Get(L, 2, out rect);
                    UnityEngine.Vector2 pivot;translator.Get(L, 3, out pivot);
                    float pixelsPerUnit = (float)LuaAPI.lua_tonumber(L, 4);
                    
                        UnityEngine.Sprite __cl_gen_ret = UnityEngine.Sprite.Create( texture, rect, pivot, pixelsPerUnit );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                if(__gen_param_count == 5&& translator.Assignable<UnityEngine.Texture2D>(L, 1)&& translator.Assignable<UnityEngine.Rect>(L, 2)&& translator.Assignable<UnityEngine.Vector2>(L, 3)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 4)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 5)) 
                {
                    UnityEngine.Texture2D texture = (UnityEngine.Texture2D)translator.GetObject(L, 1, typeof(UnityEngine.Texture2D));
                    UnityEngine.Rect rect;translator.Get(L, 2, out rect);
                    UnityEngine.Vector2 pivot;translator.Get(L, 3, out pivot);
                    float pixelsPerUnit = (float)LuaAPI.lua_tonumber(L, 4);
                    uint extrude = LuaAPI.xlua_touint(L, 5);
                    
                        UnityEngine.Sprite __cl_gen_ret = UnityEngine.Sprite.Create( texture, rect, pivot, pixelsPerUnit, extrude );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                if(__gen_param_count == 6&& translator.Assignable<UnityEngine.Texture2D>(L, 1)&& translator.Assignable<UnityEngine.Rect>(L, 2)&& translator.Assignable<UnityEngine.Vector2>(L, 3)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 4)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 5)&& translator.Assignable<UnityEngine.SpriteMeshType>(L, 6)) 
                {
                    UnityEngine.Texture2D texture = (UnityEngine.Texture2D)translator.GetObject(L, 1, typeof(UnityEngine.Texture2D));
                    UnityEngine.Rect rect;translator.Get(L, 2, out rect);
                    UnityEngine.Vector2 pivot;translator.Get(L, 3, out pivot);
                    float pixelsPerUnit = (float)LuaAPI.lua_tonumber(L, 4);
                    uint extrude = LuaAPI.xlua_touint(L, 5);
                    UnityEngine.SpriteMeshType meshType;translator.Get(L, 6, out meshType);
                    
                        UnityEngine.Sprite __cl_gen_ret = UnityEngine.Sprite.Create( texture, rect, pivot, pixelsPerUnit, extrude, meshType );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                if(__gen_param_count == 7&& translator.Assignable<UnityEngine.Texture2D>(L, 1)&& translator.Assignable<UnityEngine.Rect>(L, 2)&& translator.Assignable<UnityEngine.Vector2>(L, 3)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 4)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 5)&& translator.Assignable<UnityEngine.SpriteMeshType>(L, 6)&& translator.Assignable<UnityEngine.Vector4>(L, 7)) 
                {
                    UnityEngine.Texture2D texture = (UnityEngine.Texture2D)translator.GetObject(L, 1, typeof(UnityEngine.Texture2D));
                    UnityEngine.Rect rect;translator.Get(L, 2, out rect);
                    UnityEngine.Vector2 pivot;translator.Get(L, 3, out pivot);
                    float pixelsPerUnit = (float)LuaAPI.lua_tonumber(L, 4);
                    uint extrude = LuaAPI.xlua_touint(L, 5);
                    UnityEngine.SpriteMeshType meshType;translator.Get(L, 6, out meshType);
                    UnityEngine.Vector4 border;translator.Get(L, 7, out border);
                    
                        UnityEngine.Sprite __cl_gen_ret = UnityEngine.Sprite.Create( texture, rect, pivot, pixelsPerUnit, extrude, meshType, border );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                if(__gen_param_count == 8&& translator.Assignable<UnityEngine.Texture2D>(L, 1)&& translator.Assignable<UnityEngine.Rect>(L, 2)&& translator.Assignable<UnityEngine.Vector2>(L, 3)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 4)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 5)&& translator.Assignable<UnityEngine.SpriteMeshType>(L, 6)&& translator.Assignable<UnityEngine.Vector4>(L, 7)&& LuaTypes.LUA_TBOOLEAN == LuaAPI.lua_type(L, 8)) 
                {
                    UnityEngine.Texture2D texture = (UnityEngine.Texture2D)translator.GetObject(L, 1, typeof(UnityEngine.Texture2D));
                    UnityEngine.Rect rect;translator.Get(L, 2, out rect);
                    UnityEngine.Vector2 pivot;translator.Get(L, 3, out pivot);
                    float pixelsPerUnit = (float)LuaAPI.lua_tonumber(L, 4);
                    uint extrude = LuaAPI.xlua_touint(L, 5);
                    UnityEngine.SpriteMeshType meshType;translator.Get(L, 6, out meshType);
                    UnityEngine.Vector4 border;translator.Get(L, 7, out border);
                    bool generateFallbackPhysicsShape = LuaAPI.lua_toboolean(L, 8);
                    
                        UnityEngine.Sprite __cl_gen_ret = UnityEngine.Sprite.Create( texture, rect, pivot, pixelsPerUnit, extrude, meshType, border, generateFallbackPhysicsShape );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to UnityEngine.Sprite.Create!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_OverrideGeometry(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            UnityEngine.Sprite __cl_gen_to_be_invoked = (UnityEngine.Sprite)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    UnityEngine.Vector2[] vertices = (UnityEngine.Vector2[])translator.GetObject(L, 2, typeof(UnityEngine.Vector2[]));
                    ushort[] triangles = (ushort[])translator.GetObject(L, 3, typeof(ushort[]));
                    
                    __cl_gen_to_be_invoked.OverrideGeometry( vertices, triangles );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetPhysicsShapeCount(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            UnityEngine.Sprite __cl_gen_to_be_invoked = (UnityEngine.Sprite)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    
                        int __cl_gen_ret = __cl_gen_to_be_invoked.GetPhysicsShapeCount(  );
                        LuaAPI.xlua_pushinteger(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetPhysicsShapePointCount(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            UnityEngine.Sprite __cl_gen_to_be_invoked = (UnityEngine.Sprite)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    int shapeIdx = LuaAPI.xlua_tointeger(L, 2);
                    
                        int __cl_gen_ret = __cl_gen_to_be_invoked.GetPhysicsShapePointCount( shapeIdx );
                        LuaAPI.xlua_pushinteger(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetPhysicsShape(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            UnityEngine.Sprite __cl_gen_to_be_invoked = (UnityEngine.Sprite)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    int shapeIdx = LuaAPI.xlua_tointeger(L, 2);
                    System.Collections.Generic.List<UnityEngine.Vector2> physicsShape = (System.Collections.Generic.List<UnityEngine.Vector2>)translator.GetObject(L, 3, typeof(System.Collections.Generic.List<UnityEngine.Vector2>));
                    
                        int __cl_gen_ret = __cl_gen_to_be_invoked.GetPhysicsShape( shapeIdx, physicsShape );
                        LuaAPI.xlua_pushinteger(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_OverridePhysicsShape(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            UnityEngine.Sprite __cl_gen_to_be_invoked = (UnityEngine.Sprite)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    System.Collections.Generic.IList<UnityEngine.Vector2[]> physicsShapes = (System.Collections.Generic.IList<UnityEngine.Vector2[]>)translator.GetObject(L, 2, typeof(System.Collections.Generic.IList<UnityEngine.Vector2[]>));
                    
                    __cl_gen_to_be_invoked.OverridePhysicsShape( physicsShapes );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_bounds(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                UnityEngine.Sprite __cl_gen_to_be_invoked = (UnityEngine.Sprite)translator.FastGetCSObj(L, 1);
                translator.PushUnityEngineBounds(L, __cl_gen_to_be_invoked.bounds);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_rect(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                UnityEngine.Sprite __cl_gen_to_be_invoked = (UnityEngine.Sprite)translator.FastGetCSObj(L, 1);
                translator.Push(L, __cl_gen_to_be_invoked.rect);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_texture(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                UnityEngine.Sprite __cl_gen_to_be_invoked = (UnityEngine.Sprite)translator.FastGetCSObj(L, 1);
                translator.Push(L, __cl_gen_to_be_invoked.texture);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_associatedAlphaSplitTexture(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                UnityEngine.Sprite __cl_gen_to_be_invoked = (UnityEngine.Sprite)translator.FastGetCSObj(L, 1);
                translator.Push(L, __cl_gen_to_be_invoked.associatedAlphaSplitTexture);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_textureRect(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                UnityEngine.Sprite __cl_gen_to_be_invoked = (UnityEngine.Sprite)translator.FastGetCSObj(L, 1);
                translator.Push(L, __cl_gen_to_be_invoked.textureRect);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_textureRectOffset(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                UnityEngine.Sprite __cl_gen_to_be_invoked = (UnityEngine.Sprite)translator.FastGetCSObj(L, 1);
                translator.PushUnityEngineVector2(L, __cl_gen_to_be_invoked.textureRectOffset);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_packed(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                UnityEngine.Sprite __cl_gen_to_be_invoked = (UnityEngine.Sprite)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, __cl_gen_to_be_invoked.packed);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_packingMode(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                UnityEngine.Sprite __cl_gen_to_be_invoked = (UnityEngine.Sprite)translator.FastGetCSObj(L, 1);
                translator.Push(L, __cl_gen_to_be_invoked.packingMode);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_packingRotation(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                UnityEngine.Sprite __cl_gen_to_be_invoked = (UnityEngine.Sprite)translator.FastGetCSObj(L, 1);
                translator.Push(L, __cl_gen_to_be_invoked.packingRotation);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_pivot(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                UnityEngine.Sprite __cl_gen_to_be_invoked = (UnityEngine.Sprite)translator.FastGetCSObj(L, 1);
                translator.PushUnityEngineVector2(L, __cl_gen_to_be_invoked.pivot);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_border(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                UnityEngine.Sprite __cl_gen_to_be_invoked = (UnityEngine.Sprite)translator.FastGetCSObj(L, 1);
                translator.PushUnityEngineVector4(L, __cl_gen_to_be_invoked.border);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_vertices(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                UnityEngine.Sprite __cl_gen_to_be_invoked = (UnityEngine.Sprite)translator.FastGetCSObj(L, 1);
                translator.Push(L, __cl_gen_to_be_invoked.vertices);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_triangles(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                UnityEngine.Sprite __cl_gen_to_be_invoked = (UnityEngine.Sprite)translator.FastGetCSObj(L, 1);
                translator.Push(L, __cl_gen_to_be_invoked.triangles);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_uv(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                UnityEngine.Sprite __cl_gen_to_be_invoked = (UnityEngine.Sprite)translator.FastGetCSObj(L, 1);
                translator.Push(L, __cl_gen_to_be_invoked.uv);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_pixelsPerUnit(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                UnityEngine.Sprite __cl_gen_to_be_invoked = (UnityEngine.Sprite)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushnumber(L, __cl_gen_to_be_invoked.pixelsPerUnit);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        
        
		
		
		
		
    }
}
