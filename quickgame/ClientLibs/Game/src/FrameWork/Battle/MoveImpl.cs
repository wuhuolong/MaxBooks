using UnityEngine;
using UnityEngine.AI;
using Net;
using xc.protocol;
using xc.Dungeon;

namespace xc
{
    [wxb.Hotfix]
    public class MoveImpl
	{
		public float CharacterHeight 
        {
			get {return mCharacterHeight;}
		}

		public float CharacterRadius 
        {
            get {return mCharacterRadius;}
		}

		public Vector3 CharacterCenter 
        {
			get {return mCharacterCenter;}
		}
	
		public Vector3 BoundCenter
		{
            get
            {
                return mOwner.Trans.position + mCharacterCenter;
            }
		}
	
        /// <summary>
        /// 当前玩家是否在地面上
        /// </summary>
		bool m_IsGround = true;

		Actor mOwner;
        Transform mOwnerTrans;
        GameObject mOwnerObj;
		float mCharacterHeight = 2.0f;
        public const float mDefaultCharacterRadius = 0.5f;
		float mCharacterRadius = mDefaultCharacterRadius;
		Vector3 mCharacterCenter = Vector3.zero;
		int mLayerAirWall = 0;
        int mLayerMonster = 0;
	
		public bool IsGrounded
        {
			get { return m_IsGround; }
		}
	
		public MoveImpl (Actor actor)
		{
			mOwner = actor;
           
			mLayerAirWall = LayerMask.NameToLayer ("AirWall");
            mLayerMonster = LayerMask.NameToLayer("Monster");

            OnModelChanged();
		}

        public void OnResLoaded()
        {
            if (mOwner.IsDestroy)
                return;

            // 根据资源配置来获取角色的大小
            var capsule_info = mOwner.GetModelComponent<CapsuleInfo>();
            if (capsule_info != null)
            {
                mCharacterHeight = capsule_info.Height;
                mCharacterRadius = capsule_info.Radius;
                mCharacterCenter = capsule_info.Center;
                if(mCharacterHeight < 2 * mCharacterRadius)
                {//如果高度一定是大于或等于2倍的半径
                    mCharacterHeight = 2 * mCharacterRadius;
                }
            } 
            else
            {
                mCharacterHeight = 2.0f;
                mCharacterRadius = mDefaultCharacterRadius;
                mCharacterCenter = new Vector3(0,1.0f,0);
            }
            if(mOwner.mRideCtrl != null && mOwner.mRideCtrl.Rider != null)
            {
                Vector3 rider_root_localPos = mOwner.Trans.InverseTransformVector(mOwner.ActorTrans.position - mOwner.Trans.position);
                mCharacterHeight = mOwner.mRideCtrl.Rider.Height + rider_root_localPos.y;
                if (mOwner.mRideCtrl.GrowSkinItem != null)
                {
                    float fix_height = DBVocationMountInfo.Instance.GetSelfHeightOnRiding((byte)mOwner.VocationID, mOwner.mRideCtrl.GrowSkinItem.IdleActionWhenRiding);
                    if (Mathf.Abs(fix_height) >= 0.01f && mOwner.ActorTrans != null && mOwner.ActorTrans.parent != null)
                        mCharacterHeight = fix_height + rider_root_localPos.y - mOwner.ActorTrans.parent.localPosition.y;
                    //mCharacterHeight = mCharacterHeight + mOwner.mRideCtrl.GrowSkinItem.SceneModelOffset.y;
                }
                if (mCharacterHeight <= 0)
                    mCharacterHeight = 0.1f;
                mCharacterCenter = new Vector3(mCharacterCenter.x, mCharacterHeight / 2, mCharacterCenter.z);
            }

            // 在根节点增加CapsuleCollider（现在所有角色都需要点击响应）
            var collider = mOwnerObj.GetComponent<CapsuleCollider> ();
            if (collider == null)
                collider = mOwnerObj.AddComponent<CapsuleCollider> ();

            collider.height = mCharacterHeight;
            collider.radius = mCharacterRadius;
            collider.center = mCharacterCenter;
            collider.isTrigger = true;

            var rigid = mOwnerObj.GetComponent<Rigidbody>();
            if (mOwner is LocalPlayer)// 本地玩家才需要增加刚体来进行碰撞检测
            {
                if (rigid == null)
                {
                    rigid = mOwnerObj.AddComponent<Rigidbody>();
                    rigid.useGravity = false;
                    rigid.isKinematic = true;
                }
            }
            else// 非本地玩家需要销毁Rigidbody
            {
                if(rigid != null)
                {
                    GameObject.DestroyImmediate(rigid);
                }
            }
        }

        public void OnModelChanged()
        {
            mOwnerTrans = mOwner.transform;
            mOwnerObj = mOwner.gameObject;
        }
	
