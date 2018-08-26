using System;
using UnityEngine;

///@brief
///文件名称:State
///功能描述:
///数据表:
///作者:YuXianQiang
///日期:#CreateTime#
///R1:
///修改作者:
///修改日期:
///修改理由:

namespace XianQiang.Yu
{
    public class State
    {
        //brief 进入
        public Action OnEnter;
        //brief 离开
        public Action OnLeave;
        //brief 更新状态
        public Action<float> OnUpdate;
    }

    public class StateMachine : MonoBehaviour
    {
        //brief 状态时间
        public float stateTime { get; private set; }

        private State _state;
        public State state
        {
            //得到当前状态
            get { return _state; }
            //设置当前状态
            set
            {
                //退出上一次的状态
                if (_state != null && _state.OnLeave != null) _state.OnLeave();
                stateTime = 0;
                _state = value;
                //开始当前的状态
                if (_state != null && _state.OnEnter != null) _state.OnEnter();
            }
        }
        
        //brief 更新状态
        protected void OnUpdateState(float deltaTime)
        {
            stateTime += deltaTime;
            if (_state != null && _state.OnUpdate != null) _state.OnUpdate(deltaTime);
        }
    }
}