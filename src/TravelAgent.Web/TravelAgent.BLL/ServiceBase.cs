using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TravelAgent.DALFactory;

namespace TravelAgent.BLL
{
    public abstract class ServiceBase
    {
        /// <summary>
        /// 获取DAL对象
        /// </summary>
        /// <typeparam name="T">DAL接口类型</typeparam>
        /// <param name="class_name">DAL实现类名称</param>
        /// <returns>DAL实现类实例对象</returns>
        protected T GetDao<T>(string class_name)
        { 
            return  DALBuild.GetObj<T>(class_name);
        }
    }
}
