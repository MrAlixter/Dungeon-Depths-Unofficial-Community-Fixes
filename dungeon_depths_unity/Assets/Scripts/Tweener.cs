using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using UnityEngine;

public class Tweener : ScriptableObject
{
    private static Tweener _instance;
    public static Tweener instance { get { if(_instance == null) { _instance = CreateInstance<Tweener>(); } return _instance; } }

    private static Dictionary<int, Dictionary<int, List<ToTween>>> queue;
    protected static float delta_time;
    
    protected abstract class ToTween
    {
        //Required
        public object to_change_on;
        public MemberInfo to_change;
        public string to_change_name;
        public object target_value;
        
        //Optional
        public Action callback;

        //Set based on required params
        protected Type type;
        protected PropertyInfo pi;
        protected FieldInfo fi;
        protected bool to_change_is_prop;

        protected ToTween(object to_change_on, MemberInfo to_change, string to_change_name, object target_value, Action callback)
        {
            this.to_change_on = to_change_on;
            this.to_change = to_change;
            this.to_change_name = to_change_name;
            this.target_value = target_value;
            this.callback = callback;

            to_change_is_prop = to_change is PropertyInfo;
            if(to_change_is_prop)
            {
                pi = (PropertyInfo)to_change;
            }
            else
            {
                fi = (FieldInfo)to_change;
            }
            type = to_change.ReflectedType;
        }

        public abstract bool Update();
        
        
        protected static int tween_int_speed(int current, int target, int max)
        {
            bool going_right = target > current;
            int left = going_right ? target - current : current - target;
            left = Mathf.Abs(target - current);
            int to_lerp = Mathf.Min(max, Mathf.Abs(left));
            if(target < current) { to_lerp *= -1; }
            return current + to_lerp;
        }

        protected static float tween_float_speed(float current, float target, float max)
        {
            bool going_right = target > current;
            float left = going_right ? target - current : current - target;
            float to_lerp = Mathf.Min(max, Mathf.Abs(left));
            if(target < current) { to_lerp *= -1; }
            return current + to_lerp;
        }
    }
    protected abstract class ToTweenTimed : ToTween
    {
        public float time_since_start;
        public float time_to_finish_in;
        public object start_val;

        public ToTweenTimed(object to_change_on, MemberInfo to_change, string to_change_name, object target_value, Action callback, float time_to_finish_in) : base(to_change_on, to_change, to_change_name, target_value, callback)
        {
            this.time_since_start = 0;
            this.time_to_finish_in = time_to_finish_in;
        }
    }
    protected class ToTweenPrimitiveTimed : ToTweenTimed
    {
        public ToTweenPrimitiveTimed(object to_change_on, MemberInfo to_change, string to_change_name, object target_value, float time_to_finish_in, Action callback) : base(to_change_on, to_change, to_change_name, target_value, callback, time_to_finish_in)
        {
            start_val = val_raw;
        }
        
        private object val_raw
        {
            get
            {
                return to_change_is_prop ? pi.GetValue(to_change_on) : fi.GetValue(to_change_on);
            }
            set
            {
                if(to_change_is_prop)
                {
                    pi.SetValue(to_change_on, value);
                }
                else
                {
                    fi.SetValue(to_change_on, value);
                }
            }
        }

        public override bool Update()
        {
            time_since_start += delta_time;
            switch(val_raw)
            {
                case int v: tween_int_val(); break;
                case float v: tween_float_val(); break;
                default: throw new Exception($"Tweener Primitive does not support tweening with type {type.FullName}");
            }
            return target_value.Equals(val_raw);
        }

        private void tween_int_val()
        {
            val_raw = (int)Mathf.Lerp((float)start_val, (float)target_value, time_since_start / time_to_finish_in);
        }
        private void tween_float_val()
        {
            val_raw = Mathf.Lerp((float)start_val, (float)target_value, time_since_start / time_to_finish_in);
        }
    }
    protected class ToTweenVector3Timed : ToTweenTimed
    {
        public ToTweenVector3Timed(object to_change_on, MemberInfo to_change, string to_change_name, object target_value, float time_to_finish_in, Action callback) : base(to_change_on, to_change, to_change_name, target_value, callback, time_to_finish_in)
        {
            this.vector_part_name = to_change_name;
            Vector3 vector = val;
            switch(vector_part_name)
            {
                case "x":
                    start_val = vector.x;
                    break;
                case "y":
                    start_val = vector.y;
                    break;
                case "z":
                    start_val = vector.z;
                    break;
            }
        }

        public string vector_part_name;

        private float target { get { return (float)target_value; } set { target_value = value; } }
        private Vector3 val
        {
            get
            {
                return (Vector3)(to_change_is_prop ? pi.GetValue(to_change_on) : fi.GetValue(to_change_on));
            }
            set
            {
                if(to_change_is_prop)
                {
                    pi.SetValue(to_change_on, value);
                }
                else
                {
                    fi.SetValue(to_change_on, value);
                }
            }
        }