		public void SetPosition (Vector3 pos)
		{
			Vector3 newPos = pos;
            newPos.y = RoleHelp.GetHeightInScene(mOwner.ActorId, newPos.x, newPos.z);

            /*if (m_NavMeshAgent != null)
            {
                m_NavMeshAgent.enabled = false;
            }*/

            mOwnerTrans.position = newPos;

            /*if (m_NavMeshAgent != null)
            {
                m_NavMeshAgent.enabled = true;
            }*/

            m_IsGround = true;
            OnMove();
		}
	
        // 缓存滑动的数据，只有当数据发生改变时，才发送消息
        public class SliderData
        {
            //public int pos_x = int.MaxValue;
            //public int pos_y = int.MaxValue;
            public float dir_x = float.MaxValue;
            public float dir_y = float.MaxValue;
            public int speed = int.MaxValue;

            /// <summary>
            /// 方向和速度是否都相同
            /// </summary>
            public bool Equal(PkgNwarMove moveData)
            {
                if(moveData == null)
                    return false;

                float vx = moveData.speed * Mathf.Cos(moveData.dir);
                float vy = moveData.speed * Mathf.Sin(moveData.dir);

                //pos_x == moveData.px && pos_y == moveData.py && 
                return  Mathf.Approximately(dir_x ,vx) &&  Mathf.Approximately(dir_y , vy)
                        && speed == moveData.speed;
            }

            /// <summary>
            /// 给滑动数据赋值
            /// </summary>
            public void Assign(PkgNwarMove moveData)
            {
                if(moveData == null)
                    return;

                float vx = moveData.speed * Mathf.Cos(moveData.dir);
                float vy = moveData.speed * Mathf.Sin(moveData.dir);

                //pos_x = moveData.px;
                //pos_y = moveData.py;
                dir_x = vx;
                dir_y = vy;
                speed = (int)moveData.speed;
            }
        }

        SliderData mSliderData = new SliderData();
        PkgNwarMove move_data = new PkgNwarMove();
        C2SNwarSlide slider_data = new C2SNwarSlide();
        bool m_IsTouchEdge = false;

        public const float Radius = 0.1f;

