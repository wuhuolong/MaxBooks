//************************************
//  AssetReource.cs
//  The AssetResource is the encapsulation of an request asset resource, it contains the asset and you can use it to release the asset after you use
//  Created by leon @INCEPTION .
//  Last modify 14-12-19 : refactor
//************************************
using UnityEngine;
using System.Collections;

namespace SGameEngine
{

    //  The AssetResource is the encapsulation of an request asset resource, it contains the asset and you can use it to release the asset after you use
    // you must always call destroy after you do not use the asset.
    public class AssetResource
    {

        private AssetObject obj_ = null;
        private bool destroyed_ = false;

        /////////////////////////////////////////public interfaces/////////////////////////////////////////
        //get the asset
        //notice 1: you may get null.
        //notice 2; be carefull if you modify this asset directly, it will affect others who are using ths asset in the game,
        public UnityEngine.Object asset_
        {
            get
            {
                if (obj_ == null)
                {
                    return null;
                }
                return obj_.get_obj_;
            }
        }

        //release your use. it will decrease the ref count, if all ref count to 0, it will be release from memory.
        public void destroy()
        {
            if (destroyed_)
            {
                return;
            }
            destroyed_ = true;
            if (obj_ != null)
            {
                obj_.decrence_ref();
                obj_ = null;
            }
        }

        //--------------------------------------------------------
        // 内部接口，主要给Resourceloader使用
        //--------------------------------------------------------

        /// <summary>
        /// 设置AssetObject，会增加其引用计数
        /// </summary>
        public void set_obj(AssetObject _asset_obj)
        {
            // 之前有Obj_要先destroy
            if (obj_ != null)
            {
                Debug.LogError("reused a assetresource");
                destroy();
            }

            // 设置AssetObject，并增加引用计数
            obj_ = _asset_obj;
            _asset_obj.add_ref();
            destroyed_ = false;
        }

        /// <summary>
        /// 获取AssetObject
        /// </summary>
        public AssetObject get_obj()
        {
            return obj_;
        }

    }
}
