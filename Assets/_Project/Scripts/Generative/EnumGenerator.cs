using System.IO;
using System.Text;
using UnityEditor;

namespace gishadev.tools.Generative
{
    public class EnumGenerator
    {
        public static void GenerateEnumClass(string enumName, string[] enumEntries)
        {
            string path = "Assets/Generated/" + enumName + ".cs";

            var str = new StringBuilder();
            str.AppendFormat("public enum {0}", enumName);
            str.AppendLine();
            str.AppendLine("{");
            for (var i = 0; i < enumEntries.Length; i++)
            {
                str.AppendFormat("\t{0}", enumEntries[i]);
                
                if (i < enumEntries.Length - 1)
                {
                    str.Append(',');
                    str.AppendLine();
                }
            }

            str.AppendLine();
            str.AppendLine(@"}");

            FileInfo file = new FileInfo(path);
            file.Directory?.Create();

            File.WriteAllText(path, str.ToString());
            AssetDatabase.ImportAsset(path);
        }
    }
}