        public override bool Update()
        {
            time_since_start += delta_time;
            Vector3 v = val;
            float tweened = float.PositiveInfinity;
            switch(vector_part_name)
            {
                case "x":
                    tweened = Mathf.Lerp((float)start_val, target, time_since_start/time_to_finish_in);
                    v = new Vector3(tweened, v.y, v.z);
                    break;
                case "y":
                    tweened = Mathf.Lerp((float)start_val, target, time_since_start / time_to_finish_in);
                    v = new Vector3(v.x, tweened, v.z);
                    break;
                case "z":
                    tweened = Mathf.Lerp((float)start_val, target, time_since_start / time_to_finish_in);
                    v = new Vector3(v.x, v.y, tweened);
                    break;
            }
            val = v;
            return tweened == target;
        }
    }
    protected abstract class ToTweenSpeedLimited : ToTween
    {
        public object max_speed;
        public bool max_speed_is_combined;

        public ToTweenSpeedLimited(object to_change_on, MemberInfo to_change, string to_change_name, object target_value, Action callback, object max_speed, bool max_speed_is_combined = false) : base(to_change_on, to_change, to_change_name, target_value, callback)
        {
            this.max_speed = max_speed;
            this.max_speed_is_combined = max_speed_is_combined;
        }
    }
    protected class ToTweenPrimitiveSpeedLimited : ToTweenSpeedLimited
    {
        public ToTweenPrimitiveSpeedLimited(object to_change_on, MemberInfo to_change, string to_change_name, object target_value, object max_speed, bool max_speed_is_combined, Action callback) : base(to_change_on, to_change, to_change_name, target_value, callback, max_speed, max_speed_is_combined) { }

        private object val_raw
        {
            get
            {
                return to_change_is_prop ? pi.GetValue(to_change_on) : fi.GetValue(to_change_on);
            }
            set
            {
                if(to_change_is_prop)
                {
                    pi.SetValue(to_change_on, value);
                }
                else
                {
                    fi.SetValue(to_change_on, value);
                }
            }
        }

        public override bool Update()
        {
            switch(val_raw)
            {
                case int v: tween_int_val(); break;
                case float v: tween_float_val(); break;
                default: throw new Exception($"Tweener Primitive does not support tweening with type {type.FullName}");
            }
            return target_value.Equals(val_raw);
        }

        private void tween_int_val()
        {
            val_raw = tween_int_speed((int)val_raw, (int)target_value, (int)max_speed);
        }
        private void tween_float_val()
        {
            val_raw = tween_float_speed((float)val_raw, (float)target_value, (float)max_speed);
        }
    }
    protected class ToTweenVector3SpeedLimited : ToTweenSpeedLimited
    {
        public ToTweenVector3SpeedLimited(object to_change_on, MemberInfo to_change, string to_change_name, object target_value, object max_speed, bool max_speed_is_combined, Action callback) : base(to_change_on, to_change, to_change_name, target_value, callback, max_speed, max_speed_is_combined)
        {
            this.vector_part_name = to_change_name;
        }

        public string vector_part_name;

        private float target { get { return (float)target_value; } set { target_value = value; } }
        private float max { get { return (float)max_speed; } set { max_speed = value; } }
        private Vector3 val
        {
            get
            {
                return (Vector3)(to_change_is_prop ? pi.GetValue(to_change_on) : fi.GetValue(to_change_on));
            }
            set
            {
                if(to_change_is_prop)
                {
                    pi.SetValue(to_change_on, value);
                }
                else
                {
                    fi.SetValue(to_change_on, value);
                }
            }
        }
        
        public override bool Update()
        {
            Vector3 v = val;
            float tweened = float.PositiveInfinity;
            if(vector_part_name == "x")
            {
                tweened = tween_float_speed(v.x, target, max);
                v = new Vector3(tweened, v.y, v.z);
            }
            else if(vector_part_name == "y")
            {
                tweened = tween_float_speed(v.y, target, max);
                v = new Vector3(v.x, tweened, v.z);
            }
            else if(vector_part_name == "z")
            {
                tweened = tween_float_speed(v.z, target, max);
                v = new Vector3(v.x, v.y, tweened);
            }
            val = v;
            return tweened == target;
        }
    }

    Tweener()
    {
        queue = new Dictionary<int, Dictionary<int, List<ToTween>>>();
    }