        /// <summary>
        /// 移动固定的位置
        /// </summary>
        /// <param name="offset">移动的偏移数值</param>
        /// <param name="on_ground">移动时是否贴近地面</param>
        /// <param name="slider">移动时是否沿着边界滑动</param>
        public void Move (Vector3 offset, bool on_ground, bool slider = true)
        {
//             MoveAgent(offset, on_ground, slider);
//             return;

            if (offset == Vector3.zero || mOwner.DisableMoveState)
               return;

            move_data.pos = new PkgNwarPos();

            // 减少Trans.position 这样的调用，会显著影响性能
            Vector3 ownerPos = mOwnerTrans.position;

            // 当移动不贴近地面（浮空等）时，需要先计算贴近地面的高度，不然NavMesh的碰撞检测可能检测不到 
            if(on_ground == false)
            {
                float height = RoleHelp.GetHeightInScene(mOwner.ActorId, ownerPos.x, ownerPos.z);
                ownerPos.y = height;
            }

            Vector3 origin = ownerPos;// 碰撞检测的起点
            Vector3 newPos = origin + offset;// 移动后的新位置

            Vector3 move = offset; // 偏移量
            float offset_y = move.y;// 记录原有的高度偏移
            move.y = 0;// 碰撞检测时将高度偏移设置为0

            bool touchEdge = false;// 已经触碰到边界

            bool is_localplayer = mOwner.IsLocalPlayer;

            bool collide_check = true;
            bool is_monster = mOwner.IsMonster();//怪物不进行碰撞检测
            if (is_monster)
            {
                collide_check = false;
            }
            else
            {
                collide_check = true;
            }
            
            if (collide_check)
            {
                Vector3 final_move = move;
                XNavMeshHit hit;
                if(XNavMesh.Raycast(origin, origin + move * (1.0f + Radius / move.magnitude ), out hit, LevelManager.GetInstance().AreaExclude))
                {
                    touchEdge = true;

                    if (slider)// 需要沿着边界滑动时
                    {
                        float sameDir = Vector3.Dot(hit.normal, final_move);
                        if (sameDir > 0)// 法线与移动方向相同，说明角色在边界外
                        {
                            final_move.y = offset_y;
                            newPos = origin + final_move;
                        }
                        else
                        {
                            if (hit.normal == Vector3.zero)// NavMesh获得的法线数值可能为0
                            {
                                Debug.DrawLine(origin, origin + final_move, Color.yellow, 5.0f);

                                final_move.y = offset_y;
                                newPos = origin + final_move;
                                //final_move = Vector3.zero;
                                //newPos = origin;
                            }
                            else
                            {
                                // 碰到边界进行滑动
                                Vector3 tanget = Vector3.Cross(Vector3.up, hit.normal);
                                final_move = tanget * Vector3.Dot(tanget, final_move);
                                float sMoveLen = final_move.magnitude;
                                if (sMoveLen < DBActor.MinDisToGround)// 移动方向垂直于法线
                                {
                                    final_move = Vector3.zero;
                                    newPos = origin;
                                }
                                else
                                {
                                    // 沿着切线方向再次做检测，以免滑动的时候移动到另一个边界外
                                    if (XNavMesh.Raycast(origin, origin + final_move * (1.0f + Radius / sMoveLen), out hit, LevelManager.GetInstance().AreaExclude))
                                    {
                                        final_move = Vector3.zero;
                                        newPos = origin;
                                    }
                                    else
                                    {
                                        final_move.y = offset_y;
                                        newPos = origin + final_move;
                                    }
                                }
                            }
                        }
                    }
                    else// 不滑动，则直接移动到碰撞点
                    {
                        Vector3 radius_pos = PhysicsHelp.BoundaryHitPos(origin, hit.position);
                        newPos.x = radius_pos.x;
                        newPos.z = radius_pos.z;
                    }
                }
            }

            float terrain_height = RoleHelp.GetHeightInScene(mOwner.ActorId, newPos.x, newPos.z);
            if (newPos.y < terrain_height + DBActor.MinDisToGround)// 如果当前位置已经贴近地面，则设置m_IsGround为true
            {
                m_IsGround = true;
                newPos.y = terrain_height;
            } 
            else 
            {
                if(on_ground || touchEdge) // 如果角色已经触碰到边界，则让其掉到地上
                {
                    newPos.y = terrain_height;
                    m_IsGround = true;
                }
                else
                    m_IsGround = false;
            }

            // 在多人副本、野外地图中，本地玩家碰到障碍物的时候需要通知服务端
            if(is_localplayer && slider)
            {
                if(touchEdge)
                {
                    m_IsTouchEdge = true;

                    Vector3 totalMove = newPos - origin;
                    totalMove.y = 0;
                    Vector3 moveDir = totalMove.normalized;

                    move_data.id = mOwner.UID.obj_idx;
                    move_data.pos.px = (int)(origin.x * 100.0f);
                    move_data.pos.py = (int)(origin.z * 100.0f);
                    move_data.dir = Maths.Util.VectorToAngle(moveDir);

                    float totalMoveLen = totalMove.magnitude;
                    Vector3 xz_offset = offset;
                    xz_offset.y = 0;
                    float ortMoveLen = xz_offset.magnitude;
                    if(totalMoveLen > 0 && ortMoveLen > 0)
                        move_data.speed = (uint)(mOwner.MoveSpeed * (totalMoveLen/ortMoveLen) * 100);
                    else
                        move_data.speed = 0;

                    // 数据发生变化时才发送滑动协议
                    if(!mSliderData.Equal(move_data))
                    {
                        mSliderData.Assign(move_data);

                        slider_data.slide = move_data;
                        NetClient.GetCrossClient().SendData<C2SNwarSlide>(NetMsg.MSG_NWAR_SLIDE, slider_data);
                    }
                }
                // 当滑动结束时，需要同步一次方向和位置
                else if(m_IsTouchEdge)
                {
                    m_IsTouchEdge = false;

                    Vector3 totalMove = newPos - origin;
                    totalMove.y = 0;
                    Vector3 moveDir = totalMove.normalized;
                    
                    move_data.id = mOwner.UID.obj_idx;
                    move_data.pos.px = (int)(origin.x * 100.0f);
                    move_data.pos.py = (int)(origin.z * 100.0f);
                    move_data.dir = Maths.Util.VectorToAngle(moveDir);

                    float totalMoveLen = totalMove.magnitude;
                    Vector3 xz_offset = offset;
                    xz_offset.y = 0;
                    float ortMoveLen = xz_offset.magnitude;
                    if(totalMoveLen > 0 && ortMoveLen > 0)
                        move_data.speed = (uint)(mOwner.MoveSpeed * (totalMoveLen/ortMoveLen) * 100);
                    else
                        move_data.speed = 0;

                    mSliderData.Assign(move_data);
                    slider_data.slide = move_data;
                    NetClient.GetCrossClient().SendData<C2SNwarSlide>(NetMsg.MSG_NWAR_SLIDE, slider_data);
                }
            }

            mOwnerTrans.position = newPos;
            OnMove();
        }

