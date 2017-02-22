using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TravelAgent.Model
{
    public class Club
    {
        private int _id;
        private string _clubName = "";
        private string _clubMobile = "";
        private string _clubEmail = "";
        private string _clubPwd = "";
        private string _trueName = "";
        private string _clubSex = "";
        private string _clubBirthday = "";
        private int _currentPoints = 0;
        private int _isLock = 0;
        private DateTime _regDate = DateTime.Now;
        private int _emailIsValid = 0;
        private int _mobileIsValid = 0;
        private int _classId = 0;
        /// <summary>
        /// 编号
        /// </summary>
        public int id { 
            get{return _id;}
            set { _id = value; }
        }
        /// <summary>
        /// 会员名
        /// </summary>
        public string clubName 
        {
            get { return _clubName;}
            set { _clubName = value; } 
        }
        /// <summary>
        /// 手机号
        /// </summary>
        public string clubMobile 
        {
            get { return _clubMobile;}
            set { _clubMobile=value;} 
        }
        /// <summary>
        /// 邮箱
        /// </summary>
        public string clubEmail 
        {
            get { return _clubEmail;}
            set { _clubEmail=value;}
        }
        /// <summary>
        /// 密码
        /// </summary>
        public string clubPwd
        {
            get { return _clubPwd; }
            set { _clubPwd= value; } 
        }
        /// <summary>
        /// 真实姓名
        /// </summary>
        public string trueName
        { 
            get {return _trueName ;} 
            set { _trueName=value;} 
        }
        /// <summary>
        /// 性别
        /// </summary>
        public string clubSex 
        {
            get { return _clubSex;}
            set { _clubSex=value;}
        }
        /// <summary>
        /// 出生日期
        /// </summary>
        public string clubBirthday 
        {
            get { return _clubBirthday;}
            set { _clubBirthday=value;}
        }
        /// <summary>
        /// 当前积分
        /// </summary>
        public int currentPoints 
        {
            get { return _currentPoints;}
            set { _currentPoints=value;}
        }
        /// <summary>
        /// 是否锁定
        /// </summary>
        public int isLock 
        {
            get { return _isLock;}
            set { _isLock=value;}
        }
        /// <summary>
        /// 注册日期
        /// </summary>
        public DateTime regDate 
        {
            get { return _regDate;}
            set { _regDate=value;}
        }
        /// <summary>
        /// 邮箱是否验证
        /// </summary>
        public int emailIsValid 
        {
            get { return _emailIsValid;}
            set { _emailIsValid=value;}
        }
        /// <summary>
        /// 手机是否验证
        /// </summary>
        public int mobileIsValid 
        {
            get { return _mobileIsValid;}
            set { _mobileIsValid=value;}
        }
        /// <summary>
        /// 会员级别
        /// </summary>
        public int classId 
        {
            get { return _classId;}
            set { _classId=value;}
        }

        public static Club Register(string phone,string email,string pwd)
        {

            if(String.IsNullOrEmpty(pwd) || (String.IsNullOrEmpty(phone) && String.IsNullOrEmpty(email)))
            {
                throw new Exception("用户名密码不能为空");
            }

            return new Club() {
                _clubMobile = phone,
                _clubEmail = email,
                _clubPwd = pwd,
                _regDate = DateTime.Now,
                _emailIsValid = 0,
                _mobileIsValid = 0,
                _isLock = 0,
                _classId = 0,
                _currentPoints = 0,
                _clubName = "NA",
                _clubSex = "NA",
                _clubBirthday = "NA",
                _trueName = "NA"
            };
        }
    }
}