    public static void TweenInTime<T>(object to_change_on, string member_name_to_change, T target_value, float in_seconds, Action callback = null)
    {
        if(to_change_on is Transform)
        {
            string vector_part_name = "";
            MemberInfo to_change_info = null;
            if(member_name_to_change.Contains("."))
            {
                string[] split_member_name = member_name_to_change.Split('.');
                vector_part_name = split_member_name[split_member_name.Length - 1];
                string member_name = split_member_name[0];
                for(int i = 1; i < split_member_name.Length - 2; i++)
                {
                    member_name += split_member_name[i];
                }
                to_change_info = get_member(to_change_on, member_name);
            }
            else
            {
                vector_part_name = member_name_to_change;
                to_change_info = get_member(to_change_on, member_name_to_change);
            }
            float target = float.NegativeInfinity;
            if(target_value is int)
            {
                target = (float)(int)(object)target_value;
            }
            else if(target_value is float)
            {
                target = (float)(object)target_value;
            }
            ToTween new_tween = new ToTweenVector3Timed(to_change_on, to_change_info, vector_part_name, target, in_seconds, callback);

            add_to_object_queue(to_change_on, to_change_info, vector_part_name, new_tween);
        }
        else
        {
            MemberInfo to_change_info = get_member(to_change_on, member_name_to_change);
            ToTween new_tween = new ToTweenPrimitiveTimed(to_change_on, to_change_info, member_name_to_change, target_value, in_seconds, callback);

            add_to_object_queue(to_change_on, to_change_info, member_name_to_change, new_tween);
        }
    }
    public static void TweenAtSpeed<T>(object to_change_on, string member_name_to_change, T target_value, T max_speed, bool max_speed_is_combined = false, Action callback = null)
    {
        if(to_change_on is Transform)
        {
            string vector_part_name = "";
            MemberInfo to_change_info = null;
            if(member_name_to_change.Contains("."))
            {
                string[] split_member_name = member_name_to_change.Split('.');
                vector_part_name = split_member_name[split_member_name.Length - 1];
                string member_name = split_member_name[0];
                for(int i = 1; i < split_member_name.Length - 2; i++)
                {
                    member_name += split_member_name[i];
                }
                to_change_info = get_member(to_change_on, member_name);
            }
            else
            {
                vector_part_name = member_name_to_change;
                to_change_info = get_member(to_change_on, member_name_to_change);
            }
            float target = float.NegativeInfinity;
            if(target_value is int)
            {
                target = (float)(int)(object)target_value;
            }
            else if(target_value is float)
            {
                target = (float)(object)target_value;
            }
            ToTween new_tween = new ToTweenVector3SpeedLimited(to_change_on, to_change_info, vector_part_name, target, max_speed, max_speed_is_combined, callback);

            add_to_object_queue(to_change_on, to_change_info, vector_part_name, new_tween);
        }
        else
        {
            MemberInfo to_change_info = get_member(to_change_on, member_name_to_change);
            ToTween new_tween = new ToTweenPrimitiveSpeedLimited(to_change_on, to_change_info, member_name_to_change, target_value, max_speed, max_speed_is_combined, callback);

            add_to_object_queue(to_change_on, to_change_info, member_name_to_change, new_tween);
        }
    }

    public void Update()
    {
        delta_time = Time.deltaTime;
        List<int> objects_to_remove = new List<int>();
        foreach(KeyValuePair<int, Dictionary<int, List<ToTween>>> object_queue_pair in queue)
        {
            int object_code = object_queue_pair.Key;
            Dictionary<int, List<ToTween>> time_queue = object_queue_pair.Value;
            List<int> time_queues_to_remove = new List<int>();
            foreach(KeyValuePair<int, List<ToTween>> tween_list_pair in time_queue)
            {
                int time_code = tween_list_pair.Key;
                List<ToTween> tween_list = tween_list_pair.Value;
                for(int i = 0; i < tween_list.Count; i++)
                {
                    try
                    {
                        ToTween tween = tween_list[i];
                        if(tween.Update())
                        {
                            tween.callback?.Invoke();
                            tween_list.RemoveAt(i--);
                        }
                    }
                    catch(Exception e)
                    {
                        Debug.LogError(e);
                    }
                }
                if(tween_list.Count == 0) { time_queues_to_remove.Add(time_code); }
            }
            time_queues_to_remove.ForEach(tqtr => time_queue.Remove(tqtr));
            if(time_queue.Count == 0) { objects_to_remove.Add(object_code); }
        }
        objects_to_remove.ForEach(otr => queue.Remove(otr));
    }

    private static MemberInfo get_member(object to_change_on, string member_name_to_change)
    {
        return to_change_on.GetType().GetMember(member_name_to_change, BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Static | BindingFlags.Instance)[0];
    }

    private static int get_time_code()
    {
        return Time.time.GetHashCode();
    }

    private static void add_to_object_queue(object object_for, MemberInfo member_to_change, string member_name_to_change, ToTween to_add)
    {
        int object_code = object_for.GetHashCode();
        int time_code = get_time_code();
        if(!queue.ContainsKey(object_code)) { queue.Add(object_code, new Dictionary<int, List<ToTween>>()); }
        Dictionary<int, List<ToTween>> object_queue = queue[object_code];
        foreach(KeyValuePair<int, List<ToTween>> time_list in object_queue)
        {
            List<ToTween> tween_list_for_time = time_list.Value;
            int i = tween_list_for_time.IndexOf(tween_list_for_time.Where(tween => tween.to_change == member_to_change && tween.to_change_name == member_name_to_change).FirstOrDefault());
            if(i > -1)
            {
                //Already a tween to change that value, replace it
                tween_list_for_time.RemoveAt(i);
                break;
            }
        }
        if(!object_queue.ContainsKey(time_code)) { object_queue.Add(time_code, new List<ToTween>()); }
        List<ToTween> tween_list = object_queue[time_code];
        tween_list.Add(to_add);
    }
}