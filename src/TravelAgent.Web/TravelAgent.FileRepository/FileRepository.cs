using System.Configuration;
using System.IO;
using TravelAgent.Tool;

namespace TravelAgent.FileRepository
{
    public sealed class FileRepository
    {

        private static FileRepository INSTANCE = new FileRepository();
        private FileRepository()
        {

        }

        public static FileRepository GetInstance()
        {
            if(null == INSTANCE)
            {
                return new FileRepository();
            }
            return INSTANCE;
        }

        public void Write(string content,string filename)
        {
            string path = ConfigurationManager.AppSettings["filerepository"];
            File.WriteAllText(filename,content);
        }

        public void Write<T>(T t,string filename)
        {
            string path = ConfigurationManager.AppSettings["filerepository"];
            File.WriteAllText(path + "/" + filename, SerializationUtil.ToJson(t));

        }

        public T Read<T>(string filename)
        {
            string path = ConfigurationManager.AppSettings["filerepository"];
            string data = File.ReadAllText(path+ "/" +filename);
            T t = SerializationUtil.ToObj<T>(data);
            return t;
        }

        public string Read(string filename)
        {
            string path = ConfigurationManager.AppSettings["filerepository"];
            return File.ReadAllText(path + "/" + filename);
        }

    }
}