        //NavMeshAgent m_NavMeshAgent;
        /*public void MoveAgent(Vector3 offset, bool on_ground, bool slider = true)
        {
            if (offset == Vector3.zero || mOwner.DisableMoveState)
                return;

            InitNavMeshAgent();

            // 减少Trans.position 这样的调用，会显著影响性能
            Vector3 ori_pos = mOwnerTrans.position;
            if (on_ground)
            {
                m_NavMeshAgent.baseOffset = 0;
                ori_pos.y = RoleHelp.GetHeightInScene(mOwner.ActorId, ori_pos.x, ori_pos.z);
                mOwnerTrans.position = ori_pos;
            }

            Vector3 want_pos_xz = ori_pos + offset;
            want_pos_xz.y = 0;

            m_NavMeshAgent.baseOffset += offset.y;

            Vector3 new_pos = Vector3.zero;
            if (slider)// 可以滑动时，调用move函数
            {
                if(mOwner.IsMonster())//怪物不进行碰撞检测
                {
                    new_pos = ori_pos + offset;

                    if (m_NavMeshAgent != null)
                    {
                        m_NavMeshAgent.enabled = false;
                    }

                    mOwnerTrans.position = new_pos;

                    if (m_NavMeshAgent != null)
                    {
                        m_NavMeshAgent.enabled = true;
                    }
                }
                else
                {
                    m_NavMeshAgent.Move(offset);
                    new_pos = mOwnerTrans.position;// 移动后的新位置
                }
            } 
            else// 不能滑动时，调用Raycast函数
            {
                Vector3 start_pos = ori_pos;
                Vector3 offset_xz = offset;
                offset_xz.y = 0;
                NavMeshHit hit;
                if (m_NavMeshAgent.Raycast(start_pos + offset_xz, out hit))
                {
                    new_pos = hit.position;
                }
                else
                    new_pos = ori_pos + offset;

                mOwnerTrans.position = new_pos;
            }

            bool touch_edge = false;// 是否触碰到边界
            Vector3 new_pos_xz = new_pos;
            new_pos_xz.y = 0;
            if (want_pos_xz != new_pos_xz)
                touch_edge = true;

            float base_offset = m_NavMeshAgent.baseOffset;
            if (base_offset <= 0)
            {
                m_NavMeshAgent.baseOffset = 0;
                base_offset = 0;
            }

            if (base_offset > 0)
            {
                if (touch_edge)
                {
                    m_NavMeshAgent.baseOffset = 0;
                    m_IsGround = true;
                }
                else
                    m_IsGround = false;
            }
            else
            {
                m_IsGround = true;
            }

            // 本地玩家碰到障碍物的时候需要通知服务端
            if (mOwner.IsLocalPlayer && slider)
            {
                Vector3 actual_move = new_pos - ori_pos;
                actual_move.y = 0;
                offset.y = 0;
                Vector3 move_dir = actual_move.normalized;
                float actual_move_len = actual_move.magnitude;
                float ori_move_len = offset.magnitude;

                move_data.id = mOwner.UID.obj_idx;
                move_data.pos = new PkgNwarPos();
                move_data.pos.px = (int)(ori_pos.x * 100.0f);
                move_data.pos.py = (int)(ori_pos.z * 100.0f);
                move_data.dir = Maths.Util.VectorToAngle(move_dir);

                if (actual_move_len > 0 && ori_move_len > 0)
                    move_data.speed = (uint)(mOwner.MoveSpeed * (actual_move_len / ori_move_len) * 100);
                else
                    move_data.speed = 0;

                if (touch_edge)
                {
                    m_IsTouchEdge = true;

                    // 数据发生变化时才发送滑动协议
                    if (!mSliderData.Equal(move_data))
                    {
                        mSliderData.Assign(move_data);

                        slider_data.slide = move_data;
                        NetClient.GetCrossClient().SendData<C2SNwarSlide>(NetMsg.MSG_NWAR_SLIDE, slider_data);
                    }
                }
                // 当滑动结束时，需要同步一次方向和位置
                else if (m_IsTouchEdge)
                {
                    m_IsTouchEdge = false;

                    mSliderData.Assign(move_data);
                    slider_data.slide = move_data;
                    NetClient.GetCrossClient().SendData<C2SNwarSlide>(NetMsg.MSG_NWAR_SLIDE, slider_data);
                }
            }
            OnMove();
        }*/

        /*void InitNavMeshAgent()
        {
            if (m_NavMeshAgent == null)
                m_NavMeshAgent = mOwner.gameObject.AddComponent<NavMeshAgent>();

            m_NavMeshAgent.radius = 0.1f;
            m_NavMeshAgent.obstacleAvoidanceType = ObstacleAvoidanceType.NoObstacleAvoidance;
            m_NavMeshAgent.autoBraking = false;
            m_NavMeshAgent.autoRepath = false;
            m_NavMeshAgent.autoTraverseOffMeshLink = false;
        }*/

        private void OnMove()
        {

        }
	}
}