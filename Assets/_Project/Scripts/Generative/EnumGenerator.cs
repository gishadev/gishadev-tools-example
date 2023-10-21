using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using UnityEditor;
using UnityEngine;

namespace gishadev.tools.Generative
{
    public class EnumGenerator
    {
        private static HashSet<string> csharpKeywords = new HashSet<string>
        {
            "abstract", "as", "base", "bool", "break", "byte", "case", "catch", "char", "checked",
            "class", "const", "continue", "decimal", "default", "delegate", "do", "double", "else",
            "enum", "event", "explicit", "extern", "false", "finally", "fixed", "float", "for",
            "foreach", "goto", "if", "implicit", "in", "int", "interface", "internal", "is", "lock",
            "long", "namespace", "new", "null", "object", "operator", "out", "override", "params",
            "private", "protected", "public", "readonly", "ref", "return", "sbyte", "sealed",
            "short", "sizeof", "stackalloc", "static", "string", "struct", "switch", "this", "throw",
            "true", "try", "typeof", "uint", "ulong", "unchecked", "unsafe", "ushort", "using",
            "virtual", "void", "volatile", "while"
        };

        public static void GenerateEnumClass(string enumName, string[] enumEntries)
        {
            string path = "Assets/Generated/" + enumName + ".cs";

            var str = new StringBuilder();
            str.AppendFormat("public enum {0}", enumName);
            str.AppendLine();
            str.AppendLine("{");
            for (var i = 0; i < enumEntries.Length; i++)
            {
                str.AppendFormat("\t{0}", ValidateEnumString(enumEntries[i]));

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

        private static string ValidateEnumString(string text)
        {
            if (text.Length <= 0)
            {
                Debug.LogError("Invalid enum name");
                return null;
            }

            // Turn all whitespaces into _.
            string whitespacePattern = @"\s+";
            string replacement = "_";
            var result = Regex.Replace(text, whitespacePattern, replacement).ToUpper();

            // First char must be a letter or an underscore.
            string specialCharactersPattern = @"[^\w\d]+";
            result = Regex.Replace(result, specialCharactersPattern, "_");

            return result;
        }
    }
}